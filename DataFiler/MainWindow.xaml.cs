using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DataFiler
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly string[] VideoExtensions = { ".avi", ".mkv", ".mp4", ".wmv", ".mov", ".flv" };


		private List<FileInfo> AllVideoFiles = new List<FileInfo>();

		public MainWindow()
		{
			InitializeComponent();

			LoadFiles();
			LoadData();
		}

		private void LoadData()
		{
			// Load data in gridview

			List<Movie> lMovies = new List<Movie>();
			for (int i = 0; i < AllVideoFiles.Count; i++)
			{
				var video = AllVideoFiles[i];

				string name = video.Name.Replace(video.Extension, String.Empty);
			
				lMovies.Add(new Movie
				{
					Name = name,
					ParentFolder = AllVideoFiles[i].DirectoryName,
				});
			}
			
			dataGrid.ItemsSource = lMovies;


			// Load Detaisl?


			// Load ComboBox
			

		}

		private void LoadFiles()
		{
			try
			{
				var fileNames = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*", SearchOption.AllDirectories);

				AllVideoFiles = fileNames.Select(x => new FileInfo(x)).Where(y => VideoExtensions.Contains(y.Extension)).ToList();
			}
			catch (Exception ex)
			{
				lblStatus.Text = "Unexpected exception happened: " + ex.Message;
			}
		}

		private void NumberValidator(object sender, TextCompositionEventArgs e)
		{

		}
	}
}
