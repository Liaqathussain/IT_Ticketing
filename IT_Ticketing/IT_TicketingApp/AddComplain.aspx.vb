Imports Telerik.Web.UI
Imports System.Data.OleDb
Imports System.Net.Mail
Imports System.IO
Imports System.Net
Imports System.Drawing

Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim Count As Integer
    Dim StatusID, AppID, PriorityID, UserId, ComplainDate As String
    Dim objGP As New clsDBAccess(My.Settings.conEmailServer, DBEngineType.SQL)
    Dim Smtp_Server As SmtpClient
    Dim TicketNo As String
    Public objBL As New ItTicketing_Methods
    Dim Attachment(1) As String
    Dim dtFormat As DataTable
    Dim Subject, EmailFrom, EmailCC, EmailTo, EmailFormat, ApplciationName, ApplicationOwner, TransactionDate, UserName, UserRemarks, StatusName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
            Dim dtApp = objBL.GetApplicationDetails()
            Dim dtStatus = objBL.GetComplainStatus()
            Dim dtPriority = objBL.GetPriority
            Dim DTRequestType = objBL.GetRequestType

            RadComApp.Items.Add(New RadComboBoxItem("Please-Select", dtApp.Rows.Count))
            For i As Integer = 0 To dtApp.Rows.Count - 1
                RadComApp.Items.Add(New RadComboBoxItem(dtApp.Rows(i)("ApplciationName").ToString, i))
            Next


            RadComPriority.Items.Add(New RadComboBoxItem("Please-Select", dtPriority.Rows.Count))
            For k As Integer = 0 To dtPriority.Rows.Count - 1
                RadComPriority.Items.Add(New RadComboBoxItem(dtPriority.Rows(k)("Priority").ToString, k))
            Next


            RadComReqType.Items.Add(New RadComboBoxItem("Please-Select", DTRequestType.Rows.Count))
            For k As Integer = 0 To DTRequestType.Rows.Count - 1
                RadComReqType.Items.Add(New RadComboBoxItem(DTRequestType.Rows(k)("RequestType").ToString, k))
            Next
            RedComComplainDate.SelectedDate = Date.Now
        End If
        loadCombos()
    End Sub

    Private Sub loadCombos()
        Try
            'objBL.GetRequestType(ddReqType)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "IT Addmisntrator")
        End Try


    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try

            Call CreateTicketID()
            Attachment(0) = ""
            Attachment(1) = ""
            Dim count As Integer = 1
            If RadAsyncUpload1.UploadedFiles.Count > 0 Then
                For Each file As UploadedFile In RadAsyncUpload1.UploadedFiles
                    Dim targetFolder As [String] = Server.MapPath("~/Folder/")
                    file.SaveAs(Path.Combine(targetFolder, TicketNo & "-" & file.FileName))
                    Me.WriteToFile("btnSubmit: " & targetFolder & TicketNo & "-" & file.FileName)
                    If count = 1 Then
                        Attachment(0) = TicketNo & "-" & file.FileName
                    Else
                        Attachment(1) = TicketNo & "-" & file.FileName
                    End If
                    count = count + 1L
                    '
                Next
            Else
                Attachment(0) = ""
                Attachment(1) = ""
            End If

            Call ClearVariables()

            'Dim filename As String = RadAsyncUpload1.MultipleFileSelection
            Dim DTstatus As Boolean = objBL.InsertComplain(TicketNo, Session("AppID"), Session("PriorityID"), 1, UserId, Session("ComplainDate"), Session("FormName"), Session("ReqType"), Session("UserRemarks"), Attachment(0), Attachment(1), Session("Notes"), Session("UserId"))
            If DTstatus = True Then
                lblStatus.Text = "Inserted Successfully"

                'Due date First(two days before)
                Dim para As String(,) = {{"@AppID", Session("AppID")}}
                dtFormat = objBL.GetForwardEmail(Session("AppID"))
                If dtFormat.Rows.Count > 0 Then
                    Call EmailFormating()
                    Call ConformationEmail(Subject, EmailFrom, EmailCC, EmailTo, EmailFormat)

                End If
            Else
                lblStatus.Text = "Complain Failed"
            End If

            If lblStatus.Text = "Inserted Successfully" Then
                Dim HisDTstatus As Boolean = objBL.InsertComplainHistory(TicketNo, Session("UserId"), Session("ComplainDate"), 1, Session("UserRemarks"), Session("ETTR"), Attachment(0), Attachment(1))
                If HisDTstatus = True Then
                    lblStatus.Text = "Inserted Successfully"
                Else
                    lblStatus.Text = "History Failed"
                End If
            Else
                lblStatus.Text = "History Failed"
            End If
          
        Catch ex As Exception

            lblStatus.Text = "Status:Fail,Please Select All Required Fields"
        End Try
    End Sub
    Public Function CreateTicketID()
        Try
            Dim dt As Date = Date.Today
            Dim TotalTransactions As Integer
            Dim NumFormat As String = ""
            Dim MaxTicketNo As String = ""
            'Dim dtTotalTransactions = objBL.GetTotalComplaints
            Dim dtMaxTicketNo As DataTable = objBL.GetMaxTicketNo
            If dtMaxTicketNo.Rows.Count > 0 Then
                MaxTicketNo = dtMaxTicketNo.Rows(0)("TicketNo")
            End If

            'TotalTransactions = dtTotalTransactions.Rows(0)("Tcomplaints")

            If dt.ToString("MM") <> Mid(MaxTicketNo, 1, 2) Then
                TotalTransactions = 1
            Else
                TotalTransactions = Right(MaxTicketNo, 4)
            End If
            TotalTransactions = TotalTransactions + 1
            Dim LenTrans As String = TotalTransactions
            If Len(LenTrans) = 1 Then
                NumFormat = "000" & TotalTransactions
            ElseIf Len(LenTrans) = 2 Then
                NumFormat = "00" & TotalTransactions
            ElseIf Len(LenTrans) = 3 Then
                NumFormat = "0" & TotalTransactions
            ElseIf Len(LenTrans) = 4 Then
                NumFormat = TotalTransactions
            End If
            TicketNo = dt.ToString("MMddyyyy") & NumFormat

            Session("TicketNo") = TicketNo
            UserId = AppDomain.CurrentDomain.GetData("UserID")
            'Session("UserId") = UserId
            Dim dt1 As DataTable = objBL.RoleBaseLogin(UserId)
            Session("UserName") = dt1.Rows(0)("UserName").ToString
            lblTicketNo.Text = "Ticket No: " & Session("TicketNo")
        Catch ex As Exception

        End Try
    End Function

    Protected Sub RadComPriority_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComPriority.SelectedIndexChanged
        Try
            Session("PriorityID") = RadComPriority.SelectedIndex

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadComApp_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadComApp.DataBinding
        Try
            Session("AppID") = RadComApp.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub RadComApp_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComApp.SelectedIndexChanged
        Try
            Session("AppID") = RadComApp.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub


    Private Sub RedComComplainDate_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles RedComComplainDate.DataBinding

    End Sub

    Protected Sub RedComComplainDate_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RedComComplainDate.SelectedDateChanged
        Try
            Session("ComplainDate") = RedComComplainDate.ValidationDate & " " & Format(TimeOfDay, "hh:mm:ss")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub RadComReqType_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComReqType.SelectedIndexChanged
        Try
            Session("ReqType") = RadComReqType.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub tbFormName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbFormName.TextChanged
        Try
            Session("FormName") = tbFormName.Text
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub tbUserRemarks_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbUserRemarks.TextChanged
        Try
            Session("UserRemarks") = tbUserRemarks.Text
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub tbNotes_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbNotes.TextChanged
        Try
            Session("Notes") = tbNotes.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearVariables()
        Try

            If Session("FormName") = Nothing Then
                Session("FormName") = ""
            End If

            Session("ETTR") = ""

            If Session("Notes") = Nothing Then
                Session("Notes") = ""
            End If
            If Session("OwnerRemarks") = Nothing Then
                Session("OwnerRemarks") = ""
            End If
            If Session("UserRemarks") = Nothing Then
                Session("UserRemarks") = ""
            End If
            If Session("ComplainDate") = Nothing Then
                Session("ComplainDate") = Format(Now.Date, "yyyy-MM-dd")
            End If



        Catch ex As Exception

        End Try
    End Sub

    Public Function ConformationEmail(ByVal Subject As String, ByVal EmailFrom As String, ByVal EmailCC As String, ByVal Emailto As String, ByVal EmailFormat As String) As Boolean

        Try
            Dim dt_Server = objGP.SP_Datatable("sp_GetEmailServer")
            Smtp_Server = New SmtpClient
            Dim msg As MailMessage
            Dim dt = objBL.GetEmailData(TicketNo)
            Call ClearVariables()
            Dim Priority, DepartmentName, EmailID As String
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    msg = New MailMessage
                    ApplciationName = dt.Rows(i)("ApplciationName").ToString
                    TransactionDate = dt.Rows(i)("TransactionDate").ToString
                    Session("UserRemarks") = dt.Rows(i)("UserRemarks").ToString
                    StatusName = dt.Rows(i)("StatusName").ToString
                    Session("UserName") = dt.Rows(i)("UserName").ToString
                    Priority = dt.Rows(i)("Priority").ToString
                    EmailID = dt.Rows(i)("EmailID").ToString
                    DepartmentName = AppDomain.CurrentDomain.GetData("DepartmentName")
                    Dim city As String = AppDomain.CurrentDomain.GetData("City")
                    Dim SubjectForLog As String = Subject  'Trim(ClientName) & "(" & Format(Date.Now, "MMM-yyyy") & ")"
                    msg.From = New MailAddress(EmailID) 'EmailFrom
                    msg.To.Add(Emailto)
                    'msg.To.Add("liaqat.hussain@multinet.com.pk") '"nomansh@multinet.com.pk

                    Dim strArry() As String
                    Dim count As Integer
                    'strArry = EmailID.Split(",")
                    'For count = 0 To strArry.Length - 1
                    '    msg.CC.Add(strArry(count))
                    'Next


                    msg.CC.Add(EmailCC)
                    msg.Subject = Subject  'Trim(ClientName) & "(" & Format(Date.Now, "MMM-yyyy") & ")"
                    msg.IsBodyHtml = True
                    msg.Priority = MailPriority.High

                    'msg.Attachments.Add(RadAsyncUpload1.Uploade dFiles)

                    Dim EmailFormatForAll As String

                    If EmailFormat <> "" Then
                        Dim arr() As String = Split(EmailFormat, "!")
                        EmailFormatForAll = arr(0).ToString & ApplciationName & arr(2).ToString & Session("TicketNo") & arr(4).ToString _
                                             & StatusName & arr(6).ToString & Priority & arr(8).ToString & DepartmentName & arr(10).ToString _
                                             & city & arr(12).ToString & Session("UserRemarks") & arr(14).ToString & arr(15).ToString _
                                              & arr(16).ToString & arr(17).ToString & arr(18).ToString & Session("UserName") & arr(20).ToString
                        msg.Body = EmailFormatForAll
                    Else
                    End If



                    Smtp_Server.Host = dt_Server.Rows(1)(2)
                    Smtp_Server.Send(msg)
                    msg.To.Clear()
                    msg.CC.Clear()
                    Me.WriteToFile("Email Details: " & "Alert:" & SubjectForLog & Emailto)
                Next
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub EmailFormating()
        Try
            Subject = dtFormat.Rows(0)("Subject").ToString
            EmailFrom = dtFormat.Rows(0)("EmailFrom").ToString
            EmailTo = dtFormat.Rows(0)("EmailTo").ToString
            EmailCC = dtFormat.Rows(0)("EmailCC").ToString
            EmailFormat = dtFormat.Rows(0)("EmailFormat").ToString
        Catch ex As Exception

        End Try
    End Sub
    Private Sub WriteToFile(ByVal text As String)
        Dim path As String = My.Settings.Logfile
        Using writer As New StreamWriter(path, True)
            writer.WriteLine(String.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")))
            writer.Close()
        End Using
    End Sub




End Class