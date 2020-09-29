<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prof.aspx.cs" Inherits="SistemaPreguntas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1" style="background-color: royalblue; color: white">Profesor</h1>
        </div>
        <p style="text-align: center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar Sesion" />
        &nbsp;
            <asp:Button ID="ButtonCambio" runat="server" OnClick="ButtonCambio_Click" Text="Cambiar Contraseña" />
        </p>
        <hr />
        <p style="text-align: left">
            Bienvenid@
            <asp:Label ID="Label1" runat="server"></asp:Label>
        &nbsp;</p>
        <p style="text-align: left">
            Filtrar preguntas por alumno:
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Filtrar" />
        </p>
        <strong>Preguntas por responder:<br /></strong>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="15" CellPadding="3">
        </asp:GridView>
        <strong>
        <br />
        Preguntas contestadas:</strong><br />
        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" CellPadding="3">
        </asp:GridView>
        <br />
        <hr />
        <asp:Panel ID="Panel1" runat="server">
            <div id="seleccion">
                <strong>Selección</strong><br /> Folio:
                <asp:Label ID="Label3" runat="server"></asp:Label>
                <br />
                Alumno:
                <asp:Label ID="Label5" runat="server"></asp:Label>
                <br />
                Fecha:
                <asp:Label ID="Label6" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label8" runat="server"></asp:Label>
                <br />
                Pregunta:<br />
                <asp:Label ID="Label7" runat="server"></asp:Label>
                <br />
                Respuesta:<br />
                <asp:TextBox ID="TextBox1" runat="server" Height="69px" Width="282px" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Responder" />
                <br />
            </div>
        </asp:Panel>
        <p>
            <asp:Label ID="Label4" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
