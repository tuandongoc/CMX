SELECT NoteID, E.EmployeeName, DebtorID, BillID, NoteDateTime, NoteType, NoteText, NotePriority
FROM NotesCurrent NC
LEFT JOIN Employee E ON NC.EmployeeID = E.EmployeeID
WHERE (NC.BillID = ? OR DebtorID = ?) AND
	NoteType = ? 
ORDER BY NoteDateTime DESC



235	CWX Manager	12986	85865	2015-05-15 17:20:06.990	A	Group account was created for account/s C000000000056943(primary)	0