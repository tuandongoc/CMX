SELECT UserID, UserName, Salt, Password
FROM CWX_User
WHERE UserStatus = 'A' AND
	Email = ?