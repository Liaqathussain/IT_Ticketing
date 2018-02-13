<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainForm.Master" CodeBehind="FrmSearch.aspx.vb" Inherits="IT_TicketingApp.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style9
        {
            height: 21px;
        }
        .style10
        {
            width: 211px;
        }
        .style11
        {
            height: 22px;
            width: 211px;
        }
        .style12
        {
            height: 21px;
            width: 211px;
        }
    </style>

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 10px; border: medium groove #000080; height: 440px; width: 840px " 
    align="center">
    <table class="style4">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td align="right" class="style10">
                <telerik:RadComboBox ID="RadComAppName" Runat="server">
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadButton ID="RadBtnSearch" runat="server" Skin="Web20" Text="Search" 
                    Width="60px">
                </telerik:RadButton>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7" colspan="8">
            <div style="width:835px; height: 300px; overflow: scroll;"  align="center">
                              <telerik:RadGrid ID="RadGridSearch" runat="server" Width ="100%" 
                                    GridLines="None" AllowPaging="True" AllowSorting="True" Skin="Outlook" >
                     
                                  <ClientSettings>
                                      <Selecting AllowRowSelect="True" />
                                      <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                  </ClientSettings>
                <MasterTableView>
                <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

                    <Columns>
                        <telerik:GridButtonColumn CommandName="Select" Text="Select" 
                            UniqueName="column1" HeaderText="Select">
                        </telerik:GridButtonColumn>
                    </Columns>

                </MasterTableView>

                                  <PagerStyle Mode="NextPrev" />

                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                                </telerik:RadGrid>
            </div>
              
                </td>
        </tr>
        <tr>
            <td class="style9" align="right" style="font-size: 14px">
                Total Count: </td>
            <td class="style12" align="left" style="font-size: 14px">
                <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                </td>
            <td class="style9">
                </td>
            <td class="style9">
                </td>
            <td class="style9">
                </td>
            <td class="style9">
                </td>
            <td class="style9">
                </td>
            <td class="style9">
                </td>
        </tr>
        <tr>
            <td class="style7" align="right">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6" colspan="8">
                &nbsp;</td>
        </tr>
    </table>
    </div>
</asp:Content>
