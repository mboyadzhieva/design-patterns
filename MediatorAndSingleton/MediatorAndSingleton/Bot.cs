namespace MediatorAndSingleton
{
    using System;

    public class Bot : ChatMember
    {
        private static Bot chatBot;

        private Bot() 
        {
        }

        private Bot(string name, IMediator mediator) : base(name, mediator)
        {
        }

        private static Bot Instance
        {
            get => chatBot;
            set => chatBot = value;
        }

        // this method is used to assign a mediator and a name to the Bot
        public static Bot GetInstance(string name, IMediator mediator)
        {
            if (Instance != null)
            {
                Console.WriteLine("A chatbot has already been created " +
                    $"with name {Instance.Name} and Mediator \"{Instance.Mediator.GetType().Name}\".");
            }
            else
            {
                Instance = new Bot(name, mediator);
            }

            return Instance;
        }

        public override void SendMessage(string message)
        {
            this.Mediator.SendMessage(message, this);
        }

        public override void ReceiveMessage(string message, ChatMember sender)
        {
            Console.WriteLine("ChatBot received " + "\"" + message + "\"" + " from " + sender.Name + ".");

            if (message.ToLower() == "darkness")
            {
                this.RemoveChatMember(sender);
                this.SendMessage("Darkness is a fobidden word! " + sender.Name + " has been removed");
            }
        }

        public void RemoveChatMember(ChatMember chatMember)
        {
            this.Mediator.RemoveChatMember(chatMember);
        }
    }
}
