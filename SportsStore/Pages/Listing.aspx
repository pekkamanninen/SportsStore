<%@ Page Language="vb" AutoEventWireup="false" 
    MasterPageFile="/Pages/Store.Master"
    CodeBehind="Listing.aspx.vb" Inherits="SportsStore.Listing" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="SportsStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">

    <div id="content">
<%--            <%For Each prod As Product In GetProducts()
                    Response.Write("<div class='item'>")
                    Response.Write(String.Format("<h3>{0}</h3>", prod.Name))
                    Response.Write(prod.Description)
                    Response.Write(String.Format("<h4>{0:c}</h4>", prod.Price))

                    Response.Write(String.Format("<button name='add' type='submit'" & "value ='{0}'>Add to Cart</button>", prod.ProductID))

                    Response.Write("</div>")

                Next%>--%>
        <asp:Repeater ID="Repeater1" ItemType="SportsStore.Product" 
            SelectMethod="GetProducts" 
            runat="server">
			
            <ItemTemplate>
                <div class="item">
                    <h3><%# Item.Name %></h3>
                    <%# Item.Description %>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name="add" type="submit"
                        value="<%# Item.ProductID %>">Add to Cart</button>
                </div>
            </ItemTemplate>
			
        </asp:Repeater>

        </div>


 <div class="pager">
        <% Response.Write("<br />" & "Hardcoded Pagination Links: ")
            For i As Integer = 1 To MaxPage
                Response.Write(
                    String.Format(
                        "<a href='/Pages/Listing.aspx?page={0}' {1}>{2}</a>",
                        i, If(i = CurrentPage, "class='selected'", ""), i))
            Next%>        
        <% Response.Write("<br />" & "Generated Pagination Links: ")
            For i As Integer = 1 To MaxPage
                Dim path As String =
                    RouteTable.Routes.GetVirtualPath(
                        Nothing, Nothing,
                        New RouteValueDictionary() _
                        From {{"page", i}}).VirtualPath
                Response.Write(String.Format(
                    "<a href='{0}' {1}>{2}</a>",
                    path, If(i = CurrentPage, "class='selected'", ""), i))
            Next%>
    </div>
</asp:Content>