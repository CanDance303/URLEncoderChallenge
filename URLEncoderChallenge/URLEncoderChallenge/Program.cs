using System;
using System.Collections.Generic;


namespace URLEncoder
{
    class Program
    {
        //delimiter characters aka things that would need to be replaced in URL

        static Dictionary<string, string> delimiters = new Dictionary<string, string>
        {
            {":", "%3A"}, {"+", "%2B"}, {";", "%3B"}, {"[", "%5B"}, {"{", "%7B"}, {",", "%2C"},
            {"<", "%3C"}, {"\\", "%5C"}, {"|", "%7C"},{"=", "%3D"}, {"]", "%5D"}, {"}", "%7D"},
            {">", "%3E"}, {"^", "%5E"}, {"/", "%2F"}, {"?", "%3F"},{" ", "%20"}, {"\"", "%22"},
            {"#", "%23"}, {"$", "%24"},{"&", "%26"}, {"@", "%40"}, {"`", "%60"}

        };


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the URL Encoder");

            do
            { //ask user to name project and activity 
                //also encodes user input if a delimiter is used

                Console.WriteLine("Name your project: ");
                string ProjectName = Encode(GetInput());
                Console.WriteLine("Name your activity: ");
                string ActivityName = Encode(GetInput());

                //display URL

                Console.WriteLine("https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf", ProjectName, ActivityName);

                //ask if user wants to make another

                Console.WriteLine("Would you like to make another URL? (y/n): ");

            } while (Console.ReadLine().ToLower().Equals("y"));
        }

        static string GetInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (Valid(input)) return input;
                Console.WriteLine("You used invalid characters. Please try again: ");
            } while (true);
        }

        //checks for control characters, if control characters are used - code will prompt invalid characters and to try again

        static bool Valid(string input)
        {
            string control = ("0x00"); //was only able to get one control character to work as I was unable to get list function work due to complier error

            // commented out list funtion as I was unable to clear a compiler error, did not delete as it also gives reference for all control characters
            // List<int> control = new List<int>
            // {
            //  0x00,
            //  0x01,
            // 0x02,
            // 0x03,
            // 0x04,
            // 0x05,
            //  0x06,
            //  0x07,
            // 0x08,
            // 0x09,
            // 0x10,
            //  0x12,
            //  0x13,
            // 0x14,
            //  0x15,
            //  0x16,
            //  0x17,
            //  0x18,
            //  0x19,
            //  0x0A,
            //  0x1A,
            // 0x0B,
            //  0x1B,
            //  0x0C,
            //  0x1C,
            // 0x0D,
            // 0x1D,
            // 0x0E,
            // 0x1E,
            //  0x0F,
            //  0x1F,
            // 0x7F
            // };


            //converts hexa to integer

            int intValue = Convert.ToInt32(control, 16); //-- when trying to use the list option, could not fix complier error: Argument 2: cannot convert 'int' to 'System.IFormatProvider' error  -- thus code wouldn't run

            foreach (char character in input)
            {

                if (control.Contains(character))
                {

                    return false;
                }
            }
            return true;
        }

        //replaces delimiters if needed

        static string Encode(string limiters)
        {
            limiters = limiters.Replace("*", "%2A");
            foreach (var item in limiters)
            {
            }
            foreach (KeyValuePair<string, string> delimiters in delimiters)
            {
                limiters = limiters.Replace(delimiters.Key, delimiters.Value);
            }

            return limiters;

        }


    }
}
