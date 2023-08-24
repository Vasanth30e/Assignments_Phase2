<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductRegistration.aspx.cs" Inherits="Product_Registration.ProductRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <title>Product Registration</title>
    <style type="text/css">
        .auto-style1 {
            width: 299px;
        }
        .auto-style2 {
            width: 299px;
            height: 45px;
        }
        .auto-style3 {
            height: 45px;
        }
        .auto-style6 {
            width: 299px;
            height: 43px;
        }
        .auto-style7 {
            height: 43px;
        }
        .auto-style8 {
            width: 299px;
            height: 21px;
        }
        .auto-style9 {
            height: 21px;
        }
        .auto-style10 {
            width: 299px;
            height: 74px;
        }
        .auto-style11 {
            height: 74px;
        }
    </style>
</head>
<body>
    <h2 style="text-align : center">Product Page</h2>
    <form id="form1" runat="server">             
        <div class="row">
             <div class="col-md-2"><asp:Image runat="server" ID="Image1" ImageUrl="~/Images/photo1.jpg"
                 Width="500" Height="150" CssClass="img-fluid" /></div>
             <div class="col-md-2" style="margin-left : 150px"><asp:Image runat="server" ID="Image2" ImageUrl="~/Images/photo2.jpg"
                 Width="500" Height="150" CssClass="img-fluid" /></div>            
         </div>
        
            <table class="w-100">
                <tr>
                    <td class="auto-style2">Product Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TxtName" runat="server" Width="165px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtName" ErrorMessage="Enter Product Name First" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Category</td>
                    <td class="auto-style11">
                        <asp:DropDownList ID="DdlCategory" runat="server" Height="45px" Width="125px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Smartwatch</asp:ListItem>
                            <asp:ListItem>Headphone</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlCategory" ErrorMessage="Enter Category First" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Price</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TxtPrice" runat="server" Width="165px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtPrice" ErrorMessage="Enter Price First" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtPrice" ErrorMessage="Enter only digits" ForeColor="#FF3300" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Description</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TxtDesc" runat="server" Height="95px" TextMode="MultiLine" Width="230px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDesc" ErrorMessage="Enter Description First" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Release Date</td>
                    <td>
                        <asp:Calendar ID="CalRD" runat="server"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style9">
                        <asp:Button ID="BtnRegister" runat="server" OnClick="Button1_Click" Text="Register" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9" colspan="2">
                        <asp:Label ID="LblInfo" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        
    </form>
</body>
</html>
