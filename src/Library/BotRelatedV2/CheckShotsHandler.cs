using Telegram.Bot.Types;

namespace Library
{
    public class CheckShotsHandler : BaseHandler
    {
        private Game game;
        private string result;
        
        public CheckShotsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/TirosBarco", "TirosBarco", "/TirosAgua", "TirosAgua"};
        }

        protected override void InternalHandle(Message message, out string response)
        {     
            game = Administrator.Instance.GetPlayerGame(message.Chat.Id);
            (int waterHit, int shipHit) = game.CheckShots();
            if (message.Text == "/TirosBarco" || message.Text == "TirosBarco")
            {
                result = $"La cantidad de tiros a barco totales es: {shipHit}";
            }
            else if (message.Text == "/TirosAgua" || message.Text == "TirosAgua")
            {
                result = $"La cantidad de tiros a barco totales es: {waterHit}";
            }
            response = result;
        }
    }
}