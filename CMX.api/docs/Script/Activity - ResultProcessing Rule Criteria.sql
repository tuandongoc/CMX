SELECT RT.ID AS RuleID, RT.Description AS RuleName, RT.Category, RC.Criteria, RC.Operator, RC.Combining, RC.MatchingCriteria, RC.MatchingCriteria2, RC.SQLFormat, RC.OrderNumber
FROM RuleTable RT
LEFT JOIN RuleCriteria RC ON RT.ID = RC.RuleID 
WHERE RuleType = 3 AND
	Status = 'A' 