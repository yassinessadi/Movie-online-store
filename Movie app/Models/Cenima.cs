using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_app.Models
{
    public class Cenima
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cinema Logo")]
        public string CenimaLogo { get; set; }
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        //relationships
        public List<Movie> Movies { get; set; }
    }
}
