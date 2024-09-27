-- Query 1: Retrieve books and authors for a customer named 'John Doe'
SELECT DISTINCT b.title AS book, a.name AS author
FROM purchase p
JOIN book b ON p.book_id = b.book_id
JOIN author a ON b.author_id = a.author_id
JOIN customer c ON p.customer_id = c.customer_id
WHERE c.name = 'John Doe';

-- Query 2: Retrieve pairs of customers who have purchased the same books
SELECT DISTINCT c1.name AS customer1, c2.name AS customer2
FROM customer c1
JOIN customer c2 ON c1.customer_id < c2.customer_id
WHERE NOT EXISTS (
    SELECT p1.book_id
    FROM purchase p1
    WHERE p1.customer_id = c1.customer_id
    AND NOT EXISTS (
        SELECT 1
        FROM purchase p2
        WHERE p2.customer_id = c2.customer_id
        AND p2.book_id = p1.book_id
    )
);

-- Query 3: Retrieve customers who have purchased books only by 'Jane Austen'
SELECT c.name
FROM customer c
WHERE NOT EXISTS (
    SELECT 1
    FROM purchase p
    JOIN book b ON p.book_id = b.book_id
    JOIN author a ON b.author_id = a.author_id
    WHERE p.customer_id = c.customer_id
    AND a.name != 'Jane Austen'
)
AND EXISTS (
    SELECT 1
    FROM purchase p
    JOIN book b ON p.book_id = b.book_id
    JOIN author a ON b.author_id = a.author_id
    WHERE p.customer_id = c.customer_id
    AND a.name = 'Jane Austen'
);

-- Query 4: Retrieve books with the highest number of customers who purchased them, along with the average rating
SELECT b.title AS book, 
       COUNT(DISTINCT p.customer_id) AS cnt, 
       AVG(CAST(r.rating AS FLOAT)) AS avg
FROM book b
LEFT JOIN purchase p ON b.book_id = p.book_id
LEFT JOIN review r ON b.book_id = r.book_id
GROUP BY b.book_id, b.title
ORDER BY cnt DESC, b.title ASC;

-- Query 5: Retrieve customers who have given the highest rating to a book, along with the book title
WITH CustomerMaxRating AS (
    SELECT c.customer_id, c.name, MAX(r.rating) AS max_rating
    FROM customer c
    LEFT JOIN review r ON c.customer_id = r.customer_id
    GROUP BY c.customer_id, c.name
)
SELECT cmr.name AS customer, 
       COALESCE(b.title, 'NULL') AS book
FROM CustomerMaxRating cmr
LEFT JOIN review r ON cmr.customer_id = r.customer_id AND cmr.max_rating = r.rating
LEFT JOIN book b ON r.book_id = b.book_id
ORDER BY cmr.name, b.title;

-- Query 6: Retrieve customers who have purchased all books in a genre
SELECT c.name
FROM customer c
WHERE NOT EXISTS (
    SELECT DISTINCT b.genre
    FROM book b
    WHERE NOT EXISTS (
        SELECT 1
        FROM purchase p
        WHERE p.customer_id = c.customer_id
        AND p.book_id = b.book_id
    )
);

-- Query 7: Retrieve authors along with the average price of their books, sorted by average price in descending order
SELECT a.name AS author, AVG(b.price) AS avg_price
FROM author a
JOIN book b ON a.author_id = b.author_id
GROUP BY a.author_id, a.name
ORDER BY avg_price DESC, a.name ASC;

-- Query 8: Retrieve customers who have given a minimum rating of 3 or have not given any ratings
SELECT DISTINCT c.name
FROM customer c
LEFT JOIN review r ON c.customer_id = r.customer_id
GROUP BY c.customer_id, c.name
HAVING MIN(r.rating) >= 3 OR MIN(r.rating) IS NULL;

-- Query 9: Retrieve genres along with the total number of books purchased and total number of purchases, sorted by total books purchased in descending order
SELECT b.genre, 
       COUNT(DISTINCT p.book_id) AS total_books_purchased,
       COUNT(p.purchase_id) AS total_purchases
FROM book b
LEFT JOIN purchase p ON b.book_id = p.book_id
GROUP BY b.genre
ORDER BY total_books_purchased DESC, b.genre ASC;

-- Query 10: Retrieve pairs of authors who have customers in common
SELECT DISTINCT a1.name AS author1, a2.name AS author2
FROM author a1
JOIN author a2 ON a1.author_id < a2.author_id
WHERE NOT EXISTS (
    SELECT DISTINCT p1.customer_id
    FROM purchase p1
    JOIN book b1 ON p1.book_id = b1.book_id
    WHERE b1.author_id = a1.author_id
    AND NOT EXISTS (
        SELECT 1
        FROM purchase p2
        JOIN book b2 ON p2.book_id = b2.book_id
        WHERE b2.author_id = a2.author_id
        AND p2.customer_id = p1.customer_id
    )
);