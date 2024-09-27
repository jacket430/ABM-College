-- Create Patients table
CREATE TABLE Patients (
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    ContactNumber NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    EmergencyContact NVARCHAR(100) NOT NULL,
    Gender CHAR(1) NOT NULL,
    BloodType CHAR(3) NOT NULL,
    MedicalHistory NVARCHAR(MAX) NOT NULL,
    InsuranceProvider NVARCHAR(100) NOT NULL,
    PolicyNumber NVARCHAR(50) NOT NULL,
    CoverageLimits DECIMAL(10, 2) NOT NULL
);

-- Create Doctors table
CREATE TABLE Doctors (
    DoctorID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Specialization NVARCHAR(100) NOT NULL,
    ContactNumber NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    OfficeHours NVARCHAR(50) NOT NULL,
    Department NVARCHAR(100) NOT NULL
);

-- Create Nurses table
CREATE TABLE Nurses (
    NurseID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ShiftTimings NVARCHAR(50) NOT NULL,
    ContactNumber NVARCHAR(15) NOT NULL,
    AssignedWard INT NOT NULL
);

-- Create Wards table
CREATE TABLE Wards (
    WardNumber INT IDENTITY(1,1) PRIMARY KEY,
    WardType NVARCHAR(50) NOT NULL,
    FloorNumber INT NOT NULL,
    TotalBedCapacity INT NOT NULL,
    CurrentAvailability INT NOT NULL
);

-- Create Appointments table
CREATE TABLE Appointments (
    AppointmentID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    ReasonForVisit NVARCHAR(255) NOT NULL,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);

-- Create Procedures table
CREATE TABLE Procedures (
    ProcedureID INT IDENTITY(1,1) PRIMARY KEY,
    ProcedureName NVARCHAR(100) NOT NULL,
    ProcedureDate DATETIME NOT NULL,
    PerformingDoctorID INT NOT NULL,
    Cost DECIMAL(10, 2) NOT NULL,
    Results NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (PerformingDoctorID) REFERENCES Doctors(DoctorID)
);

-- Create MedicalRecords table
CREATE TABLE MedicalRecords (
    RecordID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,
    RecordDetails NVARCHAR(MAX) NOT NULL,
    RecordDate DATETIME NOT NULL,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);

-- Create Billing table
CREATE TABLE Billing (
    BillingID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT NOT NULL,
    TotalCost DECIMAL(10, 2) NOT NULL,
    InsuranceCoverage DECIMAL(10, 2) NOT NULL,
    OutOfPocketExpenses DECIMAL(10, 2) NOT NULL,
    PaymentStatus NVARCHAR(50) NOT NULL,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID)
);

-- Create Events table
CREATE TABLE Events (
    EventID INT IDENTITY(1,1) PRIMARY KEY,
    EventName NVARCHAR(100) NOT NULL,
    EventDate DATETIME NOT NULL,
    Presenters NVARCHAR(255) NOT NULL,
    Topic NVARCHAR(255) NOT NULL
);

-- Create PatientWardHistory table
CREATE TABLE PatientWardHistory (
    HistoryID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT NOT NULL,
    WardNumber INT NOT NULL,
    AdmissionDate DATETIME NOT NULL,
    DischargeDate DATETIME NOT NULL,
    ReasonForTransfer NVARCHAR(255) NOT NULL,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (WardNumber) REFERENCES Wards(WardNumber)
);

-- Create DoctorPatient relationship table
CREATE TABLE DoctorPatient (
    DoctorID INT NOT NULL,
    PatientID INT NOT NULL,
    PRIMARY KEY (DoctorID, PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID),
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID)
);

-- Create NurseWard relationship table
CREATE TABLE NurseWard (
    NurseID INT NOT NULL,
    WardNumber INT NOT NULL,
    PRIMARY KEY (NurseID, WardNumber),
    FOREIGN KEY (NurseID) REFERENCES Nurses(NurseID),
    FOREIGN KEY (WardNumber) REFERENCES Wards(WardNumber)
);

---- INSERTIONS ----

