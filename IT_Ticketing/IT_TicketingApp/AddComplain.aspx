<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainForm.Master" CodeBehind="AddComplain.aspx.vb" Inherits="IT_TicketingApp.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            height: 23px;
        }
        .style5
        {
            height: 26px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border: medium groove #000080; height: 440px; width: 840px; margin-top: 10px;" 
    align="center">
    <div style="margin-top: 10px;">
    <table >
    <tr>
    <td colspan="4" align="center" bgcolor="#000066" 
            style="font-size: 16px; font-weight: bolder; font-style: normal; color: #FFFFFF">
    &nbsp;&nbsp;&nbsp;
                Complain Registration Form</td>
    </tr>
    <tr>
    <td align="left" style="font-size: 12px; font-weight: normal" width="80">
                            &nbsp;</td>
    <td width="200" align="left">
    
        </td>
    <td align="left" style="font-size: 12px; font-weight: normal"  width="80" >
                            &nbsp;</td>
    <td width="200" align="left">

                            &nbsp;</td>
    </tr>
    <tr>
    <td align="left" style="font-size: 12px; font-weight: normal" width="80">
                            Application Name</td>
    <td width="200" align="left">
                             <telerik:RadComboBox ID="RadComApp" Runat="server" Width="178px">
                            </telerik:RadComboBox>

                            <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator10" ValidationGroup="ValidationProduct"
                             ControlToValidate="RadComApp" ErrorMessage="*"
                             InitialValue="Please-Select" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </td>
    <td align="left" style="font-size: 12px; font-weight: normal"  width="80" >
                            Priority</td>
    <td width="200" align="left">
                            <telerik:RadComboBox ID="RadComPriority" Runat="server" Width="178px">
                            </telerik:RadComboBox>

                            <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator1" ValidationGroup="ValidationProduct"
                             ControlToValidate="RadComPriority" ErrorMessage="*"
                             InitialValue="Please-Select" ForeColor="#FF3300"></asp:RequiredFieldValidator>

    </td>
    </tr>
    <tr>
    <td align="left" style="font-size: 12px; font-weight: normal" width="80" 
            class="style5">
                            Complain Date</td>
    <td width="200" class="style5">
                            <telerik:RadDatePicker ID="RedComComplainDate" Runat="server"  AutoPostBack = "true"  OnSelectedIndexChanged ="RedComComplainDate_SelectedDateChanged"
                                Skin="Web20" Width="205px" SelectedDate="2016-04-02">
                                <Calendar Skin="Web20" UseColumnHeadersAsSelectors="False" 
                                    UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" Height="23px" 
                                    SelectedDate="2016-04-02">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker>
    </td>
    <td align="left" style="font-size: 12px; font-weight: normal" width="80" 
            class="style5">
                            Request Type</td>
    <td width="200" class="style5" align="left">
                            <telerik:RadComboBox ID="RadComReqType" Runat="server" Width="178px">
                            </telerik:RadComboBox>

                            <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator2" ValidationGroup="ValidationProduct"
                             ControlToValidate="RadComReqType" ErrorMessage="*"
                             InitialValue="Please-Select" ForeColor="#FF3300"></asp:RequiredFieldValidator>

    </td>
    </tr>
    <tr>
    <td align="left" style="font-size: 12px; font-weight: normal" width="100">
                            Form Name</td>
    <td width="200" align="left">
                            <telerik:RadTextBox ID="tbFormName" Runat="server" Skin="Web20" Width="175px" 
                                >
                            </telerik:RadTextBox>
    </td>
    <td align="left" style="font-size: 12px; font-weight: normal" width="80">
                            Attachment</td>
    <td width="200">
                            <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" 
                                MaxFileInputsCount="2" Width="250px" MaxFileSize="1048576">
                            </telerik:RadAsyncUpload>
    </td>
    </tr>
    <tr>
    <td align="left" style="font-size: 12px; font-weight: normal" width="80">
                            User Remarks</td>
    <td width="200">
                            <telerik:RadTextBox ID="tbUserRemarks" Runat="server" Height="40px" 
                                TextMode="MultiLine" Width="230px">
                            </telerik:RadTextBox>
    </td>
    <td align="left" style="font-size: 12px; font-weight: normal" width="80">
                            Notes</td>
    <td width="200">
                            <telerik:RadTextBox ID="tbNotes" Runat="server" Height="40px" 
                                TextMode="MultiLine" Width="230px">
                            </telerik:RadTextBox>
    </td>
    </tr>
    <tr>
    <td align="right" style="font-size: 12px; font-weight: normal" width="80">
                            &nbsp;</td>
    <td width="200">
                            &nbsp;</td>
    <td align="right" style="font-size: 12px; font-weight: normal" width="80">
        &nbsp;</td>
    <td width="200">
                            &nbsp;</td>
    </tr>
    <tr>
    <td align="right" style="font-size: 12px; font-weight: normal" width="80">
                            &nbsp;</td>
    <td width="200">
                            &nbsp;</td>
    <td align="right" style="font-size: 12px; font-weight: normal" width="80">
                                                        <telerik:RadButton ID="btnSubmit" runat="server" Skin="Web20" Text="Submit" 
                                                            Width="70px" OnClick="btnSubmit_Click" ValidationGroup="ValidationProduct">
                                                            
                                                        </telerik:RadButton>
                                                        
        </td>
    <td width="200" align="left">
                                                        <telerik:RadButton ID="btnClear" runat="server" Skin="Web20" Text="Clear" 
                                                            Width="70px">
                                                        </telerik:RadButton>
        </td>
    </tr>
    <tr>
    <td align="right" style="font-size: 12px; font-weight: normal" width="80">
        &nbsp;</td>
    <td width="200">
        &nbsp;</td>
    <td align="left" style="font-size: 12px; font-weight: normal" width="80">
        &nbsp;</td>
    <td width="200" align="left" style="font-size: 12px">
        <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
        </td>
    </tr>
    <tr>
    <td align="right" style="font-size: 12px; font-weight: normal" width="80">
        &nbsp;</td>
    <td width="200">
        &nbsp;</td>
    <td align="left" style="font-size: 12px; font-weight: normal" width="80">
        &nbsp;</td>
    <td width="200" align="left" style="font-size: 12px">
        <asp:Label ID="lblTicketNo" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
    <td align="right" style="font-size: 12px; font-weight: normal" class="style4" 
            colspan="4">
            &nbsp;</td>
    </tr>
    </table>
    </div>

</div>
</asp:Content>
