using Application.WeatherForecasts.Command;
using Application.WeatherForecasts.Query;
using Application.WeatherForecasts.Response;
using Domain.WeatherForecasts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Net;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ISender _sender;

    public WeatherForecastController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("/list")]
    [ProducesResponseType(typeof(WeatherForecastResponse),
        (int)HttpStatusCode.OK
    )]
    public async Task<ActionResult<IEnumerable<WeatherForecastResponse>>> GetList(
        CancellationToken cancellationToken
    )
    {
        var registros = await _sender.Send(new WeatherForecastList(), cancellationToken);

        if (registros is null || registros.Count() == 0)
            return new NotFoundResult();

        return Ok(registros);
    }

    [HttpGet("/city")]
    [ProducesResponseType(typeof(WeatherForecastResponse),
        (int)HttpStatusCode.OK
    )]
    public async Task<ActionResult<IEnumerable<WeatherForecastResponse>>> GetCity(
        [FromQuery] string city,
        CancellationToken cancellationToken
    )
    {
        var registro = await _sender.Send(new WeatherForecastCity(city), cancellationToken);

        if (registro is null || registro.Count() == 0)
            return new NotFoundResult();  

        return Ok(registro);
    }

    [HttpPost("/add")]
    [ProducesResponseType(typeof(Guid),
        (int)HttpStatusCode.Created
    )]
    public async Task<ActionResult<Guid>> Add(
        [FromBody] WeatherForecastAddCommand temperature,
        CancellationToken cancellationToken
    )
    {
        var registro = await _sender.Send(temperature, cancellationToken);        
        return Created("/add", registro);
    }

    [HttpPut("/update")]
    [ProducesResponseType(typeof(WeatherForecastResponse),
        (int)HttpStatusCode.Accepted
    )]
    public async Task<ActionResult<IEnumerable<WeatherForecastResponse>>> Update(
        WeatherForecastUpdateCommand temperature,
        CancellationToken cancellationToken
    )
    {
        var registro = await _sender.Send(temperature, cancellationToken);
        
        if (registro is null || registro.Count() == 0)
            return new NotFoundResult();

        return Accepted("/update", registro);
    }
    
    [HttpDelete("/remove")]
    [ProducesResponseType(typeof(int),
        (int)HttpStatusCode.Accepted
    )]
    public async Task<ActionResult<int>> Remove(
        [FromQuery] WeatherForecastRemoveCommand temperature,
        CancellationToken cancellationToken
    )
    {
        var registro = await _sender.Send(temperature, cancellationToken);

        if (registro == 0) 
            return NotFound();

        return Accepted("/delete", registro);
    }
}