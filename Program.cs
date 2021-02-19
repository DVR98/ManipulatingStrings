using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ManipulatingStrings
{
    class Program
    {
        //StringBuilder class
        public static void string_builder()
        {
            //Changing character
            StringBuilder sb = new StringBuilder("A initial value");
            Console.WriteLine("Original value: {0}", sb.ToString());
            sb[0] = 'B';
            Console.WriteLine("Changed value: {0}", sb.ToString());

            //Usage for loop
            StringBuilder sb2 = new StringBuilder(string.Empty);

            for (int i = 0; i < 100; i++)
            {
                sb2.Append("x");
            }

            Console.WriteLine(sb2.ToString());
        }

        //StringWriter and StringReader classes
        public static void string_writer_reader(){
            //StringWriter
            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }
            string xml = stringWriter.ToString();
            Console.WriteLine("StringWriter: ");
            Console.WriteLine(xml);

            //StringReader
            var stringReader = new StringReader(xml);
            decimal price = 0.0m;
            using (XmlReader reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                price = decimal.Parse(reader.ReadInnerXml(),
                    new CultureInfo("en-US"));
            }

            Console.WriteLine("StringReader: ");
            Console.WriteLine("Price: {0}", price);
        }

        //String methods
        public static void string_methods(){
            //Searching for strings
            //
            //Using IndexOf and LastIndexOf
            Console.WriteLine("IndexOf and LastIndexOf:");
            string value = "My Sample Value";
            Console.WriteLine(value);
            int indexOfp = value.IndexOf('p'); // returns 6
            Console.WriteLine("Index of p: {0}", indexOfp);
            int lastIndexOfm = value.LastIndexOf('m'); // returns 5
            Console.WriteLine("Last index of m: {0}", lastIndexOfm);

            //Using StartWith and EndsWith
            Console.WriteLine("StartWith and EndsWith:");
            string value2 = "<mycustominput>";
            Console.WriteLine(value2);
            if (value2.StartsWith("<")) {
                Console.WriteLine("string starts with <");
             }
            if (value2.EndsWith(">")) { 
                Console.WriteLine("String ends with >");
            }

            //Reading a SubString
            Console.WriteLine("SubString:");
            string value3 = "My Sample Value";
            string subString = value3.Substring(3, 6); // Returns 'Sample'
            Console.WriteLine("Original string: {0}, SubString: {1}", value3, subString);

            //Changing string with regular expression
            Console.WriteLine("Regular Expressions: Removing Mr. and Ms.");
            string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
                        "Abraham Adams", "Ms. Nicole Norris" };

            foreach (string name in names)
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
        }   

        //Formatting strings
        class Person
        {
            public Person(string firstName, string lastName)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }

            //Formatting ToString() method
            public override string ToString()
            {
                return FirstName + LastName;
            }
        }
        
        public static void string_format(){
            Person p = new Person("John", "Doe");
            Console.WriteLine("Formatting strings: {0}", p); // Displays 'John Doe'

            //Displaying number with currency format
            Console.WriteLine("Number with currency format: ");
            double cost = 1234.56;
            Console.WriteLine(cost.ToString("C", new System.Globalization.CultureInfo("en-US")));

            //Using DateTime to format strings
            Console.WriteLine("DateTime: ");
            DateTime d = new DateTime(2013, 4, 22);
            CultureInfo provider = new CultureInfo("en-US");
            Console.WriteLine(d.ToString("d", provider)); // Displays 4/22/2013
            Console.WriteLine(d.ToString("D", provider)); // Displays Monday, April 22, 2013
            Console.WriteLine(d.ToString("M", provider)); // Displays April 22

        }

        //System.String namespace
        //.NET framework offers several classes to manipulate strings:
        // 1) Stringbuilder: used to modify strings
        // 2) StringWriter: Adaptation of StringBuilder, Used to write strings for TextWriter
        // 3) StringReader: Adaptation of StringBuilder, Used to read strings for TextReader
        //String namespace also provides many methods that you could use to read or manipulate strings
        //You can use .ToString() method to format any type
        static void Main(string[] args)
        {
            //StringBuilder
            Console.WriteLine("Using StringBuilder: ");
            string_builder();

            //StringWriter/StringReader
            string_writer_reader();

            //Working with string methods
            string_methods();

            //Formatting strings
            string_format();
        }
    }
}
