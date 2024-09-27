-- Create Student Table
CREATE TABLE Student (
    StudentID INT PRIMARY KEY,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    ContactNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    IsUndergraduate BIT NOT NULL,
    Program NVARCHAR(255) NOT NULL,
    YearOfStudy INT NOT NULL
);

-- Create Department Table
CREATE TABLE Department (
    DepartmentID INT PRIMARY KEY,
    DepartmentName NVARCHAR(255) UNIQUE NOT NULL
);

-- Create Professor Table
CREATE TABLE Professor (
    ProfessorID INT PRIMARY KEY,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    OfficeLocation NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    DepartmentID INT NOT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

-- Create Course Table
CREATE TABLE Course (
    CourseCode NVARCHAR(10) PRIMARY KEY,
    CourseName NVARCHAR(255) NOT NULL,
    DepartmentID INT NOT NULL,
    Credits INT NOT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

-- Create Course Prerequisite Table
CREATE TABLE CoursePrerequisite (
    CourseCode NVARCHAR(10) NOT NULL,
    PrerequisiteCode NVARCHAR(10) NOT NULL,
    PRIMARY KEY (CourseCode, PrerequisiteCode),
    FOREIGN KEY (CourseCode) REFERENCES Course(CourseCode),
    FOREIGN KEY (PrerequisiteCode) REFERENCES Course(CourseCode)
);

-- Create Semester Table
CREATE TABLE Semester (
    SemesterID INT PRIMARY KEY,
    SemesterName NVARCHAR(20) NOT NULL
);

-- Create Classroom Table
CREATE TABLE Classroom (
    RoomNumber NVARCHAR(20) PRIMARY KEY,
    Building NVARCHAR(255) NOT NULL,
    Capacity INT NOT NULL
);

-- Create Professor Course Relationship Table
CREATE TABLE ProfessorCourse (
    ProfessorID INT NOT NULL,
    CourseCode NVARCHAR(10) NOT NULL,
    SemesterID INT NOT NULL,
    AcademicYear INT NOT NULL,
    ClassroomRoomNumber NVARCHAR(20) NOT NULL,
    PRIMARY KEY (ProfessorID, CourseCode, SemesterID, AcademicYear),
    FOREIGN KEY (ProfessorID) REFERENCES Professor(ProfessorID),
    FOREIGN KEY (CourseCode) REFERENCES Course(CourseCode),
    FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID),
    FOREIGN KEY (ClassroomRoomNumber) REFERENCES Classroom(RoomNumber)
);

-- Create Student Enrollment Relationship Table
CREATE TABLE StudentEnrollment (
    StudentID INT NOT NULL,
    CourseCode NVARCHAR(10) NOT NULL,
    SemesterID INT NOT NULL,
    AcademicYear INT NOT NULL,
    EnrollmentDate DATE NOT NULL,
    FinalGrade NVARCHAR(2) NOT NULL, -- E.g., A, B, C, F
    GPA DECIMAL(3, 2) NOT NULL,
    PRIMARY KEY (StudentID, CourseCode, SemesterID, AcademicYear),
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseCode) REFERENCES Course(CourseCode),
    FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID)
);

-- Create Fee Table
CREATE TABLE Fee (
    FeeID INT PRIMARY KEY,
    StudentID INT NOT NULL,
    SemesterID INT NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    AmountPaid DECIMAL(10, 2) NOT NULL,
    DueDate DATE NOT NULL,
    PaymentDate DATE NOT NULL,
    PaymentMethod NVARCHAR(255) NOT NULL,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID)
);

-- Create Event
CREATE TABLE Event (
    EventID INT PRIMARY KEY,
    EventName NVARCHAR(255) NOT NULL,
    EventDate DATE NOT NULL,
    EventOrganizer NVARCHAR(255) NOT NULL,
    ClassroomRoomNumber NVARCHAR(20) NOT NULL,
    FOREIGN KEY (ClassroomRoomNumber) REFERENCES Classroom(RoomNumber)
);

