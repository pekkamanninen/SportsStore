Imports System.Data.Entity
Public Class EFDbContext
    Inherits DbContext
    Public Property Products() As DbSet(Of Product)
    Public Property Orders() As DbSet(Of Order)
End Class
