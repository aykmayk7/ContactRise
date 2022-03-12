﻿using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Report.Aggregator.Models
{
    public class ReportInfoCreate
    {
        [BsonElement("ReportId")]
        public Guid ReportId { get; set; }

        [BsonElement("ReportName")]
        public string ReportName { get; set; }

        [BsonElement("SavePath")]
        public string SavePath { get; set; }
    }
}
