UPDATE ATA
SET ATA.ActivityStatus = ?,
	ATA.StartDate = ?,
	ATA.DueDate = ?,
	ATA.UpdatedBy = ?,
	ATA.UpdatedDate = ?,
	ATA.CompletedBy = ?,
	ATA.CompletedDate = ?
FROM CWX_AccountTicketActivity ATA
WHERE ATA.AccountTicketID = ?