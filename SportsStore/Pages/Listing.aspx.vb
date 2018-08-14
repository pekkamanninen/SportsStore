Imports SportsStore.Repository
Imports System.Web.Routing
Public Class Listing
    Inherits System.Web.UI.Page
    Private repo As New Repository()
    Private pageSize As Integer = 4
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Dim selectedProductId As Integer
            If Integer.TryParse(Request.Form("add"), selectedProductId) Then
                Dim selectedProduct As Product =
                    repo.Products.Where(
                        Function(p) p.ProductID =
                            selectedProductId).FirstOrDefault()
                If selectedProduct IsNot Nothing Then
                    SessionHelper.GetCart(
                        Session).AddItem(selectedProduct, 1)
                    SessionHelper.[Set](
                        Session, SessionKey.RETURN_URL, Request.RawUrl)

                    Response.Redirect(
                        RouteTable.Routes.GetVirtualPath(
                            Nothing,
                            "cart",
                            Nothing).VirtualPath)
                End If
            End If
        End If
    End Sub
    Public Function GetProducts() As IEnumerable(Of Product)
        Return FilterProducts().OrderBy(
            Function(p) p.ProductID
                ).Skip((CurrentPage - 1) * pageSize).Take(pageSize)
    End Function
    Protected ReadOnly Property CurrentPage() As Integer
        Get
            Dim page As Integer = GetPageFromRequest()
            Return If(page > MaxPage, MaxPage, page)
        End Get
    End Property
    Protected ReadOnly Property MaxPage() As Integer
        Get
            Dim prodCount As Integer = FilterProducts().Count()
            Return CInt(
                Math.Truncate(
                    Math.Ceiling(
                        CDec(prodCount) / pageSize)))
        End Get
    End Property
    Private Function FilterProducts() As IEnumerable(Of Product)
        Dim products As IEnumerable(Of Product) = repo.Products
        Dim currentCategory As String =
            If(DirectCast(RouteData.Values("category"), String),
               Request.QueryString("category"))
        Return If(currentCategory Is Nothing, products,
                  products.Where(Function(p) p.Category = currentCategory))
    End Function

    Private Function GetPageFromRequest() As Integer
        Dim page As Integer
        Dim reqValue As String = RouteData.Values("page")
        If RouteData.Values("page") Is Nothing Then _
            reqValue = Request.QueryString("page")
        Return If(reqValue IsNot Nothing AndAlso
                  Integer.TryParse(reqValue, page), page, 1)
    End Function
End Class