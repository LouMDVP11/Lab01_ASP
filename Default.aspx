<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab01_ASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Control de temperatura de Departamentos</h1>
        <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Temperatura Promedio en todo el país"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTemp" runat="server" Text="Label"></asp:Label>
        <p> Seleccione un Departamento:</p>
       
        <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="155px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true">
        </asp:DropDownList>
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTempPromedio" runat="server" Text="Temperatura promedio en el departamento: "></asp:Label>
        <br />
        <br />
       
        <div style="height: 270px; width: 815px; margin-right: 2px;">
            <asp:GridView ID="dtgDatos" runat="server">
            </asp:GridView>*hacer doble click para que se ordene, ya que ordena hasta que se cliquea por segunda vez el botón<br />
            <asp:Button ID="brnAscendente" runat="server" Height="30px" OnClick="brnAscendente_Click" Text="Ordenar Ascendente" Width="188px" />
            &nbsp;&nbsp;
            <asp:Button ID="brnAscendente0" runat="server" Height="30px" OnClick="Button1_Click" Text="Ordenar Descendente" Width="188px" />
        
            <br />
&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="brnAscendente1" runat="server" Height="30px" OnClick="Button2_Click" Text="Reestablecer" Width="188px" />
        
        </div>
       
    </div>


</asp:Content>
