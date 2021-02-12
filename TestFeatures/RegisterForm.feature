Feature: RegisterForm
	As a new user, I would like to register an account. calculator for adding two numbers

@scopedBidings
Scenario: Open AuthSystem on Register page and register user
	Given Open AuthSystem in browser
	And fill up the form using the data <name> <lastname> <email> <password> with <confirmPassword>
	When Click Register button
	Then check if the home page is displayed

	Examples:
		| name       | lastname | email                | password    | confirmPassword |
		| MaciejTest | Testing  | test@testexample.com | Start@12345 | Start@12345     |

@scopedBidings
Scenario: Open AuthSystem on Register page and register user with invalid email
	Given Open AuthSystem in browser
	And fill up the form using the data <name> <lastname> <email> <password> with <confirmPassword>
	When Click Register button
	Then check if error message is displayed

	Examples:
		| name       | lastname | email     | password    | confirmPassword |
		| MaciejTest | Testing  | test12345 | Start@12345 | Start@12345     |

@scopedBidings
Scenario: Open AuthSystem on Register page and register user with incorrect password
	Given Open AuthSystem in browser
	And fill up the form using the data <name> <lastname> <email> <password> with <confirmPassword>
	When Click Register button
	Then check if error message is displayed

	Examples:
		| name        | lastname | email                 | password | confirmPassword |
		| MaciejTest2 | Testing2 | test2@testexample.com | 1234     | 1234            |

@scopedBidings
Scenario: Open AuthSystem on Register page and register user with not matched passwords
	Given Open AuthSystem in browser
	And fill up the form using the data <name> <lastname> <email> <password> with <confirmPassword>
	When Click Register button
	Then check if error message is displayed

	Examples:
		| name        | lastname | email                 | password    | confirmPassword |
		| MaciejTest2 | Testing2 | test2@testexample.com | Start@12345 | Start!09876     |

@scopedBidings
Scenario: Open AuthSystem on Register page and register user without First Name or Last Name
	Given Open AuthSystem in browser
	And fill up the form using the data <name> <lastname> <email> <password> with <confirmPassword>
	When Click Register button
	Then check if error message is displayed

	Examples:
		| name    | lastname | email                 | password    | confirmPassword |
		|         | Testing3 | test2@testexample.com | Start@12345 | Start@12345     |
		| Maciej3 |          | test2@testexample.com | Start@12345 | Start@12345     |