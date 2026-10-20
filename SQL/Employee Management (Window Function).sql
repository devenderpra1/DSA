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
Where 


Select *
From
(
    Select *,
    ROW_NUMBER() Over(partition by DEPT_name order By salary) As RankInEachGroup
    From employee
) AS WithRankTable
Where WithRankTable.RankInEachGroup > 3