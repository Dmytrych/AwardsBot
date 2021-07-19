using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AwardBot.Handling.UpdateHandlers
{
    public class AwardBotUpdateHandler : IBotUpdateHandler
    {
        public Task UpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}