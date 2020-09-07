SELECT AT.TicketID, AT.Description AS Workplan, TC.EmployeeName, AT.CreatedDate, AT.DueDate, AT.TicketStatus, TU.EmployeeName, AT.UpdatedDate
FROM CWX_AccountTicket AT
INNER JOIN CWX_AccountTicketActivity ATA ON AT.TicketID = ATA.AccountTicketID
INNER JOIN Account A ON AT.AccountID = A.AccountID
LEFT JOIN Employee TC ON AT.CreatedBy = TC.EmployeeID
LEFT JOIN Employee TU ON AT.UpdatedBy = TU.EmployeeID
WHERE AT.AccountID = ?
