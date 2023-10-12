CREATE TABLE Employees (
    employee_id INT  PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100),
    phone_number VARCHAR(20),
    hire_date DATE,
    salary DECIMAL(10, 2),
    department VARCHAR(50)
);
CREATE TABLE Admin (
    admin_id INT PRIMARY KEY,
    username VARCHAR(50),
    password VARCHAR(100),
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);
CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    description TEXT,
    price DECIMAL(10, 2),
    stock_quantity INT,
    category VARCHAR(50)
);
CREATE TABLE Customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100),
    phone_number VARCHAR(20),
    address VARCHAR(255)
);

INSERT INTO Employees (employee_id,first_name, last_name, email, phone_number, hire_date, salary, department)
VALUES
    (1,'Nam', 'Trần', 'namtran@example.com', '123-456-7890', '2023-01-15', 50000.00, 'HR'),
    (2,'Thu', 'Nguyêmx', 'thunguyen@example.com', '987-654-3210', '2022-11-20', 55000.00, 'Sales');
INSERT INTO Admin (admin_id,username, password, first_name, last_name)
VALUES
    (1,'admin1', 'a1', 'Admin', 'One'),
    (2,'admin2', 'a2', 'Admin', 'Two');
INSERT INTO Products (product_id,product_name, description, price, stock_quantity, category)
VALUES
    (01,'Cà Phê Đen', 'Thơm ngon chuẩn vị', 15.000 , 50,'Cà Phê'),
    (02,'Cà Phê Sữa', 'Ngọt ngào', 17.000, 25,'Cà Phê');
INSERT INTO Products (product_id,product_name, description, price, stock_quantity, category)
VALUES
	(03,'Sinh tố xoài', 'Ngọt ngào', 18.000, 25,'Sinh tố'),
	(04,'Sinh tố Dâu', 'Ngọt ngào', 18.000, 25,'Sinh tố'),
	(05,'Cơm Hải Sản', 'Thơm ngon bổ dưỡng', 45.000, 25,'Đồ ăn'),
	(06,'Suop Cua', 'Khai vị hấp dẫn', 45.000, 25,'Đồ ăn'),
	(08,'Cháo hành', 'Chị dậu đến', 39.000, 25,'Đồ ăn'),
	(09,'Gỏi Xoài', 'Khai Vị ngon', 39.000, 25,'Đồ ăn'),
	(10,'Cua Hấp', 'Hấp Dẫn', 109.000, 25,'Đồ ăn'),
	(11,'Tôm Nướng', 'Thơm ngon', 99.000, 25,'Đồ ăn'),
	(12,'Hàu Sống', 'Tê tái', 99.000, 25,'Đồ ăn');
INSERT INTO Customers ( customer_id,first_name, last_name, email, phone_number, address)
VALUES
    (1,'Nguyễn', 'Văn Chiến', 'nguyenvana@example.com', '123-456-7890', '123 Đường Paster, Quận 1, Thành phố Hồ Chí Minh'),
	(2,'Nguyễn', 'Văn Chung', 'nguyenvanc@example.com', '123-456-7890', '123 Đường Đông Du, Quận 1, Thành phố Hồ Chí Minh'),
	(3,'Hoàng', 'Văn Hảo', 'hoangvanhao@example.com', '123-456-7890', '33 Đường Vườn Lài,Quận Tân Phú , Thành phố Hồ Chí Minh'),
	(4,'Trần', 'Thi Yến', 'tranthiy@example.com', '123-456-7890', '23 Đường Vườn Lài, Quận Tân Phú, Thành phố Hồ Chí Minh'),
	(5,'Nguyễn', 'Thế Trung', 'nguyenthet@example.com', '123-456-7890', '112 Đường Trường Trinh, Quận Tân Bình, Thành phố Hồ Chí Minh'),
    (6,'Trần', 'Thị Bưởi', 'tranthib@example.com', '987-654-3210', '456 Đường XYZ, Quận 2, Thành phố Hà Nội');
