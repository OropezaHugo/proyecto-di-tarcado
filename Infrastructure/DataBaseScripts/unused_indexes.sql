--Muestra índices que no están siendo utilizados.
SELECT
    i.name AS IndexName,
    OBJECT_NAME(i.object_id) AS TableName,
    i.type_desc AS IndexType,
    s.user_seeks,
    s.user_scans,
    s.user_lookups,
    s.user_updates
FROM sys.indexes AS i
         INNER JOIN sys.dm_db_index_usage_stats AS s
                    ON i.object_id = s.object_id AND i.index_id = s.index_id
WHERE s.database_id = DB_ID()
  AND i.type > 0
  AND (s.user_seeks = 0 AND s.user_scans = 0)
ORDER BY TableName, IndexName;