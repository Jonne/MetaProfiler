<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage<MetaProfiler.Areas.Manage.Models.EditProfile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Profiel wijzigen
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Profiel wijzigen</h2>
    
    <% Html.RenderPartial("EditProfileForm", Model); %>
</asp:Content>
