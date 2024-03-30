using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWasm.Shared
{
    public class Item
    {

        public int Id { get; set; }

        //[Column(TypeName = "varchar(50)")]
        public string Code { get; set; }
        
       //[Column(TypeName = "varchar(200)")]
        public string Description { get; set; }        
       
        public bool Status { get; set; }        
       
        public bool IsActive { get; set; }
        
        public List<UnitOfMeasurement> UnitOfMeasurements { get; set;}

    }
}
