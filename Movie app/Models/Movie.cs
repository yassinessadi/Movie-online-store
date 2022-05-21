using Movie_app.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_app.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        //relationships
        public List<Actor_Movie> Actor_Movies { get; set; }
        //Cenima
        public int CenimaId { get; set; }
        [ForeignKey("CenimaId")]
        public Cenima Cenima { get; set; }

        //producer
        public int ProducerId { get; set; }
        [ForeignKey("CenimaId")]
        public Producer Producer { get; set; }
    }
}
