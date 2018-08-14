Imports System.ComponentModel.DataAnnotations
Public Class Order
    Public Property OrderId() As Integer
    <Required(ErrorMessage:="Please enter your name")>
    Public Property Name() As String
    <Required(ErrorMessage:="Please enter the first address line")>
    Public Property Line1() As String
    Public Property Line2() As String
    Public Property Line3() As String
    <Required(ErrorMessage:="Please enter a city name")>
    Public Property City() As String
    <Required(ErrorMessage:="Please enter a state")>
    Public Property State() As String
    Public Property GiftWrap() As Boolean
    Public Property Dispatched() As Boolean
    Public Overridable Property OrderLines() As List(Of OrderLine)
End Class
Public Class OrderLine
    Public Property OrderLineId() As Integer
    Public Property Order() As Order
    Public Property Product() As Product
    Public Property Quantity() As Integer
End Class
