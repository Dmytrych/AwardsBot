using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace AwardBot.Handling.ErrorHandlers
{
    public interface IBotErrorHandler
    {
        public Task ProcessAsync(ITelegramBotClient client, Exception update, CancellationToken cancellationToken);
    }
}