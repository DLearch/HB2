--Server=tcp:dobro.database.windows.net,1433;Initial Catalog=Market;Persist Security Info=False;User ID=test@dobro;Password=!QAZ2wsx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

--Server=tcp:dobro.database.windows.net,1433;  Or -- tcp:dobro.database.windows.net,1433\sqlexpres
--Initial Catalog=Market;
--User ID=test@dobro;
--Password=!QAZ2wsx;

--Create Table HB.Categories(
--	[Id] int identity primary key not null,
--	[Name] nvarchar(50) not null,
--	[Type] bit not null
--)

--Create Table HB.Users(
--	[Id] int identity primary key not null,
--	[Name] nvarchar(50) not null,
--	[Password] nvarchar(50) not null
--)

--Create Table HB.Orders(
--	[Id] int identity primary key not null,
--	[Category_Id] int not null foreign key references HB.Categories(Id),
--	[User_Id] int not null foreign key references HB.Users(Id),
--	[Price] money not null,
--	[Date] DateTime not null,
--	[Description] nvarchar(MAX) null
--)

--Create Table HB.LogHistDateOrder(
--[Id] int identity primary key NOT NULL,
--[OrderId] int NOT NULL,
--[DateOrder] DateTime NOT NULL,
--[Summa] money NOT NULL
--)


--Create Table HB.Users(
--	[Id] int identity primary key not null,
--	[Email] nvarchar(50) not null,
--	[Name] nvarchar(50) not null,
--	[Password] nvarchar(50) not null,
--	[Family_Id] int not null foreign key references HB.FamilyMembers(Id)
--)

--Create Table HB.FamilyMembers(
--	[Id] int identity primary key not null,
--	[Name] nvarchar(50) not null
--)
 
--������, ������� ������������� ����� ������ ������� ���������� � ��������� ������� ���������� ����������� ����� 
-- (������� ����� ����� ������� ��������� �� �������)
--CREATE TRIGGER HB.InsertGodds_tg
--	ON HB.Orders
--    FOR INSERT
--    AS
--		INSERT INTO HB.LogHistDateOrder([DateOrder], [OrderId], [Summa]) 		
--		SELECT  inserted.Date, inserted.Id, inserted.Price
--		FROM inserted

--INSERT INTO HB.Users VALUES(N'nina_3@email.com', N'ͳ��ͳ�����', '1234', 1)
--INSERT INTO HB.Users VALUES(N'taras_2@email.com', N'Tarasik@', '1234', 1)
--INSERT INTO HB.Users VALUES(N'ru_23@email.com', N'������', '1234', 1)
--INSERT INTO HB.Users VALUES(N'sergiy_56@email.com', N'�����', '1234', 1)
--INSERT INTO HB.Users VALUES(N'tany_2@email.com', N'TanyGmail', '1234', 1)

--INSERT INTO HB.FamilyMembers VALUES('Family_1')
--INSERT INTO HB.FamilyMembers VALUES('Family_2')

--INSERT INTO  HB.Categories  VALUES(N'��������', 1)
--INSERT INTO  HB.Categories  VALUES(N'���', 0)
--INSERT INTO  HB.Categories  VALUES(N'����', 0)
--INSERT INTO  HB.Categories  VALUES(N'������', 0)
--INSERT INTO  HB.Categories  VALUES(N'³���� � �������', 0)
--INSERT INTO  HB.Categories  VALUES(N'������� ������', 0)
--INSERT INTO  HB.Categories  VALUES(N'������', 0)
--INSERT INTO  HB.Categories  VALUES(N'������ ��� ����', 0)
--INSERT INTO  HB.Categories  VALUES(N'������ �� ������y', 1)
--INSERT INTO  HB.Categories  VALUES(N'������� �� ������ � �����', 1)
--INSERT INTO  HB.Categories  VALUES(N'������', 1)
--INSERT INTO  HB.Categories  VALUES(N'��������', 1)
--INSERT INTO  HB.Categories  VALUES(N'����� �� ������� ��������� �����', 1)


	--INSERT INTO HB.Orders VALUES (2, 1, 100, '2017-10-10', N'���, �����, �����') 
	--INSERT INTO HB.Orders VALUES (3, 1, 250, '2017-10-12', N'������') 
	--INSERT INTO HB.Orders VALUES (7, 2, 150, '2017-03-10', N'������, �������')
	--INSERT INTO HB.Orders VALUES (1, 3, 5000, '2017-09-10', Null) 
	--INSERT INTO HB.Orders VALUES (4, 5, 1500, '2018-01-01', N'����') 
	--INSERT INTO HB.Orders VALUES (6, 2, 450, '2018-03-02', N'���������')
	--INSERT INTO HB.Orders VALUES (2, 4, 200, '2018-02-02', N'������, ������')
	--INSERT INTO HB.Orders VALUES (1, 4, 7000, '2018-03-02', null) 
	--INSERT INTO HB.Orders VALUES (1, 3, 10000, '2018-01-02', null)
	--INSERT INTO HB.Orders VALUES (1, 2, 10000, '2018-02-02', null)
	--INSERT INTO HB.Orders VALUES (5, 2, 2000, '2018-01-02', N'��������')
