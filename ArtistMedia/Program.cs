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
            using (var context = new ArtistMediaContext())
            {
                using (var reader = new StreamReader(@"/home/snyssen/Downloads/mbdump/artist"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        Console.WriteLine(line);
                        var values = line.Split('\t');
                        Console.WriteLine($"Extracted {values.Length} values");
                        Artist art;
                        try {
                            art = new Artist() // See order here -> https://github.com/metabrainz/musicbrainz-server/blob/master/admin/sql/CreateTables.sql#L208
                            {
                                Id = int.Parse(values[0]),
                                //Gid = new Guid(values[1]),
                                Name = values[2],
                                Sort_name = values[3],
                                Begin_date_year = int.Parse(values[4])
                                // etc.
                            };
                        } catch (Exception e) {
                            Console.WriteLine("Couldn't parse all values.\n" + e.Message);
                            continue;
                        }
                        Console.WriteLine($"Successfully parsed artist {art.Name}");

                        //context.Artists.Add(art); // Uncomment this when every Artist variable has been parsed
                    }
                }
                //context.SaveChanges(); // Uncomment this when every Artist variable has been parsed
            }

            // Then repeat this operation for every other table needed
        }
    }
    }

