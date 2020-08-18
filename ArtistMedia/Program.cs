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
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }
        }
    }
    }

