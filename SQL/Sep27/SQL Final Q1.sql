--                  QUESTION 1

--              1.      Entity Requirements

--              1.1     Countries Table
CREATE TABLE Countries (
    country_id INT IDENTITY(1,1) PRIMARY KEY,
    country_name NVARCHAR(100) NOT NULL,
    region NVARCHAR(50) NOT NULL,
    customs_rules TEXT NOT NULL,
    time_zone NVARCHAR(50) NOT NULL
);

--              1.2     Logistics_Hubs Table
CREATE TABLE Logistics_Hubs (
    hub_id INT IDENTITY(1,1) PRIMARY KEY,
    hub_name NVARCHAR(100) NOT NULL,
    country_id INT NOT NULL,
    hub_type NVARCHAR(50) NOT NULL,
    capacity INT NOT NULL,
    time_zone NVARCHAR(50) NOT NULL,
    FOREIGN KEY (country_id) REFERENCES Countries(country_id)
);

--              1.3     Transport_Vehicles Table
CREATE TABLE Transport_Vehicles (
    vehicle_id INT IDENTITY(1,1) PRIMARY KEY,
    vehicle_type NVARCHAR(50) NOT NULL,
    max_weight_capacity DECIMAL(18, 2) NOT NULL,
    hub_id INT NOT NULL,
    status NVARCHAR(50) NOT NULL,
    current_location INT NOT NULL,
    FOREIGN KEY (hub_id) REFERENCES Logistics_Hubs(hub_id),
    FOREIGN KEY (current_location) REFERENCES Logistics_Hubs(hub_id)
);

--              1.4     Shipments Table
CREATE TABLE Shipments (
    shipment_id INT IDENTITY(1,1) PRIMARY KEY,
    tracking_number NVARCHAR(100) UNIQUE NOT NULL,
    shipment_type NVARCHAR(50) NOT NULL,
    origin_hub_id INT NOT NULL,
    destination_hub_id INT NOT NULL,
    dispatch_date DATETIME NOT NULL,
    expected_arrival_date DATETIME NOT NULL,
    current_status NVARCHAR(50) NOT NULL,
    FOREIGN KEY (origin_hub_id) REFERENCES Logistics_Hubs(hub_id),
    FOREIGN KEY (destination_hub_id) REFERENCES Logistics_Hubs(hub_id)
);

--              1.5     Goods Table
CREATE TABLE Goods (
    goods_id INT IDENTITY(1,1) PRIMARY KEY,
    shipment_id INT NOT NULL,
    description NVARCHAR(255) NOT NULL,
    weight DECIMAL(18, 2) NOT NULL,
    customs_clearance_status NVARCHAR(50) NOT NULL,
    FOREIGN KEY (shipment_id) REFERENCES Shipments(shipment_id)
);

--              1.6     Routes Table
CREATE TABLE Routes (
    route_id INT IDENTITY(1,1) PRIMARY KEY,
    origin_hub_id INT NOT NULL,
    destination_hub_id INT NOT NULL,
    vehicle_id INT NOT NULL,
    distance DECIMAL(18, 2) NOT NULL,
    estimated_time DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (origin_hub_id) REFERENCES Logistics_Hubs(hub_id),
    FOREIGN KEY (destination_hub_id) REFERENCES Logistics_Hubs(hub_id),
    FOREIGN KEY (vehicle_id) REFERENCES Transport_Vehicles(vehicle_id)
);

--              1.7     Schedules Table
CREATE TABLE Schedules (
    schedule_id INT IDENTITY(1,1) PRIMARY KEY,
    vehicle_id INT NOT NULL,
    route_id INT NOT NULL,
    departure_time DATETIME NOT NULL,
    arrival_time DATETIME NOT NULL,
    status NVARCHAR(50) NOT NULL,
    FOREIGN KEY (vehicle_id) REFERENCES Transport_Vehicles(vehicle_id),
    FOREIGN KEY (route_id) REFERENCES Routes(route_id)
);



--                      INSERTIONS

