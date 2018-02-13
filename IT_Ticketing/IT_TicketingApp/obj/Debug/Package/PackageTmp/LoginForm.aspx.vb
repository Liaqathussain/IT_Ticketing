Public Class LoginForm
    Inherits Global.System.Web.UI.Page
    Dim objMain As New MainServiceMethod
    Dim objSub As New ItTicketing_Methods
    'Dim objAuth As New LdapAuthentication
    Dim adAuth As LDAP.WebServiceSoapClient = New LDAP.WebServiceSoapClient
    Public Shared User As LDAP.AuthUser = New LDAP.AuthUser()
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try
            With User
                .UserName = "Portal_01"
                .Password = "Mppl@2017"
            End With
            Me.tbLoginName.Enabled = False
            Me.tbPassword.Enabled = False
            btnSubmit.Enabled = False
            '

            If adAuth.Ldap_Authentication(User, tbLoginName.Text.Trim, tbPassword.Text.Trim) Then
                Dim dt As DataTable = objMain.AuthenticateUser(tbLoginName.Text.Trim)
                If dt.Rows.Count > 0 Then
                    'AppDomain.CurrentDomain.SetData("City", dt.Rows(0)("City"))
                    AppDomain.CurrentDomain.SetData("UserName", dt.Rows(0)("UserName"))
                    AppDomain.CurrentDomain.SetData("UserDeptID", dt.Rows(0)("DeptID"))
                    'AppDomain.CurrentDomain.SetData("DepartmentName", dt.Rows(0)("DepartmentName"))
                    'Session("DeptName") = AppDomain.CurrentDomain.SetData("DepartmentName", str3(1))
                    AppDomain.CurrentDomain.SetData("UserID", dt.Rows(0)("UserID"))
                    AppDomain.CurrentDomain.SetData("UserLoginID", dt.Rows(0)("LoginID"))
                    AppDomain.CurrentDomain.SetData("UserEmailID", dt.Rows(0)("EmailID"))
                    Response.Redirect("Home.aspx", False)
                Else
                    Me.tbLoginName.Enabled = True
                    Me.tbPassword.Enabled = True
                    btnSubmit.Enabled = True

                End If
            Else
                lblStatus.Text = "User name and password Incorrect"
            End If



            'Else

            'lblNotify.Text = "Invalid User Name or Password"
            'lblNotify.Visible = True
            'Me.txtUsername.Enabled = True
            'Me.txtPassword.Enabled = True
            'End If

        Catch ex As Exception
            Me.tbLoginName.Enabled = True
            Me.tbPassword.Enabled = True
            btnSubmit.Enabled = True
            lblStatus.Text = "User name and password Incorrect"
            Me.tbLoginName.Enabled = True
            Me.tbLoginName.Enabled = True
        End Try
    End Sub


End Class