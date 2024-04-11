SELECT 
    subjects.Short,
    MAX(grading.Grade) AS Best,
    MIN(grading.Grade) AS Worst,
    AVG(grading.Grade) AS Average,
    COUNT(grading.Grade) AS Students
FROM subjects
LEFT JOIN student_subject ON subjects.Short = student_subject.SubjectShort
LEFT JOIN grading ON student_subject.StudentID = grading.StudentID
GROUP BY subjects.Short;