INSERT INTO Countries (country_name, region, customs_rules, time_zone) VALUES
('United States', 'North America', 'Standard US customs rules', 'UTC-5'),
('Canada', 'North America', 'Standard Canadian customs rules', 'UTC-5'),
('Germany', 'Europe', 'Standard EU customs rules', 'UTC+1'),
('France', 'Europe', 'Standard EU customs rules', 'UTC+1'),
('Japan', 'Asia', 'Standard Japanese customs rules', 'UTC+9'),
('China', 'Asia', 'Standard Chinese customs rules', 'UTC+8'),
('Brazil', 'South America', 'Standard Brazilian customs rules', 'UTC-3'),
('Australia', 'Oceania', 'Standard Australian customs rules', 'UTC+10'),
('India', 'Asia', 'Standard Indian customs rules', 'UTC+5:30'),
('South Africa', 'Africa', 'Standard South African customs rules', 'UTC+2');

INSERT INTO Logistics_Hubs (hub_name, country_id, hub_type, capacity, time_zone) VALUES
('First Airport', 1, 'AirPort', 10000, 'UTC-5'),
('Second Airport', 2, 'AirPort', 12000, 'UTC-5'),
('First Port', 3, 'SeaPort', 8000, 'UTC+1'),
('Second Port', 4, 'SeaPort', 15000, 'UTC+1'),
('First Warehouse', 5, 'Warehouse', 5000, 'UTC+1'),
('Third Airport', 6, 'AirPort', 20000, 'UTC+9'),
('Third Port', 7, 'SeaPort', 18000, 'UTC+8'),
('Fourth Port', 8, 'SeaPort', 9000, 'UTC-3'),
('Second Warehouse', 9, 'Warehouse', 7000, 'UTC+10'),
('Fifth Port', 10, 'SeaPort', 11000, 'UTC+5:30');

INSERT INTO Transport_Vehicles (vehicle_type, max_weight_capacity, hub_id, status, current_location) VALUES
('Truck', 20000, 1, 'Available', 1),
('Cargo Ship', 500000, 3, 'Available', 3),
('Cargo Plane', 100000, 3, 'In transit', 2),
('Truck', 15000, 4, 'Available', 5),
('Cargo Ship', 600000, 5, 'Under maintenance', 4),
('Cargo Plane', 120000, 6, 'Available', 6),
('Truck', 18000, 7, 'In transit', 7),
('Cargo Ship', 550000, 8, 'Available', 8),
('Cargo Plane', 110000, 9, 'Available', 9),
('Truck', 16000, 10, 'Available', 10);

INSERT INTO Shipments (tracking_number, shipment_type, origin_hub_id, destination_hub_id, dispatch_date, expected_arrival_date, current_status) VALUES
('TRK123456', 'International', 1, 5, '2024-09-01 08:00:00', '2024-09-05 12:00:00', 'In Transit'),
('TRK123457', 'Domestic', 2, 4, '2024-09-02 09:00:00', '2024-09-02 18:00:00', 'Arrived'),
('TRK123458', 'International', 3, 4, '2024-09-03 10:00:00', '2024-09-07 14:00:00', 'Customs'),
('TRK123459', 'Domestic', 4, 5, '2024-09-04 11:00:00', '2024-09-04 20:00:00', 'Delivered'),
('TRK123460', 'International', 5, 6, '2024-09-05 12:00:00', '2024-09-10 16:00:00', 'Held'),
('TRK123461', 'Domestic', 6, 7, '2024-09-06 13:00:00', '2024-09-06 22:00:00', 'In Transit'),
('TRK123462', 'International', 7, 2, '2024-09-07 14:00:00', '2024-09-12 18:00:00', 'In Transit'),
('TRK123463', 'Domestic', 8, 7, '2024-09-08 15:00:00', '2024-09-08 23:00:00', 'Arrived'),
('TRK123464', 'International', 9, 3, '2024-09-09 16:00:00', '2024-09-13 20:00:00', 'Customs'),
('TRK123465', 'Domestic', 10, 6, '2024-09-10 17:00:00', '2024-09-10 23:00:00', 'Delivered');

