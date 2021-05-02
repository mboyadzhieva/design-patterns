namespace MediatorAndSingleton
{
    public class Program
    {
        public static void Main()
        {
            var chatRoom = new Chat();

            var firstUser = new User("Alina", chatRoom);
            var secondUser = new User("Kirigan", chatRoom);
            var thirdUser = new User("Mal", chatRoom);

            firstUser.SendMessage("Welcome!");
            secondUser.SendMessage("AddBot");
            thirdUser.SendMessage("Darkness");
            firstUser.SendMessage("Who's here?");
            
            /*Output:
            Alina sent "Welcome!".
            Kirigan received "Welcome!" from Alina.
            Mal received "Welcome!" from Alina.
            Kirigan sent "AddBot".
            ChatBot entered the chat.
            Mal sent "Darkness".
            ChatBot received "Darkness" from Mal.
            ChatBot sent "Darkness is a fobidden word! Mal has been removed".
            Alina received "Darkness is a fobidden word! Mal has been removed" from ChatBot.
            Kirigan received "Darkness is a fobidden word! Mal has been removed" from ChatBot.
            Alina sent "Who's here?".
            ChatBot received "Who's here?" from Alina.
            Kirigan received "Who's here?" from Alina.*/
        }
    }
}
