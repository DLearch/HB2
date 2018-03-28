Create schema HBTest

use Market

Create Table HBTest.Users(
	[Id] int identity primary key not null,
	[Email] nvarchar(50) not null,
	[Password] nvarchar(50) not null
)

Create Table HBTest.FamilyMembers(
	[Id] int identity primary key not null,
	[Name] nvarchar(50) not null,
	[User_Id] int not null foreign key references HBTest.Users(Id)
)

Create Table HBTest.Categories(
	[Id] int identity primary key not null,
	[Name] nvarchar(50) not null,
	[Type] bit not null,
	[User_Id] int not null foreign key references HBTest.Users(Id)
)

Create Table HBTest.Orders(
	[Id] int identity primary key not null,
	[Category_Id] int not null foreign key references HBTest.Categories(Id),
	[FamilyMember_Id] int not null foreign key references HBTest.FamilyMembers(Id),
	[Price] money not null,
	[Date] DateTime not null,
	[Description] nvarchar(MAX) null
)

INSERT INTO HBTest.Users VALUES(N'terminator@gmail.com', '3453')
INSERT INTO HBTest.Users VALUES(N'russsik@yandex.ru', '564556')
INSERT INTO HBTest.Users VALUES(N'potap@gmail.com', '111')

INSERT INTO HBTest.FamilyMembers VALUES(N'����', 1)
INSERT INTO HBTest.FamilyMembers VALUES(N'����', 1)
INSERT INTO HBTest.FamilyMembers VALUES(N'����', 2)
INSERT INTO HBTest.FamilyMembers VALUES(N'����', 3)
INSERT INTO HBTest.FamilyMembers VALUES(N'����', 1)
INSERT INTO HBTest.FamilyMembers VALUES(N'���������� ������������', 2)


INSERT INTO  HBTest.Categories  VALUES(N'��������', 1, 2)
INSERT INTO  HBTest.Categories  VALUES(N'���', 0, 3)
INSERT INTO  HBTest.Categories  VALUES(N'����', 0, 1)
INSERT INTO  HBTest.Categories  VALUES(N'������', 0, 2)
INSERT INTO  HBTest.Categories  VALUES(N'³���� � �������', 0, 2)
INSERT INTO  HBTest.Categories  VALUES(N'������� ������', 0, 2)
INSERT INTO  HBTest.Categories  VALUES(N'������', 0, 1)
INSERT INTO  HBTest.Categories  VALUES(N'������ ��� ����', 0, 1)
INSERT INTO  HBTest.Categories  VALUES(N'������ �� ������y', 1, 2)
INSERT INTO  HBTest.Categories  VALUES(N'������� �� ������ � �����', 1, 3)
INSERT INTO  HBTest.Categories  VALUES(N'������', 1, 3)
INSERT INTO  HBTest.Categories  VALUES(N'��������', 1, 3)
INSERT INTO  HBTest.Categories  VALUES(N'����� �� ������� ��������� �����', 1, 1)


INSERT INTO HBTest.Orders VALUES (2, 1, 100, '2017-10-10', N'���, �����, �����') 
INSERT INTO HBTest.Orders VALUES (3, 1, 250, '2017-10-12', N'������') 
INSERT INTO HBTest.Orders VALUES (7, 2, 150, '2017-03-10', N'������, �������')
INSERT INTO HBTest.Orders VALUES (1, 3, 5000, '2017-09-10', Null) 
INSERT INTO HBTest.Orders VALUES (4, 5, 1500, '2018-01-01', N'����') 
INSERT INTO HBTest.Orders VALUES (6, 2, 450, '2018-03-02', N'���������')
INSERT INTO HBTest.Orders VALUES (2, 4, 200, '2018-02-02', N'������, ������')
INSERT INTO HBTest.Orders VALUES (1, 6, 7000, '2018-03-02', null) 
INSERT INTO HBTest.Orders VALUES (1, 3, 10000, '2018-01-02', null)
INSERT INTO HBTest.Orders VALUES (1, 6, 10000, '2018-02-02', null)
INSERT INTO HBTest.Orders VALUES (5, 2, 2000, '2018-01-02', null)