using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCounter
{
    internal class ValidPasswordsCounter
    {
        private List<string> passwordsLines = new List<string>();

        internal ValidPasswordsCounter()
        {

        }

        private async Task GetPasswordsFromFile(string path)
        {
            string line;

            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        passwordsLines.Add(line);
                    }
                }
            }
        }

        internal async Task<int> CountValidPasswords(string path)
        {
            int counter = 0;

            await GetPasswordsFromFile(path);
            foreach (var line in passwordsLines)
            {
                try
                {
                    var valid = ValidationOfPassword(line);
                    if (valid)
                    {
                        counter++;
                    }
                }
                catch (Exception ex) { }
            }

            return counter;
        }

        private bool ValidationOfPassword(string line)
        {
            int count;
            char[] separators = { ' ', '-', ':' };
            string[] partsOfLine = line.Split(separators);
            char symbol = Char.Parse(partsOfLine[0]);
            int minRepeat = Int32.Parse(partsOfLine[1]);
            int maxRepeat = Int32.Parse(partsOfLine[2]);
            string password = partsOfLine[4];

            count = password.Count(s => s.Equals(symbol));

            return count >= minRepeat && count <= maxRepeat;
        }
    }
}
