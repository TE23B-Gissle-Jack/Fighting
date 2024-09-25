using System.Drawing;
using System.Security.Cryptography;

int enemyHP = 0;
int protaganistHP = 0;

ConsoleColor[] color = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
//1 = blue; 12 = red

bool bWin = enemyHP <= 0 && protaganistHP > 0;
bool rWin = enemyHP > 0 && protaganistHP <= 0;
bool tie = enemyHP <= 0 && protaganistHP <= 0;

string champName = "";
int coins = 50;

string enemyName;

string[] opponentName = ["Bob", champName + " Killer", "Joe Mom", "Dare Devil", "Kaan", "Sherk", "Garmadon", "Adolf H.", "Ronald Mc Donald"];


string[] armourType = ["nothing", "Leather", "Chain", "Copper", "Iron", "Steel", "Knights"];
int[] typeHP = [0, 20, 40, 50, 70, 90, 120];
int[] typeCost = [0, 40, 50, 60, 75, 90, 150];
int currentArmour = 0;



for (int i = 0; i < 9; i++)
{
    while (champName.Length < 1 || champName.Length > 8)
    {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Write a name for your champion, bettwen 1 & 8 caracters");
    Console.ForegroundColor = ConsoleColor.Cyan;
    champName = Console.ReadLine();

    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine($"\n{champName} is in Blue.");
    }
    string[] names =[champName, opponentName[Random.Shared.Next(opponentName.Length)]];
    Console.ForegroundColor = ConsoleColor.DarkRed;
    //enemyName = opponentName[Random.Shared.Next(opponentName.Length)];
        Console.WriteLine($"Your oppenet in Red is named {names[1]}. Press Enter to continue\n\n");

    Console.ReadLine();

    string awns = "temp";
    int betAmt = 0;
    while (awns != "")
    {
        bool buyArmour = currentArmour != 6;

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"you have {coins} coins that you can either bet or use to buy equipment for your champion\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Write: A to bet");
        if (buyArmour)
        {
            Console.WriteLine($"Write: B to buy {armourType[currentArmour + 1]} Armour for {typeCost[currentArmour + 1]} coins");
        }
        Console.WriteLine("Write nothing to begin the fight");
        Console.ForegroundColor = ConsoleColor.Cyan;
        awns = Console.ReadLine().ToLower();

        Console.ForegroundColor = ConsoleColor.Yellow;
        if (awns == "a")
        {
            Console.WriteLine("How much do you want to bet that your champion wins?");
            Console.ForegroundColor = ConsoleColor.Cyan;
            awns = Console.ReadLine().ToLower();
            betAmt = int.Parse(awns);
            if (betAmt > coins)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You dont have enough Coins, enter a valid amount\nYou have {coins} coins");
                betAmt = 0;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"You will get {coins * 2} if your champion wins now\n\n");
                coins -= betAmt;
            }
        }
        else if (awns == "b" && buyArmour)
        {
            if (typeCost[currentArmour + 1] > coins)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You dont have enough coins, the armour costs {typeCost[currentArmour + 1]} and you only have {coins}");
            }
            else
            {
                currentArmour++;
                Console.WriteLine($"The Armour incresses your Chmpions HP with {typeHP[currentArmour]}\n");
                coins -= typeCost[currentArmour];
            }

        }
    }

    enemyHP = 100;
    protaganistHP = 100 + typeHP[currentArmour];

    while (enemyHP > 0 && protaganistHP > 0)
    {
        int eHit = Random.Shared.Next(0, 10);
        int pHit = Random.Shared.Next(0, 10);


        //Red Attack
        Console.ForegroundColor = ConsoleColor.Red;
        if (eHit > 4)
        {
            int eDmg = Random.Shared.Next(1, 20);
            protaganistHP -= eDmg;
            Console.WriteLine($"{names[1]} hit {champName} and did {eDmg} damage\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{champName} now has  {protaganistHP}HP");
        }
        else
        {
            Console.WriteLine($"{names[1]} tried to hit {champName} but missed\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{champName} still has {protaganistHP}HP");
        }
        //split
        volor();
        Console.WriteLine("""

#######################################

""");

        //Blue attack               stupid repetision
        Console.ForegroundColor = ConsoleColor.Blue;
        if (pHit > 4)
        {
            int pDmg = Random.Shared.Next(1, 20);
            enemyHP -= pDmg;
            Console.WriteLine($"{champName} hit {names[1]} and did {pDmg} damage\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{names[1]} now has " + enemyHP + "HP");
        }
        else
        {
            Console.WriteLine($"{champName} tried to hit {names[1]} but missed\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{names[1]} still has {enemyHP}HP");
        }
        //split
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("""

#######################################

""");



        Console.ReadLine();
    }

    tie = enemyHP <= 0 && protaganistHP <= 0;
    bWin = enemyHP <= 0 && protaganistHP > 0;

    textResult();
    if(betAmt>0){
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        if(tie){
            Console.WriteLine("Becuse of the tie you get your money back");
            coins = betAmt;
        }else if(bWin){
            Console.WriteLine($"Congratulations to the wicrory! Here is the {betAmt*2} coins payout from your bet");
            coins = betAmt*2;
        }
        betAmt = 0;
    }
    Console.ReadLine();

    /*Console.ForegroundColor = ConsoleColor.DarkRed;
    enemyName = opponentName[Random.Shared.Next(opponentName.Length)];
    Console.WriteLine("Your oppenet in Red is named " + enemyName + "\n\n");*/

}



