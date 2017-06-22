CREATE DATABASE Fake_Library;

USE Fake_Library;

CREATE TABLE Publisher (
	Name VARCHAR(50) PRIMARY KEY,
	Address VARCHAR(75),
	Phone VARCHAR(20),
);

CREATE TABLE Book (
	BookId INT PRIMARY KEY NOT NULL IDENTITY,
	Title VARCHAR(75),
	PublisherName VARCHAR(50) FOREIGN KEY REFERENCES Publisher(Name),
);

CREATE TABLE Book_Author (
	BookId INT PRIMARY KEY FOREIGN KEY REFERENCES Book(BookId) ON UPDATE NO ACTION ON DELETE CASCADE,
	AuthorName VARCHAR (50)
);

CREATE TABLE Library_Branch (
	BranchId INT PRIMARY KEY NOT NULL IDENTITY,
	BranchName VARCHAR(50),
	Address VARCHAR (75)
);

CREATE TABLE Book_Copies (
	BookId INT FOREIGN KEY REFERENCES Book(BookID) ON UPDATE NO ACTION ON DELETE CASCADE,
	BranchId INT FOREIGN KEY REFERENCES Library_Branch(BranchID) ON UPDATE CASCADE,
	No_Of_Copies INT 
);

CREATE TABLE Borrower (
	CardNo INT PRIMARY KEY NOT NULL IDENTITY,
	Name VARCHAR(50), 
	Address VARCHAR(75),
	Phone VARCHAR(20)
);

CREATE TABLE Book_Loans (
	BookId INT FOREIGN KEY REFERENCES Book(BookID) ON UPDATE NO ACTION ON DELETE CASCADE,
	BranchId INT FOREIGN KEY REFERENCES Library_Branch(BranchID) ON UPDATE CASCADE,
	CardNo INT FOREIGN KEY REFERENCES Borrower(CardNo) ON UPDATE CASCADE,
	DateOut DATE,
	DateDue DATE,
);

INSERT INTO Publisher (Name, Address, Phone)
	VALUES
	('Smith & Bueller', '849 Lochland Pl', '362-383-9238'),
	('Johnson French', '9234 N 52nd Ave', '397-294-2847'),
	('Lemur Productions', '1492 Columbus Blvd', '934-384-2479'),
	('Small Fry Books', '338 Hunter St', '234-437-8478')
;

INSERT INTO Book (Title, PublisherName)
	VALUES	
	('The Little Prince', 'Smith & Bueller'), -- Antoine St Exupery #1
	('Count On Me', 'Lemur Productions'),
	('Technology for All', 'Small Fry Books'),
	('Get What You Want', 'Small Fry Books'),
	('The Lost Tribe', 'Johnson French'),
	('Birds of Prey', 'Johnson French'),
	('The Shining', 'Smith & Bueller'),		-- Stephen King #7
	('Sunshine', 'Lemur Productions'),
	('Making Money for Free', 'Smith & Bueller'),
	('Along Came a Spider', 'Smith & Bueller'),	--James Patterson #10
	('In the Fog', 'Johnson French'),
	('Along the Waterfall', 'Lemur Productions'),
	('We Used to Sing', 'Johnson French'),
	('Wicked Watchtower', 'Smith & Bueller'),
	('In the Green Grass', 'Small Fry Books'),
	('Lob Folly', 'Johnson French'), -- #16 Olive
	('Here We Go', 'Smith & Bueller'),
	('People Like Us', 'Small Fry Books'), -- #18
	('Double Dutch', 'Lemur Productions'),
	('The Blind Assasin', 'Lemur Productions'), --#20 Atwood
	('The Dead Zone', 'Smith & Bueller') --#21 King
;

INSERT INTO Book_Author (BookId, AuthorName)
	VALUES
	('1', 'Antoine de Saint-Exupery'),
	('2', 'Harrison Marshall'),
	('3', 'Edward Hopper'),
	('4', 'Melissa English'),
	('5', 'George Scott'),
	('6', 'Walter Nguyen'),
	('7', 'Stephen King'),
	('8', 'Ziggy Love'),
	('9', 'Reverand Lowell Price'),
	('10', 'James Patterson'),
	('11', 'Jeanell Brown'),
	('12', 'Nancy Lee'),
	('13', 'Hassan Guettaf'),
	('14', 'Eliot Luthor'),
	('15', 'Seamus MacNeil'),
	('16', 'Olive Garvey'),
	('17', 'Raymond Anderson'),
	('18', 'Oliver Cochener'),
	('19', 'Missy Scott'),
	('20', 'Margaret Atwood'),
	('21', 'Stephen King')
;

INSERT INTO Library_Branch (BranchName, Address)
	VALUES
	('Lynchburg', '8521 N Western Ave'),
	('Central', '1639 W Main St'),
	('Fairfield', '327 S Tinseltown Ln'),
	('Ontario', '9863 Watery Grave Way'),
	('Sharpstown', '2340 Gunslinger Rd')
;

