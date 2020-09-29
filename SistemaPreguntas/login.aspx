<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SistemaPreguntas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            height: 42px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1">&nbsp;</h1>
            <h1 class="auto-style1">&nbsp;</h1>
            <h1 class="auto-style1">&nbsp;Sistema de Preguntas</h1>
        </div>
        <p style="text-align: center">
            Usuario:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p style="text-align: center">
            Contraseña:
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p style="text-align: center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="text-align: center" Text="Ingresar" />
        </p>
        <p style="text-align: center">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="¿Eres un alumno? Regístrate" />
        </p>
        <p style="text-align: center">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
