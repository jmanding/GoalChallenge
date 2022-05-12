using GoalChallenge.Common.Exceptions;
using System.Net;

namespace GoalChallenge.Api.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NoDataException ex)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (ArgumentNullException ex) 
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusCode httpStatusCode, string messageException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            return context.Response.WriteAsync(messageException);


   //         var responseMessageList = ResponseMessageList.createNewResponseMessageList();

   //         if (exception is RethinkSoftwareException)
			//{
   //             context.Response.StatusCode = (int)HttpStatusCode.OK;
   //             responseMessageList = responseMessageList.addWarning(exception.Message);
   //         }
   //         else
			//{
   //             context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
   //             responseMessageList = responseMessageList.addError(exception);
   //         }
            
            //var exceptionMessageJson = JsonConvert.SerializeObject(new Response<dynamic>("", responseMessageList), new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            //return context.Response.WriteAsync(exceptionMessageJson);
        }
    }
}
