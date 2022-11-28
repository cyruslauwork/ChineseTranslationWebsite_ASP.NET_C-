using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace proj
{
    public partial class Default : System.Web.UI.Page
    {
        // Create dictionary
        IDictionary<String, String> codepoints = new Dictionary<String, String>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Define file path
            //private const string Path = @"F:\Proj\proj\proj\Unihan_STVariants.txt"; // Absolute path
            String FilePath = Server.MapPath("Unihan_STVariants.txt"); // Relative path
            Stream stream = File.OpenRead(FilePath);
            stream.Seek(0, SeekOrigin.Begin); // Clear stream

            // Define buffer
            //StringBuilder buffer = new StringBuilder(1000);
            //buffer.Clear(); // Clear buffer

            // Create RegEx
            Regex firstCodepointRegex = new Regex(@"^[U][+]\w+");
            Regex secondCodepointRegex = new Regex(@"[U][+]\w+$"); // The last of the code points in the second half is the largest
            // Define variables for matching
            string firstCodepoint = "";
            string secondCodepoint = "";

            // Read txt file line by line
            StreamReader sReader = new StreamReader(stream, Encoding.UTF8);
            String line = sReader.ReadLine();
            while (line != null)
            {
                //buffer.Append(line);
                //buffer.Append(Environment.NewLine);

                // Matching
                // Using MatchCollection
                MatchCollection firstCodepoint_matches = firstCodepointRegex.Matches(line);
                foreach (Match match in firstCodepoint_matches)
                {
                    string str = Regex.Replace(match.Value, @"[U][+]", "0000"); // Replace U+ by 0000
                    firstCodepoint = $"{str}";
                }
                MatchCollection secondCodepoint_matches = secondCodepointRegex.Matches(line);
                foreach (Match match in secondCodepoint_matches)
                {
                    string str = Regex.Replace(match.Value, @"[U][+]", "0000"); // Replace U+ by 0000
                    secondCodepoint = $"{str}";
                }
                // Using Match
                //Match firstCodepoint_match = firstCodepointRegex.Match(line);
                //while (firstCodepoint_match.Success)
                //{
                //    firstCodepoint = $"{firstCodepoint_match.Value}";
                //}
                //Match secondCodepoint_match = secondCodepointRegex.Match(line);
                //while (secondCodepoint_match.Success)
                //{
                //    secondCodepoint = $"{secondCodepoint_match.Value}";
                //}
                // Add codepoints to dictionary
                if (!codepoints.ContainsKey(firstCodepoint)) // Add directly without duplication
                {
                    codepoints.Add(firstCodepoint, secondCodepoint);
                }
                else // Remove existing if duplicate, then add new
                {
                    codepoints.Remove(firstCodepoint);
                    codepoints.Add(firstCodepoint, secondCodepoint);
                }

                line = sReader.ReadLine();
            }
            //TextBox.Text = buffer.ToString();

            // For debugging
            //foreach (var codepoint in codepoints)
            //{
            //    TextBox.Text += codepoint.Key + "\t" + codepoint.Value + "\n";
            //}

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            //string[] lines = System.IO.File.ReadAllLines(FilePath);
            // Display the file contents by using foreach loop.
            //foreach (string line in lines)
            //{
            //    buffer.Append(line);
            //    buffer.Append(Environment.NewLine);
            //}
            //TextBox.Text = buffer.ToString();
        }

        protected void ConvertBtn_Click(object sender, EventArgs e)
        {
            Label.Text = ""; // Clear text

            // Remove things that avoid translations from Textbox.Text
            string str = TextBox.Text.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(" ", "");
            // Get bytes from TextBox
            byte[] input_byte_arr = Encoding.GetEncoding("UTF-32BE").GetBytes(str);
            // Encoding (Dec to Hex)
            string raw_codepoint_noWhiteSpace = "";
            for (int i = 0; i < input_byte_arr.Length; i++)
            {
                raw_codepoint_noWhiteSpace += input_byte_arr[i].ToString("X2");
            }
            // Add whitespace to each code point.
            string raw_codepoint_haveWhiteSpace = Regex.Replace(raw_codepoint_noWhiteSpace, @"([0][0][0][0])([A-Z1-9])", " 0000$2");
            // Create a List to store the code points.
            List<string> codepoint_list = new List<string>();
            // Add each code point to the list via a foreach loop.
            Regex codepointRegex = new Regex(@"[0][0][0][0]\w+");
            MatchCollection codepoint_matches = codepointRegex.Matches(raw_codepoint_haveWhiteSpace);
            foreach (Match match in codepoint_matches)
            {
                codepoint_list.Add($"{match.Value}");
            }
            // Process all code points in a list via foreach loop.
            foreach (string codepoint in codepoint_list)
            {
                // Matches the bytes in the dictionary (Translation)
                string final_codepoint;
                if (codepoints.TryGetValue(codepoint, out final_codepoint))
                {
                    // Decoding (Hex to Dec)
                    byte[] output_byte_arr = new byte[final_codepoint.Length / 2];
                    for (Int32 i = 0; i < final_codepoint.Length / 2; i++)
                    {
                        output_byte_arr[i] = Convert.ToByte(final_codepoint.Substring(2 * i, 2), 16);
                    }
                    // Convert the byte string to string and
                    // present the result in the label
                    string output = Encoding.GetEncoding("UTF-16BE").GetString(output_byte_arr);
                    Label.Text += output;
                }
                else
                {
                    //  If there is no match (No translation needed), directly define the final code point.
                    // Decoding (Hex to Dec)
                    byte[] output_byte_arr = new byte[codepoint.Length / 2];
                    for (Int32 i = 0; i < codepoint.Length / 2; i++)
                    {
                        output_byte_arr[i] = Convert.ToByte(codepoint.Substring(2 * i, 2), 16);
                    }
                    // Convert the byte string to string and
                    // present the result in the label
                    string output = Encoding.GetEncoding("UTF-16BE").GetString(output_byte_arr);
                    Label.Text += output;
                }
            }
        }
    }
}