using BlazorWasmAuthentication.Models;

namespace BlazorWasmAuthentication.Services
{
    public interface IReviewRepository
    {
        Task<IEnumerable<BookReview>> GetReviewsAsync();
        Task<IEnumerable<BookReview>> GetReviewSummariesAsync();
    }
}
