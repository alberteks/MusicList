﻿namespace MusicList.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
    }
}
