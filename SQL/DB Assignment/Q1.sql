--------------------------------------- Question 1 ---------------------------------------

--------------------------------------- Q1. A ---------------------------------------
-- No script supplied with pdf, created placeholders.
-- Placeholders can be viewed in the "Demo Data.sql" file in this repo's folder.

--------------------------------------- Q2. B ---------------------------------------

--------------------------------------- Q2. B (i) ---------------------------------------
CREATE SEQUENCE ResortSeq
    START WITH 100
    INCREMENT BY 1;

--------------------------------------- Q2. B (ii) ---------------------------------------
-- Insert new manager
INSERT INTO MANAGER (manager_name, manager_phone)
VALUES
    ('Garrott Gooch', '6002318099');

-- Insert new resort
INSERT INTO RESORT (resort_name, resort_street_address, resort_pcode, resort_star_rating, resort_livein_manager, town_id, manager_id)
VALUES
    ('Awesome Resort', '50 Awesome Road', '4830', 0, 0, 4, 6);

-- Add new cabins to Awesome Resort
INSERT INTO CABIN (resort_id, cabin_bedrooms, cabin_sleeping_capacity, cabin_description)
VALUES
    (6, 3, 6, 'Free Wi-Fi, kitchen with 400 ltr refrigerator, stove, microwave, pots, pans, silverware, toaster, electric kettle, TV, and utensils'),
    (6, 2, 4, 'Free Wi-Fi, kitchen with 280 ltr refrigerator, stove, pots, pans, silverware, toaster, electric kettle, TV, and utensils');

--------------------------------------- Q2. B (iii) ---------------------------------------
-- Insert new manager
INSERT INTO MANAGER (manager_name, manager_phone)
VALUES
    ('Fonsie Tillard', '9636535741');

-- Update Awesome Resort with new manager
DECLARE @new_manager_id INT = (SELECT manager_id FROM MANAGER WHERE manager_name = 'Fonsie Tillard' AND manager_phone = '9636535741');
UPDATE RESORT
SET manager_id = @new_manager_id, resort_livein_manager = 1
WHERE resort_name = 'Awesome Resort';

--------------------------------------- Q2. B (iv) ---------------------------------------
ALTER TABLE BOOKING
    DROP CONSTRAINT FK_BOOKING_CABIN;
ALTER TABLE REVIEW
    DROP CONSTRAINT FK_REVIEW_RESORT;

DELETE FROM RESORT
WHERE resort_name = 'Awesome Resort';

ALTER TABLE BOOKING
    ADD CONSTRAINT FK_BOOKING_CABIN FOREIGN KEY (cabin_no, resort_id) REFERENCES CABIN(cabin_no, resort_id) ON DELETE CASCADE;
ALTER TABLE REVIEW
    ADD CONSTRAINT FK_REVIEW_RESORT FOREIGN KEY (resort_id) REFERENCES RESORT(resort_id) ON DELETE CASCADE;