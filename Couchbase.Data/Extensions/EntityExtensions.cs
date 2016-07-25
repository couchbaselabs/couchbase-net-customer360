using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Couchbase.IO;

using Couchbase.Data.DAL;

namespace Couchbase.Data.Extensions
{
    public static class EntityExtensions
    {
        public static IDocument<T> Wrap<T>(this T entity) where T : IEntity
        {
            return new Document<T>
            {
                Id = entity.Id,
                Cas = entity.Cas,
                Content = entity
            };
        }

        public static T UnWrap<T>(this IDocument<T> document) where T : IEntity
        {
            var entity = document.Content;
            entity.Cas = document.Cas;
            entity.Id = document.Id;
            return entity;
        }
    }
}
