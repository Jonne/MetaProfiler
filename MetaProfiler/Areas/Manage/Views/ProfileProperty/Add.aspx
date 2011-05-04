<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage<MetaProfiler.Areas.Manage.Models.AddProperty>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            loadDetailsEditor();

            $('.propertyTypeSelector').change(function() {
                loadDetailsEditor();
            });
        });

        function loadDetailsEditor() {
            $('#propertyDetails').load('/Manage/ProfileProperty/RenderDetails?name=' + $('.propertyTypeSelector').val());
        }
    </script>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Algemeen</legend>
                       
            <div class="editor-label">
                <%= Html.LabelFor(model => model.NewProperty.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.NewProperty.Description)%>
                <%= Html.ValidationMessageFor(model => model.NewProperty.Description)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.NewProperty.PropertyType)%>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.NewProperty.PropertyType, Model.AvailablePropertyTypes, new { @class = "propertyTypeSelector" })%>
                <%= Html.ValidationMessageFor(model => model.NewProperty.PropertyType)%>
            </div>
        </fieldset>
        
        <fieldset>
            <legend>Details</legend>
            
            <div id="propertyDetails"/>
        </fieldset>
        
        <input type="submit" value="Opslaan" />

    <% } %>
</asp:Content>