-- I've done some research into the best way to handle this.
-- From what I can tell, it would be best to calculate the relationship dynamically.
-- But for the sake of completeness, and to stick to the assignment as closeley as possible, I have included the final grade and GPA in the enrollment section.
-- But I think the final grade should probably be calculated dynamically from the GPA value.
-- This is the one question I was a bit iffy on, but I hope this is a correct approach.

-- Create Table GradePoints
-- This table stores the "Final Grade" and the GPA required to get that grade. 
CREATE TABLE GradePoints (
    LetterGrade NVARCHAR(2) PRIMARY KEY, 
    GradePoint DECIMAL(3, 2) NOT NULL
);

-- Insert the grade point values
INSERT INTO GradePoints (LetterGrade, GradePoint) VALUES
('A', 4.00), ('A-', 3.67), ('B+', 3.33), ('B', 3.00),
('B-', 2.67), ('C+', 2.33), ('C', 2.00), ('C-', 1.67), 
('D+', 1.33), ('D', 1.00), ('F', 0.00); 

-- INSERT VALUES --
INSERT INTO Student (StudentID, FirstName, LastName, DateOfBirth, Address, ContactNumber, Email, IsUndergraduate, Program, YearOfStudy) VALUES
(1, 'Peter', 'Parker', '2001-08-10', '20 Ingram Street, Forest Hills, NY', '555-1234', 'peter.parker@university.edu', 1, 'Physics', 3),
(2, 'Mary Jane', 'Watson', '2001-06-01', '22 Ingram Street, Forest Hills, NY', '555-5678', 'mj.watson@university.edu', 1, 'Theater Arts', 2),
(3, 'Harry', 'Osborn', '2001-02-15', '10 Rich Avenue, Manhattan, NY', '555-8765', 'harry.osborn@university.edu', 1, 'Business', 3),
(4, 'Gwen', 'Stacy', '2001-04-10', '30 Queens Boulevard, Queens, NY', '555-4321', 'gwen.stacy@university.edu', 1, 'Biology', 2),
(5, 'Flash', 'Thompson', '2000-12-20', '50 Elm Street, Brooklyn, NY', '555-3456', 'flash.thompson@university.edu', 1, 'Physical Education', 4),
(6, 'Felicia', 'Hardy', '2001-11-11', '60 Maple Avenue, Manhattan, NY', '555-6543', 'felicia.hardy@university.edu', 1, 'Art', 3),
(7, 'Miles', 'Morales', '2002-05-02', '70 Oak Street, Brooklyn, NY', '555-7890', 'miles.morales@university.edu', 1, 'Computer Science', 1),
(8, 'Ben', 'Reilly', '2000-09-09', '80 Pine Street, Queens, NY', '555-0987', 'ben.reilly@university.edu', 1, 'Chemistry', 4),
(9, 'May', 'Parker', '2001-03-03', '90 Cedar Avenue, Forest Hills, NY', '555-2345', 'may.parker@university.edu', 1, 'Nursing', 2),
(10, 'Norman', 'Osborn', '2000-07-07', '100 Birch Street, Manhattan, NY', '555-6789', 'norman.osborn@university.edu', 1, 'Engineering', 4);

INSERT INTO Department (DepartmentID, DepartmentName) VALUES
(1, 'Physics'),
(2, 'Theater Arts'),
(3, 'Business'),
(4, 'Biology'),
(5, 'Physical Education'),
(6, 'Art'),
(7, 'Computer Science'),
(8, 'Chemistry'),
(9, 'Nursing'),
(10, 'Engineering');

