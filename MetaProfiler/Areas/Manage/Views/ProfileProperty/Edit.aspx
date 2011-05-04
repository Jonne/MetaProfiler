<%@ Import Namespace="MetaProfiler.Code" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage<MetaProfiler.Areas.Manage.Models.Entities.ProfileProperty>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <h2>Eigenschap bewerken</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Algemeen</legend>
                       
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Description)%>
                <%= Html.ValidationMessageFor(model => model.Description)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.PropertyType)%>
            </div>
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.PropertyType) %>
                <strong><%= Model.PropertyType %></strong>
            </div>
        </fieldset>
        
        <fieldset>
            <legend>Details</legend>
            
            <div id="propertyDetails">
                <% Html.RenderDesignerFor(Model); %>
            </div>
        </fieldset>
        
        <input type="submit" value="Opslaan" />

    <% } %>
</asp:Content>
