select * From employee;

Alter Table employee
Add  man_id int

UPDATE employee
SET man_id = CASE emp_ID
    WHEN 101 THEN NULL  -- Mohan: top-level manager
    WHEN 102 THEN 101
    WHEN 103 THEN 101
    WHEN 104 THEN 101
    WHEN 105 THEN 102
    WHEN 106 THEN 104
    WHEN 107 THEN 102
    WHEN 108 THEN 101
    WHEN 109 THEN 103
    WHEN 110 THEN 103
    WHEN 111 THEN 110
    WHEN 112 THEN 111
    WHEN 113 THEN 101
    WHEN 114 THEN 102
    WHEN 115 THEN 103
    WHEN 116 THEN 104
    WHEN 117 THEN 102
    WHEN 118 THEN 104
    WHEN 119 THEN 102
    WHEN 120 THEN 101
    WHEN 121 THEN 103
    WHEN 122 THEN 110
    WHEN 123 THEN 110
    WHEN 124 THEN 112
END;

Select DEPT_NAME , Count(*) As Count
from employee
group by DEPT_NAME
Having COUNT(DEPT_NAME) > 3

Select e.*
from employee e
Where DEPT_NAME = 'IT'
Order by SALARY asc;

Select DEPT_NAME, COUNT(DEPT_NAME) As EmployeeCount
From employee
Group By DEPT_NAME


Select MAX(SALARY) 
From employee

Select MAX(SALARY) As SeconMaxSalary 
From employee
Where SALARY < (Select MAX(SALARY) From employee)

Select *
From employee
Where SALARY < (Select Avg(SALARY) From employee)

Select MAX(SALARY) As SeconMaxSalary 
From employee
Where SALARY < (Select MAX(Distinct SALARY) From employee)


Select e.emp_NAME , e.SALARY, m.emp_NAME As Manager, m.SALARY
From employee e Join employee m 
On e.man_id = m.emp_ID
Where e.SALARY > m.SALARY

SELECT
    emp_NAME,
    SALARY,
    CASE
        WHEN SALARY >= 8000 THEN 'High'
        WHEN SALARY >= 4000 THEN 'Medium'
        ELSE 'Low'
    END AS SalaryCategory
FROM employee;


Select *,
Max(SALARY) Over() As MaxSalary 
From employee  

Select *,
Avg(Salary) Over(Partition By DEPT_Name) As Dep_Avg,
Max(SALARY) Over(PARTITION By man_id) As MaxSalary
From employee


Select * From
    (
    Select *,
    Max(SALARY) Over(PARTITION By man_id) As MaxSalary
    From employee e
    ) As MaxSalaryUnderManager
Where MaxSalaryUnderManager.MaxSalary = MaxSalaryUnderManager.SALARY



Select AVG(SALARY)
From employee

Select *
From Employee
Where SALARY > (Select AVG(SALARY) From Employee)

Select *
From (   Select *,
        Avg(SALARY) Over() As AvgSalary
        From employee
    ) As TableWithAvgSalary
Where TableWithAvgSalary.SALARY > TableWithAvgSalary.AvgSalary


With TableWithAverage as  
(
    Select 
        Avg(SALARY) As AvgSalary
        From employee
)
Select * From  employee, TableWithAverage
Where employee.SALARY > TableWithAverage.AvgSalary


With TableWithAverage as  
(
    Select *,
        Avg(SALARY) Over() As AvgSalary
        From employee
)
Select *
From TableWithAverage
Where TableWithAverage.SALARY > TableWithAverage.AvgSalary


Select *,
ROW_NUMBER() Over(order By salary) As RankInEachGroup
From employee


With RankInDeptOnSalary as
(
    Select *,
    ROW_NUMBER() Over(partition by DEPT_name order By salary) As RankInEachGroup
    From employee
)
Select *
From RankInDeptOnSalary
Where RankInEachGroup =1


