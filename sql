-- 1
SELECT p.firstName, p.lastName, a.city, a.state
FROM Person as p
LEFT OUTER JOIN Address as a on a.personId = p.personId    
-- 2
SELECT name, population, area from World
WHERE World.area >= 3000000 or 
World.population >= 25000000
-- 3
SELECT email
FROM Person
GROUP BY email
HAVING COUNT(*) > 1;
-- 4
WITH base AS(
  SELECT Customers.name, Orders.customerId
  FROM Customers
  LEFT OUTER JOIN Orders ON Orders.customerId = Customers.id
)
SELECT base.name AS Customers
FROM base
WHERE customerId IS NULL;
-- 5
WITH base AS(
    SELECT e.name, e.salary, f.salary as managerSalary
    FROM Employee as e
    LEFT OUTER JOIN Employee f on e.managerId = f.id
)
SELECT name AS Employee FROM  base 
-- 6
WHERE base.salary > base.managerSalary
with cte as (
    select num,
    lead(num,1) over() num1,
    lead(num,2) over() num2
    from logs

)
select distinct num ConsecutiveNums from cte where (num=num1) and (num=num2)
-- 7
WITH base AS (
  SELECT e.id, e.name, e.salary, d.name AS Department 
  FROM Employee AS e
  LEFT OUTER JOIN Department AS d ON e.departmentId = d.id
)

SELECT Department, name as Employee,
       Salary
FROM base
WHERE salary IN (
  SELECT DISTINCT MAX(salary)
  FROM base AS inner_base
  GROUP BY Department
);
