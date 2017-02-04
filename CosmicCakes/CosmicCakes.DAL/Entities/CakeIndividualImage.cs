using System.ComponentModel.DataAnnotations.Schema;

namespace CosmicCakes.DAL.Entities
{
    public class CakeIndividualSquareImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [ForeignKey("SimpleReadyCake")]
        public int CakeId { get; set; }
        public virtual SimpleReadyCake SimpleReadyCake { get; set; }
    }
    public class CakeIndividualRectangleImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [ForeignKey("SimpleReadyCake")]
        public int CakeId { get; set; }
        public virtual SimpleReadyCake SimpleReadyCake { get; set; }
    }
}
