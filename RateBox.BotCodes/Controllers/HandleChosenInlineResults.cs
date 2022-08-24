using System.Threading.Tasks;
using RateBox.Bot.ApiHandler;
using RateBox.Bot.TextGenerators;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace RateBox.Bot.Controllers
{
    public class HandleChosenInlineResults
    {
        public async Task CheckMessage(ITelegramBotClient bot, ChosenInlineResult message)
        {
            if (message.ResultId != "howtosearch")
            {
                var movieId = message.ResultId.Replace("title-", null);
                var movie = await OmdbHandler.GetMovieDetails(movieId);
                var tuple = EnglishTextGenrators.MovieDetails(movie);

                await bot.EditMessageTextAsync(message.InlineMessageId, tuple.Item1, ParseMode.Html, replyMarkup: tuple.Item2);
            }
        }
    }
}