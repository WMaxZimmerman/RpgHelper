using CommandAndConquer.CLI.Attributes;

namespace RpgHelper.CLI.Controllers
{
    [CliController("dice", "")]
    public static class DiceController
    {
        [CliCommand("roll", "")]
        public static void RollDice([CliParameter('f',"The Formula for the dice roll you want to do.")]string formula)
        {
            
        }
    }
}