INSERT INTO Patients (FullName, DateOfBirth, Address, ContactNumber, Email, EmergencyContact, Gender, BloodType, MedicalHistory, InsuranceProvider, PolicyNumber, CoverageLimits)
VALUES 
('Peter Parker', '1995-08-10', '20 Ingram Street, Forest Hills, NY', '555-1234', 'peter.parker@example.com', 'May Parker', 'M', 'O+', 'None', 'Aetna', 'P123456', 10000.00),
('Mary Jane Watson', '1996-06-01', '22 Ingram Street, Forest Hills, NY', '555-5678', 'mj.watson@example.com', 'Anna Watson', 'F', 'A+', 'None', 'Blue Cross', 'P654321', 15000.00),
('Harry Osborn', '1995-04-15', 'Norman Osborn Mansion, NY', '555-8765', 'harry.osborn@example.com', 'Norman Osborn', 'M', 'B+', 'Asthma', 'Cigna', 'P789012', 20000.00),
('Gwen Stacy', '1996-03-10', '30 Ingram Street, Forest Hills, NY', '555-4321', 'gwen.stacy@example.com', 'George Stacy', 'F', 'AB+', 'None', 'UnitedHealth', 'P345678', 12000.00),
('Felicia Hardy', '1995-11-22', '45 Ingram Street, Forest Hills, NY', '555-8765', 'felicia.hardy@example.com', 'Walter Hardy', 'F', 'O-', 'None', 'Aetna', 'P987654', 18000.00),
('Norman Osborn', '1960-07-14', 'Norman Osborn Mansion, NY', '555-3456', 'norman.osborn@example.com', 'Emily Osborn', 'M', 'A-', 'Hypertension', 'Blue Cross', 'P112233', 25000.00),
('Otto Octavius', '1970-05-20', '50 Ingram Street, Forest Hills, NY', '555-6543', 'otto.octavius@example.com', 'Unknown', 'M', 'B-', 'Diabetes', 'Cigna', 'P445566', 22000.00),
('Eddie Brock', '1985-12-18', '60 Ingram Street, Forest Hills, NY', '555-7890', 'eddie.brock@example.com', 'Carl Brock', 'M', 'AB-', 'None', 'UnitedHealth', 'P778899', 17000.00),
('Flash Thompson', '1995-01-01', '70 Ingram Street, Forest Hills, NY', '555-0987', 'flash.thompson@example.com', 'Harrison Thompson', 'M', 'O+', 'None', 'Aetna', 'P334455', 16000.00),
('J. Jonah Jameson', '1950-03-15', 'Daily Bugle Office, NY', '555-1122', 'jj.jameson@example.com', 'Joan Jameson', 'M', 'A+', 'None', 'Blue Cross', 'P667788', 30000.00);

INSERT INTO Doctors (Name, Specialization, ContactNumber, Email, OfficeHours, Department)
VALUES 
('Curt Connors', 'Orthopedics', '555-2233', 'curt.connors@example.com', '9 AM - 5 PM', 'Orthopedics'),
('Stephen Strange', 'Neurology', '555-3344', 'stephen.strange@example.com', '10 AM - 6 PM', 'Neurology'),
('Bruce Banner', 'Radiology', '555-4455', 'bruce.banner@example.com', '8 AM - 4 PM', 'Radiology'),
('Reed Richards', 'Cardiology', '555-5566', 'reed.richards@example.com', '11 AM - 7 PM', 'Cardiology'),
('Henry Pym', 'Pediatrics', '555-6677', 'henry.pym@example.com', '7 AM - 3 PM', 'Pediatrics'),
('Charles Xavier', 'Psychiatry', '555-7788', 'charles.xavier@example.com', '12 PM - 8 PM', 'Psychiatry'),
('Hank McCoy', 'Genetics', '555-8899', 'hank.mccoy@example.com', '6 AM - 2 PM', 'Genetics'),
('Jane Foster', 'Oncology', '555-9900', 'jane.foster@example.com', '1 PM - 9 PM', 'Oncology'),
('Jean Grey', 'Dermatology', '555-1010', 'jean.grey@example.com', '2 PM - 10 PM', 'Dermatology'),
('Stephen Vincent', 'General Surgery', '555-2020', 'stephen.vincent@example.com', '3 PM - 11 PM', 'General Surgery');

