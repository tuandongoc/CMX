SELECT AccountTicketActivityID, ATA.Description ActivityName, PlanStartDate, StartDate, PlanDueDate, DueDate, ActivityStatus, EA.EmployeeName AS Assignee, EA.EmployeeName AS Creator, ATA.CreatedDate, EU.EmployeeName AS UpdatedBy, ATA.UpdatedDate
FROM CWX_AccountTicketActivity ATA 
LEFT JOIN Employee EA ON ATA.AssignTo = EA.EmployeeID
LEFT JOIN Employee EC ON ATA.CreatedBy = EC.EmployeeID
LEFT JOIN Employee EU ON ATA.UpdatedBy = EU.EmployeeID
WHERE ATA.AccountTicketActivityID = ?