Public Class Listing
    Inherits System.Web.UI.Page
    Private repo As New Repository()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Function GetProducts() As IEnumerable(Of Product)
        Return repo.Products
    End Function

End Class