-- Query 1: Retrieve products and their categories for a specific customer
SELECT p.name AS product, c.name AS category
FROM customer cu
JOIN [order] o ON cu.customer_id = o.customer_id
JOIN order_item oi ON o.order_id = oi.order_id
JOIN product p ON oi.product_id = p.product_id
JOIN category c ON p.category_id = c.category_id
WHERE cu.name = 'Alice Johnson'
ORDER BY p.name, c.name;

-- Query 2: Retrieve pairs of customers who have ordered the same products
WITH customer_products AS (
    SELECT cu.customer_id, cu.name, p.product_id
    FROM customer cu
    JOIN [order] o ON cu.customer_id = o.customer_id
    JOIN order_item oi ON o.order_id = oi.order_id
    JOIN product p ON oi.product_id = p.product_id
    GROUP BY cu.customer_id, cu.name, p.product_id
)
SELECT cp1.name AS customer1, cp2.name AS customer2
FROM customer_products cp1
JOIN customer_products cp2 ON cp1.customer_id < cp2.customer_id
WHERE NOT EXISTS (
    SELECT 1
    FROM customer_products cp3
    WHERE cp3.customer_id = cp1.customer_id
    AND NOT EXISTS (
        SELECT 1
        FROM customer_products cp4
        WHERE cp4.customer_id = cp2.customer_id
        AND cp3.product_id = cp4.product_id
    )
)
ORDER BY cp1.name, cp2.name;

-- Query 3: Retrieve customers who have only ordered products in the 'Electronics' category
SELECT cu.name
FROM customer cu
WHERE EXISTS (
    SELECT 1
    FROM [order] o
    JOIN order_item oi ON o.order_id = oi.order_id
    JOIN product p ON oi.product_id = p.product_id
    JOIN category c ON p.category_id = c.category_id
    WHERE o.customer_id = cu.customer_id
    AND c.name = 'Electronics'
)
AND NOT EXISTS (
    SELECT 1
    FROM [order] o
    JOIN order_item oi ON o.order_id = oi.order_id
    JOIN product p ON oi.product_id = p.product_id
    JOIN category c ON p.category_id = c.category_id
    WHERE o.customer_id = cu.customer_id
    AND c.name != 'Electronics'
)
ORDER BY cu.name;

-- Query 4: Retrieve products with the count of unique customers who ordered them and the average rating
SELECT p.name AS product,
       COUNT(DISTINCT o.customer_id) AS cnt,
       AVG(CAST(r.rating AS FLOAT)) AS avg
FROM product p
LEFT JOIN order_item oi ON p.product_id = oi.product_id
LEFT JOIN [order] o ON oi.order_id = o.order_id
LEFT JOIN review r ON p.product_id = r.product_id
GROUP BY p.product_id, p.name
ORDER BY cnt DESC, p.name;

-- Query 5: Retrieve the product with the maximum quantity ordered for each customer
WITH customer_max_quantity AS (
    SELECT cu.customer_id, cu.name AS customer, MAX(oi.quantity) AS max_quantity
    FROM customer cu
    LEFT JOIN [order] o ON cu.customer_id = o.customer_id
    LEFT JOIN order_item oi ON o.order_id = oi.order_id
    GROUP BY cu.customer_id, cu.name
),
customer_product AS (
    SELECT cmq.customer_id, cmq.customer, cmq.max_quantity, p.name AS product
    FROM customer_max_quantity cmq
    LEFT JOIN [order] o ON cmq.customer_id = o.customer_id
    LEFT JOIN order_item oi ON o.order_id = oi.order_id AND oi.quantity = cmq.max_quantity
    LEFT JOIN product p ON oi.product_id = p.product_id
)
SELECT customer,
       MAX(product) AS product
FROM customer_product
GROUP BY customer_id, customer
ORDER BY customer;

-- Query 6: Retrieve customers who have ordered products from all categories
SELECT cu.name
FROM customer cu
WHERE NOT EXISTS (
    SELECT c.category_id
    FROM category c
    WHERE NOT EXISTS (
        SELECT 1
        FROM [order] o
        JOIN order_item oi ON o.order_id = oi.order_id
        JOIN product p ON oi.product_id = p.product_id
        WHERE o.customer_id = cu.customer_id
        AND p.category_id = c.category_id
    )
)
ORDER BY cu.name;

-- Query 7: Retrieve categories with the average price and average rating of products in each category
SELECT c.name AS category,
       AVG(p.price) AS avg_price,
       AVG(CAST(r.rating AS FLOAT)) AS avg_rating
FROM category c
JOIN product p ON c.category_id = p.category_id
LEFT JOIN review r ON p.product_id = r.product_id
GROUP BY c.category_id, c.name
ORDER BY avg_price DESC, c.name;

-- Query 8: Retrieve customers who have given reviews with a rating of 4 or higher
SELECT cu.name
FROM customer cu
WHERE EXISTS (
    SELECT 1
    FROM review r
    WHERE r.customer_id = cu.customer_id
)
AND NOT EXISTS (
    SELECT 1
    FROM review r
    WHERE r.customer_id = cu.customer_id
    AND r.rating < 4
)
ORDER BY cu.name;

-- Query 9: Retrieve categories with the total quantity of products ordered and the total number of orders
SELECT c.name AS category,
       SUM(oi.quantity) AS total_products_ordered,
       COUNT(DISTINCT o.order_id) AS total_orders
FROM category c
JOIN product p ON c.category_id = p.category_id
JOIN order_item oi ON p.product_id = oi.product_id
JOIN [order] o ON oi.order_id = o.order_id
GROUP BY c.category_id, c.name
ORDER BY total_products_ordered DESC, c.name;

-- Query 10: Retrieve pairs of products that have been ordered by the same customers
WITH product_customers AS (
    SELECT p.product_id, p.name, o.customer_id
    FROM product p
    JOIN order_item oi ON p.product_id = oi.product_id
    JOIN [order] o ON oi.order_id = o.order_id
    GROUP BY p.product_id, p.name, o.customer_id
)
SELECT pc1.name AS product1, pc2.name AS product2
FROM product_customers pc1
JOIN product_customers pc2 ON pc1.product_id < pc2.product_id
WHERE NOT EXISTS (
    SELECT 1
    FROM product_customers pc3
    WHERE pc3.product_id = pc1.product_id
    AND NOT EXISTS (
        SELECT 1
        FROM product_customers pc4
        WHERE pc4.product_id = pc2.product_id
        AND pc3.customer_id = pc4.customer_id
    )
)
ORDER BY pc1.name, pc2.name;