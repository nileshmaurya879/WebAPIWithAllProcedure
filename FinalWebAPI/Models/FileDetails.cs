﻿namespace FinalWebAPI.Models
{
    public class FileDetails
    {
        public int ID { get; set; }
        public string? FileName { get; set; }
        public byte[] FileData { get; set; }
        public string? FileType { get; set; }
    }
}
