using BlazorWasmAuthentication.Models;
using System.Net.Http.Json;

namespace BlazorWasmAuthentication.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly HttpClient _httpClient;

        public ReviewRepository(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ServerApi");
        }

        public async Task<IEnumerable<BookReview>> GetReviewsAsync()
        {
            return  await _httpClient.GetFromJsonAsync<BookReview[]>("api/BookReviews") ?? Array.Empty<BookReview>();
        }

        public async Task<IEnumerable<BookReview>> GetReviewSummariesAsync()
        {
            return await _httpClient.GetFromJsonAsync<BookReview[]>("api/BookReviews/Summary") ?? Array.Empty<BookReview>();
        }
    }
}
