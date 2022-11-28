<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proj.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chinese Translation — LAU Ka Pui (s226064)</title>
    <style type="text/css">
        .button {
            font-size: 11px;
            font-weight: bold;
            font-family: Arial;
            color: #ffffff;
            min-width: 54px;
            height: 24px;
            white-space: nowrap;
            cursor: pointer;
            outline: 0 none;
            padding: 0 10px 2px;
            text-align: center;
            border-radius: 2px 2px 2px 2px;
            border: 1px solid #4980C1;
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#5384BE', endColorstr='#4386D7');
            /* for IE */
            -ms-filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#5384BE', endColorstr='#4386D7');
            /* for IE 8 and above */
            background: -webkit-gradient(linear, left top, left bottom, from(#5384BE), to(#4386D7));
            /* for webkit browsers */
            background: -moz-linear-gradient(top, #5384BE, #4386D7);
            /* for firefox 3.6+ */
            background: -o-linear-gradient(top, #5384BE, #4386D7);
            /* for Opera */
        }

            .button:hover {
                cursor: pointer;
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=' #85B6F0', endColorstr='#579AEB');
                /* for IE */
                -ms-filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=' #85B6F0', endColorstr='#579AEB');
                /* for IE 8 and above */
                background: -webkit-gradient(linear, left top, left bottom, from(#85B6F0), to(#579AEB));
                /* for webkit browsers */
                background: -moz-linear-gradient(top, #85B6F0, #579AEB);
                /* for firefox 3.6+ */
                background: -o-linear-gradient(top, #85B6F0, #579AEB);
                /* for Opera */
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="Table1" runat="server" Width="100%" Height="100%">

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="InputLabel" runat="server" Text="Chinese (Input)" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox" runat="server" TextMode="MultiLine" Height="200px" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="OutputLabel" runat="server" Text="Chinese (Output)" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label" runat="server" Text="" Height="200px" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <%--<asp:TableRow>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownList" AutoPostBack="true" runat="server"  Height="50px">
                        <asp:ListItem Selected="True" Value="chs">Simplified Chinese</asp:ListItem>
                        <asp:ListItem Value="cht">Traditional Chinese</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>--%>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="ConvertBtn" class="button" runat="server" Text="Convert" OnClick="ConvertBtn_Click" Height="50px" Width="100%"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
