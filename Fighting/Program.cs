﻿using System.Security.Cryptography;

int enemyHP;
int protaganistHP;
string champName = "";

string enemyName;

while(champName.Length <1 || champName.Length >8){
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Write a name for your champion, bettwen 1 & 8 caracters");
Console.ForegroundColor = ConsoleColor.DarkYellow;
 champName = Console.ReadLine();
}

string[] opponentName = ["Bob", champName + " Killer", "Joe Mom", "Dare Devil", "Kaan", "Sherk", "Garmadon", "Adolf H.", "Ronald Mc Donald"];
Console.ForegroundColor = ConsoleColor.DarkRed;
enemyName=opponentName[Random.Shared.Next(opponentName.Length)];
Console.WriteLine($"Your oppenet in Red is named {enemyName}");

Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine($"\n{champName} is in Blue. Press Enter to continue\n");
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
            Console.WriteLine($"{enemyName} hit {champName} and did {eDmg} damage\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{champName} now has  {protaganistHP}HP");
        }
        else
        {
            Console.WriteLine($"{enemyName} tried to hit {champName} but missed\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{champName} still has {protaganistHP}HP");
        }
                    //split
        volor();
        Console.WriteLine("""

#######################################

""");

                            //Blue attack
        Console.ForegroundColor = ConsoleColor.Blue;
        if (pHit > 4)
        {
            int pDmg = Random.Shared.Next(1, 20);
            enemyHP -= pDmg;
            Console.WriteLine($"{champName} hit {enemyName} and did {pDmg} damage\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{enemyName} now has " + enemyHP + "HP");
        }
        else
        {
            Console.WriteLine($"{champName} tried to hit {enemyName} but missed\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{enemyName} still has {enemyHP}HP");
        }
                  //split
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("""

#######################################

""");



        Console.ReadLine();
    }
    textResult();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    enemyName = opponentName[Random.Shared.Next(opponentName.Length)];
    Console.WriteLine("Your oppenet in Red is named " +enemyName+"\n\n");

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
}

//Stupid
static void volor(){
    int numCol = Random.Shared.Next(15);
    if(numCol == 0){
    Console.ForegroundColor = ConsoleColor.Blue;
    }
    else if(numCol == 1){
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    }
    else if(numCol == 2){
    Console.ForegroundColor = ConsoleColor.Cyan;
    }
    else if(numCol == 3){
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    }
    else if(numCol == 4){
    Console.ForegroundColor = ConsoleColor.DarkGray;
    }
    else if(numCol == 5){
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    }
    else if(numCol == 6){
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    }
    else if(numCol == 7){
    Console.ForegroundColor = ConsoleColor.DarkRed;
    }
    else if(numCol == 8){
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    }
    else if(numCol == 9){
    Console.ForegroundColor = ConsoleColor.Gray;
    }
    else if(numCol == 10){
    Console.ForegroundColor = ConsoleColor.Green;
    }
    else if(numCol == 12){
    Console.ForegroundColor = ConsoleColor.Magenta;
    }
    else if(numCol == 13){
    Console.ForegroundColor = ConsoleColor.Red;
    }
    else if(numCol == 14){
    Console.ForegroundColor = ConsoleColor.White;
    }
    else if(numCol == 15){
    Console.ForegroundColor = ConsoleColor.Yellow;
    }
}