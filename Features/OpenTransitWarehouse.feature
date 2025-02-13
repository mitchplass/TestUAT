Feature: OpenTransitWarehouse

Open the app

Scenario: Successfully launch the app
	Given the app is launched using "<version>"
	And I press transit warehouse
	Then the transit warehouse portal should be open

Examples:
	| version  |
	#| Android8 |
	| Android10 |
	| Android11 |