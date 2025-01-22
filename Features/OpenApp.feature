Feature: OpenApp

Open the app

@mytag
Scenario: Successfully launch the app
	Given the app is launched
	Then the port transport portal should be open