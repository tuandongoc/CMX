SELECT ATA.TicketActivityID, ATA.Description, ATA.ActivityStatus, TA.EmployeeName AS Assignee, PlanStartDate, PlanDueDate, StartDate, ATA.DueDate
FROM CWX_AccountTicket AT
INNER JOIN CWX_AccountTicketActivity ATA ON AT.TicketID = ATA.AccountTicketID
LEFT JOIN Employee TA ON ATA.AssignTo = TA.EmployeeID
WHERE AT.TicketID = ?