INSERT INTO Professor (ProfessorID, FirstName, LastName, Email, OfficeLocation, PhoneNumber, DepartmentID) VALUES
(1, 'Curt', 'Connors', 'curt.connors@university.edu', 'Room 101, Science Building', '555-1111', 1),
(2, 'Otto', 'Octavius', 'otto.octavius@university.edu', 'Room 102, Science Building', '555-2222', 2),
(3, 'Max', 'Dillon', 'max.dillon@university.edu', 'Room 103, Engineering Building', '555-3333', 3),
(4, 'Adrian', 'Toomes', 'adrian.toomes@university.edu', 'Room 104, Business Building', '555-4444', 4),
(5, 'Quentin', 'Beck', 'quentin.beck@university.edu', 'Room 105, Arts Building', '555-5555', 5),
(6, 'Miles', 'Warren', 'miles.warren@university.edu', 'Room 106, Biology Building', '555-6666', 6),
(7, 'Aaron', 'Davis', 'aaron.davis@university.edu', 'Room 107, Computer Science Building', '555-7777', 7),
(8, 'Herman', 'Schultz', 'herman.schultz@university.edu', 'Room 108, Physics Building', '555-8888', 8),
(9, 'Mac', 'Gargan', 'mac.gargan@university.edu', 'Room 109, Physical Education Building', '555-9999', 9),
(10, 'Flint', 'Marko', 'flint.marko@university.edu', 'Room 110, Engineering Building', '555-0000', 10);

INSERT INTO Course (CourseCode, CourseName, DepartmentID, Credits) VALUES
('PHY101', 'Introduction to Physics', 1, 3),
('THA201', 'Acting Basics', 2, 3),
('BUS301', 'Business Management', 3, 3),
('BIO101', 'General Biology', 4, 3),
('PED101', 'Physical Fitness', 5, 2),
('ART101', 'Introduction to Art', 6, 3),
('CSC101', 'Computer Programming', 7, 4),
('CHE101', 'General Chemistry', 8, 3),
('NUR101', 'Nursing Fundamentals', 9, 3),
('ENG101', 'Introduction to Engineering', 10, 4);

INSERT INTO CoursePrerequisite (CourseCode, PrerequisiteCode) VALUES
('PHY101', 'ENG101'),
('THA201', 'ART101'),
('BUS301', 'ENG101'),
('BIO101', 'CHE101'),
('PED101', 'BIO101'),
('ART101', 'ENG101'),
('CSC101', 'ENG101'),
('CHE101', 'PHY101'),
('NUR101', 'BIO101'),
('ENG101', 'PHY101');

INSERT INTO Semester (SemesterID, SemesterName) VALUES
(1, 'Fall 2024'),
(2, 'Spring 2025'),
(3, 'Summer 2025'),
(4, 'Fall 2025'),
(5, 'Spring 2026'),
(6, 'Summer 2026'),
(7, 'Fall 2026'),
(8, 'Spring 2027'),
(9, 'Summer 2027'),
(10, 'Fall 2027');

INSERT INTO Classroom (RoomNumber, Building, Capacity) VALUES
('101', 'Science Building', 30),
('102', 'Science Building', 30),
('201', 'Arts Building', 25),
('202', 'Arts Building', 25),
('301', 'Business Building', 40),
('302', 'Business Building', 40),
('401', 'Engineering Building', 35),
('402', 'Engineering Building', 35),
('501', 'Physical Education Building', 50),
('502', 'Physical Education Building', 50);

INSERT INTO ProfessorCourse (ProfessorID, CourseCode, SemesterID, AcademicYear, ClassroomRoomNumber) VALUES
(1, 'BIO101', 1, 2024, '101'),
(2, 'CHE101', 1, 2024, '102'),
(3, 'ENG101', 1, 2024, '401'),
(4, 'BUS301', 1, 2024, '301'),
(5, 'ART101', 1, 2024, '201'),
(6, 'BIO101', 2, 2025, '101'),
(7, 'CSC101', 2, 2025, '402'),
(8, 'PHY101', 2, 2025, '101'),
(9, 'PED101', 2, 2025, '501'),
(10, 'ENG101', 2, 2025, '401');

INSERT INTO StudentEnrollment (StudentID, CourseCode, SemesterID, AcademicYear, EnrollmentDate, FinalGrade, GPA) VALUES
(1, 'PHY101', 1, 2024, '2024-09-01', 'A', 4.00),
(2, 'THA201', 1, 2024, '2024-09-01', 'B+', 3.33),
(3, 'BUS301', 1, 2024, '2024-09-01', 'B', 3.00),
(4, 'BIO101', 1, 2024, '2024-09-01', 'A-', 3.67),
(5, 'PED101', 1, 2024, '2024-09-01', 'C+', 2.33),
(6, 'ART101', 1, 2024, '2024-09-01', 'B-', 2.67),
(7, 'CSC101', 1, 2024, '2024-09-01', 'A', 4.00),
(8, 'CHE101', 1, 2024, '2024-09-01', 'B+', 3.33),
(9, 'NUR101', 1, 2024, '2024-09-01', 'A', 4.00),
(10, 'ENG101', 1, 2024, '2024-09-01', 'B', 3.00);

