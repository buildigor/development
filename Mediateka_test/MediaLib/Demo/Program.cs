using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLib;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioTrack mediaTrack = new AudioTrack(1,"metall","http://metall");
            Picture picture = new Picture(2,"Kurt","http://met");
            Video video = new Video(3,"garri poter","http://vid");
            Disk disk = new Disk(new List<IDisc>(){mediaTrack,picture});
            Selection selection = new Selection();
            Console.WriteLine(disk.ShowAll());
           // Series series = new Series(new List<ISerial>(){video,picture});
            AudioTrack[] tracks = new AudioTrack[5];
            for (int i = 0; i < tracks.Length; i++)
            {
                tracks[i] = new AudioTrack(i,"Name- "+i,"http://loc"+i);
                disk.AddToDisk(tracks[i]);
                selection.AddToSelection(tracks[i]);
            }
            Console.WriteLine(mediaTrack.Play());
            Console.WriteLine(disk.ShowAll());
            Series series = new Series();
            series.AddContentToSerial(video);
            series.AddContentToSerial(picture);
            series.DeleteContentFromSerial(video);
            selection.AddToSelection(mediaTrack);
            Console.WriteLine(series.ShowAll());
            disk.AddToDisk( picture); 
            Console.WriteLine(disk.AddToDisk( mediaTrack ));
               

            Console.ReadLine();
            


        }
    }
}
