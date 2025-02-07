﻿Feature: OpenApp

Open the app

@mytag
Scenario: Successfully launch the app
	Given the app is launched using "<version>"
	And I press port transport
	And I enter login details with username "--" and password "--"
	And I select account "Demo.User.1"
	Then the port transport portal should be open

Examples:
	| version  |
	#| Android8 |
	| Android10 |
	| Android11 |