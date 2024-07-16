-- GUEST table demo data
INSERT INTO GUEST (guest_name, guest_address, guest_email, guest_phone)
VALUES
    ('Alice Wonders', '1 Main Street, Merimbula NSW 2548', 'alice@example.com', '0411111111'),
    ('Bobby Bubba', '2 Beach Road, Byron Bay NSW 2481', 'bob@example.com', '0422222222'),
    ('Charlie Crusty', '3 Oasis Drive, Perth WA 6000', 'charlie@example.com', '0433333333'),
    ('Daisy Darwin', '4 Harbour View, Sydney NSW 2000', 'daisy@example.com', '0444444444'),
    ('Ella Eggplant', '5 City Lane, Melbourne VIC 3000', 'ella@example.com', '0455555555');

-- MANAGER table demo data
INSERT INTO MANAGER (manager_name, manager_phone)
VALUES
    ('John Carpenter', '0412345678'),
    ('Tony Hawk', '0498765432'),
    ('Michael Scott', '0456123456'),
    ('Sarah Pointer', '0432109876'),
    ('David Lee Roth', '0478965432');

-- TOWN table demo data
INSERT INTO TOWN (town_lat, town_long, town_name, town_state, town_avg_summer_temp, town_avg_winter_temp, town_population)
VALUES
    (-36.4414, 146.6440, 'Merimbula', 'NSW', 25.5, 10.0, 18000),
    (-34.4250, 150.8931, 'Byron Bay', 'NSW', 28.0, 15.0, 10000),
    (-31.9535, 115.8570, 'Perth', 'WA', 31.0, 18.0, 2000000),
    (-33.8688, 151.2093, 'Sydney', 'NSW', 26.0, 13.0, 5000000),
    (-37.8136, 144.9631, 'Melbourne', 'VIC', 24.0, 12.0, 4500000);

-- RESORT table demo data
INSERT INTO RESORT (resort_name, resort_street_address, resort_pcode, resort_star_rating, resort_livein_manager, town_id, manager_id)
VALUES
    ('Merimbula Beachside Cabins', '123 Beach Road', '2548', 4.5, 1, 1, 1),
    ('Byron Bay Eepyville', '456 Sunshine Avenue', '2481', 4.2, 1, 2, 2),
    ('Perth Pillows', '789 Oasis Boulevard', '6060', 4.8, 0, 3, 3),
    ('Sydney Sleepy City', '321 Harbour View', '2050', 4.7, 0, 4, 4),
    ('Melbourne City Cabins', '987 City Lane', '3070', 4.6, 1, 5, 5);

-- CABIN table demo data
INSERT INTO CABIN (resort_id, cabin_bedrooms, cabin_sleeping_capacity, cabin_description)
VALUES
    (1, 2, 4, 'Comfortable cabin with a relately horrible smell.'),
    (1, 3, 6, 'Spacious cabin where the entire floor is covered in loose LEGO bricks.'),
    (2, 2, 4, 'Secluded cabins surrounded by spiders. We have no idea how many. A lot.'),
    (2, 1, 2, 'A padded cell.'),
    (3, 4, 8, 'A perfect recreation of the Motel from My Name Is Earl.'),
    (4, 3, 6, 'Tiny cabin where all of the walls are one-way mirrors.'),
    (5, 2, 4, 'City center cabins close to a Pitbull impersonator.'),
    (5, 1, 2, 'Compact cabins for robots and robots ONLY.');

-- BOOKING table demo data
INSERT INTO BOOKING (booking_from, booking_to, booking_noadults, booking_nochildren, booking_charge, guest_no, cabin_no, resort_id)
VALUES
    ('2024-08-01', '2024-08-07', 2, 1, 1200.00, 1, 1, 1),
    ('2024-09-15', '2024-09-20', 2, 0, 950.00, 2, 3, 2),
    ('2024-07-10', '2024-07-15', 4, 2, 2800.00, 3, 5, 3),
    ('2024-10-01', '2024-10-07', 2, 1, 1500.00, 4, 7, 4),
    ('2024-08-20', '2024-08-25', 1, 0, 600.00, 5, 8, 5);

-- REVIEW table demo data
INSERT INTO REVIEW (review_comment, review_date, review_rating, guest_no, resort_id)
VALUES
    ('Great location and friendly staff.', '2024-08-08', 5, 1, 1),
    ('Lovely retreat, perfect for relaxing.', '2024-09-21', 4, 2, 2),
    ('Amazing resort with excellent amenities.', '2024-07-16', 5, 3, 3),
    ('Fantastic views of Sydney Harbor!', '2024-10-08', 5, 4, 4),
    ('Convenient and comfortable stay.', '2024-08-26', 4, 5, 5);

-- POINT_OF_INTEREST table demo data
INSERT INTO POINT_OF_INTEREST (poi_street_address, poi_name, poi_description, poi_open_time, poi_close_time, town_id)
VALUES
    ('123 Aquarium Road', 'Merimbula Aquarium', 'A small yet charming aquarium.', '09:00', '17:00', 1),
    ('456 Beach Street', 'Magic Mountain', 'A fun-filled theme park.', '10:00', '16:00', 1),
    ('789 Coastal Path', 'Merimbula Boardwalk', 'A scenic boardwalk along the coast.', NULL, NULL, 1),
    ('123 Lighthouse Road', 'Cape Byron Lighthouse', 'A historic lighthouse.', '08:00', '18:00', 2),
    ('456 Surf Avenue', 'Byron Bay Surf School', 'Learn to surf with experienced instructors.', '08:00', '18:00', 2),
    ('789 Nature Trail', 'Arakwal National Park', 'A protected area with walking trails.', '06:00', '20:00', 2),
    ('123 Riverside Drive', 'Perth Zoo', 'A diverse zoo housing animals from around the world.', '09:00', '17:00', 3),
    ('456 Kings Park Road', 'Kings Park and Botanic Garden', 'A large park with a stunning view of Perth’s skyline.', '06:00', '20:00', 3),
    ('789 Museum Street', 'WA Museum Boola Bardip', 'A museum dedicated to the history of Western Australia.', '10:00', '17:00', 3);