using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
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
using Microsoft.Win32;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            CommandBinding saveCommand = new CommandBinding(
                ApplicationCommands.Save, Execute_Save, CanExecute_Save);
            CommandBinding openCommand = new CommandBinding(
                ApplicationCommands.Open, Execute_Open, CanExecute_Open);
            CommandBinding cleanCommand = new CommandBinding(
                CustomCommands.Clean, Execute_Clean, CanExecute_Clean);
            CommandBindings.Add(saveCommand);
            CommandBindings.Add(openCommnd);
            CommandBindings.Add(cleanCommand);

        }


        void CanExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        { 
            e.CanExecute = inputTextBox.Text.Trim().Length > 0;
        }

        void Execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            System.IO.File.WriteAllText("d:\\myFile.txt", inputTextBox.Text);
            MessageBox.Show("The file was saved!");
        }

        void CanExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void Execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text files | *.txt";
            bool? success = fileDialog.ShowDialog();
            if (success == true) 
            { 
                string path = fileDialog.FileName;
                string text = File.ReadAllText(path);
                inputTextBox.Text = text;
            }
        }

        void CanExecute_Clean(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = inputTextBox.Text.Length > 0;
        }

        void Execute_Clean(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.Text = "";
        }


    }
}
