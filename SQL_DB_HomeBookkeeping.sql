--Server=tcp:dobro.database.windows.net,1433;Initial Catalog=Market;Persist Security Info=False;User ID=test@dobro;Password=!QAZ2wsx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

--Server=tcp:dobro.database.windows.net,1433;  Or -- tcp:dobro.database.windows.net,1433\sqlexpres
--Initial Catalog=Market;
--User ID=test@dobro;
--Password=!QAZ2wsx;

Create Table Categories_HB(
	[Id] int identity primary key not null,
	[Name] nvarchar(50) not null,
	[Type] bit not null
)

Create Table Users_HB(
	[Id] int identity primary key not null,
	[Name] nvarchar(50) not null,
	[Password] nvarchar(50) not null
)

Create Table Orders_HB(
	[Id] int identity primary key not null,
	[Category_Id] int not null foreign key references Categories_HB(Id),
	[User_Id] int not null foreign key references Users_HB(Id),
	[Price] money not null,
	[Date] DateTime not null,
	[Description] nvarchar(MAX) null
)

Create Table LogHistDateOrder_HB(
[Id] int identity primary key NOT NULL,
[OrderId] int NOT NULL,
[DateOrder] DateTime NOT NULL,
[Summa] money NOT NULL
)

--тригер, который автоматически после каждой покупки дописывает в отдельную таблицу количество потраченных денег 
-- (подсчёт суммы денег которая потрачена на покупки)
CREATE TRIGGER InsertGodds_tg
	ON Orders_HB
    FOR INSERT
    AS
		INSERT INTO LogHistDateOrder_HB([DateOrder], [OrderId], [Summa]) 		
		SELECT  inserted.Date, inserted.Id, inserted.Price
		FROM inserted

INSERT INTO Users_HB VALUES(N'Ніна Нікитюк', '1234')
INSERT INTO Users_HB VALUES(N'Tarasik@', '1234')
INSERT INTO Users_HB VALUES(N'Руслан', '1234')
INSERT INTO Users_HB VALUES(N'Сергій', '1234')
INSERT INTO Users_HB VALUES(N'TanyGmail', '1234')

INSERT INTO  Categories_HB  VALUES(N'Зарплата', 1)
INSERT INTO  Categories_HB  VALUES(N'Їжа', 0)
INSERT INTO  Categories_HB  VALUES(N'Одяг', 0)
INSERT INTO  Categories_HB  VALUES(N'Взуття', 0)
INSERT INTO  Categories_HB  VALUES(N'Віддих і розваги', 0)
INSERT INTO  Categories_HB  VALUES(N'Побутові техніка', 0)
INSERT INTO  Categories_HB  VALUES(N'Аптека', 0)
INSERT INTO  Categories_HB  VALUES(N'Товари для дома', 0)
INSERT INTO  Categories_HB  VALUES(N'Прихід від бизнесy', 1)
INSERT INTO  Categories_HB  VALUES(N'Процент по вкладу в банку', 1)
INSERT INTO  Categories_HB  VALUES(N'Пенсия', 1)
INSERT INTO  Categories_HB  VALUES(N'Стипендія', 1)
INSERT INTO  Categories_HB  VALUES(N'Дохід від продажу особистих речей', 1)


	INSERT INTO Orders_HB VALUES (2, 1, 100, '2017-10-10', N'Хліб, цукор, масло') 
	INSERT INTO Orders_HB VALUES (3, 1, 250, '2017-10-12', N'Пальто') 
	INSERT INTO Orders_HB VALUES (7, 2, 150, '2017-03-10', N'Аспірин, Анальгін')
	INSERT INTO Orders_HB VALUES (1, 3, 5000, '2017-09-10', Null) 
	INSERT INTO Orders_HB VALUES (4, 5, 1500, '2018-01-01', N'Туфлі') 
	INSERT INTO Orders_HB VALUES (6, 2, 450, '2018-03-02', N'Сковорідка')
	INSERT INTO Orders_HB VALUES (2, 4, 200, '2018-02-02', N'Молоко, йогурт')
	INSERT INTO Orders_HB VALUES (1, 4, 7000, '2018-03-02', null) 
	INSERT INTO Orders_HB VALUES (1, 3, 10000, '2018-01-02', null)
	INSERT INTO Orders_HB VALUES (1, 2, 10000, '2018-02-02', null)
	INSERT INTO Orders_HB VALUES (5, 2, 2000, '2018-01-02', null)