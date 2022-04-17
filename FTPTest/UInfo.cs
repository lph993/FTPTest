using FTPTest.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTPTest
{
    public class UInfo
    {
        public string Name { get; set; }
        public string Time { get; set; }
		public string Link { get; set; }
        public long Size { get; set; }
		public State State { get; set; }
		public bool IsLink { get; set; }
		public int ImageIndex
		{
			get
			{
				switch(State){
					case State.file: return 1;
					case State.folder: return 2;
					case State.link: return 3;
					default: return 0;
				}
			}
		}
		public string QX { get; set; }
		public string Others { get; set; }
    }

	public enum State
	{
		file,folder,link,unknow
	}
}
