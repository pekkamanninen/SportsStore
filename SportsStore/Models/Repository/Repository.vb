Imports System.Collections.Generic
Public Class Repository
    Private context As New EFDbContext()
    Public ReadOnly Property Products() As IEnumerable(Of Product)
        Get
            Return context.Products
        End Get
    End Property
End Class
