using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("products/GetProductsWithCategory");

            return response.Data;
        }

        public async Task<ProductDto> SaveAsync(ProductDto newProductDto)
        {
            var response = await _httpClient.PostAsJsonAsync("products", newProductDto);
            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(ProductDto newProductDto)
        {
            
           var response = await _httpClient.PutAsJsonAsync("products", newProductDto);

            return response.IsSuccessStatusCode;
            
        }
        public async Task<bool> UpdateAsync(int id)
        {

            var response = await _httpClient.DeleteAsync($"products/{id}");

            return response.IsSuccessStatusCode;

        }
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var respone = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");
            return respone.Data;
        }

    }
}
