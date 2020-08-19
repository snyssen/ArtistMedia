using ArtistMedia.Models;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;

using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;



namespace ArtistMedia

{

    public class Program

    {

        static void Main(string[] args)

        {

            using (var context = new ArtistMediaContext())

            {

                using (var reader = new StreamReader(@"/home/snyssen/Downloads/mbdump/artist"))

                {
                    int counter = 1;

                    while (!reader.EndOfStream)

                    {

                        var line = reader.ReadLine();

                        Console.WriteLine(line);

                        var values = line.Split('\t');

                        Console.WriteLine($"Extracted {values.Length} values");

                        Artist art;

                        try
                        {


                            art = new Artist() // See order here -> https://github.com/metabrainz/musicbrainz-server/blob/master/admin/sql/CreateTables.sql#L208

                            {

                                Gid = new Guid(values[1]),

                                Name = values[2],

                                Sort_name = values[3],

                                Begin_date_year = values[4] == "\\N" ? null : (int?)int.Parse(values[4]),

                                Begin_date_month = values[5] == "\\N" ? null : (int?)int.Parse(values[5]),
                                Begin_date_day = values[6] == "\\N" ? null : (int?)int.Parse(values[6]),
                                End_date_year = values[7] == "\\N" ? null : (int?)int.Parse(values[7]),
                                End_date_month = values[8] == "\\N" ? null : (int?)int.Parse(values[8]),
                                End_date_day = values[9] == "\\N" ? null : (int?)int.Parse(values[9]),
                                Type = values[10] == "\\N" ? null : (int?)int.Parse(values[10]),
                                Area = values[11] == "\\N" ? null : (int?)int.Parse(values[11]),
                                Gender = values[12] == "\\N" ? null : (int?)int.Parse(values[12]),

                                Comment = values[13],
                                Edits_pending = values[14] == "\\0" ? null : (int?)int.Parse(values[14]),
                                Last_updated = values[15] == "\\N" ? null : (DateTime?)DateTime.Parse(values[15]),
                                Ended = values[16] == "t",

                            };

                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e);

                            continue;

                        }

                        Console.WriteLine($"Successfully parsed artist {art.Name}");



                        context.Artists.Add(art);

                        if (counter >= 100) {
                            try {
                                Console.WriteLine("Saving batch of artists to DB...");
                                var result = context.SaveChanges();
                                Console.WriteLine($"Saved {result} artists !");
                                counter = 0;
                            } catch (Exception e) {
                                Console.WriteLine("Couldn't save artists to database");
                                Console.WriteLine(e);
                                return;
                            }
                        }

                        counter++;
                    }
                }

                try
                {
                    Console.WriteLine("Finished parsing artists, saving to database...");
                    var result = context.SaveChanges();
                    Console.WriteLine($"Saved {result} artists !");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Couldn't save artists to database");
                    Console.WriteLine(e);
                    return;
                }
            }
            /*
                        using (var context = new ArtistMediaContext())

                        {

                            using (var reader = new StreamReader(@"C:\gender.txt"))

                            {

                                while (!reader.EndOfStream)

                                {

                                    var line = reader.ReadLine();

                                    Console.WriteLine(line);

                                    var values = line.Split('\t');

                                    Console.WriteLine($"Extracted {values.Length} values");

                                    Gender gen;

                                    try
                                    {

                                        gen = new Gender() // See order here -> https://github.com/metabrainz/musicbrainz-server/blob/master/admin/sql/CreateTables.sql#L208

                                        {

                                            Name = values[1],
                                            Parent = values[2] == "\\N" ? null : (int?)int.Parse(values[2]),
                                            Child_order = int.Parse(values[3]),
                                            description = values[4],
                                            Gid = new Guid(values[5])
                                        };

                                    }
                                    catch (Exception e)
                                    {

                                        Console.WriteLine(e);

                                        continue;

                                    }

                                    Console.WriteLine($"Successfully parsed gender {gen.Name}");



                                    context.Genders.Add(gen); 

                                }

                            }

                             context.SaveChanges(); 

                        }
                        using (var context = new ArtistMediaContext())

                        {

                            using (var reader = new StreamReader(@"C:\artist_type.txt"))

                            {

                                while (!reader.EndOfStream)

                                {

                                    var line = reader.ReadLine();

                                    Console.WriteLine(line);

                                    var values = line.Split('\t');

                                    Console.WriteLine($"Extracted {values.Length} values");

                                    Artist_Type typ;

                                    try
                                    {

                                        typ = new Artist_Type() // See order here -> https://github.com/metabrainz/musicbrainz-server/blob/master/admin/sql/CreateTables.sql#L208

                                        {

                                            Name = values[1],
                                            Parent = values[2] == "\\N" ? null : (int?)int.Parse(values[2]),
                                            Child_order = int.Parse(values[3]),
                                            description = values[4],
                                            Gid = new Guid(values[5])
                                        };

                                    }
                                    catch (Exception e)
                                    {

                                        Console.WriteLine(e);

                                        continue;

                                    }

                                    Console.WriteLine($"Successfully parsed artist_type {typ.Name}");



                                    context.Artist_Types.Add(typ);

                                }

                            }

                            context.SaveChanges();

                        }
            */

        }

    }

}

