using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EI.Hanoi.Contracts;

using SlackBotMessages;

namespace EI.Hanoi.Services
{
    public class SlackService : ISlack
    {
        public string Send(string text)
        {
            var output = string.Empty;

            var client = new SBMClient("https://hooks.slack.com/services/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");
            var message = new Message(text, "general", "juninhodev", ":bust_in_silhouette:");

            client.Send(message);

            // release resource
            client = null;

            return output;
        }
    }
}