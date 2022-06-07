using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class OrgUser
    {
        [Key]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string UserId { get; set; }
    }
}
