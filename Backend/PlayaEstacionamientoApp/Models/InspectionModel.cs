using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Models
{
    public class InspectionModel
    {
        public int Id { get; set; }

        public int StatusId { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int InspectionTypeId { get; set; }
        public InspectionType? InspectionType { get; set; }
    }
}
