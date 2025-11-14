using Api.TransferModels.GenericDto;

namespace Api.Mappers;

public static class ResponseMappers
{
    public static ReturnBoolDto ToReturnedBoolDto(this bool model)
    {
        return new ReturnBoolDto
        {
            isTrue = model
        };
    }

    public static ResponseDto ToResponseDto<T>(this T responseData, string message)
    {
        return new ResponseDto
        {
            MessageToClient = message,
            ResponseData = responseData
        };
    }
}