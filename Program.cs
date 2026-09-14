using System.Collections;

//det initiala värdet på text är bara för testning
//String text = "29535123p48723487597645723645";

Console.ForegroundColor = ConsoleColor.White;
static long FindNumberSubstring(int startHere, string myText) {
    long number = 0;
    String numbers ="";
    String sameStartandEnd = "";
    bool foundmatch = false;
    for (int i = startHere; i < myText.Length; i++) {
        bool foundNumber = long.TryParse(myText[i].ToString(), out number);
        if (foundNumber) { 
            numbers += myText[i].ToString();
        }
        else
        {
            break;
        }
    
    }

    for (int i = 0; i < numbers.Length; i++) { 
        if (i > 0 && numbers[i] == numbers[0])
        {
            sameStartandEnd += numbers[i];
            foundmatch = true;
            break;
        }
        sameStartandEnd += numbers[i];
    }

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

    Console.WriteLine($"Total sum of all red substrings: {total}");

}

PrintInput();
