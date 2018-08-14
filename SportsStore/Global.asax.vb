Imports System.Web.SessionState
Imports System.Web.Routing
Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
    End Sub
End Class