using System.Threading;
using System.Threading.Tasks;
using AwardBot.Handling.ErrorHandlers;
using AwardBot.Handling.UpdateHandlers;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace AwardBot
{
    internal class AwardBot : IAwardBot
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IBotUpdateHandler _botUpdateHandler;
        private readonly IBotErrorHandler _botErrorHandler;

        public AwardBot(
            ITelegramBotClient telegramBotClient,
            IBotUpdateHandler botUpdateHandler,
            IBotErrorHandler botErrorHandler)
        {
            _telegramBotClient = telegramBotClient;
            _botUpdateHandler = botUpdateHandler;
            _botErrorHandler = botErrorHandler;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            var updateHandler = new DefaultUpdateHandler(_botUpdateHandler.UpdateAsync, _botErrorHandler.ProcessAsync);

            while (!cancellationToken.IsCancellationRequested)
            {
                Update[] updates = await _telegramBotClient.GetUpdatesAsync(0, 0, 0, null, cancellationToken);

                foreach (var update in updates)
                {
                    updateHandler.HandleUpdate(_telegramBotClient, update, cancellationToken);
                }
            }
        }
    }
}