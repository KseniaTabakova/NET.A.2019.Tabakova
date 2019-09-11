-- Request displays the number of customer companies that are located in cities 
-- belonging to three Scandinavian countries. The resulting table should consist of two columns City and CustomerCount.

SELECT city, COUNT(*) AS nordCustomers FROM address
      WHERE country IN ('Norway', 'Sweden', 'Finland')
      GROUP BY city;
