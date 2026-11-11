SELECT c.name 
FROM customers c
WHERE c.id NOT IN (SELECT DISTINCT customer_id FROM orders)