namespace CookingAppApi.Services
{
    public class RecipeService
    {
        // Inject the HttpClient
        private readonly HttpClient _httpClient;
        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Create at least one Get method calling the API
        public async Task<Rootobject> GetRecipe(string searchTerm)
        {
           
            // Make a request, and store the response
            HttpResponseMessage response = await _httpClient.GetAsync(searchTerm);

            // Deserialize the response from JSON into C# objects. NOTE: we will ReadAsAsync() which requires the NuGet package: Microsoft.AspNet.WebApi.Client
            Rootobject result = await response.Content.ReadAsAsync<Rootobject>();

            return result;
        }
    }
}
