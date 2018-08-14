Public Class Cart
    Private lineCollection As New List(Of CartLine)()
    Public Sub AddItem(
        product As Product, quantity As Integer)
        Dim line As CartLine =
            lineCollection.Where(
                Function(p) p.Product.ProductID =
                    product.ProductID).FirstOrDefault()
        If line Is Nothing Then
            lineCollection.Add(New CartLine() With {
            .Product = product, .Quantity = quantity})
        Else
            line.Quantity += quantity
        End If
    End Sub
    Public Sub RemoveLine(product As Product)
        lineCollection.RemoveAll(
            Function(l) l.Product.ProductID =
                product.ProductID)
    End Sub
    Public Function ComputeTotalValue() As Decimal
        Return lineCollection.Sum(
            Function(e) e.Product.Price * e.Quantity)
    End Function
    Public Sub Clear()
        lineCollection.Clear()
    End Sub
    Public ReadOnly Property Lines() _
        As IEnumerable(Of CartLine)
        Get
            Return lineCollection
        End Get
    End Property
End Class
Public Class CartLine
    Public Property Product() As Product
    Public Property Quantity() As Integer
End Class
