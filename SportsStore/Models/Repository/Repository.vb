Imports System.Collections.Generic
Imports System.Data.Entity
Public Class Repository
    Private context As New EFDbContext()
    Public ReadOnly Property Products() As IEnumerable(Of Product)
        Get
            Return context.Products
        End Get
    End Property
    Public ReadOnly Property Orders() As IEnumerable(Of Order)
        Get
            Return context.Orders.Include(
                Function(o) o.OrderLines.Select(Function(ol) ol.Product))
        End Get
    End Property
    Public Sub SaveOrder(order As Order)
        If order.OrderId = 0 Then
            order = context.Orders.Add(order)

            For Each line As OrderLine In order.OrderLines
                'context.Entry(line.Product).State = System.Data.EntityState.Modified
            Next
        Else
            Dim dbOrder As Order = context.Orders.Find(order.OrderId)
            If dbOrder IsNot Nothing Then
                dbOrder.Name = order.Name
                dbOrder.Line1 = order.Line1
                dbOrder.Line2 = order.Line2
                dbOrder.Line3 = order.Line3
                dbOrder.City = order.City
                dbOrder.State = order.State
                dbOrder.GiftWrap = order.GiftWrap
                dbOrder.Dispatched = order.Dispatched
            End If
        End If
        context.SaveChanges()
    End Sub
End Class
