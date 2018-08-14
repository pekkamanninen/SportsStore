Imports System.Web.Routing
Public Class CartSummary
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim myCart As Cart =
            SessionHelper.GetCart(Session)
        csQuantity.InnerText =
            myCart.Lines.Sum(Function(x) x.Quantity).ToString()
        csTotal.InnerText =
            myCart.ComputeTotalValue().ToString("c")
        csLink.HRef =
            RouteTable.Routes.GetVirtualPath(
                Nothing,
                "cart",
                Nothing).VirtualPath
    End Sub
End Class