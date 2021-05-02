namespace MediatorAndSingleton
{
    using System;

    public class User : ChatMember
    {
        public User(string name, IMediator mediator) : base(name, mediator)
        {
            this.Mediator.AddChatMember(this);
        }

        public override void ReceiveMessage(string message, ChatMember sender)
        {
            Console.WriteLine(this.Name + " received " + "\"" + message + "\"" + " from " + sender.Name + ".");
        }

        public override void SendMessage(string message)
        {
            this.Mediator.SendMessage(message, this);
        }
    }
}
