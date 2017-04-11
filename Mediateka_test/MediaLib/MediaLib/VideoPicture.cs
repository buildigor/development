using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib
{
   public class VideoPicture
   {
       private readonly List<IVideoElement> _videoPicElements;
       

       public VideoPicture()
       {
           _videoPicElements = new List<IVideoElement>();
       }

       public VideoPicture(List<IVideoElement> videoPicElements)
       {
           this._videoPicElements = videoPicElements;
       }

       public void AddToVideoPicture(IVideoElement videoPicElement)
       {
           _videoPicElements.Add(videoPicElement);
       }

       public void DeleteFromVideoPicture(IVideoElement videoPicElement)
       {
           _videoPicElements.Remove(videoPicElement);
       }
       public string ShowAll()
       {
           return _videoPicElements.Aggregate<IVideoElement, string>(null, (current, videoPictureElement) => current + ("VideoElement: " + videoPictureElement.Id + " " + videoPictureElement.Name + "\n"));
       }
   }
}
