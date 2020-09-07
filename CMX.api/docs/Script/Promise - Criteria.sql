SELECT AccountID, BillBalance, [dbo].[CWX_Get_SystemWideDefault](AccountID,5) AS MinPromiseAmount, [dbo].[CWX_Get_SystemWideDefault](AccountID,6) AS MinPromisePercent, BillBalance * [dbo].[CWX_Get_SystemWideDefault](AccountID,6) / 100 AS MinPromiseAmountPercent, 
	DATEADD(DAY,CAST([dbo].[CWX_Get_SystemWideDefault](AccountID,10) AS int),GETDATE()) AS MaxPromiseDate
FROM Account
WHERE AccountID = ?
