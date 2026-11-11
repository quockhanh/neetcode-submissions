-- Write your query below
SELECT e1.student_id, e1.exam_id, e1.score
FROM exam_results e1
WHERE e1.exam_id IN (
    SELECT e2.exam_id
    FROM exam_results e2
    WHERE e1.student_id = e2.student_id
    ORDER BY e2.score DESC, e2.exam_id ASC
    LIMIT 1
)
ORDER BY e1.student_id

-- WITH RankedExams AS (
--     SELECT
--         student_id,
--         exam_id,
--         score,
--         ROW_NUMBER() OVER (
--             PARTITION BY student_id
--             ORDER BY score DESC, exam_id ASC
--         ) AS rn
--     FROM exam_results
-- )
-- SELECT
--     student_id,
--     exam_id,
--     score
-- FROM RankedExams
-- WHERE rn = 1
-- ORDER BY student_id ASC;