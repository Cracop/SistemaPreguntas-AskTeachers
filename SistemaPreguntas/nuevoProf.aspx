<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nuevoProf.aspx.cs" Inherits="SistemaPreguntas.nuevoProf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 13px;
        }
        .auto-style2 {
            margin-left: 100px;
        }
        .auto-style3 {
            margin-left: 124px;
        }
        .auto-style4 {
            margin-left: 126px;
        }
    </style>
</head>
<body style="" >
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="282px" HorizontalAlign="Center" >
            <asp:Label ID="Label1" runat="server" Text="Coloca los datos del nuevo profesor" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:Button ID="ButtonRegresar" runat="server" OnClick="ButtonRegresar_Click" Text="Regresar" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="TextBoxUser" runat="server" CssClass="auto-style4"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server" CssClass="auto-style3"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="TextBoxPass1" runat="server" CssClass="auto-style2" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Confirmar Contraseña:"></asp:Label>
            <asp:TextBox ID="TextBoxPass2" runat="server" CssClass="auto-style1" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonAgregar" runat="server" OnClick="ButtonAgregar_Click" Text="AgregarProf" />
            <br />
            <asp:Label ID="LabelExcep" runat="server"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
