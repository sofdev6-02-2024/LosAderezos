CREATE DATABASE IF NOT EXISTS dbaderezosdev;

USE dbaderezosdev;
-- CATEGORY
CREATE TABLE IF NOT EXISTS Category(
    Id      VARCHAR(36) PRIMARY KEY NOT NULL,
    Name    VARCHAR(80)
);

-- COMPANY
CREATE TABLE IF NOT EXISTS Company(
    Id      VARCHAR(36) PRIMARY KEY NOT NULL,
    Name    VARCHAR(80),
    UserId  VARCHAR(36)
);

-- SUBSIDIARY
CREATE TABLE IF NOT EXISTS Subsidiary(
    Id          VARCHAR(36) PRIMARY KEY NOT NULL,
    Location    VARCHAR(50),
    Name        VARCHAR(80),
    Type        VARCHAR(80),
    CompanyId   VARCHAR(36),
    FOREIGN KEY (CompanyId) REFERENCES Company(Id)
);

DELIMITER //
CREATE PROCEDURE GetSubsidiariesByCompanyId(IN companyId CHAR(36))
BEGIN
  SELECT
    s.Id,
    s.Coordinate,
    s.Name,
    s.Type
  FROM
    Subsidiary s
  WHERE
    s.CompanyId = companyId;
END //
DELIMITER ;

-- PRODUCT
CREATE TABLE IF NOT EXISTS Product(
    Id          VARCHAR(36) PRIMARY KEY NOT NULL,
    Name        VARCHAR(80),
    IncomePrice DECIMAL(7,2),
    Code        INT,
    SellPrice   DECIMAL(7,2),
    CompanyId   VARCHAR(36),
    LowExistence INT,
    Notify      BIT,
    FOREIGN KEY (CompanyId) REFERENCES Company(Id)
);

DELIMITER //
CREATE PROCEDURE GetProductsByCompanyId(IN companyId CHAR(36))
BEGIN
  SELECT
    p.Id,
    p.Name,
    p.IncomePrice,
    p.Code,
    p.SellPrice,
    p.LowExistence,
    p.Notify
  FROM
    Product p
  WHERE
    p.CompanyId = companyId;
END //
DELIMITER ;

-- STOCK
CREATE TABLE IF NOT EXISTS Stock(
    Id              VARCHAR(36) PRIMARY KEY NOT NULL,
    Code            INT,
    Quantity        INT,
    ProductId       VARCHAR(36),
    SubsidiaryId    VARCHAR(36),
    FOREIGN KEY (SubsidiaryId) REFERENCES Subsidiary(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

DELIMITER //
CREATE PROCEDURE GetStocksBySubsidiaryId(IN subsidiaryId CHAR(36))
BEGIN
  SELECT
    s.Id,
    s.Code,
    s.Quantity,
    s.ProductId
  FROM
    Stock s
  WHERE
    s.SubsidiaryId = subsidiaryId;
END //
DELIMITER ;

-- SUBSIDIARY USERS
CREATE TABLE IF NOT EXISTS SubsidiaryUsers( 
    UserId          VARCHAR(36) NOT NULL,
    SubsidiaryId    VARCHAR(36) NOT NULL,
    FOREIGN KEY (SubsidiaryId) REFERENCES Subsidiary(Id)
);

DELIMITER //
CREATE PROCEDURE GetSubsidiaryUsersBySubsidiaryId(IN subsidiaryId CHAR(36))
BEGIN
  SELECT
    su.UserId,
    su.SubsidiaryId
  FROM
    SubsidiaryUsers su
  WHERE
    su.SubsidiaryId = subsidiaryId;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE GetSubsidiaryUsersByUserId(IN userId CHAR(36))
BEGIN
  SELECT
    su.UserId,
    su.SubsidiaryId
  FROM
    SubsidiaryUsers su
  WHERE
    su.UserId = userId;
END //
DELIMITER ;

-- PRODUCT CATEGORIES
CREATE TABLE IF NOT EXISTS ProductCategories(
    ProductId   VARCHAR(36) NOT NULL,
    CategoryId  VARCHAR(36) NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);

DELIMITER //
CREATE PROCEDURE GetProductCategoriesByProductId(IN productId CHAR(36))
BEGIN
  SELECT
    pc.ProductId,
    pc.CategoryId
  FROM
    ProductCategories pc
  WHERE
    pc.ProductId = productId;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE GetProductCategoriesByCategoryId(IN categoryId CHAR(36))
BEGIN
  SELECT
    pc.ProductId,
    pc.CategoryId
  FROM
    ProductCategories pc
  WHERE
    pc.CategoryId = categoryId;
END //
DELIMITER ;


-- TRUNCATE ALL TABLES
DELIMITER //
CREATE PROCEDURE TruncateAllTables()
BEGIN
    SET FOREIGN_KEY_CHECKS = 0;
    TRUNCATE TABLE Category;
    TRUNCATE TABLE Company;
    TRUNCATE TABLE Subsidiary;
    TRUNCATE TABLE Product;
    TRUNCATE TABLE Stock;
    TRUNCATE TABLE SubsidiaryUsers;
    TRUNCATE TABLE ProductCategories;
    SET FOREIGN_KEY_CHECKS = 1;
END //
DELIMITER ;
