using System.Net;
using System.Net.Mime;
using System.Text.Json;

using Dartomat.Core;
using Dartomat.Core.Domain;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace Dartomat.Presentation.Functions.GameHistory
{
    public class GetGameHistory
    {
        private readonly ILogger<GetGameHistory> _logger;

        public GetGameHistory(ILogger<GetGameHistory> logger)
        {
            _logger = logger;
        }


        //// Add these three attribute classes below
        //[Function("GetGameHistory")]
        //[OpenApiOperation(operationId: "Get Game History", tags: new[] { "game" }, Summary = "Update an existing pet", Description = "This updates an existing pet.", Visibility = OpenApiVisibilityType.Important)]
        //[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Game[]), Summary = "Pet details updated", Description = "Pet details updated")]
        //[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
        //[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Pet not found", Description = "Pet not found")]
        //[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.MethodNotAllowed, Summary = "Validation exception", Description = "Validation exception")]
        //public IActionResult Get([HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/game")] HttpRequest req)
        //{
        //    _logger.LogInformation("C# HTTP trigger function processed a request.");
        //    return new OkObjectResult("Welcome to Azure Functions!");
        //}

        // Add these three attribute classes below
        [Function("AddGameToHistory")]
        [OpenApiOperation(operationId: "Add Game History", tags: new[] { "game" }, Summary = "Update an existing pet", Description = "This updates an existing pet.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(Game), Description = "The Game to Post")]
        //[OpenApiRequestBody(contentType: "application/json", bodyType: typeof(SetGame), Description = "The Game to Post")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Pet details updated", Description = "Pet details updated")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Pet not found", Description = "Pet not found")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.MethodNotAllowed, Summary = "Validation exception", Description = "Validation exception")]
        public IActionResult Post([HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/game2")] HttpRequest req, [FromBody] Game game)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(game);
        }
    }
}
