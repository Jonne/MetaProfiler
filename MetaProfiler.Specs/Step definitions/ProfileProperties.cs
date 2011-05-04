using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using MetaProfiler.Specs.Logic.PageObjects;
using MetaProfiler.Specs.Logic;
using FluentAssertions;
using MongoDB;

namespace MetaProfiler.Specs.Step_definitions
{
    [Binding]
    public class ProfileProperties
    {
        private EditProfilePropertyPage editProfilePropertyPage;
        private ProfilePropertiesPage profilePropertiesPage;

        [Given("I have no profile properties")]
        public void GivenIHaveNoProfileProperties()
        {
            using (var mongo = new Mongo())
            {
                mongo.Connect();

                IMongoDatabase db = mongo.GetDatabase("MetaProfiler");

                IMongoCollection mongoCollection = db.GetCollection("ProfileProperties");

                mongoCollection.Remove(new Document());

                mongo.Disconnect();
            }
        }

        [Given("I am on the add profile property page")]
        public void GivenIAmOnTheAddProfilePropertyPage()
        {
            editProfilePropertyPage = new EditProfilePropertyPage(WebBrowser.Current);
            editProfilePropertyPage.Visit();
        }

        [When("I add a new profile property with name \"(.*)\" and type \"(.*)\"")]
        public void WhenIAddANewProfileProperty(string name, string type)
        {
            editProfilePropertyPage.Name = name;
            editProfilePropertyPage.Type = type;
            editProfilePropertyPage.Save();
        }

        [Then("I should be redirected to the profile property overview page")]
        public void ThenIShouldBeRedirectedToTheProfilePropertyOverviewPage()
        {
            profilePropertiesPage = new ProfilePropertiesPage(WebBrowser.Current);
            profilePropertiesPage.IsCurrent.Should().BeTrue();
        }

        [Then("it should display a property with name \"(.*)\" and type \"(.*)\"")]
        public void ThenThePropertyShouldBeDisplayedOnThePropertiesPage(string name, string type)
        {
            profilePropertiesPage.NumberOfProperties.Should().Be(1);
            profilePropertiesPage.NameFor(1).Should().Be(name);
            profilePropertiesPage.TypeFor(1).Should().Be(type);
        }
    }
}
