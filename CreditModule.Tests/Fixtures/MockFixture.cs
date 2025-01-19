using AutoMapper;
using CreditModule.Tests.Mock;
using DataAccess.CreditModule.Repository.Shared;
using Moq;

namespace CreditModule.Tests.Fixtures;

public class MockFixture : IDisposable
{
    #region Non-Mock Services
    public IMapper Mapper { get; } = Utilities.AutoMapper.GetMapper;
    #endregion

    #region Mock Data Providers

    public Mock<ICreditRepository> CreditRepositoryMock { get; } = DataAccessMock.CreditRepositoryMock;

    #endregion

    #region IDisposable Implementation
    public void Dispose()
    {
        ResetAllMocks();
    }

    private void ResetAllMocks()
    {
        CreditRepositoryMock.Reset();
    }
    #endregion
}