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

namespace HappyTomato
{
  /// <summary>
  /// MainWindow.xaml の相互作用ロジック
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }
    
    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
      StartButton.IsEnabled = false;
      // red #FFBF1D06
      // green #7a952b
      run();

    }

    async void run()
    {
      const int limit = 3;
      this.TimerLabel.Content = toTimer(limit);
      for (var i = limit - 1; i >= 0; i--)
      {
        this.TimerLabel.Content = await countTimer(i);
      }
      this.TimerLabel.Content = "Finished!";
      StartButton.IsEnabled = true;
    }

    async Task<string> countTimer(int percent) 
    {
      await Task.Delay(1000);
      return toTimer(percent);
    }

    private string toTimer(int i)
    {
      TimeSpan ts = TimeSpan.FromSeconds(i);
      return ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
    }
  }
}
