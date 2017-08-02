<%@ page title="Products" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true"
    codebehind="ProductList.aspx.cs" inherits="WingtipToys.ProductList" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <style>
        .sort {
                font-size:18px;
                font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
                font-weight: 500;
                color: #157ab5;
                margin-top: 0px;
                margin-bottom: 0px;
                
        }
    </style>
    <section>
        <div>
            <hgroup>
                
            </hgroup>
            <table>
                 <tr>
                     <td colspan="2"> <h2><%: Page.Title %></h2></td>
                     <%--<td colspan="2">
                        <p style="margin-left: 500px;"></p>
                         
                     </td>--%>

                <td class="sort"  ><span style="margin-left: 600px;">Sort By:</span></td>

                <td class="sort"  style="color:black;font-style:normal;font-size:16px">

                    <asp:DropDownList id="ddlsortlist" runat="server"  AutoPostBack="true"  >
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Product Name:ASC" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Product Name:DESC" Value="2"></asp:ListItem>
            </asp:DropDownList>
                </td>
                
            </tr>
            </table>
           
            

            <asp:ListView ID="productList" runat="server" 
                DataKeyNames="ProductID" GroupItemCount="4"
                ItemType="WingtipToys.Models.Product" SelectMethod="GetProducts">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                  <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName = Item.ProductName}) %>">
                                    <image src='/Catalog/Images/Thumbs/<%#:Item.ImagePath%>'
                                      width="100" height="75" border="1" />
                                  </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName = Item.ProductName}) %>">
                                      <%#:Item.ProductName%>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
                                    </span>
                                    <br />
                                    <a href="/AddToCart.aspx?productID=<%#:Item.ProductID %>">               
                                        <span class="ProductListItem">
                                            <b>Add To Cart<b>
                                        </span>           
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:content>
