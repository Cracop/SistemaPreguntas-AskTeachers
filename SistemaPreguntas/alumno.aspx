<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alumno.aspx.cs" Inherits="SistemaPreguntas.alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1" style="background-color:forestgreen; color:white">Alumno</h1>
        </div>
        <p style="text-align: center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar Sesion" />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Cambiar Contraseña" />
        </p>
        <hr />
        <p style="text-align: left">
            Bienvenid@
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p style="text-align: left">
            Filtrar por profesor:
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
&nbsp;<asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Filtrar" />
        </p>
        <p style="text-align: left">
            <strong>Preguntas respondidas:</strong></p>
        <p style="text-align: left;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="3">
            </asp:GridView>
        </p>
        <p style="text-align: left; font-weight: 700;">
            Preguntas no respondidas:</p>
        <p style="text-align: left;">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" CellPadding="3">
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <hr />
        <table style="width:100%;table-layout:fixed;">
            <tr style="vertical-align:top">
                <td style="">
                    <asp:Panel ID="Panel2" runat="server" style="font-weight: 700">
                        Nueva Pregunta<br /> <span class="auto-style2">Profesor: </span>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                        <br />
                        <span class="auto-style2">Pregunta:</span><br />
                        <asp:TextBox ID="TextBox2" runat="server" Height="72px" Width="346px" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Mandar Pregunta" />
                        <br />
                    </asp:Panel>
                </td>
                <td style="">
                    <asp:Panel ID="Panel1" runat="server">
                        <strong>Selección<br /> </strong>Folio:
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        <br />
                        Profesor:
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                        <br />
                        Fecha de Pregunta:
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                        &nbsp;<asp:Label ID="Label4" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                        <br />
                        Pregunta:
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" Height="75px" Width="423px" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Editar Pregunta" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Borrar Pregunta" />
                        <br />
                        <br />
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" style="width: 77px" Text="Cancelar" />
                        <br />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <p>
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
