using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal
{
    public static class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
      new Lazy<IDocumentStore>(() =>
      {
          var store = new DocumentStore
          {
              ConnectionStringName = "RavenDB"
          };

          return store.Initialize();
      });

        public static IDocumentStore Store =>
            LazyStore.Value;
    }
}