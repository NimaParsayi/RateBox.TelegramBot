﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace RateBox.Bot.Controllers
{
    public class HandleInlineQueries
    {
        public async Task CheckText(ITelegramBotClient bot, InlineQuery query)
        {
            if (query.Query.Trim() != "")
            {
                var list = new List<InlineQueryResultArticle>();
                foreach (var item in await ApiHandler.OmdbHandler.SearchByName(query.Query))
                {
                    var text = $"- Title: {item.Title}" +
                               $"\n- Year: {item.Year}";

                    var iqrp = new InlineQueryResultArticle(
                        id: "title-" + item.Id,
                        title: $"{item.Title}",
                        inputMessageContent: new InputTextMessageContent(text)
                    )
                    {
                        Description = $"Year: {item.Year}",
                        ThumbUrl = item.Poster,
                        ThumbHeight = 400,
                        ThumbWidth = 80,
                        ReplyMarkup = new InlineKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithUrl("🔗 Rate Box Channel", "https://t.me/RateBox")
                            }
                        })
                    };
                    list.Add(iqrp);
                }

                try
                {
                    foreach (var item in list.FindAll(x => !x.ThumbUrl.StartsWith("http")))
                    {
                        list.Find(x => x.Id == item.Id).ThumbUrl = "https://s6.uupload.ir/files/1-40-512_jtkg.png";
                    }

                    var results = list.Take(10).ToArray();
                    await bot.AnswerInlineQueryAsync(inlineQueryId: query.Id, results: results, cacheTime: 0);
                }
                catch (Exception ex)
                {
                    // Nothing to Do !
                }
            }
        }
    }
}