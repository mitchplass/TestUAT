Feature: OpenApp

Open the app

@mytag
Scenario: Successfully launch the app
	Given the app is launched
	And I press port transport
	And I enter login details with username "<username>" and password "<password>"
	Then the port transport portal should be open