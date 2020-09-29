<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPasswd.aspx.cs" Inherits="SistemaPreguntas.CambioPasswd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 90px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: center">Cambio de Contraseña</h1>
        <p style="text-align: center">
            <asp:Button ID="ButtonRegresar" runat="server" OnClick="ButtonRegresar_Click" Text="Regresar" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtoCerrar" runat="server" Text="Cerrar Sesión" OnClick="ButtoCerrar_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ID="TextBoxPass1" runat="server" CssClass="auto-style1" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Confirmar Contraseña:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxPass2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirmar Cambio" />
            <br />
            <br />
            <asp:Label ID="LabelExep" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
