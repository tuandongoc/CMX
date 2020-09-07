SELECT ActionID, Description, NextActionId, CallResultId, QueueDays
FROM AvailableActions
WHERE Status = 'A' AND
	IncludeOnReport = 1