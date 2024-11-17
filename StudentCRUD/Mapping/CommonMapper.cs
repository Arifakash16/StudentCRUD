using FluentNHibernate.Mapping;
using StudentCRUD.Models;

namespace StudentCRUD.Mapping
{
    public abstract class CommonMapper<T>: ClassMap<T> where T : CommonModel
    {
        public CommonMapper(string tableName)
        {
            Table(tableName);
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.CreatedAt).Nullable();
            Map(x => x.UpdatedAt).Nullable();


        }
    }
}
