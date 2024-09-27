-- Query 1: Get courses and students taught by Dr. Smith
SELECT c.title AS course, s.name AS student
FROM course c
JOIN professor p ON c.professor_id = p.professor_id
JOIN enrollment e ON c.course_id = e.course_id
JOIN student s ON e.student_id = s.student_id
WHERE p.name = 'Dr. Smith'
ORDER BY c.title, s.name;

-- Query 2: Get pairs of students who share at least one course
SELECT s1.name AS student1, s2.name AS student2
FROM student s1
JOIN student s2 ON s1.student_id < s2.student_id
WHERE EXISTS (
    SELECT 1
    FROM enrollment e1
    JOIN enrollment e2 ON e1.course_id = e2.course_id
    WHERE e1.student_id = s1.student_id
    AND e2.student_id = s2.student_id
)
ORDER BY s1.name, s2.name;

-- Query 3: Get students taught only by Dr. Johnson
SELECT s.name
FROM student s
WHERE EXISTS (
    SELECT 1
    FROM enrollment e
    JOIN course c ON e.course_id = c.course_id
    JOIN professor p ON c.professor_id = p.professor_id
    WHERE e.student_id = s.student_id
    AND p.name = 'Dr. Johnson'
)
AND NOT EXISTS (
    SELECT 1
    FROM enrollment e
    JOIN course c ON e.course_id = c.course_id
    JOIN professor p ON c.professor_id = p.professor_id
    WHERE e.student_id = s.student_id
    AND p.name != 'Dr. Johnson'
)
ORDER BY s.name;

-- Query 4: Get course enrollment count and average grade
SELECT c.title AS course, 
       COUNT(DISTINCT e.student_id) AS enrollment_count,
       AVG(CAST(g.grade AS FLOAT)) AS average_grade
FROM course c
LEFT JOIN enrollment e ON c.course_id = e.course_id
LEFT JOIN grade g ON e.enrollment_id = g.enrollment_id
GROUP BY c.course_id, c.title
ORDER BY enrollment_count DESC, c.title ASC;

-- Query 5: Get top grade for each student
WITH GradesCalculation AS (
    SELECT s.name AS student, c.title AS course, g.grade,
           ROW_NUMBER() OVER (PARTITION BY s.student_id ORDER BY g.grade DESC) AS rn
    FROM student s
    LEFT JOIN enrollment e ON s.student_id = e.student_id
    LEFT JOIN course c ON e.course_id = c.course_id
    LEFT JOIN grade g ON e.enrollment_id = g.enrollment_id
)
SELECT student, course
FROM GradesCalculation
WHERE rn = 1
ORDER BY student;

-- Query 6: Get students enrolled in all departments
SELECT s.name
FROM student s
WHERE NOT EXISTS (
    SELECT DISTINCT c.department
    FROM course c
    EXCEPT
    SELECT DISTINCT c2.department
    FROM enrollment e
    JOIN course c2 ON e.course_id = c2.course_id
    WHERE e.student_id = s.student_id
)
ORDER BY s.name;

-- Query 7: Get average number of students per course for each professor
SELECT p.name AS professor, AVG(student_count) AS avg_students_per_course
FROM professor p
LEFT JOIN (
    SELECT c.professor_id, c.course_id, COUNT(e.student_id) AS student_count
    FROM course c
    LEFT JOIN enrollment e ON c.course_id = e.course_id
    GROUP BY c.professor_id, c.course_id
) AS course_counts ON p.professor_id = course_counts.professor_id
GROUP BY p.professor_id, p.name
ORDER BY avg_students_per_course DESC, p.name ASC;

-- Query 8: Get students with grades above or equal to 50
SELECT DISTINCT s.name
FROM student s
WHERE NOT EXISTS (
    SELECT 1
    FROM enrollment e
    JOIN grade g ON e.enrollment_id = g.enrollment_id
    WHERE e.student_id = s.student_id AND g.grade < 50
)
ORDER BY s.name;

-- Query 9: Get total students and courses count per department
SELECT c.department, COUNT(DISTINCT e.student_id) AS total_students, COUNT(DISTINCT c.course_id) AS total_courses
FROM course c
LEFT JOIN enrollment e ON c.course_id = e.course_id
GROUP BY c.department
ORDER BY total_students DESC, c.department ASC;

-- Query 10: Get pairs of professors who teach the same courses
SELECT DISTINCT p1.name AS professor1, p2.name AS professor2
FROM professor p1
JOIN professor p2 ON p1.professor_id < p2.professor_id
WHERE NOT EXISTS (
    SELECT c1.course_id
    FROM course c1
    WHERE c1.professor_id = p1.professor_id
    AND NOT EXISTS (
        SELECT c2.course_id
        FROM course c2
        WHERE c2.professor_id = p2.professor_id
        AND c1.title = c2.title
    )
)
ORDER BY p1.name, p2.name;
