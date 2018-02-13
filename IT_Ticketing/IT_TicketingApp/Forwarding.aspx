<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainForm.Master" CodeBehind="Forwarding.aspx.vb" Inherits="IT_TicketingApp.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style17
        {
            width: 5px;
        }
        .style20
        {
        }
        .style21
        {
            width: 137px;
            height: 19px;
        }
        .style22
        {
            height: 19px;
        }
        .style23
        {
        }
        .style25
        {
            width: 123px;
        }
        .style26
        {
            height: 19px;
            }
        .style29
        {
            height: 189px;
        }
        .style31
        {
        }
        .style32
        {
            width: 235px;
        }
        .style35
        {
            width: 41px;
        }
        .style39
        {
            width: 130px;
        }
        .style40
        {
            width: 55px;
        }
        .style44
        {
            width: 73px;
        }
        .style45
        {
            width: 229px;
        }
        .style46
        {
            width: 123px;
            height: 19px;
        }
        .style47
        {
            width: 45px;
        }
        .style48
        {
            width: 45px;
            height: 19px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <table class="style4" width ="300px">
        <tr>
            <td align="Center" class="style29" colspan="4" style="font-size: 12px">

                <div style="margin-top: 10px; border: medium groove #000080; height: 230px; width: 700px" align="center">

                <table class="style4" >
                    <tr>
                        <td align="right" class="style20" 
                            style="background-color: #C0C0C0; font-size: 18px; font-style: normal; font-family: Arial, Helvetica, sans-serif;" 
                            colspan="2">
                            TicketNo:</td>
                        <td align="left" class="style23" 
                            style="background-color: #C0C0C0; font-size: 18px; font-style: normal; font-family: Arial, Helvetica, sans-serif;" 
                            colspan="2">
                <asp:Label ID="lblTicketNo" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style20" style="font-weight: bold">
                            Priority:</td>
                        <td class="style25" align="left" style="font-size: 12px">
                            <asp:Label ID="lblPriority" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="left"  style="font-weight: bold">
                            ApplciationName:</td>
                        <td style="font-size: 12px;" align="left">
                            <asp:Label ID="lblApplicationName" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  style="font-weight: bold">
                            ModuleName:</td>
                        <td class="style46" align="left" style="font-size: 12px">
                            <asp:Label ID="lblModuleName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="left"  style="font-weight: bold">
                            UserName:</td>
                        <td class="style22" style="font-size: 12px;" align="left">
                            <asp:Label ID="lblusername" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style21" style="font-weight: bold">
                            DepartmentName:</td>
                        <td class="style46" align="left" style="font-size: 12px">
                            <asp:Label ID="lblDeptName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="left" class="style48" style="font-weight: bold">
                            ComplainDate:</td>
                        <td class="style22" style="font-size: 12px;" align="left">
                            <asp:Label ID="lblComplainDate" runat="server" Text="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style21" style="font-weight: bold">
                            User
                            Attachement1:</td>
                        <td class="style46" align="left" style="font-size: 12px">
                            <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                        </td>
                        <td align="left" class="style48" style="font-weight: bold">
                            StatusName:</td>
                        <td class="style22" style="font-size: 12px;" align="left">
                            <asp:Label ID="lblStatusName" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style21" style="font-weight: bold">
                            User
                            Attachement2:</td>
                        <td class="style46" align="left" style="font-size: 12px">
                            <asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton>
                        </td>
                        <td align="left"  style="font-weight: bold" class="style47">
                            &nbsp;</td>
                        <td class="style22" style="font-size: 12px;" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" class="style21" style="font-weight: bold">
                            UserRemarks:</td>
                        <td class="style26" align="left" colspan="3">
                                <telerik:RadTextBox ID="lblUserRemarks" Runat="server" EnableTheming="True" 
                    Skin="Windows7" TextMode="MultiLine" Width="500px">
                                </telerik:RadTextBox>
                                                                
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style21" style="font-weight: bold">
                            OwnerRemarks:</td>
                        <td class="style26" align="left" colspan="3">
                                <telerik:RadTextBox ID="lblOwnerName" Runat="server" EnableTheming="True" 
                    Skin="Windows7" TextMode="MultiLine" Width="500px">
                                </telerik:RadTextBox>
                                                                
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style21" style="font-weight: bold">
                            &nbsp;</td>
                        <td class="style26" align="left" colspan="3">
                            &nbsp;</td>
                    </tr>
                    </table>

                </div>
                </td>
        </tr>
        <tr>
            <td align="left" class="style31" style="font-size: 12px">
                &nbsp;</td>
            <td class="style32" style="font-size: 12px">
                &nbsp;</td>
            <td class="style17" style="font-size: 12px">
                &nbsp;</td>
            <td style="font-size: 12px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style31" style="font-size: 12px " colspan="4">
            <div width ="100%">
            
              <telerik:RadGrid ID="RadGridHistory" runat="server" Width ="100%" 
                    GridLines="None" AllowPaging="True" AllowSorting="True" >
                     
                  <ClientSettings>
                      <Selecting AllowRowSelect="True" />
                  </ClientSettings>
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

    <Columns>
        <telerik:GridButtonColumn CommandName="Select" HeaderText="Select" 
            Text="Select" UniqueName="column2">
        </telerik:GridButtonColumn>
    </Columns>

</MasterTableView>

<HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                </telerik:RadGrid>
            
            </div>
               </td>
        </tr>
        <tr>
            <td align="right" class="style31" style="font-size: 14px" colspan="4">
               <div style="  width: 700px" align="center">
                <table  width ="100%" >
                        <tr>
                            <td align="left" style="font-size: 12px"  >
                                Status:</td>
                            <td align="left">
                                <telerik:RadComboBox ID="RadComFStatus" Runat="server">
                                </telerik:RadComboBox>

                                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator2" ValidationGroup="ValidationProduct"
                             ControlToValidate="RadComFStatus" ErrorMessage="*"
                             InitialValue="Please-Select" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                            <td align="left" style="font-size: 12px" >
                                <asp:Label ID="lblAttachement" runat="server" Text="Attachement:"></asp:Label>
                            </td>
                            <td align="left" >
                                <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" 
                                    MaxFileInputsCount="2" Width="100px">
                                </telerik:RadAsyncUpload>
                            </td>
                            <td align="left" >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size: 12px"   >
                                <asp:Label ID="lblOwner" runat="server" Text="Owner Remarks:"></asp:Label>
                            </td>
                            <td align="left" class="style45"  >
                                <telerik:RadTextBox ID="RadTextOwner" Runat="server" EnableTheming="True" 
                    Skin="Windows7" TextMode="MultiLine" Width="250px">
                                </telerik:RadTextBox>
                                                                
                            </td>
                            </td>
                            <td align="left" style="font-size: 12px" >
                                <asp:Label ID="lblETTR" runat="server" Text="ETTR :"></asp:Label>
                            </td>
                            <td align="left" class="style39">
                                <telerik:RadDateTimePicker ID="RadDateTimePicker1" Runat="server" 
                                    SelectedDate="04/02/2016 18:08:46">
<TimeView CellSpacing="-1"></TimeView>

<TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>

<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="04/02/2016 18:08:46"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:RadDateTimePicker>

                                 <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator10" ValidationGroup="ValidationProduct"
                             ControlToValidate="RadDateTimePicker1" ErrorMessage="*"
                             InitialValue="Please-Select" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                            <td align="left" class="style35">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size: 12px" >
                                <asp:Label ID="lblUser" runat="server" Text="User Remarks:"></asp:Label>
                            </td>
                            <td align="left" class="style45" >
                                <telerik:RadTextBox ID="RadTextUser" Runat="server" TextMode="MultiLine" 
                    Width="250px">
                                </telerik:RadTextBox>
                            </td>
                            <td align="left" style="font-size: 12px" >
                                <asp:Label ID="lblAssignto" runat="server" Text="Assign to:"></asp:Label>
                            </td>
                            <td align="left" class="style39">
                                <telerik:RadComboBox ID="RadComboAssignTo" Runat="server" 
                                    style="margin-left: 0px">
                                </telerik:RadComboBox>
                            </td>
                            <td align="left" class="style35">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" class="style44" >
                                &nbsp;</td>
                            <td align="left" class="style45" >
                                <telerik:RadButton ID="RadBtnFUpdate" runat="server" Text="Update" Width="60px" 
                    Skin="Web20" OnClick="RadBtnFUpdate_Click" ValidationGroup="ValidationProduct">
                                </telerik:RadButton>
                            </td>
                            <td align="right" class="style40">
                                &nbsp;</td>
                            <td align="left" class="style39">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="style35">
                                &nbsp;</td>
                        </tr>
                        </table>
               </div>
            </td>
        </tr>
        <tr>
            <td class="style31">
                &nbsp;</td>
            <td class="style32" >
                &nbsp;</td>
            <td class="style17" >
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
