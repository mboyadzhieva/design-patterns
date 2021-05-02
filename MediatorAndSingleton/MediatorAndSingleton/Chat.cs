namespace MediatorAndSingleton
{
    using System;
    using System.Collections.Generic;

    public class Chat : IMediator
    {
        private List<ChatMember> chatMembers = new List<ChatMember>();

        public List<ChatMember> ChatMembers
        {
            get => this.chatMembers;
            private set => this.chatMembers = value;
        }

        public void AddChatMember(ChatMember chatMember)
        {
            this.ChatMembers.Add(chatMember);
        }

        public void RemoveChatMember(ChatMember chatMember)
        {
            this.ChatMembers.Remove(chatMember);
        }

        public void SendMessage(string message, ChatMember sender)
        {
            if (!this.ChatMembers.Contains(sender))
            {
                // if the sender has been removed, his message is not sent
                return;
            }

            /* the logic for printing the message has been moved from the user class 
             because the Chat class is the only one that knows if the sender is still in the chat*/
            Console.WriteLine(sender.Name + " sent " + "\"" + message + "\".");

            if (message.ToLower() == "addbot")
            {
                if (this.ChatMembers.Exists(m => m is Bot))
                {
                    Console.WriteLine("A bot is already in the chat.");
                    return;
                }

                Bot chatBot = Bot.GetInstance("ChatBot", this);

                /* The bot is inserted as a first element so it can check the message before 
                 it's sent to other members*/
                this.ChatMembers.Insert(0, chatBot);
                Console.WriteLine("ChatBot entered the chat.");
            }
            else
            {
                /* using ChatMembers.ToArray() because the ChatMembers collection is being modified
                 inside of the foreach, when a user is removed, which throws an exception */
                foreach (var user in this.ChatMembers.ToArray())
                {
                    /*checking for a second time if the sender is still present in the chat
                     because he could have been removed by the bot for sending a forbidden word*/
                    if (user != sender && this.ChatMembers.Contains(sender))
                    {
                        user.ReceiveMessage(message, sender);
                    }
                }
            }
        }
    }
}
