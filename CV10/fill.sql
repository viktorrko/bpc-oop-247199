INSERT INTO students(ID, FirstName, LastName, Birthday) VALUES (247299, 'Viktor', 'Voscek', '2003-07-25')
INSERT INTO students(ID, FirstName, LastName, Birthday) VALUES (284689, 'Zidan', 'Devat', '2002-05-13')
INSERT INTO students(ID, FirstName, LastName, Birthday) VALUES (184986, 'David', 'Nosek', '2005-01-01')
INSERT INTO students(ID, FirstName, LastName, Birthday) VALUES (785623, 'Daniel', 'Dic', '2002-09-08')
INSERT INTO students(ID, FirstName, LastName, Birthday) VALUES (255666, 'Eidam', 'Yaeksh', '2003-06-06')

INSERT INTO subjects(Short, Name) VALUES ('BPC-ANA', 'Analogová technika')
INSERT INTO subjects(Short, Name) VALUES ('BPC-ASI', 'Analýza signálù a soustav')
INSERT INTO subjects(Short, Name) VALUES ('BPC-FY1B', 'Fyzika 1')
INSERT INTO subjects(Short, Name) VALUES ('BPC-MA3', 'Matematika 3')
INSERT INTO subjects(Short, Name) VALUES ('BPC-MVAA', 'Mìøení v audiotechnice')

INSERT INTO student_subject(StudentID, SubjectShort) VALUES (247299, 'BPC-ANA')
INSERT INTO student_subject(StudentID, SubjectShort) VALUES (247299, 'BPC-ASI')
INSERT INTO student_subject(StudentID, SubjectShort) VALUES (247299, 'BPC-MA3')
INSERT INTO student_subject(StudentID, SubjectShort) VALUES (247299, 'BPC-MVAA')

INSERT INTO student_subject(StudentID, SubjectShort) VALUES (284689, 'BPC-FY1B')
INSERT INTO student_subject(StudentID, SubjectShort) VALUES (284689, 'BPC-MA3')

INSERT INTO student_subject(StudentID, SubjectShort) VALUES (184986, 'BPC-ANA')
INSERT INTO student_subject(StudentID, SubjectShort) VALUES (184986, 'BPC-ASI')
INSERT INTO student_subject(StudentID, SubjectShort) VALUES (184986, 'BPC-FY1B')

INSERT INTO student_subject(StudentID, SubjectShort) VALUES (785623, 'BPC-MA3')

INSERT INTO student_subject(StudentID, SubjectShort) VALUES (255666, 'BPC-ANA')
INSERT INTO student_subject(StudentID, SubjectShort) VALUES (255666, 'BPC-ASI')
INSERT INTO student_subject(StudentID, SubjectShort) VALUES (255666, 'BPC-MA3')
INSERT INTO student_subject(StudentID, SubjectShort) VALUES (255666, 'BPC-MVAA')