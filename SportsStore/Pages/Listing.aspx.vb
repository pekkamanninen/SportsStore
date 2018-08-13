Public Class Listing
    Inherits System.Web.UI.Page
    Private repo As New Repository()
    Private pageSize As Integer = 4
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'Protected Function GetProducts1() As IEnumerable(Of Product)
    '    Return repo.Products
    'End Function
    Protected Function GetProducts() As IEnumerable(Of Product)
        Return repo.Products.OrderBy(
            Function(p) p.ProductID
                ).Skip((CurrentPage - 1) * pageSize).Take(pageSize)
    End Function
    Protected ReadOnly Property CurrentPage() As Integer
        Get
            Dim page As Integer
            page =
                If(Integer.TryParse(
                   Request.QueryString("page"), page
                   ), page, 1)
            Return If(page > MaxPage, MaxPage, page)
        End Get
    End Property
    Protected ReadOnly Property MaxPage() As Integer
        Get
            Return CInt(
                Math.Ceiling(
                    CDec(repo.Products.Count()
                        ) / pageSize))
        End Get
    End Property
End Class