INSERT INTO Goods (shipment_id, description, weight, customs_clearance_status) VALUES
(1, 'Electronics', 500, 'Cleared'),
(2, 'Furniture', 1500, 'Cleared'),
(3, 'Clothing', 300, 'Pending'),
(4, 'Books', 200, 'Cleared'),
(5, 'Toys', 100, 'Held'),
(6, 'Food Items', 800, 'Cleared'),
(7, 'Machinery', 2000, 'Pending'),
(8, 'Medical Supplies', 400, 'Cleared'),
(9, 'Automobile Parts', 1200, 'Held'),
(10, 'Cosmetics', 600, 'Cleared');

INSERT INTO Routes (origin_hub_id, destination_hub_id, vehicle_id, distance, estimated_time) VALUES
(1, 2, 1, 5000, 72),
(2, 3, 2, 100, 2),
(3, 4, 3, 8000, 96),
(4, 5, 4, 50, 1),
(5, 6, 5, 7000, 84),
(6, 7, 6, 200, 3),
(7, 8, 7, 9000, 108),
(8, 9, 8, 150, 4),
(9, 10, 9, 6000, 72),
(10, 1, 10, 100, 2);

INSERT INTO Schedules (vehicle_id, route_id, departure_time, arrival_time, status) VALUES
(1, 1, '2024-09-01 08:00:00', '2024-09-05 08:00:00', 'Completed'),
(2, 2, '2024-09-02 09:00:00', '2024-09-02 11:00:00', 'Completed'),
(3, 3, '2024-09-03 10:00:00', '2024-09-07 10:00:00', 'In Transit'),
(4, 4, '2024-09-04 11:00:00', '2024-09-04 12:00:00', 'Completed'),
(5, 5, '2024-09-05 12:00:00', '2024-09-10 12:00:00', 'In Transit'),
(6, 6, '2024-09-06 13:00:00', '2024-09-06 16:00:00', 'Completed'),
(7, 7, '2024-09-07 14:00:00', '2024-09-12 14:00:00', 'In Transit'),
(8, 8, '2024-09-08 15:00:00', '2024-09-08 19:00:00', 'Completed'),
(9, 9, '2024-09-09 16:00:00', '2024-09-13 16:00:00', 'In Transit'),
(10, 10, '2024-09-10 17:00:00', '2024-09-10 19:00:00', 'Completed');


--          2.      ADVANCED REQUIREMENTS

--          2.1     Dynamic Time Zones
-- This was a bit of a pain to get working properly, but it displays both the adjusted and original time zones.

SELECT 
    s.shipment_id,
    s.tracking_number,
    s.dispatch_date,
    DATEADD(HOUR, COALESCE(r.estimated_time, 0), s.dispatch_date) AS estimated_arrival_time_utc,
    DATEADD(
        MINUTE, 
        COALESCE(r.estimated_time, 0) * 60 + 
        (
            (CAST(SUBSTRING(d.time_zone, 4, 2) AS INT) * 60 + CAST(SUBSTRING(d.time_zone, 7, 2) AS INT)) - 
            (CAST(SUBSTRING(o.time_zone, 4, 2) AS INT) * 60 + CAST(SUBSTRING(o.time_zone, 7, 2) AS INT))
        ), 
        s.dispatch_date
    ) AS estimated_arrival_time_local
FROM 
    Shipments s
LEFT JOIN 
    Routes r ON s.origin_hub_id = r.origin_hub_id AND s.destination_hub_id = r.destination_hub_id
LEFT JOIN 
    Logistics_Hubs o ON s.origin_hub_id = o.hub_id
LEFT JOIN 
    Logistics_Hubs d ON s.destination_hub_id = d.hub_id;


--          2.2     Recursive Shipment Routes
-- Displays shipment routes, including stops along the way.

