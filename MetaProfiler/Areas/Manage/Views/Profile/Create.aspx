<%@ Page Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage<MetaProfiler.Areas.Manage.Models.EditProfile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Profiel toevoegen
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Profiel toevoegen</h2>
    
    <% Html.RenderPartial("EditProfileForm", Model); %>
</asp:Content>
