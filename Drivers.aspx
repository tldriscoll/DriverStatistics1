<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Drivers.aspx.cs" Inherits="DriverStatistics1.Drivers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="align-items:center">
            <asp:Label ID="Label1" runat="server" Text="This application generates a driver report containing total miles driven and average speeds sorted by most miles driven to least. The miles driven and miles per hour are rounded to the nearest integer."></asp:Label>
        
            <div>
            </div>
            <p>
                <asp:Button ID="Results" runat="server" OnClick="Results_Click" Text="Results" />
            </p>
            
                <table style="width:60%">
                    <tr>
                        <td>
                        <asp:Label ID="Label2" runat="server" Text="Original"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label3" runat="server" Text="Results"></asp:Label>
                        </td>
                    </tr> 

                </table>
            
        </div>
        <asp:ListBox ID="ListBoxOriginal" runat="server" Width="260px"></asp:ListBox>
        <asp:ListBox ID="ListBoxResults" runat="server" Width="301px"></asp:ListBox>
    </form>
</body>
</html>
