--Muestra cuántas veces se ejecuta cada consulta.
SELECT
    q.text AS QueryText,
    qs.execution_count,
    qs.total_elapsed_time / qs.execution_count AS AvgExecutionTime
FROM sys.dm_exec_query_stats AS qs
    CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) AS q
ORDER BY qs.execution_count DESC;