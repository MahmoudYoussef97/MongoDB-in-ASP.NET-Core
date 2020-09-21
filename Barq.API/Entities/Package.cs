using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Barq.API.Entities
{
    public class Package
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        public int NumberOfRides { get; set; }
        public int LimitedNumberPerRides { get; set; }
        public int NumberOfGiftCodes { get; set; }
    }
}
