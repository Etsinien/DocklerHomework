using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DocklerHW
{
    /// <summary>
    /// Interaction logic for AweVideoPreviewItem.xaml
    /// </summary>
    public partial class AweVideoPreviewItem : UserControl
    {

        public string VideoTitle
        {
            get { return (string)GetValue(VideoTitleProperty); }
            set { SetValue(VideoTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VideoTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VideoTitleProperty =
            DependencyProperty.Register("VideoTitle", typeof(string), typeof(AweVideoPreviewItem), new PropertyMetadata(string.Empty));


        public Uri PreviewImageUri
        {
            get { return (Uri)GetValue(PreviewImageUriProperty); }
            set { SetValue(PreviewImageUriProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PreviewImageUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreviewImageUriProperty =
            DependencyProperty.Register("PreviewImageUri", typeof(Uri), typeof(AweVideoPreviewItem), new PropertyMetadata(new Uri("https://th.bing.com/th/id/OIP.VvvX4Ug_y6j3qz2l5aJIMAAAAA?pid=ImgDet&rs=1")));

        public string Quality
        {
            get { return (string)GetValue(QualityProperty); }
            set { SetValue(QualityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PreviewImageUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QualityProperty =
            DependencyProperty.Register("Quality", typeof(string), typeof(AweVideoPreviewItem), new PropertyMetadata(string.Empty));

        public string Duration
        {
            get { return (string)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PreviewImageUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(string), typeof(AweVideoPreviewItem), new PropertyMetadata(string.Empty));


        public AweVideoPreviewItem()
        {
            InitializeComponent();
        }
    }
}