INSERT INTO Book_Copies (BookId, BranchId, No_Of_Copies)
	VALUES
	('15','1','4'), ('18','1','3'), ('3','1','3'), ('7','1','5'), ('2','1','2'),
	('8','2','2'), ('20','2','5'), ('13','2','2'), ('5','2','4'), ('9','2','6'),
	('1','3','3'), ('12','3','4'), ('4','3','3'), ('17','3','7'), ('19','3','5'),
	('6','4','3'), ('14','4','6'), ('10','4','3'), ('21','4','2'), ('11','4','4'),
	('16','5','6'), ('13','5','3'), ('7','5','2'), ('1','5','4'), ('4','5','6'),
	('21','2','4'), ('5','3','6'), ('9','5','2'), ('8','1','4'), ('5','4','3'),
	('10','5','7'), ('11','2','4'), ('7','4','3'), ('13','1','4'), ('3','3','3'),
	('18','4','7'), ('20','3','5'), ('19','1','5'), ('15','5','3'), ('7','2','2'),
	('10','3','7'), ('1','2','5'), ('21','5','3'), ('12','4','9'), ('17','1','3'),
	('15','2','4'), ('9','4','5'), ('18','3','3'), ('14','1','4'), ('2','5','2'),
	('6','3','6'), ('20','3','4'), ('14','2','4'), ('5','5','2')
;

INSERT INTO Borrower(Name, Address, Phone)
	VALUES	
	('Jason Goddard', '9734 N Tillamook Ln', '937-984-9758'),
	('Marzipan Cochener', '27 Capistrano Ave', '849-370-9277'),
	('Olivia Wilde', '209 W Hollywood Blvd', '320-946-8268'),
	('Anthony Teller', '9278 Gillette St', '397-927-9468'),
	('Meredith French', '823 NE Fremont Way', '893-947-9374'),
	('Brian Anderson', '1999 Burdett Ave', '518-394-2947'),
	('Geoffrey Oliver', '14404 W 90th Terrace', '918-84-8274'),
	('Jessica Rabbit', '8920 Acme Dr', '392-947-9739'),
	('Madonna Johnson', '9794 E Cicerone St', '937-947-2048')
;

INSERT INTO Book_Loans (BookId, BranchId, CardNo, DateOut, DateDue)
	VALUES
	('14','1','3','2017-04-13','2017-06-12'), ('17','1','3','2017-04-13','2017-06-12'),
	('9','2','7','2017-04-30','2017-05-30'), ('10','4','3','2017-03-31','2017-05-30'),
	('12','4', '3','2017-03-31','2017-05-30'), ('12','3','9','2017-05-24','2017-06-23'),
	('16','5','2','2017-05-01','2017-05-31'), ('18','4','2','2017-05-02','2017-06-01'),
	('21','5','6','2017-05-21','2017-06-20'), ('7','5','6','2017-05-21','2017-06-20'), -- 10 records
	('13','5','6','2017-05-21','2017-06-20'), ('16','5','6','2017-05-21','2017-06-20'),
	('4','5','6','2017-05-21','2017-06-20'), ('4','5','3','2017-04-17','2017-06-16'),
	('9','5','3','2017-04-17','2017-06-16'), ('19','1','7','2017-05-16','2017-06-15'),
	('3','1','7','2017-05-16','2017-06-15'), ('15','2','4','2017-05-03','2017-06-02'),
	('1','3','6','2017-05-24','2017-06-23'), ('12','3','6','2017-05-24','2017-06-23'), -- 20 records
	('19','3','6','2017-05-24','2017-06-23'), ('20','3','6','2017-05-24','2017-06-23'),
	('5','3','6','2017-05-24','2017-06-23'), ('11','2','4','2017-05-13','2017-06-12'),
	('20','2','3','2017-05-12','2017-07-11'), ('21','2','3','2017-05-12','2017-07-11'),
	('6','4','6','2017-05-26','2017-06-25'), ('10','4','6','2017-05-26','2017-06-25'), 
	('14','4','6','2017-05-26','2017-06-25'), ('18','4','6','2017-05-26','2017-06-25'), -- 30 records
	('5','5','9','2017-05-18','2017-06-17'), ('1','5','2','2017-05-20','2017-06-19'), 
	('6','3','4','2017-04-30','2017-05-30'), ('2','5','9','2017-05-14','2017-06-13'), 
	('2','1','6','2017-05-28','2017-06-27'), ('15','1','6','2017-05-28','2017-06-27'), 
	('8','1','6','2017-05-28','2017-06-27'), ('17','1','6','2017-05-28','2017-06-27'),
	('7','4','3','2017-04-22','2017-06-21'), ('18','4','3','2017-04-22','2017-06-21'), -- 40 records
	('17','3','9','2017-05-29','2017-06-28'), ('17','3','4','2017-05-29','2017-06-28'),
	('13','1','7','2017-05-23','2017-06-22'), ('3','1','9','2017-05-27','2017-06-26'),
	('3','3','4','2017-05-28','2017-06-27'), ('3','3','6','2017-05-30','2017-06-29'), 
	('17','3','6','2017-05-30','2017-06-29'), ('11','4','3','2017-05-15','2017-07-14'),
	('1','2','4','2017-05-21','2017-06-20'), ('8','2','4','2017-05-21','2017-06-20') -- 50 records
;
