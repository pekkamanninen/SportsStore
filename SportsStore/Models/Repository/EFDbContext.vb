Imports System.Data.Entity
Public Class EFDbContext
    Inherits DbContext
    Public Property Products() As DbSet(Of Product)
End Class
