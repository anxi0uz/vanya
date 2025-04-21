// See https://aka.ms/new-console-template for more information
using Microsoft;
using Microsoft.Extensions.Options;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

HttpClient apiClient = new HttpClient();
const string baseUrl = "http://localhost:5043";


var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("7826804135:AAGO9TdJjpeKI6uUjZS5hBqJJkJN6Ji7AlI");

Dictionary<long, ShopStates> _userState = new Dictionary<long, ShopStates>();
Dictionary<long, Shop> _shopState = new Dictionary<long, Shop>();
//Dictionary<long, ContactDto> _userContact = new Dictionary<long, ContactDto>();


var me = await bot.GetMe();
Console.WriteLine($"Id {me.Id} - name {me.FirstName}");

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
bot.StartReceiving(UpdateMessage, Error);
Console.ReadKey();
cts.Cancel();

async Task Error(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
{

}

async Task UpdateMessage(ITelegramBotClient client, Update update, CancellationToken token)
{
    var message = update.Message;
    switch (update.Type)
    {
        case UpdateType.Message:
            if (message == null) return;
            if (_userState.TryGetValue(message.Chat.Id, out var state))
            {
                switch (state)
           
                {
                    case ShopStates.AwaitingPostShop:
                        _shopState[message.Chat.Id] = new Shop { name = message.Text };
                        _userState[message.Chat.Id] = ShopStates.AwaitingPostContactQuantity;
                        await bot.SendMessage(message.Chat.Id, "Хорошо! Теперь укажите количество:");
                        break;
                    case ShopStates.AwaitingPostContactQuantity:
                        if (_shopState.TryGetValue(message.Chat.Id, out var model))
                        {
                            model.quantity = Convert.ToInt32(message.Text);
                            _userState[message.Chat.Id] = ShopStates.AwaitingPostContactPriceShop;
                            await bot.SendMessage(message.Chat.Id, "Хорошо! Теперь укажите цену:");
                        }
                        break;
                    case ShopStates.AwaitingPostContactPriceShop:
                        if (_shopState.TryGetValue(message.Chat.Id, out model))
                        {
                            model.priceShop= Convert.ToInt32(message.Text);
                            _userState[message.Chat.Id] = ShopStates.AwaitingPostContactSupplierId;
                            await bot.SendMessage(message.Chat.Id, "Хорошо! Теперь укажите ID поставщика:");
                        }
                        break;
                    case ShopStates.AwaitingPostContactSupplierId:
                        if (_shopState.TryGetValue(message.Chat.Id, out model))
                        {
                            model.supplierId = Convert.ToInt32(message.Text);
                            _userState[message.Chat.Id] = ShopStates.AwaitingPostContactAssortmentId;
                            await bot.SendMessage(message.Chat.Id, "Хорошо! Теперь укажите ID ассортимента:");
                        }
                        break;
                    case ShopStates.AwaitingPostContactAssortmentId:
                        if (_shopState.TryGetValue(message.Chat.Id, out model))
                        {
                            model.assortmentId = Convert.ToInt32(message.Text);

                            //await bot.SendMessage(message.Chat.Id, "Хорошо! Теперь укажите ID ассортимента:");
                            var fractionJson = JsonSerializer.Serialize<Shop>(model);
                            var content = new StringContent(fractionJson, Encoding.UTF8, "application/json");
                            var response = await apiClient.PostAsync("http://localhost:5043/Shop", content);

                            await bot.SendMessage(message.Chat.Id, $"Ассортимент '{message.Text}' добавлен!");
                            _userState.Remove(message.Chat.Id);
                        }
                        break;
                }
            }
            switch (message.Text)
            {
                case "Привет":
                    var listButtons = new InlineKeyboardMarkup(new[]
                    {
            new [] {InlineKeyboardButton.WithCallbackData("Получить", "give")},
            new [] {InlineKeyboardButton.WithCallbackData("Отправить", "send")},
             });
                    client.SendMessage(message.Chat.Id, "Вы написали Привет", replyMarkup: listButtons);
                    break;
            }
            break;
        case UpdateType.CallbackQuery:
            var callBackQuery = update.CallbackQuery;
            string responseMessage = String.Empty;
            switch (callBackQuery.Data)
            {
                case "give":
                    var respone = await apiClient.GetAsync("http://localhost:5043/Shop");
                    var content = await respone.Content.ReadAsStringAsync();
                    var group = JsonSerializer.Deserialize<List<Shop>>(content);
                    responseMessage = $"|Pharma_Shop| \n{string.Join("\n", group.Select(s => s.name))}";
                    break;
                case "send":
                    responseMessage = "Напишите название нового препарата:";
                    _userState[callBackQuery.Message.Chat.Id] = ShopStates.AwaitingPostShop;
                    break;
            }
            await client.SendMessage(callBackQuery.Message.Chat, responseMessage);
            await client.AnswerCallbackQuery(callBackQuery.Id);
            break;

    }
    static async Task Post(Shop shop, HttpClient apiClient)
    {
        var PostJson = JsonSerializer.Serialize(shop);
        var content = new StringContent(PostJson, Encoding.UTF8, "application/json");
        var response = await apiClient.PostAsync("http://localhost:5043/Shop", content);
    }
}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}