using System.Collections;

String text = "29535123p48723487597645723645";
long total = 0;

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

for (int i = 0; i < text.Length; i++) {
    long n = FindNumberSubstring(i, text);
    if (n > 0) {
        total += n;

        for (int j = 0; j < text.Length; j++)
        {


            if (j == i && n > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{text[j]}");

            }
            else if (j > i && text[j].Equals(text[i]))
            {
                Console.Write($"{text[j]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write($"{text[j]}");
            }

        }
        Console.WriteLine();
    }
    
    

}


Console.WriteLine($"Total sum of all red substrings: {total}");
