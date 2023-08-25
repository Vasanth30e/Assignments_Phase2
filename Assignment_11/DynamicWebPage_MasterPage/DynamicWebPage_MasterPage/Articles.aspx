<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="DynamicWebPage_MasterPage.Articles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align : center">New Articles</h2>
<p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ArticleId" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" PageSize="5">
        <Columns>
            <asp:BoundField DataField="ArticleId" HeaderText="ArticleId" ReadOnly="True" SortExpression="ArticleId" />
            <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" />
            <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" SortExpression="PublishDate" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ContentDBConnectionString %>" DeleteCommand="DELETE FROM [Articles] WHERE [ArticleId] = @original_ArticleId AND [Content] = @original_Content AND (([PublishDate] = @original_PublishDate) OR ([PublishDate] IS NULL AND @original_PublishDate IS NULL))" InsertCommand="INSERT INTO [Articles] ([ArticleId], [Content], [PublishDate]) VALUES (@ArticleId, @Content, @PublishDate)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:ContentDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Articles]" UpdateCommand="UPDATE [Articles] SET [Content] = @Content, [PublishDate] = @PublishDate WHERE [ArticleId] = @original_ArticleId AND [Content] = @original_Content AND (([PublishDate] = @original_PublishDate) OR ([PublishDate] IS NULL AND @original_PublishDate IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_ArticleId" Type="Int32" />
            <asp:Parameter Name="original_Content" Type="String" />
            <asp:Parameter Name="original_PublishDate" Type="DateTime" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ArticleId" Type="Int32" />
            <asp:Parameter Name="Content" Type="String" />
            <asp:Parameter Name="PublishDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Content" Type="String" />
            <asp:Parameter Name="PublishDate" Type="DateTime" />
            <asp:Parameter Name="original_ArticleId" Type="Int32" />
            <asp:Parameter Name="original_Content" Type="String" />
            <asp:Parameter Name="original_PublishDate" Type="DateTime" />
        </UpdateParameters>
    </asp:SqlDataSource>
</p>
</asp:Content>
