USE sales;
GO -- (For SQL Server)
Select * 
From sales

Select store_name , Sum(cost)
From sales
Group by store_name


Select store_name, AVG(cost)
From sales
Group by store_name


Select SUM(cost), COUNT(store_id)
From sales
Where store_name = 'Apple Originals 1'

Select *
From 
	(	Select store_id,  
		Avg(cost) over() as AverageSale ,
		Sum(cost) over(Partition by store_name) as TotalSale 
		From sales
	) AvgTotalSumStoreName
Where AvgTotalSumStoreName.AverageSale

With AvgTotalSumStoreName as
(
	Select store_id,  
			Avg(cost) over() as AverageSale ,
			Sum(cost) over(Partition by store_name) as TotalSale 
			From sales
)
Select store_id
From AvgTotalSumStoreName
Where TotalSale > AverageSale


with avgCostTotal as
	(
	Select AVG(cost) as avgCost
		From sales
	),
	totalSaleStore as (select store_name, SUM(cost) as individual From sales Group by store_name)
Select store_name
From avgCostTotal,totalSaleStore
Where avgCost < totalSaleStore.individual


Select *
From
(
	Select AVG(cost) as avgCost
		From sales
)



Select SUM(cost)
From sales,AvgCost
Group by store_id
Having SUM(cost)> avgCost