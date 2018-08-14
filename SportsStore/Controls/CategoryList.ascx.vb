Imports System.Web.Routing
Public Class CategoryList
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load

    End Sub
    Protected Function GetCategories() As IEnumerable(Of String)
        Return New Repository().Products.[Select](
            Function(p) p.Category).Distinct().OrderBy(Function(x) x)
    End Function
    Protected Function CreateHomeLinkHtml() As String
        Dim path As String =
            RouteTable.Routes.GetVirtualPath(Nothing, Nothing).VirtualPath
        Return String.Format("<a href='{0}'>Home</a>", path)
    End Function
    'Protected Function CreateLinkHtml(category As String) As String

    '    Dim path As String =
    '        RouteTable.Routes.GetVirtualPath(
    '            Nothing, Nothing, New RouteValueDictionary() From {
    '                {"category", category},
    '                {"page", "1"}
    '            }).VirtualPath

    '    Return String.Format("<a href='{0}'>{1}</a>", path, category)
    'End Function
    Protected Function CreateLinkHtml(category As String) As String

        Dim selectedCategory As String =
            If(Page.RouteData.Values("category"), Request.QueryString("category"))

        Dim path As String = RouteTable.Routes.GetVirtualPath(
            Nothing, Nothing, New RouteValueDictionary() From {
                {"category", category},
                {"page", "1"}
        }).VirtualPath

        Return String.Format(
            "<a href='{0}' {1}>{2}</a>", path,
            If(category = selectedCategory, "class='selected'", ""), category)
    End Function
End Class