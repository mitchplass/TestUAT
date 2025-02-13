Feature: OpenPortTransport

Open the app

Scenario: Successfully launch the app
	Given the app is launched using "<version>"
	And I press port transport
	Then the port transport portal should be open

Examples:
	| version  |
	#| Android8 |
	| Android10 |
	| Android11 |