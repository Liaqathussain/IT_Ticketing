Imports Telerik.Web.UI
Imports System


Public Class WebForm3
    Inherits System.Web.UI.Page
    Public objBL As New ItTicketing_Methods
    Dim objMain As New MainServiceMethod

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTGetSearchResult As DataTable
            If Not IsPostBack = True Then
                Dim dtApp = objBL.GetApplicationDetails()
                Dim dtStatus = objBL.GetComplainStatus()
                Dim dtPriority = objBL.GetPriority
                Dim DTRequestType = objBL.GetRequestType

                Dim array As Integer() = New Integer(3) {}
                Dim UserId As Integer = AppDomain.CurrentDomain.GetData("UserID")

                Dim DT As DataTable = objMain.GetUserDetailsbyUserID(UserId)

                RadComAppName.Items.Add(New RadComboBoxItem("Please-Select", dtApp.Rows.Count))
                For i As Integer = 0 To dtApp.Rows.Count - 1
                    RadComAppName.Items.Add(New RadComboBoxItem(dtApp.Rows(i)("ApplciationName").ToString, i))

                Next
                
                If DT.Rows(0)("ModuleName") = "Admin" Then
                    DTGetSearchResult = objBL.GetSearchResultAdmin()
                ElseIf DT.Rows(0)("ModuleName") = "Owner" Then
                    If DT.Rows.Count = 1 Then
                        array(0) = DT.Rows(0)("AppID")
                        array(1) = 0
                        array(2) = 0
                        array(3) = 0
                    ElseIf DT.Rows.Count = 2 Then
                        array(0) = DT.Rows(0)("AppID")
                        array(1) = DT.Rows(1)("AppID")
                        array(2) = 0
                        array(3) = 0
                    ElseIf DT.Rows.Count = 3 Then
                        array(0) = DT.Rows(0)("AppID")
                        array(1) = DT.Rows(1)("AppID")
                        array(2) = DT.Rows(2)("AppID")
                        array(3) = 0
                    ElseIf DT.Rows.Count = 4 Then
                        array(0) = DT.Rows(0)("AppID")
                        array(1) = DT.Rows(1)("AppID")
                        array(2) = DT.Rows(2)("AppID")
                        array(3) = DT.Rows(3)("AppID")
                    End If
                    DTGetSearchResult = objBL.GetSearchResult(array(0), array(1), array(2), array(3))
                ElseIf DT.Rows(0)("ModuleName") = "User" Then
                    DTGetSearchResult = objBL.GetSearchResultbyUser(UserId)
                End If
                If DTGetSearchResult.Rows.Count > 0 Then
                    lblStatus.Text = DTGetSearchResult.Rows.Count
                    Dim dt1 As New DataTable()
                    dt1.Columns.AddRange(New DataColumn(19) {New DataColumn("Ticket No"), New DataColumn("App Name"), New DataColumn("Complain Date"), New DataColumn("Department Name"), New DataColumn("Status Name"), New DataColumn("User Name"), _
                                                           New DataColumn("UserID"), New DataColumn("AppID"), New DataColumn("Priority"), New DataColumn("ModuleName"), New DataColumn("FormName"), New DataColumn("UserRemarks"), New DataColumn("OwnerRemarks"), _
                                                             New DataColumn("Notes"), New DataColumn("ModuleID"), New DataColumn("Attachment1"), New DataColumn("Attachment2"), New DataColumn("OwnerAttach1"), New DataColumn("OwnerAttach2"), New DataColumn("TransactionDateTime")})
                    For i As Integer = 0 To DTGetSearchResult.Rows.Count - 1
                        dt1.Rows.Add(DTGetSearchResult.Rows(i)("TicketNo").ToString, DTGetSearchResult.Rows(i)("ApplciationName").ToString, Format(DTGetSearchResult.Rows(i)("ComplainDate"), "dd-MMM-yyyy hh:mm:ss"), DTGetSearchResult.Rows(i)("DepartmentName").ToString, DTGetSearchResult.Rows(i)("StatusName").ToString, DTGetSearchResult.Rows(i)("UserName").ToString, _
                                    DTGetSearchResult.Rows(i)("UserID").ToString, DTGetSearchResult.Rows(i)("AppID").ToString, DTGetSearchResult.Rows(i)("Priority").ToString, DTGetSearchResult.Rows(i)("ModuleName").ToString, DTGetSearchResult.Rows(i)("FormName").ToString, DTGetSearchResult.Rows(i)("UserRemarks").ToString, DTGetSearchResult.Rows(i)("OwnerRemarks").ToString, _
                                    DTGetSearchResult.Rows(i)("Notes").ToString, DTGetSearchResult.Rows(i)("ModuleID").ToString, DTGetSearchResult.Rows(i)("Attachment1").ToString, DTGetSearchResult.Rows(i)("Attachment2").ToString, DTGetSearchResult.Rows(i)("OwnerAttach1").ToString, DTGetSearchResult.Rows(i)("OwnerAttach2").ToString, DTGetSearchResult.Rows(i)("TransactionDateTime").ToString)
                    Next
                    RadGridSearch.DataSource = dt1
                    RadGridSearch.DataBind()

                    RadGridSearch.MasterTableView.GetColumn("UserID").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("AppID").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("Priority").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("ModuleName").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("FormName").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("UserRemarks").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("OwnerRemarks").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("Notes").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("ModuleID").Visible = False
                    'RadGridSearch.MasterTableView.GetColumn("Attachment1").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("Attachment2").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("OwnerAttach1").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("OwnerAttach2").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("TransactionDateTime").Visible = False
                Else
                    'MsgBox("Unable to get Status", MsgBoxStyle.Critical)
                End If

                
            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub RadComAppName_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComAppName.SelectedIndexChanged
        Try
            Session("AppID") = RadComAppName.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub RadBtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadBtnSearch.Click
        Try
            If Page.IsPostBack = True Then
                Dim DTAsPerCriteria As DataTable = objBL.GetSearchAsPerCriteria(Session("AppID"))

                If DTAsPerCriteria.Rows.Count > 0 Then
                    'ViewState("SignUpID") = SignUpID

                    Dim dt1 As New DataTable()
                    dt1.Columns.AddRange(New DataColumn(19) {New DataColumn("Ticket No"), New DataColumn("App Name"), New DataColumn("Complain Date"), New DataColumn("Department Name"), New DataColumn("Status Name"), New DataColumn("User Name"), _
                                                           New DataColumn("UserID"), New DataColumn("AppID"), New DataColumn("Priority"), New DataColumn("ModuleName"), New DataColumn("FormName"), New DataColumn("UserRemarks"), New DataColumn("OwnerRemarks"), _
                                                             New DataColumn("Notes"), New DataColumn("ModuleID"), New DataColumn("Attachment1"), New DataColumn("Attachment2"), New DataColumn("OwnerAttach1"), New DataColumn("OwnerAttach2"), New DataColumn("TransactionDateTime")})
                    For i As Integer = 0 To DTAsPerCriteria.Rows.Count - 1
                        dt1.Rows.Add(DTAsPerCriteria.Rows(i)("TicketNo").ToString, DTAsPerCriteria.Rows(i)("ApplciationName").ToString, Format(DTAsPerCriteria.Rows(i)("ComplainDate"), "dd-MMM-yyyy hh:mm:ss"), DTAsPerCriteria.Rows(i)("DepartmentName").ToString, DTAsPerCriteria.Rows(i)("StatusName").ToString, DTAsPerCriteria.Rows(i)("UserName").ToString, _
                                    DTAsPerCriteria.Rows(i)("UserID").ToString, DTAsPerCriteria.Rows(i)("AppID").ToString, DTAsPerCriteria.Rows(i)("Priority").ToString, DTAsPerCriteria.Rows(i)("ModuleName").ToString, DTAsPerCriteria.Rows(i)("FormName").ToString, DTAsPerCriteria.Rows(i)("UserRemarks").ToString, DTAsPerCriteria.Rows(i)("OwnerRemarks").ToString, _
                                    DTAsPerCriteria.Rows(i)("Notes").ToString, DTAsPerCriteria.Rows(i)("ModuleID").ToString, DTAsPerCriteria.Rows(i)("Attachment1").ToString, DTAsPerCriteria.Rows(i)("Attachment2").ToString, DTAsPerCriteria.Rows(i)("OwnerAttach1").ToString, DTAsPerCriteria.Rows(i)("OwnerAttach2").ToString, DTAsPerCriteria.Rows(i)("TransactionDateTime").ToString)
                    Next
                    RadGridSearch.DataSource = dt1
                    RadGridSearch.DataBind()

                    RadGridSearch.MasterTableView.GetColumn("UserID").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("AppID").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("Priority").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("ModuleName").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("FormName").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("UserRemarks").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("OwnerRemarks").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("Notes").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("ModuleID").Visible = False
                    'RadGridSearch.MasterTableView.GetColumn("Attachment1").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("Attachment2").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("OwnerAttach1").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("OwnerAttach2").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("TransactionDateTime").Visible = False



                    lblStatus.Text = DTAsPerCriteria.Rows.Count
                    'RadGridSearch.DataSource = DTAsPerCriteria
                    'RadGridSearch.DataBind()
                    'DTGridView.Columns(0).ColumnName = False
                Else
                    lblStatus.Text = DTAsPerCriteria.Rows.Count
                    Dim dt1 As New DataTable()
                    dt1.Columns.AddRange(New DataColumn(19) {New DataColumn("Ticket No"), New DataColumn("App Name"), New DataColumn("Complain Date"), New DataColumn("Department Name"), New DataColumn("Status Name"), New DataColumn("User Name"), _
                                                           New DataColumn("UserID"), New DataColumn("AppID"), New DataColumn("Priority"), New DataColumn("ModuleName"), New DataColumn("FormName"), New DataColumn("UserRemarks"), New DataColumn("OwnerRemarks"), _
                                                             New DataColumn("Notes"), New DataColumn("ModuleID"), New DataColumn("Attachment1"), New DataColumn("Attachment2"), New DataColumn("OwnerAttach1"), New DataColumn("OwnerAttach2"), New DataColumn("TransactionDateTime")})
                    For i As Integer = 0 To DTAsPerCriteria.Rows.Count - 1
                        dt1.Rows.Add(DTAsPerCriteria.Rows(i)("TicketNo").ToString, DTAsPerCriteria.Rows(i)("ApplciationName").ToString, Format(DTAsPerCriteria.Rows(i)("ComplainDate"), "dd-MMM-yyyy"), DTAsPerCriteria.Rows(i)("DepartmentName").ToString, DTAsPerCriteria.Rows(i)("StatusName").ToString, DTAsPerCriteria.Rows(i)("UserName").ToString, _
                                    DTAsPerCriteria.Rows(i)("UserID").ToString, DTAsPerCriteria.Rows(i)("AppID").ToString, DTAsPerCriteria.Rows(i)("Priority").ToString, DTAsPerCriteria.Rows(i)("ModuleName").ToString, DTAsPerCriteria.Rows(i)("FormName").ToString, DTAsPerCriteria.Rows(i)("UserRemarks").ToString, DTAsPerCriteria.Rows(i)("OwnerRemarks").ToString, _
                                    DTAsPerCriteria.Rows(i)("Notes").ToString, DTAsPerCriteria.Rows(i)("ModuleID").ToString, DTAsPerCriteria.Rows(i)("Attachment1").ToString, DTAsPerCriteria.Rows(i)("Attachment2").ToString, DTAsPerCriteria.Rows(i)("OwnerAttach1").ToString, DTAsPerCriteria.Rows(i)("OwnerAttach2").ToString, DTAsPerCriteria.Rows(i)("TransactionDateTime").ToString)
                    Next
                    RadGridSearch.DataSource = dt1
                    RadGridSearch.DataBind()

                    RadGridSearch.MasterTableView.GetColumn("UserID").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("AppID").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("Priority").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("ModuleName").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("FormName").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("UserRemarks").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("OwnerRemarks").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("Notes").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("ModuleID").Visible = False
                    'RadGridSearch.MasterTableView.GetColumn("Attachment1").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("Attachment2").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("OwnerAttach1").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("OwnerAttach2").Visible = False
                    RadGridSearch.MasterTableView.GetColumn("TransactionDateTime").Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridSearch_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridSearch.ItemCommand
        Try
            If RadGrid.SelectCommandName = "Select" Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridSearch.SelectedIndexChanged
        Try

            For Each item As GridDataItem In RadGridSearch.SelectedItems
                If RadGrid.SelectCommandName = "Select" Then
                    Session("TicketNo") = item("Ticket No").Text
                    Session("ApplciationName") = item("App Name").Text
                    Session("ComplainDate") = item("Complain Date").Text
                    Session("DepartmentName") = item("Department Name").Text
                    Session("StatusName") = item("Status Name").Text
                    Session("UserName") = item("User Name").Text

                    Session("AppID") = item("AppID").Text
                    Session("Priority") = item("Priority").Text
                    Session("ModuleName") = item("ModuleName").Text
                    Session("FormName") = item("FormName").Text
                    Session("UserRemarks") = item("UserRemarks").Text
                    Session("OwnerRemarks") = item("OwnerRemarks").Text
                    Session("Notes") = item("Notes").Text
                    Session("TransactionDateTime") = item("TransactionDateTime").Text
                    Session("ModuleID") = item("ModuleID").Text
                    Session("Attachment1") = item("Attachment1").Text
                    Session("Attachment2") = item("Attachment2").Text
                    Session("OwnerAttach1") = item("OwnerAttach1").Text
                    Session("OwnerAttach2") = item("OwnerAttach2").Text
                    'Session("ETTR") = item("ETTR").Text
                    Response.Redirect("Forwarding.aspx", False)
                End If
            Next


        Catch ex As Exception

        End Try
    End Sub


    Protected Sub RadGridSearch_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSearch.NeedDataSource

    End Sub

   
End Class