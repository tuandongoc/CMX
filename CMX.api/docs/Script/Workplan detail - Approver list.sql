SELECT TAP.TicketApprovalID, APP.EmployeeName AS Approver, TAP.ApproverLevel, TAP.ApprovalStatus, TAP.ActionedDate, ActionedBy
FROM CWX_AccountTicket AT
INNER JOIN CWX_TicketApproval TAP ON AT.TicketID = TAP.TicketApprovalRefID AND TAP.Location = 'TICKET'
LEFT JOIN Employee APP ON TAP.ApproverID = APP.EmployeeID
LEFT JOIN Employee ACT ON TAP.ActionedBy = ACT.EmployeeID
WHERE AT.TicketID = ?