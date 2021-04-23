Feature: CreateEmployee
	As a valid user
	I am able to add an employee

@mytag
Scenario Outline: Add two numbers
	Given User have a valid uri as "https://dummy.restapiexample.com/api/v1/create"
	When User send the post request with "<name>", "<salary>" and "<age>".
	Then User get the status code as 200
	And User get the name as "<name>"
	And User get the salary as "<salary>"
	And User get the age as "<age>"

Examples: 
| name                  | salary | age |
| Lavendra Kumar Rajput | 2000   | 24  |