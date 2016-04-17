using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace EchoBotService.Controllers
{
    public class EchoController : ApiController
    {
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "You Know it", "Service Fabric Rocks!" };
        }        

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
               
                // return our reply to the user
                return message.CreateReplyMessage($"With Love, you said : {message.Text}");
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }
        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
        
    }
}
