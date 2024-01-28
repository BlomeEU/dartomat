using System.Net;

using Dartomat.Core.Contracts;
using Dartomat.Core.Domain;
using Dartomat.Core.Services.Contracts;

using MassTransit;
using MassTransit.Mediator;

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
    public class GetGameHistory(ILogger<GetGameHistory> logger, IBus bus, IMediator mediator)
    {


        //// Add these three attribute classes below
        [Function("GetGameHistory")]
        [OpenApiOperation(operationId: "Get Game History", tags: new[] { "game" }, Summary = "Update an existing pet", Description = "This updates an existing pet.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Game[]), Summary = "Pet details updated", Description = "Pet details updated")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Pet not found", Description = "Pet not found")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.MethodNotAllowed, Summary = "Validation exception", Description = "Validation exception")]
        public IActionResult Get([HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/game")] HttpRequest req)
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }

        // Add these three attribute classes below
        [Function("AddGameToHistory")]
        [OpenApiOperation(operationId: "Add Game History", tags: new[] { "game" }, Summary = "Update an existing pet", Description = "This updates an existing pet.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(Game), Description = "The Game to Post")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Pet details updated", Description = "Pet details updated")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Pet not found", Description = "Pet not found")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.MethodNotAllowed, Summary = "Validation exception", Description = "Validation exception")]
        public async Task<IActionResult> PostAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/game")] HttpRequest req, [FromBody] Game game)
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");

            //await mediator.Send(new GamePlayed { Game = game });
            var client = mediator.CreateRequestClient<GamePlayed>();
            return new OkObjectResult(await client.GetResponse<GamePlayed>(new GamePlayed { Game = game}));
        }
    }
}
