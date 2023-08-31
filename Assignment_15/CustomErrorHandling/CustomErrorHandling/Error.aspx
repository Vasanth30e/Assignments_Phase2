<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CustomErrorHandling.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:red; color:white; text-align:center">
       <h2>Error Occurred!!!</h2>
       <asp:Label ID="LblErrorMessage" runat="server"></asp:Label>
    </div>
    
<p>&nbsp;</p>
</asp:Content>
