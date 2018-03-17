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

----тригер, который автоматически после каждой покупки дописывает в отдельную таблицу количество потраченных денег 
---- (подсчёт суммы денег которая потрачена на покупки)
--CREATE TRIGGER InsertGodds_tg
--	ON Orders
--    FOR INSERT
--    AS
--		INSERT INTO LogHistDateOrder([DateOrder], [OrderId], [Summa]) 
--		SELECT  inserted.Date, inserted.Id, inserted.Price
--		FROM inserted


--INSERT INTO Users VALUES('Ніна Нікитюк', '1234')
--INSERT INTO Users VALUES('Tarasik@', '1234')
--INSERT INTO Users VALUES('Руслан', '1234')
--INSERT INTO Users VALUES('Сергій', '1234')
--INSERT INTO Users VALUES('TanyGmail', '1234')

--INSERT INTO Categories  VALUES('Зарплата', 1)
--INSERT INTO Categories  VALUES('Їжа', 0)
--INSERT INTO Categories  VALUES('Одяг', 0)
--INSERT INTO Categories  VALUES('Взуття', 0)
--INSERT INTO Categories  VALUES('Віддих і розваги', 0)
--INSERT INTO Categories  VALUES('Побутові техніка', 0)
--INSERT INTO Categories  VALUES('Аптека', 0)
--INSERT INTO Categories  VALUES('Товари для дома', 0)
--INSERT INTO Categories  VALUES('Прихід від бизнесy', 1)
--INSERT INTO Categories  VALUES('Процент по вкладу в банку', 1)
--INSERT INTO Categories  VALUES('Пенсия', 1)
--INSERT INTO Categories  VALUES('Стипендія', 1)
--INSERT INTO Categories  VALUES('Дохід від продажу особистих речей', 1)


	--INSERT INTO Orders VALUES (2, 1, 100, '2017-15-10', 'Хліб, цукор, масло') 
	--INSERT INTO Orders VALUES (3, 1, 250, '2017-10-12', 'Пальто') 
	--INSERT INTO Orders VALUES (7, 2, 150, '2017-03-10', 'Аспірин, Анальгін')
	--INSERT INTO Orders VALUES (1, 3, 5000, '2017-15-10', Null) 
	--INSERT INTO Orders VALUES (4, 5, 1500, '2018-18-01', 'Туфлі') 
	--INSERT INTO Orders VALUES (6, 2, 450, '2018-03-02', 'Сковорідка')
	--INSERT INTO Orders VALUES (2, 4, 200, '2018-02-02', 'Молоко, йогурт')
	--INSERT INTO Orders VALUES (1, 4, 7000, '2018-03-02', null) 
	--INSERT INTO Orders VALUES (1, 3, 10000, '2018-15-02', null)
	--INSERT INTO Orders VALUES (1, 2, 10000, '2018-20-02', null)
	--INSERT INTO Orders VALUES (5, 2, 2000, '2018-17-02', null)