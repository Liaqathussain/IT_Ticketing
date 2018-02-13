<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginForm.aspx.vb" Inherits="IT_TicketingApp.LoginForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IT support</title>
    <style type="text/css">
        #form1
        {
            height: 300px;
            width: 400px;
            margin-right: 160px;
            
        }
        .style15
        {
            width: 102%;
            height: 111px;
        }
        .style16
        {
            height: 10px;
            width: 398px;
        }
        .style8
        {
            width: 95%;
            height: 74px;
        }
        .style21
        {
            width: 100%;
            height: 48px;
        }
        .style22
        {
            width: 81px;
        }
        .style23
        {
            height: 24px;
            width: 117px;
        }
        .style24
        {
            height: 24px;
        }
        .style25
        {
            height: 21px;
            width: 117px;
        }
        .style26
        {
            height: 21px;
        }
        .style27
        {
            width: 396px;
        }
        </style>
</head>
<body style="height: 480px; width :1024px" >
    <div align="center" style="vertical-align: middle;  margin-top: 180px;  margin-left: 250px; width :1024px" >
    <form id="form1" runat="server"  style="border: thick groove #000080">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <div align="center" style="height: 250px; width: 400px">
    <table>
    <tr>
    <td style="font-size: 12px">
                    <asp:Image ID="Image3" runat="server" Height="53px" 
                        ImageUrl="~/Resources/HelpDesk.jpg" Width="119px" />
        </td>
    <td align="right" class="style27">
                                <asp:Image ID="Image2" runat="server" Height="46px" 
                        ImageUrl="~/Resources/\MPPLLOGO.png" style="margin-left: 66px" Width="179px" />
    </td>

    </tr>
    <tr>
    <td>
                                &nbsp;</td>
    <td class="style27">
                    LOGIN HERE</td>

    </tr>
    <tr>
    <td style="margin-left: 40px">
                                <asp:Image ID="Image1" runat="server" Height="116px" 
                                    ImageUrl="~/Resources/UserLogin.png" 
                                    Width="118px" />
    </td>
    <td class="style27">
                                <table class="style15">
                                    <tr>
                                        <td class="style16">
                                <table class="style8">
                                    <tr>
                                        <td align="left" class="style23" 
                                            
                                            
                                            
                                            style="font-size: 12px; font-weight: bold; font-style: normal; color: #000000">
                                            Login Name:</td>
                                        <td class="style24" align="left">
                                            <telerik:RadTextBox ID="tbLoginName" Runat="server" Skin="Web20" Width="135px" 
                                                Text="liaqat.hussain">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style25" 
                                            
                                            
                                            
                                            style="font-size: 12px; font-weight: bold; font-style: normal; color: #000000">
                                            Password:</td>
                                        <td class="style26" align="left">
                                            <telerik:RadTextBox ID="tbPassword" Runat="server" Skin="Web20" 
                                                TextMode="Password" Width="135px">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style25" 
                                            
                                            
                                            style="font-size: 12px; font-weight: bold; font-style: normal; color: #000000">
                                            &nbsp;</td>
                                        <td class="style26" align="left">
                                            <table class="style21">
                                                <tr>
                                                    <td align="left" class="style22">
                                                        <telerik:RadButton ID="btnSubmit" runat="server" BorderStyle="None" 
                                                            Height="29px" Skin="Web20" Text="Submit" Width="82px">
                                                        </telerik:RadButton>
                                                    </td>
                                                    <td>
                                                        <telerik:RadButton ID="btnCancel" runat="server" BorderStyle="None" 
                                                            Height="29px" Skin="Web20" Text="Cancel" Width="82px">
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style25" 
                                            
                                            
                                            style="font-size: 12px; font-weight: bold; font-style: normal; color: #000000">
                                            &nbsp;</td>
                                        <td class="style26" align="left" style="font-size: 11px">
                                            <asp:Label ID="lblStatus" runat="server" Text="Login"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                        </td>
                                    </tr>
                                    </table>
    </td>

    </tr>
    </table>
    
    </div>
    </form>
    </div>
</body>
</html>
