using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TagLib;
using System.Text.RegularExpressions;

namespace MP3BatchMetadataChange
{
    class Program
    {
        static string Capitalize(string str)
        {
            //This funtion takes a string and tunr only the fist char and change it tu uppercase
            str = str.ToLower();
            string[] strs = str.Split(' ');
            foreach (string s in strs)
            {
                Regex ex = new Regex("^[a-z]+");
                if (ex.IsMatch(s))
                {
                    string ns = "";
                    char t = s[0];
                    t -= (char)32;
                    ns = t.ToString() + s.Substring(1, s.Length - 1);
                    str = str.Replace(s, ns);
                }
            }
            return str;
        }

        static void Main(string[] args)
        {
            string artist = "";
            string album = "";
            string song_name = "";
            string song_number = "";
            string cover_file = "";

            //Need a log to save all exceptions if directories and files doesn't
            //match the names pattern 
            StreamWriter log_writer = new StreamWriter("log.txt");

            //The files in this path are for testing and does have meta data
            string music_path = @"..\..\..\music";

            string[] albums_paths = Directory.GetDirectories(music_path);

            foreach (string album_path in albums_paths)
            {
                string[] file_names = Directory.GetFiles(album_path);

                //Search for the cover image
                foreach (string file_name in file_names)
                {
                    System.IO.FileInfo file_info = new FileInfo(file_name);
                    if (file_info.Extension.ToLower() == ".jpg")
                    {
                        cover_file = file_name;
                    }
                }

                //Start the files processing
                foreach (string file in file_names)
                {
                    System.IO.FileInfo fi = new FileInfo(file);
                    if (fi.Extension.ToLower() == ".mp3")
                    {
                        try
                        {
                            //Get the metada tag from file
                            TagLib.File tag_file = TagLib.File.Create(file);
                            Tag tag = tag_file.GetTag(TagTypes.Id3v2, true);

                            //Extract the Artist and Album name from album path
                            string[] strs = Capitalize(Path.GetFileName(album_path)).Split('-');
                            artist = strs[0].Trim();
                            album = strs[1].Trim();

                            //Extract the song name and numbre rom the ile name
                            strs = Capitalize(Path.GetFileNameWithoutExtension(file)).Split('-');
                            song_name = Path.GetFileNameWithoutExtension(file).Replace(strs[strs.Length - 1], " ").Trim();
                            song_number = strs[strs.Length - 1].Replace('(', ' ').Replace(')', ' ').Trim();

                            //Set the correspondig values to the Tag
                            tag.Album = album;
                            string[] artists = { artist };
                            tag.Performers = artists;
                            tag.AlbumArtists = artists;
                            tag.Title = song_name;

                            tag.Track = Convert.ToUInt32(song_number);

                            //If found cover image add it to the file
                            if (cover_file != "")
                            {
                                Picture cover = new Picture(cover_file);
                                IPicture[] pics = { cover };
                                tag.Pictures = pics;
                            }
                            //Save the tag changes, the file is updated!
                            tag_file.Save();
                        }
                        catch (Exception e1)
                        {
                            log_writer.WriteLine(file);
                            log_writer.WriteLine(e1.Message);
                        }
                    }
                }
            }
            //Close the log file
            log_writer.Close();
        }
    }
}
