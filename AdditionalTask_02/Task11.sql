-- Query displays the EmployeeID of the penultimate employee hired by the company. 
-- Use the keywords OFFSET and FETCH.

SELECT employeeID FROM employees 
     ORDER BY employmentData DESC
     LIMIT 1
     OFFSET 1;
