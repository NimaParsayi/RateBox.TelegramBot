using System;
using RateBox.Bot.DTOs;
using Telegram.Bot.Types.ReplyMarkups;

namespace RateBox.Bot.TextGenerators
{
    public static class EnglishTextGenrators
    {
        public static Tuple<string, InlineKeyboardMarkup> MovieDetails(MovieDto movie)
        {
            var imdbLink = "https://imdb.com/title/" + movie.Id;
            var text = $"- <i>{movie.Type.ToUpperInvariant()}</i>" +
                $"\n<strong>🎦 Title:</strong> <a href=\"{imdbLink}\">{movie.Title}</a> <i>[{movie.Year}]</i>" +
                $"\n- <i>{movie.Runtime}</i>" +
                $"\n⭐ <strong>IMDb</strong> Rating is <i>{movie.IMDBRating}/10</i>" +
                $"\n- <i>of <strong>{movie.IMDBRates}</strong> Votes</i>" +
                $"\n<strong>🌎 Country:</strong> {EnglishNames.ConvertCountries(movie.Country)}" +
                $"\n<strong>ℹ️ Rated:</strong> {movie.Rated}" +
                $"\n<strong>🎭 Genres:</strong> {EnglishNames.ConvertGenres(movie.Genre)}" +
                $"\n<strong>👥 Stars:</strong> {movie.Actors}" +
                $"\n<strong>🎬 Director:</strong> {movie.Director}" +
                $"\n<strong>✍️ Writer:</strong> {movie.Writer}" +
                $"\n<strong>📝 Storyline:</strong> <i>{movie.Plot}</i>" +
                $"\n<a href=\"{movie.Poster}\">&#160</a>";
            var keyboard = new InlineKeyboardMarkup(new[]
            {
            new[]
            {
                InlineKeyboardButton.WithUrl("🔗 Join Ratebox Channel", "https://t.me/RateBox")
            }
        });

            return new Tuple<string, InlineKeyboardMarkup>(text, keyboard);
        }
    }

    public static class EnglishNames
    {
        public static string ConvertCountries(string countries)
        {
            var splitedCountries = countries.Split(',');
            for (var i = 0; i < splitedCountries.Length; i++)
            {
                splitedCountries[i] = splitedCountries[i].ToLower().TrimStart() switch
                {
                    "united states" => "🇺🇸 #United_States",
                    "greece" => "🇬🇷 #Greece",
                    "germany" => "🇩🇪 #Germany",
                    "israel" => "🇮🇱 #Israel",
                    "egypt" => "🇪🇬 #Egypt",
                    "south korea" => "🇰🇷 #South_Korea",
                    "korea" => "🇰🇷 #South_Korea",
                    "japan" => "🇯🇵 #Japan",
                    "spain" => "🇪🇸 #Spain",
                    "italy" => "🇮🇹 #Italy",
                    "australia" => "🇦🇺 #Australia",
                    "canada" => "🇨🇦 #Canada",
                    "united kingdom" => "🇬🇧 #United_Kingdom",
                    "india" => "🇮🇳 #India",
                    "afghanistan" => "🇦🇫 #Afghanistan",
                    "brazil" => "🇧🇷 #Brazil",
                    "colombia" => "🇨🇴 #Colombia",
                    "brasil" => "🇧🇷 #Brazil",
                    "china" => "🇨🇳 #China",
                    "france" => "🇫🇷 #France",
                    "finland" => "🇫🇮 #Finland",
                    "georgia" => "🇬🇪 #Georgia",
                    "pakistan" => "🇵🇰 #Pakistan",
                    "iraq" => "🇮🇶 #Iraq",
                    "syria" => "🇸🇾 #Syria",
                    "iran" => "🇮🇷 #Iran",
                    "portugal" => "🇵🇹 #Portugal",
                    "russia" => "🇷🇺 #Russia",
                    "ukraine" => "🇺🇦 #Ukraine",
                    "saudi arabia" => "🇸🇦 #Saudi_Arabia",
                    "turkey" => "🇹🇷 #Turkey",
                    "yemen" => "🇾🇪 #Yemen",
                    "chile" => "🇨🇱 #Chile",
                    "mexico" => "🇲🇽 #Mexico",
                    "hong kong" => "🇭🇰 #Hong_Kong",
                    "vietnam" => "🇻🇳 #Vietnam",
                    "switzerland" => "🇨🇭 #Switzerland",
                    _ => splitedCountries[i]
                };
            }

            return String.Join(", ", splitedCountries);
        }

        public static string ConvertGenres(string genres)
        {
            var splitedGenres = genres.Split(',');
            for (var i = 0; i < splitedGenres.Length; i++)
            {
                splitedGenres[i] = splitedGenres[i].ToLower().TrimStart() switch
                {
                    "action" => "#Action",
                    "comedy" => "#Comedy",
                    "crime" => "#Crime",
                    "thriller" => "#Thriller",
                    "western" => "#Western",
                    "drama" => "#Drama",
                    "horror" => "#Horror",
                    "fantasy" => "#Fantasy",
                    "mystery" => "#Mystery",
                    "romance" => "#Romance",
                    "sci-fi" => "#SciFi",
                    "adventure" => "#Adventure",
                    "musical" => "#Musical",
                    "biography" => "#Biography",
                    "document" => "#Document",
                    "sport" => "#Sport",
                    "talk show" => "#Talk_Show",
                    "superhero" => "#Superhero",
                    "noir" => "#NOIR",
                    _ => splitedGenres[i]
                };
            }

            return String.Join(" , ", splitedGenres);
        }
    }
}