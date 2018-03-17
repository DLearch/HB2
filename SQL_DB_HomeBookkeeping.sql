Create Table Categories(
	[Id] int identity primary key not null,
	[Name] nvarchar(50) not null,
	[Type] bit not null
)

Create Table Users(
	[Id] int identity primary key not null,
	[Name] nvarchar(50) not null,
	[Password] nvarchar(50) not null
)

Create Table Orders(
	[Id] int identity primary key not null,
	[Category_Id] int not null foreign key references Categories(Id),
	[User_Id] int not null foreign key references Users(Id),
	[Price] money not null,
	[Date] DateTime not null,
	[Description] nvarchar(MAX) null
)

Create Table LogHistDateOrder(
[Id] int identity primary key NOT NULL,
[OrderId] int NOT NULL,
[DateOrder] DateTime NOT NULL,
[Summa] money NOT NULL
)

----������, ������� ������������� ����� ������ ������� ���������� � ��������� ������� ���������� ����������� ����� 
---- (������� ����� ����� ������� ��������� �� �������)
--CREATE TRIGGER InsertGodds_tg
--	ON Orders
--    FOR INSERT
--    AS
--		INSERT INTO LogHistDateOrder([DateOrder], [OrderId], [Summa]) 
--		SELECT  inserted.Date, inserted.Id, inserted.Price
--		FROM inserted


--INSERT INTO Users VALUES('ͳ�� ͳ�����', '1234')
--INSERT INTO Users VALUES('Tarasik@', '1234')
--INSERT INTO Users VALUES('������', '1234')
--INSERT INTO Users VALUES('�����', '1234')
--INSERT INTO Users VALUES('TanyGmail', '1234')

--INSERT INTO Categories  VALUES('��������', 1)
--INSERT INTO Categories  VALUES('���', 0)
--INSERT INTO Categories  VALUES('����', 0)
--INSERT INTO Categories  VALUES('������', 0)
--INSERT INTO Categories  VALUES('³���� � �������', 0)
--INSERT INTO Categories  VALUES('������� ������', 0)
--INSERT INTO Categories  VALUES('������', 0)
--INSERT INTO Categories  VALUES('������ ��� ����', 0)
--INSERT INTO Categories  VALUES('������ �� ������y', 1)
--INSERT INTO Categories  VALUES('������� �� ������ � �����', 1)
--INSERT INTO Categories  VALUES('������', 1)
--INSERT INTO Categories  VALUES('��������', 1)
--INSERT INTO Categories  VALUES('����� �� ������� ��������� �����', 1)


	--INSERT INTO Orders VALUES (2, 1, 100, '2017-15-10', '���, �����, �����') 
	--INSERT INTO Orders VALUES (3, 1, 250, '2017-10-12', '������') 
	--INSERT INTO Orders VALUES (7, 2, 150, '2017-03-10', '������, �������')
	--INSERT INTO Orders VALUES (1, 3, 5000, '2017-15-10', Null) 
	--INSERT INTO Orders VALUES (4, 5, 1500, '2018-18-01', '����') 
	--INSERT INTO Orders VALUES (6, 2, 450, '2018-03-02', '���������')
	--INSERT INTO Orders VALUES (2, 4, 200, '2018-02-02', '������, ������')
	--INSERT INTO Orders VALUES (1, 4, 7000, '2018-03-02', null) 
	--INSERT INTO Orders VALUES (1, 3, 10000, '2018-15-02', null)
	--INSERT INTO Orders VALUES (1, 2, 10000, '2018-20-02', null)
	--INSERT INTO Orders VALUES (5, 2, 2000, '2018-17-02', null)