SELECT subjects.Short, COUNT(student_subject.StudentID) AS StudentCount
FROM subjects
LEFT JOIN student_subject ON subjects.Short = student_subject.SubjectShort
GROUP BY subjects.Short
HAVING COUNT(student_subject.StudentID) < 3;