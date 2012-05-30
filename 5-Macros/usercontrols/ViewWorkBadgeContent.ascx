<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewWorkBadgeContent.ascx.cs" Inherits="usercontrols_ViewWorkBadgeContent" %>

<div class="list-image">
    <a href="<%= LinkUrl %>" class="view-my-work">view my work</a>
    <h2>I can help you with that!</h2>
    <asp:Literal runat="server" ID="WysiwygContent" />
</div>