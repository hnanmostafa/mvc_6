namespace ServiceLifeTime.Services
{
    public interface ISingletoneService
    {
        string GetGuid();

    }
    public class SingletoneService : ISingletoneService
    {
        private Guid guid;
        public SingletoneService() 
        {
         guid = Guid.NewGuid();
        }
        public string GetGuid()=>guid.ToString();
        
    }
}
