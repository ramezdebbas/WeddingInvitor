using InvitationTemplate.Data;
using InvitationTemplate.EnableLiveTile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace InvitationTemplate
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class ItemDetailPage : InvitationTemplate.Common.LayoutAwarePage
    {
        public SampleDataItem item = null;
        public ItemDetailPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var obj = (navigationParameter as SampleDataItem);
            pageTitle.Text = obj.Title;
            iImageBox.Source = obj.Image;
            //item = (SampleDataItem)navigationParameter;
            //this.DefaultViewModel["Group"] = item.Group;
            //this.DefaultViewModel["Items"] = item.Group.Items;
            //// this.flipView.SelectedItem = item;
            //grdMain.DataContext = item;
            CreateLiveTile.ShowliveTile(false, "Wedding Invitor");
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ReviewData data = new ReviewData( iEventName.Text,
                iName.Text,
                (iDay.SelectedItem as ComboBoxItem).Content.ToString(),
                (iMonth.SelectedItem as ComboBoxItem).Content.ToString(),
                (iYear.SelectedItem as ComboBoxItem).Content.ToString(),
                (iHH.SelectedItem as ComboBoxItem).Content.ToString(),
                (iMM.SelectedItem as ComboBoxItem).Content.ToString(),
                iIniteeName.Text,
                iImageBox.Source);
                this.Frame.Navigate(typeof(Screen03), data);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
