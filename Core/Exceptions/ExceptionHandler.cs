using Core.Responses;

namespace Core.Exceptions;
public static class ExceptionHandler<T>
{

    public static ReturnModel<T> HandleException(Exception exception)
    {
        if (exception.GetType() == typeof(NotFoundException))
        {
            return new ReturnModel<T>
            {
                Message = exception.Message,
                StatusCode = 404,
                Success = false
            };
        }

        if (exception.GetType() == typeof(BusinessException))
        {
            return new ReturnModel<T>
            {
                Message = exception.Message,
                StatusCode = 400,
                Success = false
            };
        }
        if (exception.GetType() == typeof(ArgumentNullException))
        {
            return new ReturnModel<T>
            {
                Message = exception.Message,
                StatusCode = 400,
                Success = false
            };
        }
        return new ReturnModel<T>
        {
            Message = exception.Message,
            StatusCode = 500,
            Success = false
        };
    }
}