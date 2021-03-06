﻿using System.Collections.Generic;
using System.Linq;
using Couchbase.Core;
using Couchbase.Data.Extensions;
using Couchbase.N1QL;
using Couchbase.Views;
using Newtonsoft.Json;

namespace Couchbase.Data.DAL
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        public Repository(IBucket bucket)
        {
            Bucket = bucket;
        }

        public IBucket Bucket { get; private set; }

        public void Save(T document)
        {
         

            var result = Bucket.Insert(document.Wrap());
          
            result.ThrowIfNotSuccess();
        }
      
        public void Edit(T document)
        {
            var result = Bucket.Upsert(document.Wrap());
            result.ThrowIfNotSuccess();
        }
        public string EditWithReply(T document)
        {
            var result = Bucket.Upsert(document.Wrap());
            result.ThrowIfNotSuccess();
           return JsonConvert.SerializeObject(result);
        }

        public void Remove(T document)
        {
            var result = Bucket.Remove(document.Wrap());
            result.ThrowIfNotSuccess(document.Id);
        }
        public string RemoveWithReply(T document)
        {
            var result = Bucket.Remove(document.Id);
            result.ThrowIfNotSuccess(document.Id);
            return JsonConvert.SerializeObject(result);
        }
        public T Find(string key)
        {
     
            var result = Bucket.GetDocument<T>(key);
            result.ThrowIfNotSuccess();
            return result.Content;
        }

        public IEnumerable<T> Select(IQueryRequest n1qlQuery)
        {
            var results = Bucket.Query<T>(n1qlQuery);
            if (!results.Success)
            {
                var message = JsonConvert.SerializeObject(results.Errors);
                throw new QueryRequestException(message, results.Status);
            }
            return results.Rows;
        }

        public IEnumerable<T> Select(IViewQuery viewQuery)
        {
            var results = Bucket.Query<T>(viewQuery);
            if (!results.Success)
            {
                var message = results.Error;
                throw new ViewRequestException(message, results.StatusCode);
            }
            return results.Values;
        }
    }
}
