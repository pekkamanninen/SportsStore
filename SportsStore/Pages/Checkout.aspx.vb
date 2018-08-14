Imports System.Web.ModelBinding

Public Class Checkout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        checkoutForm.Visible = True
        checkoutMessage.Visible = False

        If IsPostBack Then
            Dim myOrder As New Order
            Dim myRepository As New Repository
            If TryUpdateModel(
                myOrder,
                New FormValueProvider(
                    ModelBindingExecutionContext)) Then

                myOrder.OrderLines = New List(Of OrderLine)()

                Dim myCart As Cart = SessionHelper.GetCart(Session)

                For Each line As CartLine In myCart.Lines
                    myOrder.OrderLines.Add(New OrderLine() With {
                        .Order = myOrder,
                        .Product = line.Product,
                        .Quantity = line.Quantity
                    })
                Next
                'New Repository().SaveOrder(myOrder)
                myRepository.SaveOrder(myOrder)
                myCart.Clear()
                checkoutForm.Visible = False
                checkoutMessage.Visible = True
            End If
        End If
    End Sub

End Class