using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFIDFExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Some example documents.
            string[] documents =
            {
                "The sun in the sky is bright.",
                "We can see the shining sun, the bright sun."
            };

            // Apply TF*IDF to the documents and get the resulting vectors.
            double[][] inputs = TFIDF.Transform(documents, 0);
            inputs = TFIDF.Normalize(inputs);

            // Display the output.
            for (int index = 0; index < inputs.Length; index++)
            {
                Console.WriteLine(documents[index]);

                foreach (double value in inputs[index])
                {
                    Console.Write(value + ", ");
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("Press any key ..");
            Console.ReadKey();
        }
    }
}
