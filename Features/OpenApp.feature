Feature: OpenApp

Open the app

@mytag
Scenario: Successfully launch the app
	Given the app is launched
	And I press port transport
	And I enter login details with username "mitchell.plass@wisetechglobal.com" and password "M1tchW1se.2911!"
	And I select account "Demo.User.1"
	Then the port transport portal should be open