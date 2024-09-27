-- Query 1: Retrieve the title and price of all books
SELECT title, price
FROM book;

-- Query 2: Retrieve the distinct names of authors whose books have a price greater than 10
SELECT DISTINCT a.name
FROM author a
JOIN book b ON a.author_id = b.author_id
WHERE b.price > 10;

-- Query 3: Retrieve the distinct names of customers who made a purchase
SELECT DISTINCT c.name
FROM customer c
JOIN purchase p ON c.customer_id = p.customer_id;

-- Query 4: Retrieve the title of each book and the number of reviews it has received
SELECT b.title, COUNT(r.review_id) AS num_reviews
FROM book b
LEFT JOIN review r ON b.book_id = r.book_id
GROUP BY b.book_id, b.title;

-- Query 5: Retrieve the title of the book with the highest rating and its maximum rating
SELECT TOP 1 b.title, MAX(r.rating) AS rating
FROM book b
JOIN review r ON b.book_id = r.book_id
GROUP BY b.book_id, b.title
ORDER BY rating DESC;

-- Query 6: Retrieve the title and price of books with a price less than 20
SELECT title, price
FROM book
WHERE price < 20;

-- Query 7: Retrieve the distinct names of customers who have given a rating of 5 in their reviews
SELECT DISTINCT c.name
FROM customer c
JOIN review r ON c.customer_id = r.customer_id
WHERE r.rating = 5;

-- Query 8: Retrieve the titles of books written by the author 'Mark Twain'
SELECT b.title
FROM book b
JOIN author a ON b.author_id = a.author_id
WHERE a.name = 'Mark Twain';

-- Query 9: Retrieve the average price of all books
SELECT AVG(price) AS avg_price
FROM book;

-- Query 10: Retrieve the title of books purchased by the customer 'Alice Johnson' along with the purchase date
SELECT b.title, p.purchase_date
FROM purchase p
JOIN book b ON p.book_id = b.book_id
JOIN customer c ON p.customer_id = c.customer_id
WHERE c.name = 'Alice Johnson';