using AwardBot.Handling.ErrorHandlers;
using AwardBot.Handling.UpdateHandlers;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.Enums;

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

        public void Start()
        {
            new DefaultUpdateHandler(_botUpdateHandler.UpdateAsync, _botErrorHandler.ProcessAsync, null);
        }
    }
}