CREATE TABLE Products (
	id int IDENTITY(1, 1),
  	name NVARCHAR(30) NOT NULL,
  	PRIMARY KEY(id)
);

CREATE TABLE Categories (
	id int IDENTITY(1, 1),
  	name NVARCHAR(30) NOT NULL,
  	PRIMARY KEY(id)
);

CREATE TABLE ProductCategories (
	productId int,
  	categoryId int,
  	PRIMARY KEY (productId, categoryId),
  	FOREIGN KEY (productId) REFERENCES Products(id),
  	FOREIGN KEY (categoryId) REFERENCES Categories(id)
)

INSERT INTO Products
VALUES
  ('Macbook'),
  ('Samsung GALAXY Tab'),
  ('Bose QuietComfort'),
  ('Huawei Mate'),
  ('Sony TV'),
  ('Lawn mower'); -- Продукт, для которого нет категории

INSERT INTO Categories
VALUES
  ('Electronics'),
  ('PCs'),
  ('Mobile devices'),
  ('Audio'),
  ('TVs'),
  ('Projectors'); -- Категория, для которой нет продуктов

INSERT INTO ProductCategories
VALUES
	(1, 1),
    (1, 2),
    (2, 1),
    (2, 3),
    (3, 1),
    (3, 4),
    (4, 1),
    (4, 3),
    (5, 1),
    (5, 5);

SELECT p.name AS ProductName, c.name AS CategoryName FROM Products AS p
LEFT JOIN ProductCategories AS pc ON p.id = pc.productId
LEFT JOIN Categories As c ON c.id = pc.categoryId;
