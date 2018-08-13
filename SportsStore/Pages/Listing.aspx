<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Listing.aspx.vb" Inherits="SportsStore.Listing" %>
<%@ Import Namespace="SportsStore" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1">
        <div>
             <%For Each prod As Product In GetProducts()
                    Response.Write("<div class='item'>")
                    Response.Write(String.Format("<h3>{0}</h3>", prod.Name))
                    Response.Write(prod.Description)
                    Response.Write(String.Format("<h4>{0:c}</h4>", prod.Price))
                    Response.Write("</div>")

                Next%>
        </div>
    </form>
</body>
</html>
