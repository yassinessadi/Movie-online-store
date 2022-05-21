using Movie_app.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_app.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Profile Picture Url")]
        [Required(ErrorMessage ="Profile picture is valid")]
        public string ProfilePictureUrl { get; set; }

        [Required(ErrorMessage = "please enter valid name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Please enter valid biography")]
        public string Bio { get; set; }

        //relationships
        public List<Actor_Movie> Actor_Movies { get; set; }

    }
}
