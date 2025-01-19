using ApplicationLayer.CreditModule.Dto.DTOs;

namespace ApplicationLayer.CreditModule.Dto.Outgoing
{
    public class GetStatusDataResponse : BaseResponse
    {
        public StatusDTO Status { get; set; }
    }
}
