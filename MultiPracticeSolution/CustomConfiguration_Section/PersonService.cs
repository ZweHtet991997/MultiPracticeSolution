namespace CustomConfiguration_Section
{
    public class PersonService
    {
        private readonly IConfiguration _configuration;

        public PersonService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Method 1
        public string GetPersonEmail()
        {
            return _configuration.GetValue<string>("email");
        }

        //Method 2
        public string GetPersonEmail_1()
        {
            return _configuration.GetSection("Profile").GetSection("email").Value;
        }
    }
}
