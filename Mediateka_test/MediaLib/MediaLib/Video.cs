using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib
{
    public class Video : LinkItem, ISerial
    {
        public int Id { get; private set; }
        public new string Name { get { return "Video: " + base.Name; } }
        public Video(int id,string name, string url) : base(name, url)
        {
            Id = id;
        }

        
        public string Play()
        {
            return "Played: " + Name + " from " + Url;
        }
    }
}
