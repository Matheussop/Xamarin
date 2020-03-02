using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void GoActivityIndicatorPage(object sender, EventArgs e)
        {
            Detail = new Controles.ActivityIndicatorPage();
        }

        private void GoProgressBar(object sender, EventArgs e)
        {
            Detail = new Controles.ProgressBarPage();
        }

        private void GoBoxView(object sender, EventArgs e)
        {
            Detail = new Controles.BoxViewPage();
        }

        private void GoLabel(object sender, EventArgs e)
        {
            Detail = new Controles.LabelPage();
        }

        private void GoButtonPage(object sender, EventArgs e)
        {
            Detail = new Controles.ButtonPage();
        }

        private void GoEntryEditorPage(object sender, EventArgs e)
        {
            Detail = new Controles.EntryEditorPage();
        }

        private void GoDatePickerPage(object sender, EventArgs e)
        {
            Detail = new Controles.DatePickerPage();
        }

        private void GoTimePickerPage(object sender, EventArgs e)
        {
            Detail = new Controles.TimePickerPage();
        }

        private void GoPickerPage(object sender, EventArgs e)
        {
            Detail = new Controles.PickerPage();
        }

        private void GoSearchBarPage(object sender, EventArgs e)
        {
            Detail = new Controles.SearchBarPage();
        }

        private void GoSliderStepperPage(object sender, EventArgs e)
        {
            Detail = new Controles.SliderStepperPage();
        }

        private void GoSwitchPage(object sender, EventArgs e)
        {
            Detail = new Controles.SwitchPage();
        }

        private void GoImagePage(object sender, EventArgs e)
        {
            Detail = new Controles.ImagePage();
        }

        private void GoListViewPage(object sender, EventArgs e)
        {
            Detail = new Controles.ListViewPage();
        }

        private void GoTableViewPage(object sender, EventArgs e)
        {
            Detail = new Controles.TableViewPage();
        }

        private void GoWebViewPage(object sender, EventArgs e)
        {
            Detail = new Controles.WebViewPage();
        }
    }
}