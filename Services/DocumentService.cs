using System.Collections.Generic;
using System.Linq;
using DocumentsApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DocumentsApi.Services
{
    public class DocumentService
    {
        private readonly IMongoCollection<Document> _documents;

        public DocumentService(IConfiguration config)
        {
            //var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var client = new MongoClient(config.GetConnectionString("ICDb")); 
            var database = client.GetDatabase("ICDb");
            _documents = database.GetCollection<Document>("Order");
        }

        public List<Document> Get()
        {
            return _documents.Find(document => true).ToList();
        }

        public Document Get(string id)
        {
            return _documents.Find<Document>(document => document.Id == id).FirstOrDefault();
        }

        public Document Create(Document document)
        {
            _documents.InsertOne(document);
            return document;
        }

        public void Update(string id, Document documentIn)
        {
            _documents.ReplaceOne(document => document.Id == id, documentIn);
        }

        public void Remove(Document documentIn)
        {
            _documents.DeleteOne(document => document.Id == documentIn.Id);
        }

        public void Remove(string id)
        {
            _documents.DeleteOne(document => document.Id == id);
        }
    }
}