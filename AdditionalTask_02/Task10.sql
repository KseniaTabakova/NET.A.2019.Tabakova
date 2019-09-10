-- Query displays the EmployeeID of the penultimate employee hired by the company. 
-- Use the subquery to exclude the last employee hired.

SELECT employeeID FROM employees 
     WHERE employmentData = (SELECT MAX(employmentData) FROM employees WHERE employmentData < (SELECT MAX(employmentData) FROM employees));
