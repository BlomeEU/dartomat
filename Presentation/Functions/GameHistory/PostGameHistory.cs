using Dartomat.Core.Domain;
using System.Net;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using MassTransit.Mediator;
using Contracts.Events;

namespace Presentation.Functions.GameHistory;

public class PostGameHistory(ILogger<PostGameHistory> logger, IMediator mediator)
{
    [Function("AddGameToHistory")]
    [OpenApiOperation(operationId: "Add Game History", tags: new[] { "game" }, Summary = "Insert Game", Description = "This creates a new Game.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(Game), Description = "The Game to Post")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Game created", Description = "Game successfully created")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Validation exception", Description = "Validation exception")]
    public async Task<IActionResult> PostAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/game")] HttpRequest req, [FromBody] Game game)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");
        var client = mediator.CreateRequestClient<GamePlayed>();
        return new OkObjectResult(await client.GetResponse<GamePlayed>(new GamePlayed { Game = game }));
    }
}
