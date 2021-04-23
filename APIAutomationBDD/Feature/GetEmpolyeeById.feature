Feature: GetEmpolyeeById
	As a valid user
	I want to get the detail of employee by Id.

@getEmployeeById
Scenario: Get the details of employee by Id
	Given User have the baseUri with id as "http://dummy.restapiexample.com/api/v1/employee/12"
	When User send the get request
	Then User get the Employee details with status code as 200
	| id | employee_name       | employee_salary | employee_age | profile_image |
	| 12 | Quinn Flynn         | 342000          | 22           |               |