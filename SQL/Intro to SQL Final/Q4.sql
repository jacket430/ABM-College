-- Query 1: Retrieve movies and actors for a specific customer
SELECT m.title AS movie, a.name AS actor
FROM rental r
JOIN customer c ON r.customer_id = c.customer_id
JOIN movie m ON r.movie_id = m.movie_id
JOIN movie_actor ma ON m.movie_id = ma.movie_id
JOIN actor a ON ma.actor_id = a.actor_id
WHERE c.name = 'Alice Johnson';

-- Query 2: Retrieve pairs of customers who have rented the same movies
WITH CustomerMovies AS (
    SELECT customer_id, movie_id
    FROM rental
), CustomerPairs AS (
    SELECT DISTINCT c1.customer_id AS customer1, c2.customer_id AS customer2
    FROM CustomerMovies c1
    CROSS JOIN CustomerMovies c2
    WHERE c1.customer_id <> c2.customer_id
)
SELECT c1.name AS customer1, c2.name AS customer2
FROM CustomerPairs cp
JOIN customer c1 ON cp.customer1 = c1.customer_id
JOIN customer c2 ON cp.customer2 = c2.customer_id
WHERE NOT EXISTS (
    SELECT 1
    FROM CustomerMovies cm
    WHERE cm.customer_id = cp.customer1
    AND NOT EXISTS (
        SELECT 1
        FROM CustomerMovies cm2
        WHERE cm2.customer_id = cp.customer2
        AND cm2.movie_id = cm.movie_id
    )
);

-- Query 3: Retrieve customers who have rented movies with a specific actor
SELECT DISTINCT c.name
FROM customer c
JOIN rental r ON c.customer_id = r.customer_id
JOIN movie_actor ma ON r.movie_id = ma.movie_id
JOIN actor a ON ma.actor_id = a.actor_id
WHERE a.name = 'Robert Downey Jr.'
AND NOT EXISTS (
    SELECT 1
    FROM rental r2
    JOIN movie_actor ma2 ON r2.movie_id = ma2.movie_id
    JOIN actor a2 ON ma2.actor_id = a2.actor_id
    WHERE r2.customer_id = c.customer_id
    AND a2.name <> 'Robert Downey Jr.'
);

-- Query 4: Retrieve movies with the count of customers who rented them and the average fine
SELECT m.title AS movie, COUNT(DISTINCT r.customer_id) AS cnt, AVG(rt.fine) AS avg
FROM movie m
LEFT JOIN rental r ON m.movie_id = r.movie_id
LEFT JOIN [return] rt ON r.rental_id = rt.rental_id
GROUP BY m.title
ORDER BY cnt DESC, m.title ASC;

-- Query 5: Retrieve customers who rented the most movies, along with their most rented movie
WITH CustomerMovieRentalCount AS (
    SELECT c.name AS customer, m.title AS movie, COUNT(*) AS rental_count
    FROM rental r
    JOIN customer c ON r.customer_id = c.customer_id
    JOIN movie m ON r.movie_id = m.movie_id
    GROUP BY c.name, m.title
), MaxRentals AS (
    SELECT customer, MAX(rental_count) AS max_rental_count
    FROM CustomerMovieRentalCount
    GROUP BY customer
)
SELECT cmrc.customer, cmrc.movie
FROM CustomerMovieRentalCount cmrc
JOIN MaxRentals mr ON cmrc.customer = mr.customer AND cmrc.rental_count = mr.max_rental_count
UNION
SELECT c.name AS customer, NULL AS movie
FROM customer c
LEFT JOIN rental r ON c.customer_id = r.customer_id
WHERE r.customer_id IS NULL;

-- Query 6: Retrieve customers who have rented movies from all genres they have rented before
SELECT c.name
FROM customer c
WHERE NOT EXISTS (
    SELECT DISTINCT genre
    FROM movie
    WHERE genre NOT IN (
        SELECT DISTINCT m.genre
        FROM rental r
        JOIN movie m ON r.movie_id = m.movie_id
        WHERE r.customer_id = c.customer_id
    )
)
ORDER BY c.name;

-- Query 7: Retrieve actors with the average number of movies rented per customer
SELECT a.name AS actor,
       AVG(CAST(movie_count AS FLOAT)) AS avg_rented_per_customer
FROM actor a
JOIN movie_actor ma ON a.actor_id = ma.actor_id
JOIN movie m ON ma.movie_id = m.movie_id
JOIN (
    SELECT r.movie_id, COUNT(*) AS movie_count
    FROM rental r
    GROUP BY r.movie_id
) rc ON m.movie_id = rc.movie_id
GROUP BY a.actor_id, a.name
ORDER BY avg_rented_per_customer DESC, a.name;

-- Query 8: Retrieve customers who have not returned any movies with fines
SELECT DISTINCT c.name
FROM customer c
WHERE NOT EXISTS (
    SELECT 1
    FROM rental r
    JOIN [return] ret ON r.rental_id = ret.rental_id
    WHERE r.customer_id = c.customer_id
    AND ret.return_date > r.due_date
    AND ret.fine > 0
)
AND EXISTS (
    SELECT 1
    FROM rental r
    WHERE r.customer_id = c.customer_id
)
ORDER BY c.name;

-- Query 9: Retrieve genres with the total number of rentals and total fine amount
SELECT m.genre,
       COUNT(*) AS total_rented,
       COALESCE(SUM(ret.fine), 0) AS total_fine
FROM movie m
JOIN rental r ON m.movie_id = r.movie_id
LEFT JOIN [return] ret ON r.rental_id = ret.rental_id
GROUP BY m.genre
ORDER BY total_rented DESC, m.genre;

-- Query 10: Retrieve pairs of actors who have acted in the same movies
WITH actor_movies AS (
    SELECT DISTINCT a.actor_id, a.name, m.movie_id
    FROM actor a
    JOIN movie_actor ma ON a.actor_id = ma.actor_id
    JOIN movie m ON ma.movie_id = m.movie_id
)
SELECT DISTINCT am1.name AS actor1, am2.name AS actor2
FROM actor_movies am1
JOIN actor_movies am2 ON am1.actor_id < am2.actor_id
WHERE NOT EXISTS (
    SELECT 1
    FROM actor_movies am3
    WHERE am3.actor_id = am1.actor_id
    AND NOT EXISTS (
        SELECT 1
        FROM actor_movies am4
        WHERE am4.actor_id = am2.actor_id
        AND am3.movie_id = am4.movie_id
    )
)
ORDER BY am1.name, am2.name;