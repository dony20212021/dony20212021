using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Progra1Bot.Clases
{
   public  class clsEjemplo2
    {
        private static TelegramBotClient Bot;

        public  async Task IniciarTelegram()
        {
            Bot = new TelegramBotClient("1841317892:AAFcSZdTW-XfxCjnPS9J7OQ4Mse3ErIPugs");
           
            var me = await Bot.GetMeAsync();
            Console.Title = me.Username;

            Bot.OnMessage += BotCuandoRecibeMensajes;
            Bot.OnMessageEdited += BotCuandoRecibeMensajes;
            Bot.OnReceiveError += BotOnReceiveError;

            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"escuchando solicitudes del BOT @{me.Username}");

           

            Console.ReadLine();
            Bot.StopReceiving();
        }

        // cuando recibe mensajes
        private static async void BotCuandoRecibeMensajes(object sender, MessageEventArgs messageEventArgumentos)
        {
            var ObjetoMensajeTelegram = messageEventArgumentos;
            var mensajes = ObjetoMensajeTelegram.Message;

            string mensajeEntrante = mensajes.Text;


            string respuesta = "No te entiendo";
            if (mensajes == null || mensajes.Type != MessageType.Text)
                return;

            Console.WriteLine($"Recibiendo Mensaje del chat {ObjetoMensajeTelegram.Message.Chat.Id}.");
            Console.WriteLine($"Dice {ObjetoMensajeTelegram.Message.Text}.");

            //tolower
            if (mensajes.Text.Contains("Hola"))
            {
                respuesta = "Hola que tal en que Podemos Ayudarte !!!";
            }
            if (mensajes.Text.Contains("Sobre los planes de internet"))
            {
                respuesta = "En que plan estas interesado  !!!";
            }
            if (mensajes.Text.Contains("3mb"))
            {
                respuesta = "Precio Q 200.00  !!!";
            }
            if (mensajes.Text.Contains("4mb"))
            {
                respuesta = "Precio Q 260.00  !!!";
            }
            if (mensajes.Text.Contains("5mb"))
            {
                respuesta = "Precio Q 310.00  !!!";
            }
            if (mensajes.Text.Contains("8mb"))
            {
                respuesta = "Precio Q 360.00  !!!";
            }
            if (mensajes.Text.Contains("Costo de instalacion"))
            {
                respuesta = "La instalacion es gratis  !!!";
            }
            if (mensajes.Text.Contains("Formas de pago"))
            {
                respuesta = "Deposito Bancario //33072630//), Transferencia, Efectivo //En nuestras oficinas!!!";
            }
            if (mensajes.Text.Contains("Maximo de megas"))
            {
                respuesta = "40 mb!!!";
            }
            if (mensajes.Text.Contains("Hay contrato"))
            {
                respuesta = "Si hay contrato de 6 meses!!!";
            }
            if (mensajes.Text.Contains("Estoy interesado"))
            {
                respuesta = "envianos una foto de dpi ambos lados!!!";
            }
            if (mensajes.Text.Contains("Ok"))
            {
                respuesta = "Esperamos tu Respuesta !!!";
            }
            if (!String.IsNullOrEmpty(respuesta))//    
            {
                await Bot.SendTextMessageAsync(
                    chatId: ObjetoMensajeTelegram.Message.Chat,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                    text: respuesta

            );
            }

        } // fin del metodo de recepcion de mensajes



        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("UPS!!! Recibo un error!!!: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message
            );
        }
        


    }
}

