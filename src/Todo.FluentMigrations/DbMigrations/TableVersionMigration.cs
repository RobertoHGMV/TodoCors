using FluentMigrator.Runner.VersionTableInfo;

namespace Todo.FluentMigrations.DbMigrations
{
    [VersionTableMetaData]
    public class TableVersionMigration : IVersionTableMetaData
    {
        public object ApplicationContext { get; set; }

        public bool OwnsSchema => true;

        public string SchemaName => "";

        public string TableName => "TDC_Version";

        public string ColumnName => "Version";

        public string DescriptionColumnName => "Description";

        public string UniqueIndexName => "TDC_IDX_Version";

        public string AppliedOnColumnName => "AppliedOn";
    }
}
