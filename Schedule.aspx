<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Schedule.aspx.cs" Inherits="_Default" StyleSheetTheme="" Theme="" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle3 {
            background-color: #DDDDDD;
            width: 100%;
            height: 100%;
        }
        .h1Style {
            font-size: xx-large;
            font-weight: bold;
            font-variant: normal;
            font-family: Cambria, Cochin, Georgia, Times, "Times New Roman", serif;
            text-align: center;
        }
        .auto-style4 {
            font-family: Cambria, Cochin, Georgia, Times, "Times New Roman", serif;
            font-size: large;
            font-weight: normal;
            text-align: left;
            font-variant: normal;
            text-transform: none;
            font-style: normal;
            height: 42px;
            margin-top: 14px;
            margin-left: 355px;
            margin-bottom: 0px;
        }
        .auto-style6 {
            margin-top: 50px;
            margin-right: 50px;
            margin-left: 50px;
            width: 46%;
            position: relative;
            left: 559px;
            top: 0px;
        }
    </style>

    <style>
        body {
               background-color: #DDDDDD;
        }
        .auto-style7 {
            padding: 10px;
            font-size: xx-large;
            font-weight: bold;
            font-variant: normal;
            font-family: Cambria, Cochin, Georgia, Times, "Times New Roman", serif;
            text-align: center;
            height: 88px;
            margin-top: 20px;
            margin-bottom: 0px;
            text-indent: 0px;
            vertical-align: middle;
            line-height: normal;
        }
        .newStyle4 {
            vertical-align: middle;
            text-align: left;
        }
        .auto-style8 {
            background-color: #DDDDDD;
        }
        .auto-style9 {
            height: 219px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="newStyle3">
    <div class="auto-style9">
        <asp:Panel ID="HeaderPanel" runat="server" Height="100%" Width="100%">
            <h1 class="auto-style7">
                <asp:Image ID="Image2" runat="server" CssClass="auto-style8" Height="88px" ImageAlign="Left" ImageUrl="~/ns2-sap-clients-logos.png" Width="317px" />
                &nbsp;Dear Colleagues, please be aware that the following information is internal only. Please do not forward outside of NS2.</h1>
            <h2 class="auto-style4">There is no meeting associated with this invite. The purpose of this invite is to provide a list of key contacts in case your customer is having critical issues during the weekend.</h2>
        </asp:Panel>
        </div>
<asp:GridView ID="GridView1" runat="server"
OnPageIndexChanging = "PageIndexChanging" AllowPaging = "True" CellPadding="4" ForeColor="#333333" Height="70%" ShowHeader="False" CssClass="auto-style6" GridLines="None" HorizontalAlign="Center">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View Calendar" 
               OnClientClick="window.open('CalendarView.aspx', 'CalendarView');" CssClass="auto-style2" Width="140px" style="margin-left: 985px"/>
        </p>
        </form>
</body>
</html>
