using System;
using System.ComponentModel.DataAnnotations;

namespace Zadanie2.Components
{
    public class game
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public float? Rate { get; set; }

        public string? ImageUrl { get; set; }
    }
}