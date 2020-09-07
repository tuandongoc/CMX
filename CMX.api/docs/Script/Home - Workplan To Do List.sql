SELECT AT.AccountID, InvoiceNumber, PA.Address1 + ' ' + PA.Address2 + ' ' + PA.Address3 AS Address, PA.Zip, AT.Description AS Workplan, ATA.Description AS Activity, ATA.PlanStartDate, ATA.PlanDueDate
FROM CWX_AccountTicket AT
INNER JOIN CWX_AccountTicketActivity ATA ON AT.TicketID = ATA.AccountTicketID
INNER JOIN Account A ON AT.AccountID = A.AccountID
INNER JOIN DebtorInformation D ON A.DebtorID = D.DebtorID
INNER JOIN PersonAddress PA ON D.PersonID = PA.PersonID AND PA.MailingAddress = 1
WHERE ATA.ActivityStatus = ? AND
	ATA.AssignTo = ?
