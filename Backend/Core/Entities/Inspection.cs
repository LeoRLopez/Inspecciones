using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Inspection
    {
        public int Id { get; set; }

        public int StatusId { get; set; }
        public Estado? Status { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int InspectionTypeId { get; set; }

        public InspectionType? InspectionType { get; set; }
    }
}
