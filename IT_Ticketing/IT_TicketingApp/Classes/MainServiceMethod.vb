Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.IO
Imports System.Net
Public Class MainServiceMethod
    Dim objIT As New clsDBAccess(My.Settings.conIT, DBEngineType.SQL)
    Dim Smtp_Server As SmtpClient
    Public Function RoleBaseLogin(ByVal UserID As String) As DataTable
        Dim dt As New DataTable
        Try

            Dim para As String(,) = {{"@UserID", UserID}}
            dt = objIT.SP_Datatable("sp_GetUserDetailsbyUserID", para)
            dt.TableName = "sp_GetUserDetailsbyUserID"
            Return dt

        Catch ex As Exception
            Throw ex
        Finally

        End Try
        Return dt
    End Function

    Public Function AuthenticateUser(ByVal UserName As String) As DataTable
        Dim dt As New DataTable
        Try

            Dim para As String(,) = {{"@UserName", UserName}}
            dt = objIT.SP_Datatable("sp_AuthenticateUser", para)
            dt.TableName = "sp_AuthenticateUser"
            Return dt

        Catch ex As Exception
            Throw ex
        Finally

        End Try
        Return dt
    End Function

    Public Function GetApplicationDetails() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetApplicationDetails")
            dt.TableName = "sp_GetApplicationDetails"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Public Function GetUserType() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetUserType")
            dt.TableName = "sp_GetUserType"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function


    Public Function GetPriority() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetPriority")
            dt.TableName = "sp_GetPriority"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function


    Public Function GetComplainStatus() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetStatus")
            dt.TableName = "sp_GetStatus"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function


    


    Public Function GetComplainDetails() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetComplain")
            dt.TableName = "sp_GetComplain"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function


    Public Function GetComplainHistory() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetComplainHistory")
            dt.TableName = "sp_GetComplainHistory"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function


    Public Function GetDepartment() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetDepartment")
            dt.TableName = "sp_GetDepartment"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function


    Public Function UploadFile(ByVal picture() As Byte, ByVal filename As String) As Boolean
        Try
            Dim ms As MemoryStream = New MemoryStream(picture, 0, picture.Length)
            Dim path As String = "E:\New\"
            Dim fs As New FileStream(path + filename, FileMode.Create)
            ms.WriteTo(fs)
            ms.Close()
            fs.Close()
            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function DownloadFile(ByVal filename As String) As Byte()
        Try
            Dim fs As FileStream = Nothing
            fs = New FileStream("E:\NEW\" & filename, FileMode.Open)
            Dim fi As FileInfo = New FileInfo("E:\NEW\" & filename)
            Dim temp As Long = fi.Length
            Dim lung As Integer = Convert.ToInt32(temp)
            Dim picture As Byte() = New Byte(lung - 1) {}
            fs.Read(picture, 0, lung)
            fs.Close()
            Return picture

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetUserDetailsbyUserID(ByVal UserID As Integer) As DataTable
        Try
            Dim Para As String(,) = {{"@UserID", UserID}}
            Dim dt = objIT.SP_Datatable("sp_GetUserDetailsbyUserID", Para)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConformationEmail(ByVal ComplainID As Integer, _
                                      ByVal AppID As Integer) As Boolean
        Try


            Dim dt_Server = objIT.SP_Datatable("sp_GetEmailServer")
            Smtp_Server = New SmtpClient
            Dim msg As MailMessage
            msg = New MailMessage

            Dim Para1 As String(,) = {{"@ComplainID", ComplainID}}
            Dim dt = objIT.SP_Datatable("sp_GetComplainDetailsbyComplainID", Para1)
            If dt.Rows.Count > 0 Then
                Dim TicketNo As String = dt.Rows(0)("TicketNo")
                Dim ComplainDate As String = dt.Rows(0)("ComplainDate")
                Dim AppName As String = dt.Rows(0)("ApplciationName")
                Dim RequestType As String = dt.Rows(0)("RequestType")
                Dim Status As String = dt.Rows(0)("StatusName")
                Dim Subject As String = dt.Rows(0)("Subject")
                Dim EmailTo As String = dt.Rows(0)("EmailTo")
                Dim EmailCC As String = dt.Rows(0)("EmailCC")
                Dim EmailFrom As String = dt.Rows(0)("EmailFrom")
                msg.From = New MailAddress(EmailFrom)
                msg.To.Add(EmailTo)
                msg.CC.Add(EmailCC)
                msg.Subject = Subject
                msg.IsBodyHtml = True
                msg.Priority = MailPriority.High
                msg.Body = "<table><tr><td colpsan =2><b><u><u>Complain Notification</td></tr><td bgcolor='#F6CECE'>TicketNo </td><td>" & TicketNo & "</td></tr><tr><td bgcolor='#F6CECE'>ComplainDate:  </td><td>" & ComplainDate & "</td></tr><tr><td bgcolor='#F6CECE'>Request Type  </td><td>" & RequestType & "</td></tr><tr><td bgcolor='#F6CECE'>ApplicationName  </td><td>" & AppName & "</td></tr><tr><td bgcolor='#F6CECE'>Status </td><td>" & Status & "</td></tr></table><br>*This is an autogenerated email from BSS, incase of any query please contact IT Support "
                Smtp_Server.Host = dt_Server.Rows(1)(2)
                Smtp_Server.Send(msg)
                Return True
            Else
                Return False
            End If






        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function InsertComplain(ByVal TicketNo As String, _
                                   ByVal AppID As Integer, _
                                   ByVal PriorityID As Integer, _
                                   ByVal StatusID As Integer, _
                                   ByVal UserID As Integer, _
                                   ByVal ComplainDate As DateTime, _
                                   ByVal FormName As String, _
                                   ByVal RequestID As Integer, _
                                   ByVal UserRemarks As String, _
                                   ByVal OwnerRemarks As String, _
                                   ByVal Attachment1 As String, _
                                   ByVal Attachment2 As String, _
                                   ByVal Notes As String, _
                                   ByVal ETTR As String, _
                                   ByVal TransactionBy As Integer) As Integer
        Try

            Dim Para As String(,) = {{"@TicketNo", TicketNo}, {"@AppID", AppID}, {"@PriorityID", PriorityID}, _
                                     {"@StatusID", StatusID}, {"@UserID", UserID}, {"@ComplainDate", ComplainDate}, _
                                     {"@FormName", FormName}, {"@RequestID", RequestID}, {"@UserRemarks", UserRemarks}, _
                                     {"@OwnerRemarks", OwnerRemarks}, {"@Attachment1", Attachment1}, {"@Attachment2", Attachment2}, _
                                     {"@Notes", Notes}, {"@ETTR", ETTR}, {"@TransactionBy", TransactionBy}}

            Dim lastComplainID = objIT.InsertProc_GetLastComplainID("sp_InsertComplain", Para)
            Return lastComplainID

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function UpdateComplain(ByVal ComplainID As Integer,
                                   ByVal TicketNo As String, _
                                   ByVal AppID As Integer, _
                                   ByVal PriorityID As Integer, _
                                   ByVal StatusID As Integer, _
                                   ByVal UserID As Integer, _
                                   ByVal ComplainDate As DateTime, _
                                   ByVal FormName As String, _
                                   ByVal RequestID As Integer, _
                                   ByVal UserRemarks As String, _
                                   ByVal OwnerRemarks As String, _
                                   ByVal Attachment1 As String, _
                                   ByVal Attachment2 As String, _
                                   ByVal Notes As String, _
                                   ByVal ETTR As String, _
                                   ByVal TransactionBy As Integer) As Boolean
        Try

            Dim Para As String(,) = {{"@ComplainID", ComplainID}, {"@TicketNo", TicketNo}, {"@AppID", AppID}, {"@PriorityID", PriorityID}, _
                                     {"@StatusID", StatusID}, {"@UserID", UserID}, {"@ComplainDate", ComplainDate}, _
                                     {"@FormName", FormName}, {"@RequestID", RequestID}, {"@UserRemarks", UserRemarks}, _
                                     {"@OwnerRemarks", OwnerRemarks}, {"@Attachment1", Attachment1}, {"@Attachment2", Attachment2}, _
                                     {"@Notes", Notes}, {"@ETTR", ETTR}, {"@TransactionBy", TransactionBy}}

            If objIT.executeProcess("sp_UpdateComplain", Para) Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function UpdateComplainHistory(ByVal TicketNo As String,
                                        ByVal TransactionBy As Integer, _
                                        ByVal TransactionDate As DateTime, _
                                        ByVal StatusID As Integer, _
                                        ByVal Remarks As String, _
                                        ByVal ETTR As String) As Boolean
        Try

            Dim Para As String(,) = {{"@TicketNo", TicketNo}, {"@TransactionBy", TransactionBy}, {"@TransactionDate", TransactionDate}, _
                                     {"@StatusID", StatusID}, {"@Remarks", Remarks}, {"@ETTR", ETTR}}

            If objIT.executeProcess("sp_UpdateComplainHistory", Para) Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertComplainHistory(ByVal TicketNo As String,
                                   ByVal TransactionBy As Integer, _
                                   ByVal TransactionDate As DateTime, _
                                   ByVal StatusID As Integer, _
                                   ByVal Remarks As String, _
                                   ByVal ETTR As DateTime) As Integer
        Try

            Dim Para As String(,) = {{"@TicketNo", TicketNo}, {"@TransactionBy", TransactionBy}, {"@TransactionDate", TransactionDate}, _
                                     {"@StatusID", StatusID}, {"@Remarks", Remarks}, {"@ETTR", ETTR}}

            Dim lastComplainID = objIT.InsertProc_GetLastComplainID("sp_InsertComplainHistory", Para)
            Return lastComplainID

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
