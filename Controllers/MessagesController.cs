using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace MaratonaBotsBOT
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            try {
                switch (activity.Type)
                {
                    case ActivityTypes.Message:
                        await Conversation.SendAsync(activity, () => new Dialogs.InformacoesDialog());
                        break;
                    case ActivityTypes.ConversationUpdate:
                        if (activity.MembersAdded.Any(o => o.Id == activity.Recipient.Id))
                        {
                            var reply = activity.CreateReply();
                            reply.Text = "Olá, eu sou um bot que sabe sobre gatos. Eu posso lhe informar e mostras imagens sobre " +
                                "raças, identificar uma raça baseada em uma foto, ou responder perguntas comuns sobre gatos.";
                            await connector.Conversations.ReplyToActivityAsync(reply);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                var reply = activity.CreateReply();
                reply.Text = "Se você deseja que eu analise uma imagem, primeiro me diga algo como \"analise essa imagem para mim\"";
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        
        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}