INSERT INTO Nurses (Name, ShiftTimings, ContactNumber, AssignedWard)
VALUES 
('Betty Brant', 'Day', '555-3030', 1),
('Liz Allan', 'Night', '555-4040', 2),
('Glory Grant', 'Day', '555-5050', 3),
('Debra Whitman', 'Night', '555-6060', 4),
('Anna Watson', 'Day', '555-7070', 5),
('Martha Connors', 'Night', '555-8080', 6),
('May Parker', 'Day', '555-9090', 7),
('Sally Avril', 'Night', '555-1111', 8),
('Randy Robertson', 'Day', '555-2222', 9),
('Ned Leeds', 'Night', '555-3333', 10);

INSERT INTO Wards (WardType, FloorNumber, TotalBedCapacity, CurrentAvailability)
VALUES 
('General', 1, 20, 15),
('ICU', 2, 10, 5),
('Pediatrics', 3, 15, 10),
('Maternity', 4, 12, 8),
('Surgery', 5, 18, 12),
('Orthopedics', 6, 14, 9),
('Neurology', 7, 16, 11),
('Oncology', 8, 10, 6),
('Cardiology', 9, 20, 14),
('Psychiatry', 10, 8, 4);

INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, ReasonForVisit)
VALUES 
(1, 1, '2023-10-01 10:00:00', 'Routine Checkup'),
(2, 2, '2023-10-02 11:00:00', 'Headache'),
(3, 3, '2023-10-03 12:00:00', 'X-ray'),
(4, 4, '2023-10-04 13:00:00', 'Heart Checkup'),
(5, 5, '2023-10-05 14:00:00', 'Child Vaccination'),
(6, 6, '2023-10-06 15:00:00', 'Mental Health'),
(7, 7, '2023-10-07 16:00:00', 'Genetic Testing'),
(8, 8, '2023-10-08 17:00:00', 'Cancer Screening'),
(9, 9, '2023-10-09 18:00:00', 'Skin Rash'),
(10, 10, '2023-10-10 19:00:00', 'Surgery Consultation');

INSERT INTO Procedures (ProcedureName, ProcedureDate, PerformingDoctorID, Cost, Results)
VALUES 
('Knee Surgery', '2023-10-01 10:00:00', 1, 5000.00, 'Successful'),
('Brain MRI', '2023-10-02 11:00:00', 2, 3000.00, 'Normal'),
('Chest X-ray', '2023-10-03 12:00:00', 3, 200.00, 'Clear'),
('Heart Bypass', '2023-10-04 13:00:00', 4, 15000.00, 'Successful'),
('Child Vaccination', '2023-10-05 14:00:00', 5, 100.00, 'Completed'),
('Therapy Session', '2023-10-06 15:00:00', 6, 200.00, 'Ongoing'),
('Genetic Analysis', '2023-10-07 16:00:00', 7, 1000.00, 'Normal'),
('Chemotherapy', '2023-10-08 17:00:00', 8, 5000.00, 'Ongoing'),
('Skin Biopsy', '2023-10-09 18:00:00', 9, 300.00, 'Benign'),
('Appendectomy', '2023-10-10 19:00:00', 10, 7000.00, 'Successful');

INSERT INTO MedicalRecords (PatientID, DoctorID, RecordDetails, RecordDate)
VALUES 
(1, 1, 'Routine checkup, all vitals normal.', '2023-10-01 10:00:00'),
(2, 2, 'Complaints of headache, prescribed medication.', '2023-10-02 11:00:00'),
(3, 3, 'X-ray taken, no fractures.', '2023-10-03 12:00:00'),
(4, 4, 'Heart checkup, minor irregularities.', '2023-10-04 13:00:00'),
(5, 5, 'Child vaccination completed.', '2023-10-05 14:00:00'),
(6, 6, 'Therapy session, patient showing improvement.', '2023-10-06 15:00:00'),
(7, 7, 'Genetic testing, no abnormalities.', '2023-10-07 16:00:00'),
(8, 8, 'Cancer screening, no signs of cancer.', '2023-10-08 17:00:00'),
(9, 9, 'Skin rash, prescribed ointment.', '2023-10-09 18:00:00'),
(10, 10, 'Surgery consultation, scheduled for next week.', '2023-10-10 19:00:00');

