-- Query 1: Retrieve top 3 books with the highest number of purchases and their average rating
SELECT TOP 3
    b.title AS book,
    COUNT(p.purchase_id) AS num_purchases,
    AVG(CAST(r.rating AS FLOAT)) AS avg_rating
FROM 
    book b
    LEFT JOIN purchase p ON b.book_id = p.book_id
    LEFT JOIN review r ON b.book_id = r.book_id
GROUP BY 
    b.book_id, b.title
ORDER BY 
    num_purchases DESC,
    b.title ASC;

-- Query 2: Retrieve pairs of books that have been purchased by the same customer
SELECT 
    b1.title AS book1,
    b2.title AS book2
FROM 
    book b1
    CROSS JOIN book b2
WHERE 
    b1.book_id <> b2.book_id
    AND NOT EXISTS (
        SELECT 1
        FROM purchase p1
        WHERE p1.book_id = b1.book_id
        AND NOT EXISTS (
            SELECT 1
            FROM purchase p2
            WHERE p2.book_id = b2.book_id
            AND p1.customer_id = p2.customer_id
        )
    );

-- Query 3: Retrieve names of customers who have given a rating of 5 and a rating of 1
SELECT DISTINCT c.name
FROM customer c
JOIN review r ON c.customer_id = r.customer_id
WHERE r.rating = 5
AND EXISTS (
    SELECT 1
    FROM review r2
    WHERE r2.customer_id = c.customer_id
    AND r2.rating = 1
);

-- Query 4: Retrieve authors with their total revenue and average rating of their books
SELECT 
    a.name AS author,
    SUM(b.price * p.num_purchases) AS total_revenue,
    AVG(CAST(r.rating AS FLOAT)) AS avg_rating
FROM 
    author a
    JOIN book b ON a.author_id = b.author_id
    LEFT JOIN (
        SELECT book_id, COUNT(*) AS num_purchases
        FROM purchase
        GROUP BY book_id
    ) p ON b.book_id = p.book_id
    LEFT JOIN review r ON b.book_id = r.book_id
GROUP BY 
    a.author_id, a.name
ORDER BY 
    total_revenue DESC,
    a.name ASC;

-- Query 5: Retrieve titles of books that have not been purchased by customers who have purchased a fiction book
SELECT DISTINCT b.title AS book
FROM book b
JOIN purchase p ON b.book_id = p.book_id
WHERE NOT EXISTS (
    SELECT 1
    FROM customer c
    WHERE EXISTS (
        SELECT 1
        FROM purchase p2
        JOIN book b2 ON p2.book_id = b2.book_id
        WHERE p2.customer_id = c.customer_id
        AND b2.category = 'Fiction'
    )
    AND NOT EXISTS (
        SELECT 1
        FROM purchase p3
        WHERE p3.customer_id = c.customer_id
        AND p3.book_id = b.book_id
    )
);

-- Query 6: Retrieve customers, their favorite book, and its rating
SELECT 
    c.name AS customer,
    b.title AS book,
    r.rating
FROM 
    customer c
    LEFT JOIN (
        SELECT 
            customer_id,
            book_id,
            rating,
            ROW_NUMBER() OVER (PARTITION BY customer_id ORDER BY rating DESC) AS rn
        FROM review
    ) r ON c.customer_id = r.customer_id AND r.rn = 1
    LEFT JOIN book b ON r.book_id = b.book_id;

-- Query 7: Retrieve books with their price, number of purchases, where the price is higher than the average price of their category
WITH CategoryAvg AS (
    SELECT 
        category,
        AVG(price) AS avg_price
    FROM book
    GROUP BY category
)
SELECT 
    b.title AS book,
    b.price,
    COUNT(p.purchase_id) AS num_purchases
FROM 
    book b
    JOIN CategoryAvg ca ON b.category = ca.category
    LEFT JOIN purchase p ON b.book_id = p.book_id
WHERE 
    b.price > ca.avg_price
GROUP BY 
    b.book_id, b.title, b.price;

-- Query 8: Retrieve pairs of authors where the average price of the first author's books is lower than the average price of the second author's books
WITH AuthorAvgPrice AS (
    SELECT 
        author_id,
        AVG(price) AS avg_price
    FROM book
    GROUP BY author_id
)
SELECT 
    a1.name AS author1,
    a2.name AS author2
FROM 
    AuthorAvgPrice ap1
    JOIN author a1 ON ap1.author_id = a1.author_id
    CROSS JOIN AuthorAvgPrice ap2
    JOIN author a2 ON ap2.author_id = a2.author_id
WHERE 
    ap1.author_id <> ap2.author_id
    AND ap1.avg_price < ap2.avg_price;

-- Query 9: Retrieve names of customers who have reviewed books from all categories
SELECT c.name
FROM customer c
WHERE NOT EXISTS (
    SELECT DISTINCT category
    FROM book
    EXCEPT
    SELECT DISTINCT b.category
    FROM review r
    JOIN book b ON r.book_id = b.book_id
    WHERE r.customer_id = c.customer_id
);

-- Query 10: Retrieve categories of books with their total number of reviews and average rating
SELECT 
    b.category,
    COUNT(r.review_id) AS total_reviews,
    AVG(CAST(r.rating AS FLOAT)) AS avg_rating
FROM 
    book b
    LEFT JOIN review r ON b.book_id = r.book_id
GROUP BY 
    b.category
ORDER BY 
    total_reviews DESC,
    b.category ASC;