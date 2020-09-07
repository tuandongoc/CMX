USE CWorks_Vanilla

SELECT AccountID, InvoiceNumber, PA.Address1 + ' ' + PA.Address2 + ' ' + PA.Address3 AS Address, PA.Zip, A.BillAmount, A.BillBalance, A.AccountAge, LastAllocationDate, ActionEmployee
FROM Account A 
INNER JOIN DebtorInformation D ON A.DebtorID = D.DebtorID
INNER JOIN PersonAddress PA ON D.PersonID = PA.PersonID AND PA.MailingAddress = 1
WHERE A.EmployeeID = ?
