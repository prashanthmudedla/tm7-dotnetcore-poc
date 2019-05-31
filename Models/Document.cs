using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentsApi.Models
{
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