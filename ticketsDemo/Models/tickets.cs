using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticketsDemo.Models
{
    public class tickets
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubmittedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ClosedDate { get; set; }

        public int severity { get; set; }
        public int priority { get; set; }

        public int assigneeId { get; set; }

        [ForeignKey("assigneeId")]
        public virtual assignee assignee { get; set; }

        public int submitterId { get; set; }

        [ForeignKey("submitterId")]
        public virtual submitter submitter { get; set; }

        public string description { get; set; }

        public int statusId { get; set; }

        [ForeignKey("statusId")]
        public virtual status status { get; set; }



    }

    public class submitter
    {
        public int Id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string fullName { get; set; }

    }

    public class status
    {
        public int id { get; set; }

        public string statusName { get; set; }
    }

    public class comments
    {
        public int id { get; set; }

        public int ticketID { get; set; }

        [ForeignKey("ticketID")]
        public virtual tickets tickets { get; set; }

        [DataType(DataType.Date)]
        public DateTime commentDate { get; set; }

        public string commentDescription { get; set; }

        public int assigneeId { get; set; }

        [ForeignKey("assigneeId")]
        public virtual assignee assignee { get; set; }
    }

    public class assignee
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public int isActive { get; set; }

        [DataType(DataType.Date)]
        public DateTime hireDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime terminationDate { get; set; }

    }

}
