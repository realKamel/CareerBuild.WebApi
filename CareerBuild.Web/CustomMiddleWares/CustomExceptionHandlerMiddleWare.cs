using Domain.Exceptions;
using Microsoft.Data.SqlClient;
using Serilog;
using Shared.ErrorModels;

namespace CareerBuild.Web.CustomMiddleWares
{
	public class CustomExceptionHandlerMiddleWare(RequestDelegate next)
	{
		private readonly RequestDelegate _next = next;

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
				await HandleNotFoundEndPointAsync(context);

			}
			catch (Exception e)
			{
				Log.Error(e.Message);
				await HandleExceptionAsync(context, e);
			}
		}

		private static async Task HandleExceptionAsync(HttpContext context, Exception e)
		{
			var res = new ErrorToReturn()
			{
				StatusCode = context.Response.StatusCode,
				ErrorMessage = e.Message
			};

			// we change status code for response 
			context.Response.StatusCode = e switch
			{
				WrongLoginException => StatusCodes.Status401Unauthorized,
				NotFoundException => StatusCodes.Status404NotFound,
				BadRequestException req => GetExceptionErrors(req, res),
				_ => StatusCodes.Status500InternalServerError
			};

			//Create response Object 
			// Return this object as json
			// we need to change content type of response (Json not text) done by WriteAsJsonAsync();
			await context.Response.WriteAsJsonAsync(res);
		}

		private static int GetExceptionErrors(BadRequestException requestException,
			ErrorToReturn errorToReturn)
		{
			errorToReturn.Errors = requestException.Errors;
			return StatusCodes.Status400BadRequest;
		}

		private static async Task HandleNotFoundEndPointAsync(HttpContext context)
		{
			if (context.Response.StatusCode == StatusCodes.Status404NotFound)
			{
				var res = new ErrorToReturn()
				{
					StatusCode = StatusCodes.Status404NotFound,
					ErrorMessage = $"End Point {context.Request.Path} is Not Found"
				};
				await context.Response.WriteAsJsonAsync(res);
			}
		}
	}
}
