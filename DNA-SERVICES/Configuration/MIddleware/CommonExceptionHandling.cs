using System.Text;
using Serilog;
using System.Net;
using DNA_SERVICES.Application.Helper;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace DNA_SERVICES.Configuration.MIddleware
{
	public static class CommonExceptionHandling
	{
		public static Action<IApplicationBuilder> HandleError()
		{
			return builder =>
			{
				builder.Run(
					async context =>
					{
						ErrorMessage error;
						switch(context.Features.Get<IExceptionHandlerFeature>()?.Error)
						{
							case ValidationException validationException:
								context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
								error = new ErrorMessage("ValidationError", validationException.Message);
								Log.Warning(validationException, "VALIDATION ERROR: {0}.", string.Join(",", error.Messages));
								break;

                            case NotFoundException notFoundException:
                                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                error = new ErrorMessage("NotFoundException", notFoundException.Message);
                                Log.Warning(notFoundException, "NOTFOUND ERROR: {0}.", string.Join(",", error.Messages));
                                break;

                            case AppException appException:
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                error = new ErrorMessage("NotFoundException", appException.Message);
                                Log.Warning(appException, "APP ERROR: {0}.", string.Join(",", error.Messages));
                                break;
                            case Exception exception:
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                error = new ErrorMessage("NotFoundException", exception.Message);
                                Log.Warning(exception, "UNHANDLED ERROR: {0}.", string.Join(",", error.Messages));
                                break;
                            default:
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                error = new ErrorMessage("NotFoundException", "Unknown exception");
                                Log.Warning("UNKNOWN ERROR: Empty Exception.");
                                break;
                        }

                        var serializedError = JsonConvert.SerializeObject(error);

                        context.Response.ContentType = "application/json";

                        Log.Error("Called Method: " + context.Request.Path + " | HTTP Verb: " + context.Request.Method +
                            " | UserId: " + context.Request.Headers["userid"].ToString() +
                            " | Time: " + System.DateTime.Now.ToString("MM/dd/yyyy HH-mm-ss-fff") +
                            " | Message:" + string.Join(",", error.Messages));

                        await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(serializedError), 0, serializedError.Length)
                        .ConfigureAwait(false);
					});
			};
		}
	}
}

