using FindMyPG.Core.Entities;

namespace FindMyPG.Models
{
    public class ZipCodeModel:BaseModel
    {
        public int Value { get; set; }
        public int CityId { get; set; }
        public string AreaName { get; set; }
    }
}
