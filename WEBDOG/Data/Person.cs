using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        public Coato Coato { get; set; }
        public int CoatoId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BrithDay { get; set; }
        public string Phone { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string IssuingOrg { get; set; }
        public string TagNumber { get; set; }
        public string Address { get; set; }
        public string University { get; set; }
        public string Specialization { get; set; }
    }
}