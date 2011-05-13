<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage<MetaProfiler.Areas.Manage.Models.EditArticle>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../../../Scripts/fckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../../../../Scripts/fckeditor/adapters/jquery.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {
            $('.editor').ckeditor();
        });
    </script>
    <h2>Artikel toevoegen</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Article.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Article.Name)%>
                <%= Html.ValidationMessageFor(model => model.Article.Name)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Article.CharacterizationNames) %>
            </div>
            <div class="editor-field">
                <%= Html.ListBoxFor(model => model.Article.CharacterizationNames, new MultiSelectList(Model.CharacterizationNames))%>
            </div>            

            <div class="editor-label">
                <%= Html.LabelFor(model => model.Article.Body)%>
            </div> 
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Article.Body, new { @class = "editor" })%>
            </div>
            
            <p>
                <input type="submit" value="Opslaan" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

