﻿INSERT [dbo].[Users] ([UserId], [Username], [Role],[Password],[Email],[RegDate],[Country],[Gender],[FirstName],[LastName],[BirthDate]) 
		VALUES (N'1',N'TestUser',N'1',N'Pass1',N'email@1.com','2018-20-05',N'1',N'Male',N'FNTest1',N'LNTest1','1980-01-01')
INSERT [dbo].[Users] ([UserId],[Username], [Role],[Password],[Email],[RegDate],[Country],[Gender],[FirstName],[LastName],[BirthDate]) 
		VALUES (N'2',N'TestModer',N'2',N'Pass2',N'email@2.com','2018-21-06',N'2',N'Male',N'FNTest2',N'LNTest2','1980-02-02')
INSERT [dbo].[Users] ([UserId],[Username], [Role],[Password],[Email],[RegDate],[Country],[Gender],[FirstName],[LastName],[BirthDate]) 
		VALUES (N'3',N'TestAdmin',N'3',N'Pass3',N'email@3.com','2018-22-07',N'3',N'Female',N'FNTest3',N'LNTest3','1980-03-03')