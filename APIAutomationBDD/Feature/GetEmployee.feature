Feature: GetEmployee
	As a valid user
	I want to get the list of all employee

@getEmployee
Scenario: Get Employee List
	Given User have the baseuri as "http://dummy.restapiexample.com/api/v1/employees"
	When User send a get request
	Then Empolyee list should be returned with status code 200
	| id | employee_name       | employee_salary | employee_age | profile_image |
	| 1  | Tiger Nixon         | 320800          | 61           |               |
	| 2  | Garrett Winters     | 170750          | 63           |               |
	| 3  | Ashton Cox          | 86000           | 66           |               |
	| 4  | Cedric Kelly        | 433060          | 22           |               |
	| 5  | Airi Satou          | 162700          | 33           |               |
	| 6  | Brielle Williamson  | 372000          | 61           |               |
	| 7  | Herrod Chandler     | 137500          | 59           |               |
	| 8  | Rhona Davidson      | 327900          | 55           |               |
	| 9  | Colleen Hurst       | 205500          | 39           |               |
	| 10 | Sonya Frost         | 103600          | 23           |               |
	| 11 | Jena Gaines         | 90560           | 30           |               |
	| 12 | Quinn Flynn         | 342000          | 22           |               |
	| 13 | Charde Marshall     | 470600          | 36           |               |
	| 14 | Haley Kennedy       | 313500          | 43           |               |
	| 15 | Tatyana Fitzpatrick | 385750          | 19           |               |
	| 16 | Michael Silva       | 198500          | 66           |               |
	| 17 | Paul Byrd           | 725000          | 64           |               |
	| 18 | Gloria Little       | 237500          | 59           |               |
	| 19 | Bradley Greer       | 132000          | 41           |               |
	| 20 | Dai Rios            | 217500          | 35           |               |
	| 21 | Jenette Caldwell    | 345000          | 30           |               |
	| 22 | Yuri Berry          | 675000          | 40           |               |
	| 23 | Caesar Vance        | 106450          | 21           |               |
	| 24 | Doris Wilder        | 85600           | 23           |               |
	
	
	
	
	