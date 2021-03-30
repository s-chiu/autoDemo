Feature: GoogleTest
	Simple search and verify there are search results

@test1
Scenario: Search with Results
	Given the user is on the google page
	When the user googles the term "watermelon"
	Then google search results are displayed

@test2 
Scenario: Search without Results
	Given the user is on the google page
	When the user googles the term "a43ra4t4a4"
	Then no google search results are displayed