using ApplicationLayer.CreditModule.Dto.DTOs;

namespace ApplicationLayer.CreditModule.Dto.Outgoing
{
    public class GetAllCreditsResponse : BaseResponse
    {
        public List<CreditInvoiceDto> Credits { get; set; }
    }
}
