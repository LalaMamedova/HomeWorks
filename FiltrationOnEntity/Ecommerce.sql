create database Ecommerce
use Ecommerce

CREATE TABLE Category (
    ID INT PRIMARY KEY IDENTITY ,
    CategoryName NVARCHAR(100),
    ImageLink NVARCHAR(255)
);

CREATE TABLE Product (
    ID INT PRIMARY KEY IDENTITY ,
    ImageLink NVARCHAR(max),
    ProductName NVARCHAR(100) NOT NULL ,
    Price DECIMAL(10, 2) NOT NULL ,
    Quantity INT not null ,
    [CategoryID] INT FOREIGN KEY REFERENCES Category(ID)
);


INSERT INTO Category ( CategoryName, ImageLink)
VALUES
    (N'Laptops', N'https://static.vecteezy.com/system/resources/previews/013/475/424/original/open-laptop-icon-illustration-png.png'),
    (N'Smartphones', 'https://cdn-icons-png.flaticon.com/512/65/65680.png'),
    (N'Tablets', 'https://cdn-icons-png.flaticon.com/512/0/319.png'),
    (N'Headphones', 'https://cdn-icons-png.flaticon.com/512/27/27130.png'),
    (N'Cameras', 'https://cdn-icons-png.flaticon.com/512/3566/3566345.png');

INSERT INTO Product (CategoryID, ImageLink, ProductName, Price, Quantity)
VALUES
    (1, 'https://kontakt.az/wp-content/uploads/2020/12/201210170018916895.jpg', 'MacBook Air', 999.99, 10),
    (1, 'https://media.cnn.com/api/v1/images/stellar/prod/221019173441-dell-xps-13-2022-review-cnnu-4.jpg?c=original', 'Dell XPS 13', 1299.99, 5),
    (1, 'https://aztech.az/wp-content/uploads/2022/12/Lenovo-ThinkPad-X1-Carbon-Gen-10-5.png', 'Lenovo ThinkPad X1 Carbon', 1499.99, 8),
    (2, 'https://www.soliton.az/images/articles/2020/12/07/20201207113112745_c1_1.jpg', 'iPhone 12', 799.99, 15),
    (2, 'https://kontakt.az/wp-content/uploads/2021/01/New-Project-9-2_png.webp', 'Samsung Galaxy S21', 899.99, 12),
    (2, 'https://kontakt.az/wp-content/uploads/2022/07/google-pixel-6-pro-128gb-stormy-black-ga03164-gb-21102021-01-p_png.webp', 'Google Pixel 6', 999.99, 9),
    (3, 'https://strgimgr.umico.az/sized/840/22984-e23eb73fcd3e02ac38b0d0358c1138af.jpg', 'iPad Pro', 799.99, 20),
    (3, 'https://kontakt.az/wp-content/uploads/2020/09/81yCOQUbqGL._AC_SL1500_.jpg', 'Samsung Galaxy Tab S7', 699.99, 15),
    (3, 'https://m.media-amazon.com/images/G/01/kindle/journeys/WTN3CxScwzgi6KWIbtm8Xorm6sx50imat82FEiOH0xK83D/M2JiMjU1ZTYt._CB670552974_.jpg', 'Amazon Fire HD 10', 149.99, 30),
    (4, 'https://www.sony-mea.com/image/5d02da5df552836db894cead8a68f5f3?fmt=pjpeg&wid=330&bgcolor=FFFFFF&bgc=FFFFFF', 'Sony WH-1000XM4', 349.99, 25),
    (4, 'https://m.media-amazon.com/images/I/71+iQZU-dVL.jpg', 'Bose QuietComfort 35 II', 299.99, 12),
    (4, 'https://maxi.az/upload/iblock/bfb/bfb81d2ac7a16b4d06f86383f89d1b24.jpg', 'JBL Free X', 149.99, 40),
    (5, 'https://i1.adis.ws/i/canon/eos-r5_martin_bissig_lifestyle_05_c629aad3c2154f34b3d7d7ba5a509196?$70-30-header-4by3-dt-jpg$', 'Canon EOS R5', 3899.99, 5),
    (5, 'https://almali.store/wp-content/uploads/2022/09/7163dSGBnSL._AC_SL1200_.jpg', 'Sony Alpha a7 III', 1999.99, 10),
    (5, 'https://irshad.az/resized/fit540x550/center/products/40382/ab73cdb93f88e9c25e0b868f19abd5b8.jpg', 'Nikon D850', 2999.99, 8),
    (1, 'https://irshad.az/resized/fit540x550/center/products/83218/6g6m7ea-5.jpg', 'HP Spectre x360', 1199.99, 18),
    (2, 'https://myshops.ae/image/cache/catalog/tovar/692181561254/2-500x500.jpg', 'OnePlus 9 Pro', 899.99, 20),
    (3, 'https://cdn-dynmedia-1.microsoft.com/is/image/microsoftcorp/MSFT-RWGaM8-Surface-Pro-7-in-Laptop-Mode?scl=1', 'Microsoft Surface Pro 7', 999.99, 15),
    (4, 'https://media.graphassets.com/pgJUqhYRgWki8I09hdic', 'Sennheiser HD 660 S', 499.99, 8),
    (5, 'https://m.media-amazon.com/images/I/91L2tiLsIJL.jpg', 'Fujifilm X-T4', 1699.99, 12),

INSERT INTO Product (CategoryID, ImageLink, ProductName, Price, Quantity)
VALUES (2, N'https://irshad.az/resized/fit540x550/center/products/78240/102022-blue.jpeg', 'Xiaomi Redmi 10', 599.99, 250);

