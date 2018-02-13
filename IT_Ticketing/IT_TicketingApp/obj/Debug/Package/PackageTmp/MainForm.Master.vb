Public Class MainForm
    Inherits System.Web.UI.MasterPage
    Dim objMain As New MainServiceMethod

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim UserId As Integer = AppDomain.CurrentDomain.GetData("UserID")
        Dim DT As DataTable = objMain.GetUserDetailsbyUserID(UserId)
        lblLoginName.Text = AppDomain.CurrentDomain.GetData("UserName") & "     From : " & DT.Rows(0)("DepartmentName").ToString
        Session("UserID") = UserId
        If Not IsPostBack = True Then
            If DT.Rows.Count > 0 Then
                If DT.Rows(0)("ModuleName").ToString = "Admin" Then
                    Session("ModuleAdmin") = DT.Rows(0)("ModuleName").ToString
                    Session("ModuleUser") = ""
                    Session("ModuleOwner") = ""
                ElseIf DT.Rows(0)("ModuleName").ToString = "Owner" Then
                    RadMenu1.Items.Remove(RadMenu1.FindItemByText("Admin"))
                    Session("ModuleOwner") = DT.Rows(0)("ModuleName").ToString
                    Session("ModuleUser") = ""
                    Session("ModuleAdmin") = ""
                ElseIf DT.Rows(0)("ModuleName").ToString = "User" Then
                    RadMenu1.Items.Remove(RadMenu1.FindItemByText("Admin"))
                    Session("ModuleUser") = DT.Rows(0)("ModuleName").ToString
                    Session("ModuleOwner") = ""
                    Session("ModuleAdmin") = ""
                End If

            End If
        End If

    End Sub

    Protected Sub RadMenu1_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu1.ItemClick

    End Sub
End Class