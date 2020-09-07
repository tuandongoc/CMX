USE CWorks_Vanilla

SELECT AccountID, InvoiceNumber, C.ClientName AS Product, PA.Address1 + ' ' + PA.Address2 + ' ' + PA.Address3 AS Address, PA.Zip, S.LongDesc AS Status, A.BillAmount, A.BillBalance, A.AccountAge, A.MCode, A.CCode, A.QueueDate, LastAllocationDate, ActionEmployee, BRANCH_CODE, AssignmentStartDate, AssignmentEndDate, AssignmentSegment
FROM Account A 
INNER JOIN DebtorInformation D ON A.DebtorID = D.DebtorID
INNER JOIN PersonAddress PA ON D.PersonID = PA.PersonID AND PA.MailingAddress = 1
LEFT JOIN ClientInformation C ON A.ClientID =  C.ClientID
LEFT JOIN AccountStatus S ON A.AgencyStatusID = S.AgencyStatus
WHERE A.AccountID = ? 
