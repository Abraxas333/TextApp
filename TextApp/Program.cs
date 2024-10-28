using TextApp;

class Program
{
    static void Main(string[] args)
    {
        // set current directory to project folder
        Directory.SetCurrentDirectory(@"..\..\..\");

        // save filepath in variable path
        string path = Directory.GetCurrentDirectory();

        string[] filepaths;
        List<string> files = new List<string>();
        try
        {
            // save all .txt files present in project folder to string array filepaths
            filepaths = Directory.GetFiles(path, "*.txt");

            // call DirectoryReader to output txt files to console
            files = FileHandler.DirectoryReader(filepaths);
        }

        catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }

        bool loop = true;
        do
        {
            // ask user to enter filename to read
            Console.WriteLine("Please enter the filename to read:");

            // save user input to string variable input
            string input = Console.ReadLine();

            // check for empty input
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input can't be empty!");
                continue;
            }

            // check if input is an existing file
            else if (!files.Any(x => x.Contains(input)))
            {
                Console.WriteLine("Input must be a file present in directory");
                files.ForEach(x => Console.WriteLine(x));
                continue;
            }

            // concatenate filepath with file
            string file = path + "\\" + input;

            // call FileReader method to write file content to console
            Console.WriteLine(FileHandler.FileReader(file));

            // prompt user to input new text
            Console.WriteLine($"Please input new text:");

            // save user input to variable text
            string text = Console.ReadLine();

            // prompt user to choose either overwriting file content or saving text to new file
            Console.WriteLine("To save Text to current File input 1, to save to a new file input 2:");
            string choice = Console.ReadLine();

            switch (choice)
            {

                case "1":
                    try
                    {
                        File.WriteAllText(file, text);
                    } 
                    catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }

                    // prompt user to either exit or continue
                    Console.WriteLine("To continue presse any key, to exit the program enter exit:");
                    input = Console.ReadLine();

                    if (input.Equals("exit"))
                    {
                        loop = false;
                    }  
                    break;

                case "2":
                    Console.WriteLine("Input filename to save text to:");
                    file = Console.ReadLine();

                    try
                    {
                        using (StreamWriter sw = File.CreateText(file))
                        {
                            sw.Write(text);
                        }
                    } catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }

                    // prompt user to either exit or continue
                    Console.WriteLine("To continue presse any key, to exit the program enter exit:");
                    input = Console.ReadLine();

                    if (input.Equals("exit"))
                    {
                        loop = false;
                    }
                    break;

                default:
                    Console.WriteLine("Please input either 1 or 2!");
                    break;
            }
        } while (loop);
    }
}