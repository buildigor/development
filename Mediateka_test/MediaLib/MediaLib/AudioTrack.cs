using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib
{
   public class AudioTrack:LinkItem,  IDisc,ISelection
   {
       public int Id { get; private set; }
       public new string Name { get { return "MediaTrack: " + base.Name; } }
        public AudioTrack(int id,string name, string url) : base(name, url)
        {
            Id = id;
        }


        public string Play()
        {
            return "Played: " + Name + " from " + Url;
        }

   
    }
}
