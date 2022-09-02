namespace FindMyPG.Models
{
    public class StateModel : BaseModel
    {
        public StateModel()
        {
            Citys = new List<CityModel>();
        }
        public string Name { get; set; }

        public List<CityModel> Citys { get; set; }
    }
    public class StateModelRequest
    {
        public StateModelRequest()
        {
            Citys = new List<CityModelRequest>();
        }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public List<CityModelRequest> Citys { get; set; }
    }
    public class StateModelUpdateRequest
    {
        public string StateName { get; set; }   
        public bool IsActive { get; set; }  
    }

}
