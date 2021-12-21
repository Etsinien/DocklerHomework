using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    /// <summary>
    /// Data tightly coupled to specific view
    /// Data fields are filled in AWEmpireDataProvider
    /// </summary>
    public class AWEmpireViewData
    {
        public string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }

        public Uri previewImage;
        public Uri PreviewImage
        {
            get { return previewImage; }
            set
            {
                previewImage = value;
            }
        }

        public string duration;
        public string Duration
        {
            get { return duration; }
            set
            {
                duration = @"Duration: " + value;
            }
        }

        public string quality;
        public string Quality
        {
            get { return quality; }
            set
            {
                quality = @"Quality: " + value;
            }
        }

    }
}
