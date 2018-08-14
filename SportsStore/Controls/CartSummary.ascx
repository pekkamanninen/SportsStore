<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CartSummary.ascx.vb" Inherits="SportsStore.CartSummary" %>
<div id="cartSummary">
    <span class="caption">
        <b>Your cart:</b>
        <span id="csQuantity" runat="server"></span> item(s),
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">Checkout</a>
</div>