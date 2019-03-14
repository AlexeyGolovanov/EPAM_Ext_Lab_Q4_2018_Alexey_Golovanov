--passwords 'Pass1' 'Pass2' 'Pass3'
INSERT [dbo].[Users] ([UserId], [Username], [Role],[Password],[Email],[RegDate],[Country],[Gender],[FirstName],[LastName],[BirthDate]) 
		VALUES (N'1',N'TestUser',N'1',N'AL3vy50dYT5eYwfsjRX642cTFhoyp8HqlWhkDo6sb3o7+ikf5k1Uji5u5DqCRJaffA==',N'email@1.com','2018-20-05',N'1',N'Male',N'FNTest1',N'LNTest1','1980-01-01')
INSERT [dbo].[Users] ([UserId],[Username], [Role],[Password],[Email],[RegDate],[Country],[Gender],[FirstName],[LastName],[BirthDate]) 
		VALUES (N'2',N'TestModer',N'2',N'ALxV2/mI40r0DcLz9cKzqfe+q93iByJKgziJLwf9txmqihrioKwW0t0KKZvK+sQpZw==',N'email@2.com','2018-21-06',N'2',N'Male',N'FNTest2',N'LNTest2','1980-02-02')
INSERT [dbo].[Users] ([UserId],[Username], [Role],[Password],[Email],[RegDate],[Country],[Gender],[FirstName],[LastName],[BirthDate]) 
		VALUES (N'3',N'TestAdmin',N'3',N'AK3v+8D1Mvn9z6SfIOgYoDfPB00JfS+DA6/GsPmNnXs9tV6Jz7wE4ZU1twJbLlYQgg==',N'email@3.com','2018-22-07',N'3',N'Female',N'FNTest3',N'LNTest3','1980-03-03')