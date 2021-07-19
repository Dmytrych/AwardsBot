using System.Threading;
using System.Threading.Tasks;

namespace AwardBot
{
    internal interface IAwardBot
    {
        Task Start(CancellationToken cancellationToken);
    }
}