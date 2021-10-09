namespace RPSLSGAMEver3
{
    class Program
    {

        static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();
            Player player = new Player();
            Machine machine = new Machine();
            gameBoard.GameSkeleton();
            gameBoard.WaitForUser(gameContent);
            gameBoard.MenuNavigation(player, machine, gameContent, gameBoard);
        }
    }
}
