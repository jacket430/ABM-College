-- Create Partners table
CREATE TABLE Partners (
    PartnerID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    ContactInfo NVARCHAR(255) NOT NULL,
    ContractStartDate DATE NOT NULL,
    ContractEndDate DATE NOT NULL
);

-- Create PartnerLocations table
CREATE TABLE PartnerLocations (
    LocationID INT PRIMARY KEY,
    PartnerID INT NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(100),
    Country NVARCHAR(100) NOT NULL,
    Planet NVARCHAR(50) NOT NULL,
    FOREIGN KEY (PartnerID) REFERENCES Partners(PartnerID)
);

-- Create Products table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Weight DECIMAL(10, 2) NOT NULL,
    Dimensions NVARCHAR(100) NOT NULL,
    Material NVARCHAR(255) NOT NULL,
    ManufacturerID INT NOT NULL,
    ManufactureDate DATE NOT NULL,
    ExpirationDate DATE,
    FOREIGN KEY (ManufacturerID) REFERENCES Partners(PartnerID)
);

-- Create ProductTests table
CREATE TABLE ProductTests (
    TestID INT PRIMARY KEY,
    ProductID INT NOT NULL,
    TestType NVARCHAR(100) NOT NULL,
    TestResult NVARCHAR(255) NOT NULL,
    TestDate DATE NOT NULL,
    TestFacility NVARCHAR(255) NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create Spacecraft table
CREATE TABLE Spacecraft (
    SpacecraftID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    FuelLevel DECIMAL(5, 2) NOT NULL,
    OxygenLevel DECIMAL(5, 2) NOT NULL,
    Temperature DECIMAL(5, 2) NOT NULL
);

-- Create SpacecraftComponents table
CREATE TABLE SpacecraftComponents (
    ComponentID INT PRIMARY KEY,
    SpacecraftID INT NOT NULL,
    ProductID INT NOT NULL,
    InstallationDate DATE NOT NULL,
    InstalledBy NVARCHAR(255) NOT NULL,
    FOREIGN KEY (SpacecraftID) REFERENCES Spacecraft(SpacecraftID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create Missions table
CREATE TABLE Missions (
    MissionID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Objective NVARCHAR(255) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);

-- Create MissionPhases table
CREATE TABLE MissionPhases (
    PhaseID INT PRIMARY KEY,
    MissionID INT NOT NULL,
    PhaseName NVARCHAR(255) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    FOREIGN KEY (MissionID) REFERENCES Missions(MissionID)
);

-- Create MissionResources table
CREATE TABLE MissionResources (
    ResourceID INT PRIMARY KEY,
    PhaseID INT NOT NULL,
    ResourceType NVARCHAR(255) NOT NULL,
    Quantity INT NOT NULL,
    DeliveryDate DATE NOT NULL,
    FOREIGN KEY (PhaseID) REFERENCES MissionPhases(PhaseID)
);

-- Create CrewMembers table
CREATE TABLE CrewMembers (
    CrewID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Role NVARCHAR(255) NOT NULL,
    Skills NVARCHAR(255) NOT NULL,
    HealthStatus NVARCHAR(255) NOT NULL
);

-- Create MissionCrewAssignments table
CREATE TABLE MissionCrewAssignments (
    AssignmentID INT PRIMARY KEY,
    MissionID INT NOT NULL,
    CrewID INT NOT NULL,
    Role NVARCHAR(255) NOT NULL,
    FOREIGN KEY (MissionID) REFERENCES Missions(MissionID),
    FOREIGN KEY (CrewID) REFERENCES CrewMembers(CrewID)
);

-- Create InterplanetaryTransport table
CREATE TABLE InterplanetaryTransport (
    TransportID INT PRIMARY KEY,
    SpacecraftID INT NOT NULL,
    DeparturePlanet NVARCHAR(50) NOT NULL,
    ArrivalPlanet NVARCHAR(50) NOT NULL,
    LaunchWindowStart DATE NOT NULL,
    LaunchWindowEnd DATE NOT NULL,
    ExpectedArrivalDate DATE NOT NULL,
    FOREIGN KEY (SpacecraftID) REFERENCES Spacecraft(SpacecraftID)
);

-- Create FuelStations table
CREATE TABLE FuelStations (
    StationID INT PRIMARY KEY,
    Location NVARCHAR(255) NOT NULL,
    Planet NVARCHAR(50) NOT NULL,
    FuelType NVARCHAR(50) NOT NULL,
    FuelQuantity DECIMAL(10, 2) NOT NULL
);

-- Create SecurityRoles table
CREATE TABLE SecurityRoles (
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(255) NOT NULL
);

-- Create Users table
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(255) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    RoleID INT NOT NULL,
    FOREIGN KEY (RoleID) REFERENCES SecurityRoles(RoleID)
);

-- Create UserAccessLogs table
CREATE TABLE UserAccessLogs (
    LogID INT PRIMARY KEY,
    UserID INT NOT NULL,
    AccessTime DATETIME NOT NULL,
    Action NVARCHAR(255) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Create ContingencyPlans table
CREATE TABLE ContingencyPlans (
    PlanID INT PRIMARY KEY,
    MissionID INT NOT NULL,
    ContingencyType NVARCHAR(255) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    BackupPlan NVARCHAR(255) NOT NULL,
    FOREIGN KEY (MissionID) REFERENCES Missions(MissionID)
);

------ INSERTIONS ------

INSERT INTO Partners (PartnerID, Name, Type, ContactInfo, ContractStartDate, ContractEndDate) VALUES
(1, 'SpaceX', 'Manufacturer', 'contact@spacex.com', '2023-01-01', '2025-12-31'),
(2, 'NASA', 'Supplier', 'contact@nasa.gov', '2022-01-01', '2024-12-31'),
(3, 'ESA', 'Logistics Provider', 'contact@esa.int', '2023-06-01', '2026-05-31'),
(4, 'Blue Origin', 'Manufacturer', 'contact@blueorigin.com', '2023-03-01', '2025-02-28'),
(5, 'Roscosmos', 'Supplier', 'contact@roscosmos.ru', '2022-07-01', '2024-06-30');

INSERT INTO PartnerLocations (LocationID, PartnerID, Address, City, State, Country, Planet) VALUES
(1, 1, '1 Rocket Road', 'Hawthorne', 'CA', 'USA', 'Earth'),
(2, 2, '300 E Street SW', 'Washington', 'DC', 'USA', 'Earth'),
(3, 3, '8-10 rue Mario-Nikis', 'Paris', '', 'France', 'Earth'),
(4, 4, '21218 76th Ave S', 'Kent', 'WA', 'USA', 'Earth'),
(5, 5, '42 Schepkina Street', 'Moscow', '', 'Russia', 'Earth');

INSERT INTO Products (ProductID, Name, Weight, Dimensions, Material, ManufacturerID, ManufactureDate, ExpirationDate) VALUES
(1, 'Falcon 9', 549054.00, '70m x 3.7m', 'Aluminum-Lithium Alloy', 1, '2023-01-01', NULL),
(2, 'Dragon Capsule', 4200.00, '4.4m x 3.66m', 'Carbon Composite', 1, '2023-02-01', NULL),
(3, 'SLS Rocket', 2600000.00, '98m x 8.4m', 'Aluminum Alloy', 2, '2023-03-01', NULL),
(4, 'Orion Capsule', 26000.00, '5.02m x 3.3m', 'Aluminum-Lithium Alloy', 2, '2023-04-01', NULL),
(5, 'Ariane 5', 777000.00, '53m x 5.4m', 'Aluminum Alloy', 3, '2023-05-01', NULL);

INSERT INTO ProductTests (TestID, ProductID, TestType, TestResult, TestDate, TestFacility) VALUES
(1, 1, 'Pressure', 'Pass', '2023-01-15', 'SpaceX Facility'),
(2, 2, 'Radiation', 'Pass', '2023-02-15', 'SpaceX Facility'),
(3, 3, 'Temperature', 'Pass', '2023-03-15', 'NASA Facility'),
(4, 4, 'Pressure', 'Pass', '2023-04-15', 'NASA Facility'),
(5, 5, 'Radiation', 'Pass', '2023-05-15', 'ESA Facility');

INSERT INTO Spacecraft (SpacecraftID, Name, Type, Status, FuelLevel, OxygenLevel, Temperature) VALUES
(1, 'Falcon 9', 'Cargo', 'Active', 100.00, 100.00, 22.00),
(2, 'Dragon Capsule', 'Crewed', 'Active', 100.00, 100.00, 22.00),
(3, 'SLS Rocket', 'Cargo', 'Active', 100.00, 100.00, 22.00),
(4, 'Orion Capsule', 'Crewed', 'Active', 100.00, 100.00, 22.00),
(5, 'Ariane 5', 'Cargo', 'Active', 100.00, 100.00, 22.00);

INSERT INTO SpacecraftComponents (ComponentID, SpacecraftID, ProductID, InstallationDate, InstalledBy) VALUES
(1, 1, 1, '2023-01-01', 'SpaceX Technician'),
(2, 2, 2, '2023-02-01', 'SpaceX Technician'),
(3, 3, 3, '2023-03-01', 'NASA Technician'),
(4, 4, 4, '2023-04-01', 'NASA Technician'),
(5, 5, 5, '2023-05-01', 'ESA Technician');

INSERT INTO Missions (MissionID, Name, Objective, StartDate, EndDate) VALUES
(1, 'Mars Colonization', 'Establish a colony on Mars', '2024-01-01', '2026-12-31'),
(2, 'Lunar Rover Deployment', 'Deploy a rover on the Moon', '2023-01-01', '2023-12-31'),
(3, 'Satellite Launch', 'Launch a satellite into orbit', '2023-06-01', '2023-12-31'),
(4, 'ISS Resupply', 'Resupply the International Space Station', '2023-03-01', '2023-09-30'),
(5, 'Asteroid Mining', 'Mine resources from an asteroid', '2024-01-01', '2025-12-31');

INSERT INTO MissionPhases (PhaseID, MissionID, PhaseName, StartDate, EndDate) VALUES
(1, 1, 'Pre-launch', '2024-01-01', '2024-06-30'),
(2, 1, 'Transit', '2024-07-01', '2025-06-30'),
(3, 1, 'Surface Operations', '2025-07-01', '2026-12-31'),
(4, 2, 'Pre-launch', '2023-01-01', '2023-03-31'),
(5, 2, 'Transit', '2023-04-01', '2023-06-30');

INSERT INTO MissionResources (ResourceID, PhaseID, ResourceType, Quantity, DeliveryDate) VALUES
(1, 1, 'Personnel', 10, '2024-01-01'),
(2, 2, 'Equipment', 100, '2024-07-01'),
(3, 3, 'Fuel', 5000, '2025-07-01'),
(4, 4, 'Food', 200, '2023-01-01'),
(5, 5, 'Oxygen', 1000, '2023-04-01');

INSERT INTO CrewMembers (CrewID, Name, Role, Skills, HealthStatus) VALUES
(1, 'John Doe', 'Commander', 'Leadership, Navigation', 'Healthy'),
(2, 'Jane Smith', 'Engineer', 'Mechanical, Electrical', 'Healthy'),
(3, 'Alice Johnson', 'Scientist', 'Biology, Chemistry', 'Healthy'),
(4, 'Bob Brown', 'Pilot', 'Flying, Navigation', 'Healthy'),
(5, 'Charlie Davis', 'Medic', 'Medical, First Aid', 'Healthy');

INSERT INTO MissionCrewAssignments (AssignmentID, MissionID, CrewID, Role) VALUES
(1, 1, 1, 'Commander'),
(2, 1, 2, 'Engineer'),
(3, 1, 3, 'Scientist'),
(4, 2, 4, 'Pilot'),
(5, 2, 5, 'Medic');

INSERT INTO InterplanetaryTransport (TransportID, SpacecraftID, DeparturePlanet, ArrivalPlanet, LaunchWindowStart, LaunchWindowEnd, ExpectedArrivalDate) VALUES
(1, 1, 'Earth', 'Mars', '2024-01-01', '2024-01-31', '2024-07-01'),
(2, 2, 'Earth', 'Moon', '2023-01-01', '2023-01-31', '2023-02-01'),
(3, 3, 'Earth', 'Mars', '2024-01-01', '2024-01-31', '2024-07-01'),
(4, 4, 'Earth', 'ISS', '2023-03-01', '2023-03-31', '2023-04-01'),
(5, 5, 'Earth', 'Asteroid', '2024-01-01', '2024-01-31', '2024-07-01');

INSERT INTO FuelStations (StationID, Location, Planet, FuelType, FuelQuantity) VALUES
(1, 'Earth Orbit', 'Earth', 'Hydrazine', 10000.00),
(2, 'Lunar Base', 'Moon', 'Liquid Oxygen', 5000.00),
(3, 'Mars Base', 'Mars', 'Methane', 8000.00),
(4, 'ISS', 'Earth', 'Liquid Hydrogen', 6000.00),
(5, 'Asteroid Station', 'Asteroid', 'Hydrazine', 7000.00);

INSERT INTO SecurityRoles (RoleID, RoleName) VALUES
(1, 'Technician'),
(2, 'Mission Director'),
(3, 'Astronaut'),
(4, 'Engineer'),
(5, 'Scientist');

INSERT INTO Users (UserID, Username, PasswordHash, RoleID) VALUES
(1, 'jdoe', 'hashedpassword1', 1),
(2, 'jsmith', 'hashedpassword2', 2),
(3, 'ajohnson', 'hashedpassword3', 3),
(4, 'bbrown', 'hashedpassword4', 4),
(5, 'cdavis', 'hashedpassword5', 5);

INSERT INTO UserAccessLogs (LogID, UserID, AccessTime, Action) VALUES
(1, 1, '2024-01-01 10:00:00', 'Login'),
(2, 2, '2024-01-01 10:05:00', 'Login'),
(3, 3, '2024-01-01 10:10:00', 'Login'),
(4, 4, '2024-01-01 10:15:00', 'Login'),
(5, 5, '2024-01-01 10:20:00', 'Login');

INSERT INTO ContingencyPlans (PlanID, MissionID, ContingencyType, Description, BackupPlan) VALUES
(1, 1, 'Equipment Failure', 'Failure of life support system', 'Deploy backup life support system'),
(2, 2, 'Asteroid Field', 'Unexpected asteroid field detected', 'Change course to avoid asteroid field'),
(3, 3, 'Fuel Shortage', 'Insufficient fuel for return trip', 'Refuel at nearest station'),
(4, 4, 'Communication Failure', 'Loss of communication with mission control', 'Switch to backup communication system'),
(5, 5, 'Medical Emergency', 'Crew member requires urgent medical attention', 'Perform emergency medical procedure on board');
