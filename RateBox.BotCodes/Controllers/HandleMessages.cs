using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RateBox.Bot.Controllers
{
    public class HandleMessages
    {
        public async Task CheckMessage(ITelegramBotClient bot, Message msg)
        {
            if (msg.Chat.Type == ChatType.Private)
            {
                var text = $"*This bot can help Find and Share movies with your friends.*" +
                           $"\nRateBox can work in any Chat, just type @RateBoxBot and then title of Movie, in the end select title !" +
                           $"\n\n🔗 Subscribe @RateBox for bot news." +
                           $"\n🪲 Share Suggests/Bugs with me -> @NParsayi";
                var keyboard = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithSwitchInlineQuery("🔎 Search", ""),
                        InlineKeyboardButton.WithUrl("☕ Buy Me a Coffee", "https://t.me/RateBox/2"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithUrl("🍿 Movie/Series News", "https://t.me/ComicBookStation")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithUrl("🔗 Rate Box News Channel", "https://t.me/RateBox")
                    }
                });

                await bot.SendTextMessageAsync(msg.From.Id, text, ParseMode.Markdown, replyMarkup: keyboard);
            }
        }
    }
}
