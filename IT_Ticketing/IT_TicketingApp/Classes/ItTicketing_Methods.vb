Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports Telerik.Web.UI
Imports System.Net

Public Class ItTicketing_Methods
    Dim objSub As New MainServiceMethod
    Dim objIT As New clsDBAccess(My.Settings.conIT, DBEngineType.SQL)
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
    Public Function GetTicketHistory(ByVal TicketNo As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@TicketNo", TicketNo}}
            dt = objIT.SP_Datatable("sp_GetTicketHistory", para)
            dt.TableName = "sp_GetTicketHistory"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetVendorName() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetVendorName")
            dt.TableName = "sp_GetVendorName"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetForwardEmail(ByVal TicketNo As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@TicketNo", TicketNo}}
            dt = objIT.SP_Datatable("sp_GetForwardEmailForVendor", para)
            dt.TableName = "sp_GetForwardEmailForVendor"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetEndUserEmailID(ByVal UserID As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@UserID", UserID}}
            dt = objIT.SP_Datatable("sp_GetEmailEndUser", para)
            dt.TableName = "sp_GetEmailEndUser"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetRequestType() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetRequestType")
            dt.TableName = "sp_GetRequestType"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    'Used
    Public Function GetSearchResult(ByVal AppID1 As String, ByVal AppID2 As String, ByVal AppID3 As String, ByVal AppID4 As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@AppID1", AppID1}, {"@AppID2", AppID2}, {"@AppID3", AppID3}, {"@AppID4", AppID4}}
            dt = objIT.SP_Datatable("sp_GetSearchResult", para)
            dt.TableName = "sp_GetSearchResult"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetSearchResultbyUser(ByVal UserID As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@UserID", UserID}}
            dt = objIT.SP_Datatable("sp_GetSearchResultByUser", para)
            dt.TableName = "sp_GetSearchResultByUser"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetSearchForEndUser(ByVal UserID As String, ByVal TicketID As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@UserID", UserID}, {"@TicketID", TicketID}}
            dt = objIT.SP_Datatable("sp_GetSearhForEndUser", para)
            dt.TableName = "sp_GetSearhForEndUser"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetSearchResultAdmin() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetSearchResultAdmin")
            dt.TableName = "sp_GetSearchResultAdmin"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function DownloadImages(ByVal filename As String, ByVal targetfolder As String) As Byte()
        Try
            'Dim fs As FileStream = Nothing

            'fs = New FileStream("D:\Liaqat Data D\Project Backup\IT_Ticketing\IT_Ticketing\IT_TicketingApp\Folder\" & filename, FileMode.Open)
            'Dim fi As FileInfo = New FileInfo("D:\Liaqat Data D\Project Backup\IT_Ticketing\IT_Ticketing\IT_TicketingApp\Folder\" & filename)
            'Server Setting

            Dim fs As New System.IO.FileStream(targetfolder & filename, IO.FileMode.Open, IO.FileAccess.Read)
            'fs = New FileStream("D:\BusinessApps\IT_Ticketing\IT_Ticketing\IT_TicketingApp\Folder\" & filename, FileMode.Open)
            Me.WriteToFile(targetfolder & filename)
            Dim fi As FileInfo = New FileInfo(targetfolder & filename)
            Dim temp As Long = fi.Length
            Dim lung As Integer = Convert.ToInt64(temp)
            Me.WriteToFile(temp)
            Dim picture As Byte() = New Byte(lung - 1) {}
            fs.Read(picture, 0, lung)
            fs.Close()

            Return picture

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub WriteToFile(ByVal text As String)
        Dim path As String = My.Settings.Logfile
        Using writer As New StreamWriter(path, True)
            writer.WriteLine(String.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")))
            writer.Close()
        End Using
    End Sub
    Public Function GetSearchAsPerCriteria(ByVal AppID As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@AppID", AppID}}
            dt = objIT.SP_Datatable("sp_GetSearchAsPerCriteria", para)
            dt.TableName = "sp_GetSearchAsPerCriteria"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetSearchAsPerAppID(ByVal AppID As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@AppID", AppID}}
            dt = objIT.SP_Datatable("sp_GetSearchAsPerAppID", para)
            dt.TableName = "sp_GetSearchAsPerAppID"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetForwardEmail(ByVal AppID As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@AppID", AppID}}
            dt = objIT.SP_Datatable("dbo.sp_GetForwaredEmail", para)
            dt.TableName = "dbo.sp_GetForwaredEmail"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetEmailData(ByVal TicketID As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim para As String(,) = {{"@TicketNo", TicketID}}
            dt = objIT.SP_Datatable("sp_GetSearchAsPerAppID", para)
            dt.TableName = "sp_GetSearchAsPerAppID"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Public Sub GetUserType(ByVal DropDownList As DropDownList)
        Try
            Dim dt = objSub.GetUserType()
            If dt.Rows.Count > 0 Then
                DropDownList.DataTextField = "UserType"
                DropDownList.DataValueField = "UserTpeID"
                Dim dr As DataRow = dt.NewRow
                dr(0) = 0
                dr(1) = "Please-Select"
                dt.Rows.InsertAt(dr, 0)
                DropDownList.DataSource = dt
                DropDownList.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
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
    Public Sub GetComplainStatus(ByVal DropDownList As DropDownList)
        Try
            Dim dt = objSub.GetComplainStatus()
            If dt.Rows.Count > 0 Then
                DropDownList.DataTextField = "StatusName"
                DropDownList.DataValueField = "StatusID"
                Dim dr As DataRow = dt.NewRow
                dr(0) = 0
                dr(1) = "Please-Select"
                dt.Rows.InsertAt(dr, 0)
                DropDownList.DataSource = dt
                DropDownList.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetDepartment(ByVal DropDownList As DropDownList)
        Try
            Dim dt = objSub.GetDepartment()
            If dt.Rows.Count > 0 Then
                DropDownList.DataTextField = "DepartmentName"
                DropDownList.DataValueField = "DeptID"
                Dim dr As DataRow = dt.NewRow
                dr(0) = 0
                dr(1) = "Please-Select"
                dt.Rows.InsertAt(dr, 0)
                DropDownList.DataSource = dt
                DropDownList.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function UploadFile(ByVal picture() As Byte, ByVal filename As String) As Boolean
        Try
            If objSub.UploadFile(picture, filename) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

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

    Public Function GetTotalComplaints() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetTotalComplaints")
            dt.TableName = "sp_GetTotalComplaints"
            Return dt

        Catch ex As Exception
            Throw ex
        Finally

        End Try
        Return dt
    End Function
    Public Function GetMaxTicketNo() As DataTable
        Dim dt As New DataTable
        Try
            dt = objIT.SP_Datatable("sp_GetMaxTicketNo")
            dt.TableName = "sp_GetMaxTicketNo"
            Return dt

        Catch ex As Exception
            Throw ex
        Finally

        End Try
        Return dt
    End Function
    Public Function GetVendorEmail(ByVal VendorName As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim Para As String(,) = {{"@VendorName", VendorName}}
            dt = objIT.SP_Datatable("sp_GetVendorEmail", Para)
            dt.TableName = "sp_GetVendorEmail"
            Return dt

        Catch ex As Exception
            Throw ex
        Finally

        End Try
        Return dt
    End Function

    Public Function InsertComplainHistory(ByVal TicketNo As String,
                                  ByVal TransactionBy As String, _
                                  ByVal TransactionDate As String, _
                                  ByVal StatusID As String, _
                                  ByVal Remarks As String, _
                                  ByVal ETTR As String, _
                                  ByVal Attachment1 As String, _
                                  ByVal Attachment2 As String) As Boolean
        Try

            Dim Para As String(,) = {{"@TicketNo", TicketNo}, {"@TransactionBy", TransactionBy}, {"@Date", TransactionDate}, _
                                     {"@StatusID", StatusID}, {"@Remarks", Remarks}, {"@ETTR", ETTR}, {"@Attachment1", Attachment1}, {"@Attachment2", Attachment2}}

            If objIT.InsertProc_ComplaintHistory("sp_InsertComplainHistory", Para) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UploadImageFile(ByVal picture() As Byte, ByVal filename As String) As String
        Try

            Dim ms As MemoryStream = New MemoryStream(picture, 0, picture.Length)
            Dim path As String = "D:\test\"
            Dim fi As FileInfo = New FileInfo("D:\test\" & filename)
            If fi.Exists Then
                Return "Already"
            Else
                Dim fs As New FileStream(path + filename, FileMode.Create)
                ms.WriteTo(fs)
                ms.Close()
                fs.Close()
                Return "Upload"
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
                                   ByVal Attachment1 As String, _
                                   ByVal Attachment2 As String, _
                                   ByVal Notes As String, _
                                   ByVal TransactionBy As Integer) As Integer
        Try

            Dim Para As String(,) = {{"@TicketNo", TicketNo}, {"@AppID", AppID}, {"@PriorityID", PriorityID}, _
                                     {"@StatusID", StatusID}, {"@UserID", UserID}, {"@ComplainDate", ComplainDate}, _
                                     {"@FormName", FormName}, {"@RequestID", RequestID}, {"@UserRemarks", UserRemarks}, _
                                     {"@Attachment1", Attachment1}, {"@Attachment2", Attachment2}, _
                                     {"@Notes", Notes}, {"@TransactionBy", TransactionBy}}

            Dim lastComplainID = objIT.InsertProc_GetLastComplainID("sp_InsertComplain", Para)
            Return lastComplainID

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function UpdateComplain(ByVal TicketNo As String, ByVal StatusID As Integer, ByVal ETTRDate As Date, ByVal OwnerRemarks As String, ByVal Attachment1 As String, ByVal Attachment2 As String) As Boolean
        Try

            Dim Para As String(,) = {{"@TicketNo", TicketNo}, {"@StatusID", StatusID}, {"@OwnerRemarks", OwnerRemarks}, {"@ETTR", ETTRDate}, {"@Attachment1", Attachment1}, {"@Attachment2", Attachment2}}

            If objIT.executeProcess("sp_UpdateComplain", Para) Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UpdateComplainAssignTo(ByVal TicketNo As String, ByVal FarwardToOwner As String) As Boolean
        Try

            Dim Para As String(,) = {{"@TicketNo", TicketNo}, {"@FarwardToOwner", FarwardToOwner}}

            If objIT.executeProcess("sp_UpdateComplainAssignTo", Para) Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function UpdateComplainScreens(ByVal TicketNo As String, ByVal Attachement1 As String, ByVal Attachement2 As String) As Boolean
        Try

            Dim Para As String(,) = {{"@TicketNo", TicketNo}, {"@Attachement1", Attachement1}, {"@Attachement2", Attachement2}}

            If objIT.executeProcess("sp_UpdateComplainScreen", Para) Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function UpdateUserComplain(ByVal TicketNo As String, ByVal StatusID As Integer, ByVal UserRemarks As String) As Boolean
        Try

            Dim Para As String(,) = {{"@TicketNo", TicketNo}, {"@StatusID", StatusID}, {"@UserRemarks", UserRemarks}}

            If objIT.executeProcess("sp_UpdateUserComplain", Para) Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function UpdateComplainModify(ByVal ComplainID As Integer,
                                  ByVal StatusID As Integer) As Boolean
        Try

            Dim Para As String(,) = {{"@ComplainID", ComplainID}, {"@StatusID", StatusID}}

            If objIT.executeProcess("sp_UpdateComplainModify", Para) Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
