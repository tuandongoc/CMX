SELECT CodeID, CodeDesc
FROM AccountCodeMaster
WHERE Status = 'A' AND
	CodeType = ?