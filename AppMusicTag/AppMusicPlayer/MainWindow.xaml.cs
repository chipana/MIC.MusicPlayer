using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AppMusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var tagFile = TagLib.File.Create(openFileDialog.FileName);
                foreach (string x in tagFile.Tag.Performers)
                {
                    Console.WriteLine("Artista: {0}", x);
                }
                grid.DataContext = tagFile;
                if (tagFile.Tag.Pictures.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                    ms.Seek(0, SeekOrigin.Begin);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    albumImage.Source = bitmap;

                }
            }
        }
    }
}



