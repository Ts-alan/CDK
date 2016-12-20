using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.DataAccess.Repositories.Extensions
{
    public static class CollectionExtenstions
    {
        public static void AddNewItemWithState<T>(this IDbSet<T> collection, T item)
            where T : Repository.Pattern.Ef6.Entity
        {
            item.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
            collection.Add(item);
        }
    }
}
