-- SELECT
--     c.customer_id,
--     c.customer_name
-- FROM customers c
-- JOIN orders o ON c.customer_id = o.customer_id
-- GROUP BY c.customer_id, c.customer_name
-- HAVING
--     COUNT(CASE WHEN o.product_name = 'A' THEN 1 END) > 0
--     AND COUNT(CASE WHEN o.product_name = 'B' THEN 1 END) > 0
--     AND COUNT(CASE WHEN o.product_name = 'C' THEN 1 END) = 0
-- ORDER BY c.customer_name ASC;

-- RECOMMENDED
SELECT
    c.customer_id,
    c.customer_name
FROM customers c
WHERE
    EXISTS (
        SELECT 1
        FROM orders o
        WHERE o.customer_id = c.customer_id
          AND o.product_name = 'A'
    )
    AND EXISTS (
        SELECT 1
        FROM orders o
        WHERE o.customer_id = c.customer_id
          AND o.product_name = 'B'
    )
    AND NOT EXISTS (
        SELECT 1
        FROM orders o
        WHERE o.customer_id = c.customer_id
          AND o.product_name = 'C'
    )
ORDER BY c.customer_name ASC;