<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administrador.aspx.cs" Inherits="SistemaPreguntas.administrador" %>

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
<body style="height: 635px">
    <form id="form1" runat="server">
            <div>
                <h1 style="text-align: center">
                    Administrador</h1>
                <p style="text-align: center">
                    <asp:Button ID="ButtonCerrar" runat="server" Text="Cerrar Sesíon" OnClick="ButtonCerrar_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="ButtonReporte" runat="server" Text="Ver Lista De Preguntas" OnClick="ButtonReporte_Click" />
                </p>
        </div>
                <hr />
            <h2 class="auto-style1">Resumen</h2>
            <p class="auto-style1">
                Total de Preguntas:<asp:Label ID="LabelTotalPreguntas" runat="server"></asp:Label>
&nbsp;Alumnos:
                <asp:Label ID="LabelTotalAlumnos" runat="server"></asp:Label>
&nbsp;Profesores:
                <asp:Label ID="LabelTotalProfesores" runat="server"></asp:Label>
            </p>
            <table style="width:100%;table-layout:fixed;" title="Usuarios">
                    <tr>
                      <th>
                        Alumnos
                      </th>
                      <th>
                        Profesores
                      </th>
                    </tr>
                <tr style="vertical-align:top">
                    <td><center>
                                <asp:GridView ID="ResumenAlum" runat="server" OnSelectedIndexChanged="TotsAlum_SelectedIndexChanged" CellPadding="5">
                                </asp:GridView></center>
                            <br />
                    </td>
                    <td><center>
                                <asp:GridView ID="ResumenProf" runat="server" OnSelectedIndexChanged="TotsProf_SelectedIndexChanged" CellPadding="5">
                                </asp:GridView></center>
                            </td>
                </tr>
                </table>
            <hr />
            <br />
            <h2 class="auto-style1">Usuarios</h2>
            <br />
            <table style="width:100%;table-layout:fixed;" title="Usuarios">
                    <tr>
                      <th>
                        Alumnos
                      </th>
                      <th>
                        Profesores
                      </th>
                    </tr>
                <tr style="vertical-align:top">
                    <td><center>
                                <asp:GridView ID="TotsAlum" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="TotsAlum_SelectedIndexChanged" CellPadding="5">
                                </asp:GridView></center>
                            <br />
                    </td>
                    <td><center>
                                <asp:GridView ID="TotsProf" runat="server" OnSelectedIndexChanged="TotsProf_SelectedIndexChanged" AutoGenerateSelectButton="True" CellPadding="5">
                                </asp:GridView></center>
                            </td>
                </tr>
                <tr style="vertical-align:top">
                    <td class="auto-style1">
                                <asp:Label ID="Label11" runat="server" Text="Usuario:"></asp:Label>
                                &nbsp;<asp:Label ID="LabelAn" runat="server"></asp:Label>
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label12" runat="server" Text="Nombre:"></asp:Label>
                                &nbsp;<asp:TextBox ID="TextBoxNameAlum" runat="server"></asp:TextBox>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label13" runat="server" Text="CU:"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="TextBoxCU" runat="server"></asp:TextBox>
                                <br />
                                <asp:Label ID="Label14" runat="server" Text="Contraseña:"></asp:Label>
                                &nbsp;<asp:TextBox ID="TextBoxPassAlum" runat="server" TextMode="Password"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="ButtonModAl" runat="server" OnClick="ButtonModAl_Click" Text="Modificar Alumno" />
                                &nbsp;&nbsp;
                                <asp:Button ID="ButtonBorrarAlum" runat="server" OnClick="ButtonBorrarAlum_Click" Text="Eliminar Alumno" />
                                <br />
                                <br />
                                <asp:Label ID="LabelExcAlum" runat="server"></asp:Label>
                            </td>
                    <td class="auto-style1">
                                <asp:Label ID="Label15" runat="server" Text="Usuario:"></asp:Label>
                                &nbsp;<asp:Label ID="LabelFn" runat="server"></asp:Label>
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label16" runat="server" Text="Nombre: "></asp:Label>
                                <asp:TextBox ID="TextBoxNameProf" runat="server"></asp:TextBox>
                                <br />
                                <asp:Label ID="Label17" runat="server" Text="Contraseña: "></asp:Label>
                                <asp:TextBox ID="TextBoxPassProf" runat="server" TextMode="Password"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="ButtonModProd" runat="server" OnClick="ButtonModProd_Click" Text="Modificar Profesor" />
                                <br />
                                <br />
                                <asp:Button ID="ButtonAddProf" runat="server" OnClick="ButtonAddProf_Click" Text="Añadir Profesor" />
                                &nbsp;&nbsp;
                                <asp:Button ID="ButtonBorrarProfe" runat="server" Text="Eliminar Profe" OnClick="ButtonBorrarProfe_Click" />
                                <br />
                                <br />
                                <asp:Label ID="LabelExcProf" runat="server"></asp:Label>
                            </td>
                </tr>
            </table>
    </form>
</body>
</html>
