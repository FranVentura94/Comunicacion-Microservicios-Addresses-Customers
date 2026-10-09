using BuildingBlocks.Rest.Exceptions;
using BuildingBlocks.Rest.Interfaces.IServices;
using Business.Core.Config;
using Business.Core.Dtos;
using Business.Core.Interfaces.Services;
using Common.Wrappers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Business.Infraestructure.ApiAddresses
{
    public class AddressService : IAddressService
    {
        private readonly IRest _rest;
        private readonly ApiAddressesConfig _config;

        public AddressService(IRest rest, IOptions<ApiAddressesConfig> options)
        {
            _rest = rest;
            _config = options.Value;
        }

        public async Task<HttpResponse<AddressDto>> AddAsync(AddressDto address)
        {
            try
            {
                return await _rest.Post
                    .WithoutAuth()
                    .WithUri(_config.BaseUrl, "Position")
                    .WithBody(address)
                    .DeserializeWithAsync<HttpResponse<AddressDto>>();
            }
            catch (ApiException ex) when (ex.Reason == ApiFailureReason.HttpError && !string.IsNullOrEmpty(ex.ResponseBody))
            {
                var error = JsonConvert.DeserializeObject<HttpResponse<AddressDto>>(ex.ResponseBody);
                error.Succeeded = false;
                error.ErrorCode = ex.StatusCode ?? 500;
                return error;
            }
            catch (ApiException ex)
            {
                return new HttpResponse<AddressDto>(null)
                {
                    Succeeded = false,
                    ErrorCode = ex.StatusCode ?? 503,
                    ErrorMessage = $"No fue posible comunicarse con Addresses ({ex.Reason}): {ex.Message}"
                };
            }
        }
    }
}