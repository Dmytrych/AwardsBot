using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AwardBot.Handling.UpdateHandlers
{
    public interface IBotUpdateHandler
    {
        Task UpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
    }
}