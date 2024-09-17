using System.Security.Cryptography;

int enemyHP;
int protaganistHP;
string champName = "";

Console.ForegroundColor = ConsoleColor.Yellow;
while(champName.Length <2 || champName.Length >8){
Console.WriteLine("Write a name for your champion, bettwen 2 & 8 caracters");
Console.ForegroundColor = ConsoleColor.DarkYellow;
 champName = Console.ReadLine();
}
string[] opponentName = ["Bob", champName + " Killer", "The Flash", "Dare Devil"];
Console.WriteLine("Your oppenet in Red is named" opponentName[Random.Shared.Next(opponentName.Length)]);
Console.WriteLine("Your Champion is Blue. Press Enter to continue\n");
Console.ReadLine();

for (int i = 0; i < 9; i++)
{
    enemyHP = 100;
    protaganistHP = 100;
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
            Console.WriteLine($"Red hit {champName} and did {eDmg} damage\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{champName} now has  {protaganistHP}HP");
        }
        else
        {
            Console.WriteLine($"Red tried to hit {champName} but missed\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{champName} still has {protaganistHP}HP");
        }
                    //split
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("""

#######################################

""");

                            //Blue attack
        Console.ForegroundColor = ConsoleColor.Blue;
        if (pHit > 4)
        {
            int pDmg = Random.Shared.Next(1, 20);
            enemyHP -= pDmg;
            Console.WriteLine($"{champName} hit Red and did {pDmg} damage\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red now has " + enemyHP + "HP");
        }
        else
        {
            Console.WriteLine($"{champName} tried to hit Red but missed\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red still has " + enemyHP + "HP\n\n\n");
        }



        Console.ReadLine();
        Console.Clear();
    }
    textResult();
}
void textResult()
{
    if (protaganistHP <= 0 && enemyHP <= 0)
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
    else if (enemyHP <= 0)
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
    Console.ReadLine();
    Console.Clear();
}