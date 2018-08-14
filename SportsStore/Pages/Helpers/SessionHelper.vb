Public Enum SessionKey
    CART
    RETURN_URL
End Enum

Public NotInheritable Class SessionHelper
    Private Sub New()
    End Sub

    Public Shared Sub [Set](
        session As HttpSessionState, key As SessionKey, value As Object)
        session([Enum].GetName(GetType(SessionKey), key)) = value
    End Sub

    Public Shared Function [Get](Of T)(
        session As HttpSessionState, key As SessionKey) As T
        Dim dataValue As Object =
            session([Enum].GetName(GetType(SessionKey), key))
        If dataValue IsNot Nothing AndAlso TypeOf dataValue Is T Then
            Return DirectCast(dataValue, T)
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetCart(session As HttpSessionState) As Cart
        Dim myCart As Cart = [Get](Of Cart)(session, SessionKey.CART)
        If myCart Is Nothing Then
            myCart = New Cart()
            [Set](session, SessionKey.CART, myCart)
        End If
        Return myCart
    End Function
End Class
