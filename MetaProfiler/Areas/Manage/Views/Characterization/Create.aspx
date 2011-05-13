<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master"
    Inherits="System.Web.Mvc.ViewPage<MetaProfiler.Areas.Manage.Models.EditCharacterization>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Profielschets toevoegen
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Profielschets toevoegen</h2>

    <% Html.RenderPartial("EditCharacterizationForm", Model); %>
</asp:Content>
