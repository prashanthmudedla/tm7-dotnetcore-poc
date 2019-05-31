using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentsApi.Models
{
 /*   public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }
    }

    */

    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FundId")]
        public int FundId { get; set; }

        [BsonElement("CompanyID")]
        public int CompanyID { get; set; }

        [BsonElement("PDFLocation")]
        public string PDFLocation { get; set; }

        [BsonElement("Language")]
        public string Language { get; set; }
    
    }
}