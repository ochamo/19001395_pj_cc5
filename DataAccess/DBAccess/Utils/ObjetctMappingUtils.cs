using FastMember;
using MySql.Data.MySqlClient;

using System.Data.Common;
namespace DataAccess.DBAccess.Utils
{
    public static class ObjetctMappingUtils
    {
        public static T MapDataToObject<T>(this DbDataReader dataReader) where T : class, new()
        {

            var newObject = new T();

            var objectMemberAccesor = TypeAccessor.Create(newObject.GetType());
            var propertySet = objectMemberAccesor
                .GetMembers()
                .Select(mp => mp.Name)
                .ToHashSet(StringComparer.InvariantCultureIgnoreCase);

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                var name = propertySet.FirstOrDefault(it => it.Equals(dataReader.GetName(i), StringComparison.InvariantCultureIgnoreCase));
                if (!string.IsNullOrEmpty(name))
                {
                    objectMemberAccesor[newObject, name]
                     = dataReader.IsDBNull(i) ? null : dataReader.GetValue(i);
                }
            }
            return newObject;
        }
    }
}
