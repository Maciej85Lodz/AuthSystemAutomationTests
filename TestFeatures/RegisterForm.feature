Feature: RegisterForm
	As a new user, I would like to register an account. calculator for adding two numbers

@scopedBidings
Scenario: Open AuthSystem on Register page and register user
	Given Open AuthSystem in browser
	And fill up the form using the data <name> <lastname> <email> and <password>
	When Click Register button
	Then check if message about correct registration is displayed.
	
	Examples: 
	| name       | lastname | email                | password    |
	| MaciejTest | Testing  | test@testexample.com | Start@12345 |