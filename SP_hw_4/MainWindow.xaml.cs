

using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.IO;
using System.Windows.Forms;




namespace SP_hw_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_WhereFrom(object sender, RoutedEventArgs e)
        {
          
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            WhereFromTextBox.Text = folderBrowserDialog.SelectedPath;
            folderBrowserDialog.Dispose();
            
        }

        private void Button_Click_WhereTo(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            WhereToTextBox.Text = folderBrowserDialog.SelectedPath;
            folderBrowserDialog.Dispose();
        }

        private void Button_Click_Copy(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = WhereFromTextBox.Text;
            folderBrowserDialog2.SelectedPath = WhereToTextBox.Text;
            var size = GetDirectorySize(WhereFromTextBox.Text);
            TextBlock_1.Text = size.ToString();
        }

        static long GetDirectorySize(string p) //художетсвенный фильм сп...
        {
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.*");

            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // Return total size
            return b;
        }


        /* private void Button_Click_ChooseFolder(object sender, RoutedEventArgs e)
         {
             OpenFileDialog openFileDialog = new OpenFileDialog();
             if (openFileDialog.ShowDialog() == true)
             {
                 Console.WriteLine(openFileDialog.SafeFileName);
                 MessageBox.Show(openFileDialog.SafeFileName);

                 byte[] buffer = new byte[1024];
                 long copied = 0, length = new FileInfo(openFileDialog.SafeFileName).Length;
                 using (Stream out_ = File.Create(openFileDialog.SafeFileName))
                 using (Stream in_ = File.OpenRead(openFileDialog.SafeFileName))
                     while (copied < length)
                     {
                         int read = in_.Read(buffer, 0, buffer.Length);
                         out_.Write(buffer, 0, read);
                         copied += read;
                         progressBar1.Dispatcher.Invoke(() => progressBar1.Value = 100 * copied / length);
                     }
             }
         }*/


    }
}

