using System.Drawing;
using System.Security.Cryptography;

//int enemyHP = 0;
//int protaganistHP = 0;

int[] hp = new int[2];

ConsoleColor[] color = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
//1 = blue; 12 = red

//defined later
bool bWin;
bool tie;


int coins = 50;
int totalBetAmt = 0;

string champName = "";
string[] opponentName = ["Bob", champName + " Killer", "Joe Mom", "Dare Devil", "Kaan", "Sherk", "Garmadon", "Adolf H.", "Ronald Mc Donald"];


string[] armourType = ["nothing", "Leather", "Chain", "Copper", "Iron", "Steel", "Knights"];
int[] typeHP = [0, 20, 40, 50, 70, 90, 120];
int[] typeCost = [0, 40, 50, 60, 75, 90, 150];
int currentArmour = 0;



for (int i = 0; i < 9; i++)
{
    //set up
    while (champName.Length < 1 || champName.Length > 8)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Write a name for your champion, bettwen 1 & 8 caracters");
        Console.ForegroundColor = ConsoleColor.Cyan;
        champName = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"\n{champName} is in Blue.");
    }
    string[] names = [champName, opponentName[Random.Shared.Next(opponentName.Length)]];

    Console.ForegroundColor = ConsoleColor.DarkRed;

    Console.WriteLine($"Your oppenet in Red is named {names[1]}. Press Enter to continue\n\n");

    Console.ReadLine();


    // Buying things and betting
    //=================================================================================================
    string awns = "temp";
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
            int betAmt = 0;
            Console.WriteLine("How much do you want to bet that your champion wins?");

            Console.ForegroundColor = ConsoleColor.Cyan;
            awns = Console.ReadLine().ToLower();
            int.TryParse(awns, out betAmt);
            if (betAmt > coins)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You dont have enough Coins, enter a valid amount\nYou have {coins} coins");

                //since betAmt = int.Parse(awns);
                betAmt = 0;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                totalBetAmt += betAmt;
                Console.WriteLine($"You will get {totalBetAmt * 2} coins if your champion wins\n\n");
                coins -= betAmt;

            }
            awns = "temp";
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
    //=============================================================================================

    hp = [100 + typeHP[currentArmour], 100];

    //main loop
    while (hp[0] > 0 && hp[1] > 0)
    {
        //Red Attack
        for (i = 0; i < 2;)
        {
            int hit = Random.Shared.Next(0, 10);
            int other = 1;
            if (i == 1)
            {
                other = 0;
                //split
                Console.ForegroundColor = color[Random.Shared.Next(16)];
                Console.WriteLine("""

 #######################################

 """);
            }

            if (hit > 4)
            {
                int dmg = Random.Shared.Next(1, 20);
                hp[other] -= dmg;

                Console.ForegroundColor = color[11 * i + 1]; // 12 if i = 1, 1 if i = 0 // Red = 12, Blue = 1;
                Console.WriteLine($"{names[i]} hit {names[other]} and did {dmg} damage\n");
                Console.ForegroundColor = color[-11 * i + 12]; // 1 if i = 1, 12 if i = 0
                Console.WriteLine($"{names[other]} now has  {hp[other]}HP");
            }
            else
            {
                Console.ForegroundColor = color[11 * i + 1];
                Console.WriteLine($"{names[i]} tried to hit {names[other]} but missed\n");
                Console.ForegroundColor = color[-11 * i + 12];
                Console.WriteLine($"{names[other]} still has {hp[other]}HP");
            }
            Console.ReadLine();


            i++;
        }

        //split
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("""

#######################################

     ~~~~~~~~~NEW Round~~~~~~~~

#######################################

""");



        Console.ReadLine();
    }

    tie = hp[0] <= 0 && hp[1] <= 0;
    bWin = hp[1] <= 0 && hp[0] > 0;

    textResult();
    if (totalBetAmt > 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        if (tie)
        {
            Console.WriteLine("Becuse of the tie you get your money back");
            coins = totalBetAmt;
        }
        else if (bWin)
        {
            Console.WriteLine($"Congratulations to the wicrory! Here is the {totalBetAmt * 2} coins payout from your bet");
            coins = totalBetAmt * 2;
        }
        totalBetAmt = 0;
    }
    Console.ReadLine();
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


