CREATE TABLE Students(
    StudentID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    EnrollmentDate DATE NOT NULL DEFAULT GETDATE() -- Enrollment date sets to today's date by default, can be changed. 
);

CREATE TABLE Instructors(
    InstructorID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    HireDate DATE NOT NULL DEFAULT GETDATE() -- Same deal as above
);

CREATE TABLE Courses (
    CourseID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    InstructorID INT NOT NULL,
    CONSTRAINT FK_Courses_Instructors FOREIGN KEY (InstructorID) REFERENCES Instructors(InstructorID)
);

CREATE TABLE Enrollments (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    EnrollmentDate DATE NOT NULL,
    CONSTRAINT FK_Enrollments_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_Enrollments_Courses FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    CONSTRAINT UQ_Enrollments_StudentCourse UNIQUE (StudentID, CourseID) -- One student per CourseID
);

CREATE TABLE Assignments (
    AssignmentID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    CourseID INT NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    DueDate DATE NOT NULL,
    MaxScore DECIMAL(3, 2) NOT NULL,
    CONSTRAINT FK_Assignments_Courses FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Submissions (
    SubmissionID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    StudentID INT NOT NULL,
    AssignmentID INT NOT NULL,
    SubmissionDate DATE NOT NULL,
    Score DECIMAL(3, 2) NOT NULL,
    CONSTRAINT FK_Submissions_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_Submissions_Assignments FOREIGN KEY (AssignmentID) REFERENCES Assignments(AssignmentID),
    CONSTRAINT UQ_Submissions_StudentAssignment UNIQUE (StudentID, AssignmentID),
    CONSTRAINT CK_Submissions_Score_Range CHECK (Score >= 0) -- Must contain a mark
);