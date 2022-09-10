using Azure.Storage.Blobs;
using CelsoMusic.Infra.Storage.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CelsoMusic.Infra.Storage
{
    public class Storage : IStorage
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public Storage(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Upload(string imageUrl)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            using var response = await httpClient.GetAsync(imageUrl);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();

                var blobServiceClient = new BlobServiceClient(_configuration["StorageConnectionString"]);
                var container = blobServiceClient.GetBlobContainerClient("images");

                var fileName = $"{Guid.NewGuid()}.jpg";
                await container.UploadBlobAsync(fileName, stream);

                return $"{_configuration["StorageBasePath"]}/images/{fileName}";
            }
            else
            {
                throw new FileNotFoundException($"Erro ao ler a imagem no caminho '{imageUrl}'.");
            }
        }
    }
}
