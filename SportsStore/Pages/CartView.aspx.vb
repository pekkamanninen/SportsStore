Imports System.Web.Routing
Public Class CartView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If IsPostBack Then
            Dim repo As New Repository()
            Dim productId As Integer
            If Integer.TryParse(
                Request.Form("remove"), productId) Then
                Dim productToRemove As Product =
                    repo.Products.Where(
                        Function(p) p.ProductID =
                            productId).FirstOrDefault()
                If productToRemove IsNot Nothing Then
                    SessionHelper.GetCart(
                        Session).RemoveLine(productToRemove)
                End If
            End If
        End If

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
    Public ReadOnly Property CheckoutUrl() As String
        Get
            Return RouteTable.Routes.GetVirtualPath(
                Nothing, "checkout", Nothing).VirtualPath
        End Get
    End Property
End Class