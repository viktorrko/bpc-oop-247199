SELECT students.LastName, subjects.Short
FROM students
CROSS JOIN subjects
LEFT JOIN student_subject ON students.ID = student_subject.StudentID;



