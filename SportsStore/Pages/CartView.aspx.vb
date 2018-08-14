Public Class CartView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load

    End Sub
    Public Function GetCartLines() As IEnumerable(Of CartLine)
        Return SessionHelper.GetCart(Session).Lines
    End Function

    Public ReadOnly Property CartTotal() As Decimal
        Get
            Return SessionHelper.GetCart(
                Session).ComputeTotalValue()
        End Get
    End Property

    Public ReadOnly Property ReturnUrl() As String
        Get
            Return SessionHelper.[Get](Of String)(
                Session, SessionKey.RETURN_URL)
        End Get
    End Property
End Class