
namespace Nextech.Core.Interfaces;

public interface IClientBase
{
    Task<T> Request<T>(string url) where T : new();
}
