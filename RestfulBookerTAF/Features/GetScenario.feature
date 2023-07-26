Feature: GetScenario

Scenario: Send a valid response and got 200 OK response
	Given I send a new request with the valid details:
	| UserName       | FailCount | FetchLimit |
	| John           | 123		 | 123        |
	Then OK response is returned

Scenario Outline: Send an invalid response and got 400 response
	Given I send a new request with the invalid details - '<UserName>', '<FailCount>', '<FetchLimit>'
	Then 400 response is returned

	Examples: 
	| UserName       | FailCount			| FetchLimit		  |
	| John           | 9223372036854775807	| 9223372036854775807 |
	|		         | 23					| 9223372036854775807 |
	|		         | 9223372036854775807	| 23				  |
