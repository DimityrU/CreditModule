using Microsoft.Data.Sqlite;

namespace DataAccess.CreditModule.Repository.Entities
{
    public class CreditContext(string connectionString)
    {
        public SqliteConnection Database => new(connectionString);

        public string BuildSelect<T>(string[]? item = null)
        {
            item ??= [];
            var sourceAlias = typeof(T).Name[0];
            var columns = item.Length == 0 ? "*" : $"{sourceAlias}." + string.Join($", {sourceAlias}.", item); ;
            return $"SELECT {columns} FROM {typeof(T).Name} {sourceAlias}";
        }

        public string BuildLeftJoin<TSource, TDestination>(string sourceIdName, string destinationIdName)
        {
            var tableName = typeof(TDestination).Name;
            var sourceAlias = typeof(TSource).Name[0];
            var tableAlias = tableName[0];
            return $" LEFT JOIN {tableName} {tableAlias} ON {sourceAlias}.{sourceIdName} = {tableAlias}.{destinationIdName}";
        }

        public string BuildSelectSum<T>(string item)
        {
            var tableName = typeof(T).Name;
            return $"SELECT SUM({tableName[0]}.{item}) FROM {tableName} {tableName[0]}";
        }

        public string BuildWhereEqual<T>(string item, string value)
        {
            var sourceAlias = typeof(T).Name[0];
            return $" WHERE {sourceAlias}.{item} = {value}";
        }

        public string BuildWhereNotEqual<T>(string item, string value)
        {
            var sourceAlias = typeof(T).Name[0];
            return $" WHERE {sourceAlias}.{item} != {value}";
        }
        
    }
}
