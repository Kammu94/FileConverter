using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileConverter.Models
{
    public class FileModels
    {
        public string Name { get; set; }
        public string FileId { get; set; }
        public double Size { get; set; }
        //public FileType Type { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string InvoiceNo { get; set; }
        public string App { get; set; }
        public int TotalRecords { get; set; }
        
        public string InternalFileName { get; set; }
        public string CountryCode { get; set; }
        public bool IsDeltaFile { get; set; }
    }
}