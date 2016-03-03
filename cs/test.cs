using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    class Program
    {
        static void Main(string[] args)
        {
            using(System.IO.FileStream fileStream = new System.IO.FileStream("random_csharp.bin", System.IO.FileMode.OpenOrCreate))
            using(System.IO.BinaryWriter bwriter = new System.IO.BinaryWriter(fileStream))
            {
                RandomWELL random = new RandomWELL();
                random.srand(7654321);
                for(int i=0; i<1024*1024; ++i){
                    bwriter.Write(random.frand());
                }
                bwriter.Flush();
                bwriter.Close();
            }
        }
    }
}
