namespace MovieMicroservice.Models
{
    public class CredentialsModel
    {
        public string BaseUrl { get; set; }
        public string Api_key { get; set; }

        public CredentialsModel(string api_key)
        {
            Api_key = api_key;
        }
    }
}
