SELECT RT.ID AS RuleID, RT.Description AS RuleName, RT.Category, RO.OptionType, RO.Value, RO.Value2, RO.Value3, RO.Value4, RO.Value5
FROM RuleTable RT
LEFT JOIN RuleOthers RO ON RT.ID = RO.RuleID 
WHERE RuleType = 3 AND
	Status = 'A' 