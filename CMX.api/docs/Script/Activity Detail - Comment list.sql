SELECT TicketActivityActionID, AccountTicketID, AccountTicketActivityID, Comment
FROM CWX_AccountTicketActivityAction ATAA
WHERE AccountTicketID = ? AND
	AccountTicketActivityID = ? AND
	Action = 'Noted' AND
	Type = 'Note' 
ORDER BY ActionDate DESC