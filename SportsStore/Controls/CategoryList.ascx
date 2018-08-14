<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CategoryList.ascx.vb" Inherits="SportsStore.CategoryList" %>
<%=CreateHomeLinkHtml() %>

<%For Each cat As String In GetCategories()
	Response.Write(CreateLinkHtml(cat))
Next %>