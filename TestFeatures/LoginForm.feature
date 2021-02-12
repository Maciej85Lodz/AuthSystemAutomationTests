Feature: LoginForm
	As a user, I would like to log in to my account with my email and password.

@scopedBidings
Scenario: Open AuthSystem on Login page and Login user
	Given Open AuthSystem in browser
	And fill up the login form with data <email> <password>
	When click login button
	Then check if the home page is displayed

	Examples:
		| email                | password    |
		| test@testexample.com | Start@12345 |

@scopedBidings
Scenario: Open AuthSystem on Login page and Login user without password or email
	Given Open AuthSystem in browser
	And fill up the login form with data <email> <password>
	When click login button
	Then check if the error field message is displayed

	Examples:
		| email                | password    |
		| test@testexample.com |             |
		|                      | Start@12345 |

@scopedBidings
Scenario: Open AuthSystem on Login page and Login user with nor registered user
	Given Open AuthSystem in browser
	And fill up the login form with data <email> <password>
	When click login button
	Then check if the error message is displayed

	Examples:
		| email                       | password    |
		| notregister@testexample.com | not@!123435 |

