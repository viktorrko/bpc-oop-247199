CREATE TABLE subjects (
	Short varchar(12) NOT NULL,
	Name varchar(255),
	PRIMARY KEY(Short)
	)

CREATE TABLE students (
	ID int NOT NULL,
	FirstName varchar(255),
	LastName varchar(255),
	Birthday date,
	PRIMARY KEY (ID)
	)

CREATE TABLE student_subject (
	StudentID int,
	SubjectShort varchar(12),
	FOREIGN KEY (StudentID) REFERENCES	students(ID),
	FOREIGN KEY (SubjectShort) REFERENCES subjects(Short),
	PRIMARY KEY (StudentID, SubjectShort)
	)
	
CREATE TABLE grading (
	StudentID int,
	SubjectShort varchar(12),
	Date datetime,
	Grade tinyint,
	FOREIGN KEY (StudentID) REFERENCES	students(ID),
	FOREIGN KEY (SubjectShort) REFERENCES subjects(Short),
	PRIMARY KEY (StudentID, SubjectShort)
	)