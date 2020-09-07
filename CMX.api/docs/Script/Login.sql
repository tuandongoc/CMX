USE CWX_Core_Vanilla

SELECT UserID, UserName, Salt, Password, SignOn, IsLockedOut
FROM CWX_User
WHERE UserStatus = 'A' AND
	UserName = ?

