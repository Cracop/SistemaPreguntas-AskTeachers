<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nuevoAlum.aspx.cs" Inherits="SistemaPreguntas.nuevoAlum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:aliceblue">
    <form id="form1" runat="server">
        <div>
            <br />
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="492px" HorizontalAlign="Center">
            <h1>Registro de Alumno</h1>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="TextUser" runat="server" style="margin-left: 119px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Clave Única:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextCU" runat="server" style="margin-left: 48px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="TextName" runat="server" Height="18px" style="margin-left: 126px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ID="TextPass1" runat="server" style="margin-left: 103px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Confirmar Contraseña:"></asp:Label>
            <asp:TextBox ID="TextPass2" runat="server" style="margin-left: 27px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Regresar al login" />
            &nbsp;&nbsp;
            <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Crear cuenta" />
            <br />
            <br />
            <asp:Label ID="LabelExcep" runat="server"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
