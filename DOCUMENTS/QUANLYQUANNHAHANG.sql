drop database QUANLYNHAHANG
CREATE DATABASE QUANLYNHAHANG
GO
USE QUANLYNHAHANG
GO

-- Food
-- TableFood
-- FoodCategory
-- Account
-- AccountType
-- Bill
-- BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'	-- Trống || Có người
)
GO
CREATE TABLE AccountType
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL
)
go
CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,	
	DisplayName NVARCHAR(100) NOT NULL,
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	id INT DEFAULT 0 -- 1: admin && 0: staff
	foreign key (id) references AccountType(id)
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: đã thanh toán && 0: chưa thanh toán
	
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

USE [QUANLYNHAHANG]
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1, N'Bàn ăn 1', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (2, N'Bàn ăn 2', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (3, N'Bàn ăn 3', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (4, N'Bàn ăn 4', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (5, N'Bàn ăn 5', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (6, N'Bàn ăn 6', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (7, N'Bàn ăn 7', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (8, N'Bàn ăn 8', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (9, N'Bàn ăn 9', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (10, N'Bàn ăn 10', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (1, CAST(N'2023-11-13' AS Date), NULL, 1, 0)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (2, CAST(N'2023-11-13' AS Date), NULL, 1, 0)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (3, CAST(N'2023-11-13' AS Date), NULL, 2, 0)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (4, CAST(N'2023-11-13' AS Date), NULL, 2, 0)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (5, CAST(N'2023-11-13' AS Date), NULL, 3, 0)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (6, CAST(N'2023-11-13' AS Date), NULL, 3, 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([id], [name]) VALUES (1, N'Admin')
INSERT [dbo].[AccountType] ([id], [name]) VALUES (2, N'Staff')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [id]) VALUES (N'Admin', N'Admin', N'1', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [id]) VALUES (N'Staff', N'Staff1', N'1', 2)
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (1, N'Cơm')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (2, N'Mì')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (3, N'Nướng')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (4, N'Xào')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (5, N'Hấp')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (1, N'Cơm rang', 1, 50000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (2, N'Cơm hến', 1, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (3, N'Cơm gà', 1, 50000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (4, N'Cơm cuộn sushi', 1, 80000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (5, N'Cơm sườn', 1, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (6, N'Mì xào hải sản', 2, 50000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (7, N'Mì quảng', 2, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (8, N'Mì ramen', 2, 30000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (9, N'Mì xào bò', 2, 5000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (10, N'Mì ăn liền', 2, 40000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (11, N'Heo nướng', 3, 80000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (12, N'Gà nướng', 3, 60000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (13, N'Mực nướng', 3, 100000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (14, N'Cá nướng', 3, 80000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (15, N'Nem nướng', 3, 40000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (16, N'Rau xào', 4, 30000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (17, N'Mì xào', 4, 40000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (18, N'Gà xào sả ớt', 4, 60000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (19, N'Mực xào cà chua', 4, 70000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (20, N'Bò xào hành gừng:', 4, 80000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (21, N'Gà hấp lá tranh', 5, 80000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (22, N'Rau củ hấp', 5, 40000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (23, N'Cá hồi hấp', 5, 150000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (24, N'Cua hấp', 5, 160000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (25, N'Ngao hấp', 5, 100000)
SET IDENTITY_INSERT [dbo].[Food] OFF
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1, 1, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (2, 1, 11, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (3, 1, 14, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (4, 2, 23, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (5, 2, 3, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (6, 2, 25, 1)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF

