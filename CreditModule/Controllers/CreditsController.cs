using ApplicationLayer.CreditModule.Service.Shared;
using CreditModule.DomainModels.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CreditModule.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditsController(ICreditService creditService) : ControllerBase
{
    [HttpGet("GetWithInvoices")]
    public async Task<IActionResult> GetAllCreditsWithInvoices()
    {
        var response = await creditService.GetCreditsWithInvoices();

        if (response.HasError)
        {
            return StatusCode((int)response.StatusCode, response);
        }
        return Ok(response);
    }

    #region Swagger Documentation
    /// <summary>
    /// Get status by different payment types
    /// </summary>
    /// <param name="status">
    ///     **Example:**
    ///     <remarks>
    ///         1 - Paid,
    ///         2 - Awaiting Payment
    /// 
    ///     </remarks>
    /// </param>
    /// 
    /// <response code="200">Returned Status successfully</response>
    /// <response code="400">Invalid payment type</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    #endregion
    [HttpGet("GetStatusData/{status}")]
    public async Task<IActionResult> GetStatusData(PaymentTypes status)
    {
        var response = await creditService.GetStatusData(status);

        if (response.HasError)
        {
            return StatusCode((int)response.StatusCode, response);
        }

        return Ok(response);
    }
}