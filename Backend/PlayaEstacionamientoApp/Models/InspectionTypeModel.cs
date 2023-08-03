using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class InspectionTypeModel
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string InspectionName { get; set; } = string.Empty;
    }
}
