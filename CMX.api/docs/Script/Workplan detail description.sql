SELECT AT.TicketID, AT.Description AS Workplan, TA.EmployeeName AS Assignee, TC.EmployeeName AS Creator, AT.CreatedDate, AT.DueDate, AT.TicketStatus, TU.EmployeeName AS UpdatedBy, AT.UpdatedDate
FROM CWX_AccountTicket AT
INNER JOIN Account A ON AT.AccountID = A.AccountID
LEFT JOIN Employee TA ON AT.AssignTo = TA.EmployeeID
LEFT JOIN Employee TC ON AT.CreatedBy = TC.EmployeeID
LEFT JOIN Employee TU ON AT.UpdatedBy = TU.EmployeeID
WHERE AT.TicketID = ?