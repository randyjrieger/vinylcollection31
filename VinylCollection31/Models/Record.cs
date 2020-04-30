using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinylCollection31.Models
{
    public enum AlbumCondition
    {
        NotRated = 0,
        Poor = 1,
        Good = 2,
        Excellent = 3
    };

    public class Record
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public AlbumCondition Condition { get; set; }
    }
}
