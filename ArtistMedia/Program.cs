using ArtistMedia.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArtistMedia
{
   public  class Program 
    {
        

        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"C:\artist.txt"))
            {
                List<string> Id = new List<string>();
                List<string> Name = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\t');

                    int id = int.Parse(values[0]);
                    Name.Add(values[1]);
                }
            }
        }
    }
    }