WITH ShipmentPath AS (
    SELECT
        s.shipment_id,
        s.tracking_number,
        s.origin_hub_id,
        s.destination_hub_id,
        s.origin_hub_id AS current_hub_id,
        0 AS step,
        CAST(s.origin_hub_id AS NVARCHAR(255)) AS path,
        CAST(0 AS DECIMAL(18, 2)) AS total_distance
    FROM
        Shipments s

    UNION ALL

    SELECT
        sp.shipment_id,
        sp.tracking_number,
        sp.origin_hub_id,
        sp.destination_hub_id,
        r.destination_hub_id AS current_hub_id,
        sp.step + 1 AS step,
        CAST(sp.path + ' -> ' + CAST(r.destination_hub_id AS NVARCHAR(255)) AS NVARCHAR(255)) AS path,
        CAST(sp.total_distance + r.distance AS DECIMAL(18, 2)) AS total_distance
    FROM
        ShipmentPath sp
    JOIN
        Routes r ON sp.current_hub_id = r.origin_hub_id
    WHERE
        sp.current_hub_id <> sp.destination_hub_id
)
SELECT
    shipment_id,
    tracking_number,
    origin_hub_id,
    destination_hub_id,
    MAX(step) AS total_steps,
    MAX(path) AS full_path,
    MAX(total_distance) AS total_distance
FROM
    ShipmentPath
GROUP BY
    shipment_id,
    tracking_number,
    origin_hub_id,
    destination_hub_id
ORDER BY
    shipment_id;


--          2.3     Customs Delays
-- Displays shipments at Customs (either Pending or Held) as "Customs Processing".

SELECT 
    s.shipment_id,
    s.tracking_number,
    s.shipment_type,
    s.origin_hub_id,
    s.destination_hub_id,
    s.dispatch_date,
    s.expected_arrival_date,
    CASE 
        WHEN EXISTS (
            SELECT 1 
            FROM Goods g 
            WHERE g.shipment_id = s.shipment_id 
              AND g.customs_clearance_status IN ('Pending', 'Held')
        ) THEN 'Customs Processing'
        ELSE s.current_status
    END AS current_status
FROM 
    Shipments s;


--          2.4     Real-time Vehicle Availability
-- I wasn't sure about this one, but I was able to display which ones are available or not.

SELECT 
    tv.vehicle_id,
    tv.vehicle_type,
    tv.max_weight_capacity,
    tv.hub_id,
    tv.status,
    tv.current_location,
    CASE 
        WHEN tv.status <> 'Available' THEN 'Not Available'
        ELSE 'Available'
    END AS real_time_availability
FROM 
    Transport_Vehicles tv;


--          2.5     Capacity Constraint

SELECT 
    r.route_id,
    r.vehicle_id,
    SUM(g.weight) AS total_weight,
    tv.max_weight_capacity,
    CASE 
        WHEN SUM(g.weight) > tv.max_weight_capacity THEN 'Overloaded'
        ELSE 'Within Capacity'
    END AS capacity_status
FROM 
    Routes r
JOIN 
    Shipments s ON r.origin_hub_id = s.origin_hub_id AND r.destination_hub_id = s.destination_hub_id
JOIN 
    Goods g ON s.shipment_id = g.shipment_id
JOIN 
    Transport_Vehicles tv ON r.vehicle_id = tv.vehicle_id
GROUP BY 
    r.route_id, r.vehicle_id, tv.max_weight_capacity;


--                  Visual Studio
-- All of the queries can be used in Visual Studio with the following query:

-- string connectionString = "CONNECTION STRING HERE";
--             string query = @"
--                 PASTE QUERY HERE
--             ";

--             using (SqlConnection connection = new SqlConnection(connectionString))
--             {
--                 SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
--                 DataTable dataTable = new DataTable();
--                 dataAdapter.Fill(dataTable);
--                 dataGridView1.DataSource = dataTable;
--             }
--

-- Replacing the name of the table with whatever you want to populate.
-- I can upload a build of a program that does this, but this should
-- get the idea across.