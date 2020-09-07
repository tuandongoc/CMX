UPDATE Account
SET QueueDate = ?,
	CurrentAction = ?,
	CurrentActionDate = GETDATE(),
	CurrentNextAction = ?,
	CurrentNextActionDate = GETDATE(),
	AgencyStatusID = ?,
	SystemStatusID = ?,
	ActionEmployee = ?
WHERE AccountID = ?