void textResult()
{
    if (tie)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("""





 ________  _________   ________  ______       ________       ______   ______    ________   __ __ __      
/_______/\/________/\ /_______/\/_____/\     /_______/\     /_____/\ /_____/\  /_______/\ /_//_//_/\     
\__.::._\/\__.::.__\/ \__.::._\/\::::_\/_    \::: _  \ \    \:::_ \ \\:::_ \ \ \::: _  \ \\:\\:\\:\ \    
   \::\ \    \::\ \      \::\ \  \:\/___/\    \::(_)  \ \    \:\ \ \ \\:(_) ) )_\::(_)  \ \\:\\:\\:\ \   
   _\::\ \__  \::\ \     _\::\ \__\_::._\:\    \:: __  \ \    \:\ \ \ \\: __ `\ \\:: __  \ \\:\\:\\:\ \  
  /__\::\__/\  \::\ \   /__\::\__/\ /____\:\    \:.\ \  \ \    \:\/.:| |\ \ `\ \ \\:.\ \  \ \\:\\:\\:\ \ 
  \________\/   \__\/   \________\/ \_____\/     \__\/\__\/     \____/_/ \_\/ \_\/ \__\/\__\/ \_______\/ 
                                                                                                         



""");
    }
    else if (bWin)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("""





  _______   __       __  __   ______       __ __ __    ________  ___   __    ___   __    ______      
/_______/\ /_/\     /_/\/_/\ /_____/\     /_//_//_/\  /_______/\/__/\ /__/\ /__/\ /__/\ /_____/\     
\::: _  \ \\:\ \    \:\ \:\ \\::::_\/_    \:\\:\\:\ \ \__.::._\/\::\_\\  \ \\::\_\\  \ \\::::_\/_    
 \::(_)  \/_\:\ \    \:\ \:\ \\:\/___/\    \:\\:\\:\ \   \::\ \  \:. `-\  \ \\:. `-\  \ \\:\/___/\   
  \::  _  \ \\:\ \____\:\ \:\ \\::___\/_    \:\\:\\:\ \  _\::\ \__\:. _    \ \\:. _    \ \\_::._\:\  
   \::(_)  \ \\:\/___/\\:\_\:\ \\:\____/\    \:\\:\\:\ \/__\::\__/\\. \`-\  \ \\. \`-\  \ \ /____\:\ 
    \_______\/ \_____\/ \_____\/ \_____\/     \_______\/\________\/ \__\/ \__\/ \__\/ \__\/ \_____\/ 
                                                                                                     


""");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("""





 ______    ______   ______       __ __ __    ________  ___   __    ___   __    ______      
/_____/\  /_____/\ /_____/\     /_//_//_/\  /_______/\/__/\ /__/\ /__/\ /__/\ /_____/\     
\:::_ \ \ \::::_\/_\:::_ \ \    \:\\:\\:\ \ \__.::._\/\::\_\\  \ \\::\_\\  \ \\::::_\/_    
 \:(_) ) )_\:\/___/\\:\ \ \ \    \:\\:\\:\ \   \::\ \  \:. `-\  \ \\:. `-\  \ \\:\/___/\   
  \: __ `\ \\::___\/_\:\ \ \ \    \:\\:\\:\ \  _\::\ \__\:. _    \ \\:. _    \ \\_::._\:\  
   \ \ `\ \ \\:\____/\\:\/.:| |    \:\\:\\:\ \/__\::\__/\\. \`-\  \ \\. \`-\  \ \ /____\:\ 
    \_\/ \_\/ \_____\/ \____/_/     \_______\/\________\/ \__\/ \__\/ \__\/ \__\/ \_____\/ 
                                                                                           


""");
    }
}

//Stupid
static void volor()
{
    int numCol = Random.Shared.Next(15);
    if (numCol == 0)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    else if (numCol == 1)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }
    else if (numCol == 2)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
    }
    else if (numCol == 3)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
    }
    else if (numCol == 4)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
    else if (numCol == 5)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
    }
    else if (numCol == 6)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
    }
    else if (numCol == 7)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
    }
    else if (numCol == 8)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
    }
    else if (numCol == 9)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    else if (numCol == 10)
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    else if (numCol == 12)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
    }
    else if (numCol == 13)
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    else if (numCol == 14)
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
    else if (numCol == 15)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
}