Select *
From
(
    Select *,
    ROW_NUMBER() Over(partition by DEPT_name order By salary) As RankInEachGroup
    From employee
) AS WithRankTable
Where WithRankTable.RankInEachGroup > 3


--drop table employee;
create table employee
( emp_ID int
, emp_NAME varchar(50)
, DEPT_NAME varchar(50)
, SALARY int);

insert into employee values(101, 'Mohan', 'Admin', 4000);
insert into employee values(102, 'Rajkumar', 'HR', 3000);
insert into employee values(103, 'Akbar', 'IT', 4000);
insert into employee values(104, 'Dorvin', 'Finance', 6500);
insert into employee values(105, 'Rohit', 'HR', 3000);
insert into employee values(106, 'Rajesh',  'Finance', 5000);
insert into employee values(107, 'Preet', 'HR', 7000);
insert into employee values(108, 'Maryam', 'Admin', 4000);
insert into employee values(109, 'Sanjay', 'IT', 6500);
insert into employee values(110, 'Vasudha', 'IT', 7000);
insert into employee values(111, 'Melinda', 'IT', 8000);
insert into employee values(112, 'Komal', 'IT', 10000);
insert into employee values(113, 'Gautham', 'Admin', 2000);
insert into employee values(114, 'Manisha', 'HR', 3000);
insert into employee values(115, 'Chandni', 'IT', 4500);
insert into employee values(116, 'Satya', 'Finance', 6500);
insert into employee values(117, 'Adarsh', 'HR', 3500);
insert into employee values(118, 'Tejaswi', 'Finance', 5500);
insert into employee values(119, 'Cory', 'HR', 8000);
insert into employee values(120, 'Monica', 'Admin', 5000);
insert into employee values(121, 'Rosalin', 'IT', 6000);
insert into employee values(122, 'Ibrahim', 'IT', 8000);
insert into employee values(123, 'Vikram', 'IT', 8000);
insert into employee values(124, 'Dheeraj', 'IT', 11000);
COMMIT;




/* **************
   Video Summary
 ************** */

select * from employee;

-- Using Aggregate function as Window Function
-- Without window function, SQL will reduce the no of records.
select dept_name, max(salary) from employee
group by dept_name;

-- By using MAX as an window function, SQL will not reduce records but the result will be shown corresponding to each record.
select e.*,
max(salary) over(partition by dept_name) as max_salary
from employee e;


-- row_number(), rank() and dense_rank()
select e.*,
row_number() over(partition by dept_name) as rn
from employee e;


-- Fetch the first 2 employees from each department to join the company.
select * from (
	select e.*,
	row_number() over(partition by dept_name order by emp_id) as rn
	from employee e) x
where x.rn < 3;


-- Fetch the top 3 employees in each department earning the max salary.
select * from (
	select e.*,
	rank() over(partition by dept_name order by salary desc) as rnk
	from employee e) x
where x.rnk < 4;


-- Checking the different between rank, dense_rnk and row_number window functions:
select e.*,
rank() over(partition by dept_name order by salary desc) as rnk,
dense_rank() over(partition by dept_name order by salary desc) as dense_rnk,
row_number() over(partition by dept_name order by salary desc) as rn
from employee e;



-- lead and lag

-- fetch a query to display if the salary of an employee is higher, lower or equal to the previous employee.
select e.*,
lag(salary) over(partition by dept_name order by emp_id) as prev_empl_sal,
case when e.salary > lag(salary) over(partition by dept_name order by emp_id) then 'Higher than previous employee'
     when e.salary < lag(salary) over(partition by dept_name order by emp_id) then 'Lower than previous employee'
	 when e.salary = lag(salary) over(partition by dept_name order by emp_id) then 'Same than previous employee' end as sal_range
from employee e;

-- Similarly using lead function to see how it is different from lag.
select e.*,
lag(salary) over(partition by dept_name order by emp_id) as prev_empl_sal,
lead(salary) over(partition by dept_name order by emp_id) as next_empl_sal
from employee e;
