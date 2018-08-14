Imports System.Web.Routing
Public Class RouteConfig
    Public Shared Sub RegisterRoutes(
        routes As RouteCollection)
        routes.MapPageRoute(
            Nothing,
            "list/{category}/{page}",
            "~/Pages/Listing.aspx")
        routes.MapPageRoute(
            Nothing,
            "list/{page}",
            "~/Pages/Listing.aspx")
        routes.MapPageRoute(
            Nothing,
            "",
            "~/Pages/Listing.aspx")
        routes.MapPageRoute(
            Nothing,
            "list",
            "~/Pages/Listing.aspx")
    End Sub
End Class
