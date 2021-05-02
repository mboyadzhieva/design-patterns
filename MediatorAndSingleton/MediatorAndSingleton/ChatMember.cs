namespace MediatorAndSingleton
{
    public abstract class ChatMember
    {
        private IMediator mediator;
        private string name;

        public ChatMember()
        {
        }

        public ChatMember(string name, IMediator mediator)
        {
            this.Name = name;
            this.Mediator = mediator;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public IMediator Mediator
        {
            get => this.mediator;
            private set => this.mediator = value;
        }

        public abstract void SendMessage(string message);

        public abstract void ReceiveMessage(string message, ChatMember sender);
    }
}