INSERT INTO Billing (PatientID, TotalCost, InsuranceCoverage, OutOfPocketExpenses, PaymentStatus)
VALUES 
(1, 100.00, 80.00, 20.00, 'Paid'),
(2, 200.00, 150.00, 50.00, 'Pending'),
(3, 300.00, 250.00, 50.00, 'Paid'),
(4, 400.00, 300.00, 100.00, 'Pending'),
(5, 500.00, 400.00, 100.00, 'Paid'),
(6, 600.00, 500.00, 100.00, 'Pending'),
(7, 700.00, 600.00, 100.00, 'Paid'),
(8, 800.00, 700.00, 100.00, 'Pending'),
(9, 900.00, 800.00, 100.00, 'Paid'),
(10, 1000.00, 900.00, 100.00, 'Pending');

INSERT INTO Events (EventName, EventDate, Presenters, Topic)
VALUES 
('Health Fair', '2023-10-01 10:00:00', 'Peter Parker, Mary Jane Watson', 'General Health'),
('Cancer Awareness', '2023-10-02 11:00:00', 'Harry Osborn, Gwen Stacy', 'Cancer Prevention'),
('Heart Health', '2023-10-03 12:00:00', 'Felicia Hardy, Norman Osborn', 'Heart Disease'),
('Mental Health', '2023-10-04 13:00:00', 'Otto Octavius, Eddie Brock', 'Mental Wellness'),
('Child Care', '2023-10-05 14:00:00', 'Flash Thompson, J. Jonah Jameson', 'Pediatric Care'),
('Nutrition', '2023-10-06 15:00:00', 'Curt Connors, Stephen Strange', 'Healthy Eating'),
('Fitness', '2023-10-07 16:00:00', 'Bruce Banner, Reed Richards', 'Exercise'),
('Vaccination', '2023-10-08 17:00:00', 'Henry Pym, Charles Xavier', 'Immunization'),
('Genetics', '2023-10-09 18:00:00', 'Hank McCoy, Jane Foster', 'Genetic Testing'),
('Surgery', '2023-10-10 19:00:00', 'Jean Grey, Stephen Vincent', 'Surgical Procedures');

INSERT INTO PatientWardHistory (PatientID, WardNumber, AdmissionDate, DischargeDate, ReasonForTransfer)
VALUES 
(1, 1, '2023-10-01 10:00:00', '2023-10-02 10:00:00', 'Routine Checkup'),
(2, 2, '2023-10-02 11:00:00', '2023-10-03 11:00:00', 'Headache'),
(3, 3, '2023-10-03 12:00:00', '2023-10-04 12:00:00', 'X-ray'),
(4, 4, '2023-10-04 13:00:00', '2023-10-05 13:00:00', 'Heart Checkup'),
(5, 5, '2023-10-05 14:00:00', '2023-10-06 14:00:00', 'Child Vaccination'),
(6, 6, '2023-10-06 15:00:00', '2023-10-07 15:00:00', 'Mental Health'),
(7, 7, '2023-10-07 16:00:00', '2023-10-08 16:00:00', 'Genetic Testing'),
(8, 8, '2023-10-08 17:00:00', '2023-10-09 17:00:00', 'Cancer Screening'),
(9, 9, '2023-10-09 18:00:00', '2023-10-10 18:00:00', 'Skin Rash'),
(10, 10, '2023-10-10 19:00:00', '2023-10-11 19:00:00', 'Surgery Consultation');

INSERT INTO DoctorPatient (DoctorID, PatientID)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

INSERT INTO NurseWard (NurseID, WardNumber)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

------ SELECTIONS ------

-- Select all records from Patients table
SELECT * FROM Patients;

-- Select all records from Doctors table
SELECT * FROM Doctors;

-- Select all records from Nurses table
SELECT * FROM Nurses;

-- Select all records from Wards table
SELECT * FROM Wards;

-- Select all records from Appointments table
SELECT * FROM Appointments;

-- Select all records from Procedures table
SELECT * FROM Procedures;

-- Select all records from MedicalRecords table
SELECT * FROM MedicalRecords;

-- Select all records from Billing table
SELECT * FROM Billing;

-- Select all records from Events table
SELECT * FROM Events;

-- Select all records from PatientWardHistory table
SELECT * FROM PatientWardHistory;

-- Select all records from DoctorPatient table
SELECT * FROM DoctorPatient;

-- Select all records from NurseWard table
SELECT * FROM NurseWard;
