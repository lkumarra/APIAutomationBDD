Feature: DeleteEmployee
	As a valid user
	I am able to delete employee

@deleteEmployee
Scenario: Delete Employee
	Given User have as valid endpoint as "https://dummy.restapiexample.com/public/api/v1/delete/2"
	When User send the delete request
	Then User get 200 as status code
	Then User get status as "success"
	And User get message as "successfully! deleted Records"