INSERT INTO Fee (FeeID, StudentID, SemesterID, TotalAmount, AmountPaid, DueDate, PaymentDate, PaymentMethod) VALUES
(1, 1, 1, 5000.00, 5000.00, '2024-09-15', '2024-09-01', 'Credit Card'),
(2, 2, 1, 4500.00, 4500.00, '2024-09-15', '2024-09-01', 'Credit Card'),
(3, 3, 1, 4800.00, 4800.00, '2024-09-15', '2024-09-01', 'Credit Card'),
(4, 4, 1, 4700.00, 4700.00, '2024-09-15', '2024-09-01', 'Credit Card'),
(5, 5, 1, 4600.00, 4600.00, '2024-09-15', '2024-09-01', 'Credit Card'),
(6, 6, 1, 4900.00, 4900.00, '2024-09-15', '2024-09-01', 'Credit Card'),
(7, 7, 1, 5000.00, 5000.00, '2024-09-15', '2024-09-01', 'Credit Card'),
(8, 8, 1, 4500.00, 4500.00, '2024-09-15', '2024-09-01', 'Credit Card'),
(9, 9, 1, 4800.00, 4800.00, '2024-09-15', '2024-09-01', 'Credit Card'),
(10, 10, 1, 4700.00, 4700.00, '2024-09-15', '2024-09-01', 'Credit Card');

INSERT INTO Event (EventID, EventName, EventDate, EventOrganizer, ClassroomRoomNumber) VALUES
(1, 'Science Fair', '2024-10-10', 'Peter Parker', '101'),
(2, 'Drama Play', '2024-11-15', 'Mary Jane Watson', '201'),
(3, 'Business Seminar', '2024-09-20', 'Harry Osborn', '301'),
(4, 'Biology Workshop', '2024-12-05', 'Gwen Stacy', '101'),
(5, 'Fitness Challenge', '2024-10-25', 'Flash Thompson', '501'),
(6, 'Art Exhibition', '2024-11-30', 'Felicia Hardy', '201'),
(7, 'Coding Hackathon', '2024-12-10', 'Miles Morales', '402'),
(8, 'Chemistry Lab', '2024-09-25', 'Ben Reilly', '102'),
(9, 'Nursing Conference', '2024-11-20', 'May Parker', '101'),
(10, 'Engineering Expo', '2024-12-15', 'Norman Osborn', '401');

-- The grade points could be calculated for a specific student, or all students if you remove the WHERE clause.
SELECT 
    se.StudentID,
    AVG(gp.GradePoint) AS GPA
FROM 
    StudentEnrollment se
JOIN 
    GradePoints gp ON se.FinalGrade = gp.LetterGrade
WHERE 
    se.StudentID = 1
GROUP BY 
    se.StudentID;

------ SELECTIONS ------

-- Select all records from Student table
SELECT * FROM Student;

-- Select all records from Department table
SELECT * FROM Department;

-- Select all records from Professor table
SELECT * FROM Professor;

-- Select all records from Course table
SELECT * FROM Course;

-- Select all records from CoursePrerequisite table
SELECT * FROM CoursePrerequisite;

-- Select all records from Semester table
SELECT * FROM Semester;

-- Select all records from Classroom table
SELECT * FROM Classroom;

-- Select all records from ProfessorCourse table
SELECT * FROM ProfessorCourse;

-- Select all records from StudentEnrollment table
SELECT * FROM StudentEnrollment;

-- Select all records from Fee table
SELECT * FROM Fee;

-- Select all records from Event table
SELECT * FROM Event;

-- Select all records from GradePoints table
SELECT * FROM GradePoints;