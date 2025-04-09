using Microsoft.Extensions.Configuration;

namespace FinTrack.Infrastructure.Database.Abstractions;

public interface IDatabaseInitializeService
{
	void Initialize(IServiceProvider services, IConfiguration configuration);
}