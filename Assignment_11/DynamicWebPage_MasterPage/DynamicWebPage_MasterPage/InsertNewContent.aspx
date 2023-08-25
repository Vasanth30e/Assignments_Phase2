<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="InsertNewContent.aspx.cs" Inherits="DynamicWebPage_MasterPage.InsertNewContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 331px;
    }
        .auto-style2 {
            width: 331px;
            height: 59px;
        }
        .auto-style3 {
            height: 59px;
        }
        .auto-style6 {
            width: 331px;
            height: 40px;
        }
        .auto-style7 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align : center">New Articles</h2>
<table class="w-100">
    <tr>
        <td class="auto-style6">Article ID</td>
        <td class="auto-style7">
            <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Article Content</td>
        <td class="auto-style7">
            <asp:TextBox ID="TxtCnt" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Article Publish Date</td>
        <td class="auto-style7">
            <asp:TextBox ID="TxtDt" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2"></td>
        <td class="auto-style3">
            <asp:Button ID="BtnAdd" runat="server" Text="Add Content" OnClick="BtnAdd_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="LblMsg" runat="server"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
