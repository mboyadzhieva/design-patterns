namespace MediatorAndSingleton
{
    public interface IMediator
    {
        public void SendMessage(string message, ChatMember sender);

        public void AddChatMember(ChatMember chatMember);

        public void RemoveChatMember(ChatMember chatMember);
    }
}
