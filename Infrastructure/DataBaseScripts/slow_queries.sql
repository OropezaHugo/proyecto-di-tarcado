--Encuentra las 10 consultas más lentas.
SELECT TOP 10
    qs.total_elapsed_time / qs.execution_count AS AvgExecutionTime,
        qs.execution_count,
       q.text AS QueryText
FROM sys.dm_exec_query_stats AS qs
    CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) AS q
ORDER BY AvgExecutionTime DESC;