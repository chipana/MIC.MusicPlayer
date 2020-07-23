using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMusicPlayer
{
    public class Musica
    {
        public string Title;
        public string Path;
        public Musica()
        {

        }
        public Musica(string title, string path)
        {
            this.Title = title;
            this.Path = path;
        }
    }
}
