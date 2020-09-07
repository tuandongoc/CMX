SELECT TicketActivityActionID, AccountTicketID, Comment
FROM CWX_AccountTicketActivityAction ATAA
WHERE AccountTicketID = ? AND
	Action = 'Noted' AND
	Type = 'Note' 
ORDER BY ActionDate DESC