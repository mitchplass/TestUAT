Feature: OpenApp

Open the app

@mytag
Scenario: Successfully launch the app
	Given the app is launched
	Then the app should be open
