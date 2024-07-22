-- Query 1: Retrieve the books and authors borrowed by a member named 'John Doe'
SELECT b.title AS book, a.name AS author
FROM borrowing br
JOIN member m ON br.member_id = m.member_id
JOIN book b ON br.book_id = b.book_id
JOIN book_author ba ON b.book_id = ba.book_id
JOIN author a ON ba.author_id = a.author_id
WHERE m.name = 'John Doe';

-- Query 2: Retrieve pairs of members who have borrowed at least one book in common
SELECT m1.name AS member1, m2.name AS member2
FROM member m1
JOIN member m2 ON m1.member_id < m2.member_id
WHERE NOT EXISTS (
  SELECT 1
  FROM borrowing b1
  JOIN book bo ON b1.book_id = bo.book_id
  WHERE b1.member_id = m1.member_id
  AND NOT EXISTS (
    SELECT 1
    FROM borrowing b2
    WHERE b2.member_id = m2.member_id
    AND b2.book_id = bo.book_id
  )
);

-- Query 3: Retrieve members who have not borrowed any books written by 'Mark Twain'
SELECT m.name
FROM member m
WHERE NOT EXISTS (
  SELECT 1
  FROM borrowing b
  JOIN book bo ON b.book_id = bo.book_id
  JOIN book_author ba ON bo.book_id = ba.book_id
  JOIN author a ON ba.author_id = a.author_id
  WHERE b.member_id = m.member_id
  AND a.name = 'Mark Twain'
);

-- Query 4: Retrieve the books, the count of distinct members who borrowed them, and the average fine amount for each book, sorted by the count in descending order and book title in ascending order
SELECT bo.title AS book, COUNT(DISTINCT b.member_id) AS cnt, AVG(r.fine) AS avg
FROM book bo
LEFT JOIN borrowing b ON bo.book_id = b.book_id
LEFT JOIN [return] r ON b.borrowing_id = r.borrowing_id
GROUP BY bo.title
ORDER BY cnt DESC, bo.title ASC;

-- Query 5: Retrieve the member name and the most borrowed book title for each member, sorted by member name
WITH borrowing_count AS (
  SELECT 
    m.member_id,
    b.title,
    COUNT(*) AS count,
    ROW_NUMBER() OVER (PARTITION BY m.member_id ORDER BY COUNT(*) DESC) AS row_num
  FROM member m
  LEFT JOIN borrowing bo ON m.member_id = bo.member_id
  LEFT JOIN book b ON bo.book_id = b.book_id
  GROUP BY m.member_id, b.title
)
SELECT 
  m.name AS member,
  bc.title AS book
FROM member m
LEFT JOIN borrowing_count bc ON m.member_id = bc.member_id AND bc.row_num = 1
ORDER BY m.name;

-- Query 6: Retrieve the author name and the average number of books borrowed per member for each author, sorted by the average in descending order and author name in ascending order
SELECT a.name, AVG(num_borrowed_per_member) AS avg_borrowed
FROM (
  SELECT ba.author_id, COUNT(DISTINCT b.book_id) AS num_borrowed_per_member
  FROM borrowing b
  JOIN book_author ba ON b.book_id = ba.book_id
  GROUP BY ba.author_id, b.member_id
) sub
JOIN author a ON sub.author_id = a.author_id
GROUP BY a.name
ORDER BY avg_borrowed DESC, a.name ASC;

-- Query 7: Retrieve the names of members who have borrowed books from all available genres
WITH genre_count AS (
  SELECT COUNT(DISTINCT genre) AS total_genres
  FROM book
), member_borrowed_genres AS (
  SELECT m.name, COUNT(DISTINCT b.genre) AS borrowed_genres
  FROM member m
  LEFT JOIN borrowing bo ON m.member_id = bo.member_id
  LEFT JOIN book b ON bo.book_id = b.book_id
  GROUP BY m.name
)
SELECT name
FROM member_borrowed_genres
WHERE borrowed_genres = (SELECT total_genres FROM genre_count);

-- Query 8: Retrieve the author name and the average number of books borrowed per member for each author, sorted by the average in descending order and author name in ascending order
SELECT sub.author, AVG(sub.books_borrowed_per_member) AS avg_borrowed_per_member
FROM (
  SELECT a.name AS author, m.member_id, COUNT(DISTINCT b.book_id) AS books_borrowed_per_member
  FROM borrowing b
  INNER JOIN book bk ON b.book_id = bk.book_id
  INNER JOIN book_author ba ON bk.book_id = ba.book_id
  INNER JOIN author a ON ba.author_id = a.author_id
  INNER JOIN member m ON b.member_id = m.member_id
  GROUP BY a.name, m.member_id
) AS sub
GROUP BY sub.author
ORDER BY avg_borrowed_per_member DESC, sub.author ASC;

-- Query 9: Retrieve the names of members who have not been fined or have a fine amount of 0
SELECT m.name
FROM member m
LEFT JOIN borrowing b ON m.member_id = b.member_id
LEFT JOIN [return] r ON b.borrowing_id = r.borrowing_id
WHERE r.fine IS NULL OR r.fine = 0;

-- Query 10: Retrieve the genre, the count of distinct books borrowed, and the total fine amount for each genre, sorted by the count in descending order and genre in ascending order
SELECT bk.genre, COUNT(DISTINCT b.book_id) AS total_borrowed, 
       COALESCE(SUM(r.fine), 0) AS total_fine
FROM borrowing b
INNER JOIN book bk ON b.book_id = bk.book_id
LEFT JOIN "return" r ON b.borrowing_id = r.borrowing_id
GROUP BY bk.genre
ORDER BY total_borrowed DESC, bk.genre ASC;

-- Query 11: Duplicate of Query 1. Refer to Query 1 for the answer.
