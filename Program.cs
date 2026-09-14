using System.Collections;

//det initiala värdet på text är bara för testning
//String text = "29535123p48723487597645723645";

//initielt sätter färgen för utskrifft till vit
Console.ForegroundColor = ConsoleColor.White;

//Hanterar sökning av substrängar och retunerar dem som long
static long FindNumberSubstring(int startHere, string myText) {
    long number = 0;
    String foundNumbers ="";
    String sameStartandEnd = "";
    bool foundmatch = false;

    //letar efter tal
    for (int i = startHere; i < myText.Length; i++) {
        bool isNumber = long.TryParse(myText[i].ToString(), out number);
        if (isNumber) {
            foundNumbers += myText[i].ToString();
        }
        else
        {
            break;
        }
    
    }

    //letar efter strängar som startar och slutar på samma tal
    for (int i = 0; i < foundNumbers.Length; i++) { 
        if (i > 0 && foundNumbers[i] == foundNumbers[0])
        {
            sameStartandEnd += foundNumbers[i];
            foundmatch = true;
            break;
        }
        sameStartandEnd += foundNumbers[i];
    }

    //konventerar substrängen till en long och retunerar den. retunerar 0 om ingen godkänd substräng hittas.
    if (foundmatch)
    {
        number = long.Parse(sameStartandEnd);
        //Console.WriteLine($"{sameStartandEnd} starts and end at index: {startHere.ToString()} and {startHere + sameStartandEnd.Length} total digits:{sameStartandEnd.Length} Conversion:{number}");
        return number;
    }
    else {
        return 0;
    }


    
}
//Hantering av inmatning från användaren
static string GetInput() {
    string myInput = "";
    try {
        Console.WriteLine("Detta program kommer leta efter substrängar som startar och slutar på samma tal.");
        Console.WriteLine("För att sedan skriva ut dem i rött och beräkna den totala summa av dem.");
        Console.WriteLine("Var snäll och skriv in en sträng med siffror och bokstäver!");
        myInput = Console.ReadLine();
    }
    catch {
        Console.WriteLine("Ett fel uppstod, försök igen!");
    }


    return myInput;
}

void PrintInput(){
    long total = 0; // sparar det total värded av alla substrängar som startar och slutar på samma tal.
    string mytext = GetInput();

    /*/
     * 
     * Skirver ut strängen med substrängen markerat som rött om en hittas.
     * Kallar på FindNumberSubstring() för att genomföra det.
     * Den andra for loopen är den som skriver och strängen. samt avgör när en bokstav ska vara vit eller röd.
     * Den andra for loopen körs bara när n > 0. För om n är större än 0 så betyder det att en substräng har hittas.
     * 
    /*/
    for (int i = 0; i < mytext.Length; i++)
    {
        long n = FindNumberSubstring(i, mytext);
        if (n > 0)
        {
            total += n;

            for (int j = 0; j < mytext.Length; j++)
            {

                if (j == i && n > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{mytext[j]}");

                }
                else if (j > i && mytext[j].Equals(mytext[i]))
                {
                    Console.Write($"{mytext[j]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write($"{mytext[j]}");
                }

            }
            Console.WriteLine();
        }

    }

    Console.WriteLine($"Summering av alla substrängar:{total}");

}

PrintInput();
