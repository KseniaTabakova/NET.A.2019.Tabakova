-- Request displays the number of customer companies in countries in which there are 2 or more customers. 
-- The resulting table should have the Country and bigCustomer columns, the rows of which 
-- should be sorted in reverse order by the number of customers in the country.

SELECT country, COUNT(*) AS bigCustomers FROM address
      GROUP BY country
      HAVING bigCustomers >= 2
      ORDER BY bigCustomers DESC;
