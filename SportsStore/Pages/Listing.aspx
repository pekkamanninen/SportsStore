﻿<%@ Page Language="vb" AutoEventWireup="false" 
    MasterPageFile="/Pages/Store.Master"
    CodeBehind="Listing.aspx.vb" Inherits="SportsStore.Listing" %>
<%@ Import Namespace="SportsStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
            <%For Each prod As Product In GetProducts()
                    Response.Write("<div class='item'>")
                    Response.Write(String.Format("<h3>{0}</h3>", prod.Name))
                    Response.Write(prod.Description)
                    Response.Write(String.Format("<h4>{0:c}</h4>", prod.Price))
                    Response.Write("</div>")

                Next%>
        </div>
    <div class="pager">
        <% For i As Integer = 1 To MaxPage
                Response.Write(
                    String.Format(
                        "<a href='/Pages/Listing.aspx?page={0}' {1}>{2}</a>",
                        i, If(i = CurrentPage, "class='selected'", ""), i))
            Next%>
    </div>
</asp:Content>