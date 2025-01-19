using DataAccess.CreditModule.Repository.Shared;
using Moq;

namespace CreditModule.Tests.Mock;

public static class DataAccessMock
{

    public static Mock<ICreditRepository> CreditRepositoryMock
    {
        get
        {
            Mock<ICreditRepository> mock = new();
            return mock;
        }
    }
}