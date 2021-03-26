<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab01_ASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Control de temperatura de Departamentos</h1>
        <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Temperatura Promedio en todo el país"></asp:Label>
        <br />
        <asp:Label ID="lblTemp" runat="server" Text="Label"></asp:Label>
        <br/>
        <p> Seleccione un Departamento:</p>
       
        <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="155px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true">
        </asp:DropDownList>
       
        &nbsp;
        <br />
        <br />
        <asp:Label ID="lblTempPromedio" runat="server" Text="Temperatura promedio en el departamento: "></asp:Label>
        <br />
       
        <p> 
            &nbsp;</p>
    </div>


</asp:Content>
