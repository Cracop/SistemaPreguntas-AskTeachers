<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporte.aspx.cs" Inherits="SistemaPreguntas.reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body style="height: 791px">
    <form id="form1" runat="server">
        <h1 class="auto-style1">Reporte Preguntas</h1>
        <div class="auto-style1">
            <br />
            <asp:Button ID="ButtonRegresar" runat="server" OnClick="ButtonRegresar_Click" Text="Regresar" />
            <br />
            <br />
            Filtrar por alumno:
            <asp:DropDownList ID="DropAlumnos" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp; Filtrar por profesor:
            <asp:DropDownList ID="DropProfesores" runat="server">
            </asp:DropDownList>
            &nbsp;
            <asp:Button ID="Filtrar" runat="server" OnClick="Filtrar_Click" Text="Filtrar" />
            <br />
            <hr />
            <br />
        </div>
        <asp:Panel ID="Panel4" runat="server" Height="213px">
            Folio:&nbsp;&nbsp;
            <asp:Label ID="LabelFolio" runat="server"></asp:Label>
            <br />
            Alumno:&nbsp;
            <asp:Label ID="LabelAlumno" runat="server"></asp:Label>
            <br />
            Profesor:&nbsp;
            <asp:Label ID="LabelProfesor" runat="server"></asp:Label>
            <br />
            Fecha de Pregunta:&nbsp;&nbsp;
            <asp:Label ID="LabelFechaPregunta" runat="server"></asp:Label>
            <asp:Label ID="LabelFechaRespuesta" runat="server"></asp:Label>
            <br />
            Pregunta:&nbsp;
            <asp:Label ID="LabelPregunta" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelRespuesta" runat="server" Text="Respuesta:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxRespuesta" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonBorrar" runat="server" OnClick="ButtonBorrar_Click" Text="Eliminar Pregunta" />
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="421px">
            Preguntas sin contestar:<br />
            <asp:GridView ID="GridSinContestar" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridSinContestar_SelectedIndexChanged">
            </asp:GridView>
            <br />
            Preguntas Contestadas:<br />
            <asp:GridView ID="GridContestado" runat="server" AutoGenerateSelectButton="True" EnableTheming="False" OnSelectedIndexChanged="GridContestado_SelectedIndexChanged">
            </asp:GridView>
        </asp:Panel>
    </form>
</body>
</html>
