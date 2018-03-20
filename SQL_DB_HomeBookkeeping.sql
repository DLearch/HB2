--Server=tcp:dobro.database.windows.net,1433;Initial Catalog=Market;Persist Security Info=False;User ID=test@dobro;Password=!QAZ2wsx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

--Server=tcp:dobro.database.windows.net,1433;  Or -- tcp:dobro.database.windows.net,1433\sqlexpres
--Initial Catalog=Market;
--User ID=test@dobro;
--Password=!QAZ2wsx;

Create Table HB.Categories(
	[Id] int identity primary key not null,
	[Name] nvarchar(50) not null,
	[Type] bit not null
)

Create Table HB.Users(
	[Id] int identity primary key not null,
	[Name] nvarchar(50) not null,
	[Password] nvarchar(50) not null
)

Create Table HB.Orders(
	[Id] int identity primary key not null,
	[Category_Id] int not null foreign key references HB.Categories(Id),
	[User_Id] int not null foreign key references HB.Users(Id),
	[Price] money not null,
	[Date] DateTime not null,
	[Description] nvarchar(MAX) null
)

Create Table HB.LogHistDateOrder(
[Id] int identity primary key NOT NULL,
[OrderId] int NOT NULL,
[DateOrder] DateTime NOT NULL,
[Summa] money NOT NULL
)

--тригер, который автоматически после каждой покупки дописывает в отдельную таблицу количество потраченных денег 
-- (подсчёт суммы денег которая потрачена на покупки)
CREATE TRIGGER HB.InsertGodds_tg
	ON HB.Orders
    FOR INSERT
    AS
		INSERT INTO HB.LogHistDateOrder([DateOrder], [OrderId], [Summa]) 		
		SELECT  inserted.Date, inserted.Id, inserted.Price
		FROM inserted

INSERT INTO HB.Users VALUES(N'Ніна Нікитюк', '1234')
INSERT INTO HB.Users VALUES(N'Tarasik@', '1234')
INSERT INTO HB.Users VALUES(N'Руслан', '1234')
INSERT INTO HB.Users VALUES(N'Сергій', '1234')
INSERT INTO HB.Users VALUES(N'TanyGmail', '1234')

INSERT INTO  HB.Categories  VALUES(N'Зарплата', 1)
INSERT INTO  HB.Categories  VALUES(N'Їжа', 0)
INSERT INTO  HB.Categories  VALUES(N'Одяг', 0)
INSERT INTO  HB.Categories  VALUES(N'Взуття', 0)
INSERT INTO  HB.Categories  VALUES(N'Віддих і розваги', 0)
INSERT INTO  HB.Categories  VALUES(N'Побутові техніка', 0)
INSERT INTO  HB.Categories  VALUES(N'Аптека', 0)
INSERT INTO  HB.Categories  VALUES(N'Товари для дома', 0)
INSERT INTO  HB.Categories  VALUES(N'Прихід від бизнесy', 1)
INSERT INTO  HB.Categories  VALUES(N'Процент по вкладу в банку', 1)
INSERT INTO  HB.Categories  VALUES(N'Пенсия', 1)
INSERT INTO  HB.Categories  VALUES(N'Стипендія', 1)
INSERT INTO  HB.Categories  VALUES(N'Дохід від продажу особистих речей', 1)


	INSERT INTO HB.Orders VALUES (2, 1, 100, '2017-10-10', N'Хліб, цукор, масло') 
	INSERT INTO HB.Orders VALUES (3, 1, 250, '2017-10-12', N'Пальто') 
	INSERT INTO HB.Orders VALUES (7, 2, 150, '2017-03-10', N'Аспірин, Анальгін')
	INSERT INTO HB.Orders VALUES (1, 3, 5000, '2017-09-10', Null) 
	INSERT INTO HB.Orders VALUES (4, 5, 1500, '2018-01-01', N'Туфлі') 
	INSERT INTO HB.Orders VALUES (6, 2, 450, '2018-03-02', N'Сковорідка')
	INSERT INTO HB.Orders VALUES (2, 4, 200, '2018-02-02', N'Молоко, йогурт')
	INSERT INTO HB.Orders VALUES (1, 4, 7000, '2018-03-02', null) 
	INSERT INTO HB.Orders VALUES (1, 3, 10000, '2018-01-02', null)
	INSERT INTO HB.Orders VALUES (1, 2, 10000, '2018-02-02', null)
	INSERT INTO HB.Orders VALUES (5, 2, 2000, '2018-01-02', null)
