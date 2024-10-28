namespace TextApp
{
    internal class FileHandler
    {
        // reads all .txt filenames from array of paths, appends them to list, prints them to console, returns the list
        public static List<string> DirectoryReader(string[] filepaths)
        {
            List<string> files = new List<string>();
            try
            {
                // loop that writes all files in array to standard output
                for (int i = 0; i < filepaths.Length; i++)
                {          
                    files.Add($"{i + 1}: {Path.GetFileName(filepaths[i])}");
                    Console.WriteLine($"{i + 1}: {Path.GetFileName(filepaths[i])}");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex}"); }
            return files;
        }

        // reads all text from file, saves it into a string, returns the string
        public static string FileReader(string file)
        {
            string content = String.Empty;
            try
            {
                // try to save text in file to string variable content
                content = File.ReadAllText(file);        
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            return content;
        }
    }
}
