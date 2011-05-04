Feature: Define profile properties
	In order to define profiles
	As a profile designer
	I want to specify what properties should be provided

Scenario: Add property
	Given I have no profile properties
	And I am on the add profile property page
	When I add a new profile property with name "BMI Index" and type "Number"
	Then I should be redirected to the profile property overview page
	And it should display a property with name "BMI Index" and type "Number" 
