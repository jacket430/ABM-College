CREATE TABLE Students(
    StudentID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    EnrollmentDate DATE NOT NULL DEFAULT GETDATE() -- Enrollment date sets to today's date by default, can be changed. 
);

CREATE TABLE Exams(
    ExamID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Date DATE NOT NULL
);

CREATE TABLE Questions(
    QuestionID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ExamID INT NOT NULL,
    Text NVARCHAR(MAX) NOT NULL,
    CONSTRAINT FK_Questions_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID) -- Constrained foreign key linking ExamID to Exams table.
);

CREATE TABLE Results(
    ResultID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    StudentID INT NOT NULL,
    ExamID INT NOT NULL,
    QuestionID INT NOT NULL,
    Answer NVARCHAR(MAX) NOT NULL,
    Marks INT NOT NULL,
    CONSTRAINT FK_Results_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID), -- Constrained foreign key linking StudentID to Students.
    CONSTRAINT FK_Results_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID), -- Constrained foreign key linking ExamID to Exams.
    CONSTRAINT FK_Results_Questions FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID), -- Constrained foreign key linking QuestionID to Questions.
);