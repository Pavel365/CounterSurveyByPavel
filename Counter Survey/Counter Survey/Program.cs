using System.Diagnostics.Metrics;

namespace Counter_Survey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("File.txt");

            Stack<string> strings = new Stack<string>();

            using (reader)
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    strings.Push(line.ToLower());
                }
            }

            Dictionary<string, int> teachers = new Dictionary<string, int>();

            while (strings.Count > 0)
            {
                CountTeachers(strings.Pop(), teachers);
            }


            StreamWriter writer = new StreamWriter("newFile.txt", false);
            
            foreach (var kvp in teachers)
            {
                writer.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

            writer.Close();
        }

        private static Dictionary<string, int> CountTeachers(string str, Dictionary<string, int> teachers)
        {
            if (!teachers.ContainsKey(str))
            {
                teachers.Add(str, 0);
            }

            teachers[str]++;

            return teachers;
        }
    }
}
