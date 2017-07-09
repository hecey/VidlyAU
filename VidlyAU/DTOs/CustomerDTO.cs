using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyAU.Models;

namespace VidlyAU.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSuscribedToNewsletter { get; set; }

        //public MembershipType MembershipType { get; set; }

        //[Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        //[Display(Name = "Date of Birth")]
      //  [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}