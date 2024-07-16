-- Create TOWN table, primary key
CREATE TABLE TOWN (
    town_id INT PRIMARY KEY IDENTITY(1,1),
    town_lat DECIMAL(9,6) NOT NULL,
    town_long DECIMAL(9,6) NOT NULL,
    town_name VARCHAR(100) NOT NULL,
    town_state VARCHAR(50) NOT NULL,
    town_avg_summer_temp DECIMAL(5,2) NOT NULL,
    town_avg_winter_temp DECIMAL(5,2) NOT NULL,
    town_population INT NOT NULL
);

-- Create POINT OF INTEREST table, primary key, foreign key to town_id
CREATE TABLE POINT_OF_INTEREST (
    poi_id INT PRIMARY KEY IDENTITY(1,1),
    poi_street_address VARCHAR(255) UNIQUE NOT NULL,
    poi_name VARCHAR(100) UNIQUE NOT NULL,
    poi_description TEXT,
    poi_open_time TIME,
    poi_close_time TIME,
    town_id INT NOT NULL,
    FOREIGN KEY (town_id) REFERENCES TOWN(town_id)
);

-- Create MANAGER table, primary key
CREATE TABLE MANAGER (
    manager_id INT PRIMARY KEY IDENTITY(1,1),
    manager_name VARCHAR(100) NOT NULL,
    manager_phone VARCHAR(20) UNIQUE NOT NULL
);

-- Create RESORT table, primary key, foreign key to town_id, manager_id
CREATE TABLE RESORT (
    resort_id INT PRIMARY KEY IDENTITY(1,1),
    resort_name VARCHAR(100) UNIQUE NOT NULL,
    resort_street_address VARCHAR(255) NOT NULL,
    resort_pcode VARCHAR(10),
    resort_star_rating DECIMAL(3,2),
    resort_livein_manager BIT,
    town_id INT NOT NULL,
    manager_id INT,
    FOREIGN KEY (town_id) REFERENCES TOWN(town_id),
    FOREIGN KEY (manager_id) REFERENCES MANAGER(manager_id)
);

-- Create CABIN table, primary key, foreign key to resort_id
CREATE TABLE CABIN (
    cabin_no INT PRIMARY KEY IDENTITY(1,1),
    resort_id INT NOT NULL,
    cabin_bedrooms INT,
    cabin_sleeping_capacity INT,
    cabin_description TEXT,
    FOREIGN KEY (resort_id) REFERENCES RESORT(resort_id)
);

-- Create GUEST table, primary key
CREATE TABLE GUEST (
    guest_no INT PRIMARY KEY IDENTITY(1,1),
    guest_name VARCHAR(100) NOT NULL,
    guest_address VARCHAR(255) NOT NULL,
    guest_email VARCHAR(100) NOT NULL,
    guest_phone VARCHAR(20) NOT NULL
);

-- Create BOOKING table, primary key, foreign keys to guest_no, cabin_no, resort_id
CREATE TABLE BOOKING (
    booking_id INT PRIMARY KEY IDENTITY(1,1),
    booking_from DATE,
    booking_to DATE,
    booking_noadults INT,
    booking_nochildren INT,
    booking_charge DECIMAL(10,2),
    guest_no INT NOT NULL,
    cabin_no INT,
    resort_id INT NOT NULL,
    FOREIGN KEY (guest_no) REFERENCES GUEST(guest_no),
    FOREIGN KEY (cabin_no) REFERENCES CABIN(cabin_no),
    FOREIGN KEY (resort_id) REFERENCES RESORT(resort_id)
);

-- Create REVIEW table, primary key, foreign keys to guest_no, resort_id
CREATE TABLE REVIEW (
    review_id INT PRIMARY KEY IDENTITY(1,1),
    review_comment TEXT,
    review_date DATE UNIQUE,
    review_rating INT CHECK (review_rating >= 1 AND review_rating <= 5),
    guest_no INT NOT NULL,
    resort_id INT NOT NULL,
    FOREIGN KEY (guest_no) REFERENCES GUEST(guest_no),
    FOREIGN KEY (resort_id) REFERENCES RESORT(resort_id)
);

Select * from BOOKING
Select * from CABIN
Select * from GUEST
Select * from MANAGER
Select * from POINT_OF_INTEREST
Select * from RESORT
Select * from REVIEW
Select * from TOWN


