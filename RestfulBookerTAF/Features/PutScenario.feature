Feature: PutScenario

Scenario Outline: Update record with valid details
	Given I want to update request with the following details - '<username>'
	Then the request details should be updated
	Examples: 
	| username |
	| Admin    |

Scenario Outline: Update record with invalid details
	Given I want to update request with the following invalid details - '<username>'
	Then the booking should not be updated
	Examples: 
	| username |
	| |

