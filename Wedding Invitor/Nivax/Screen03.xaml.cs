using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InvitationTemplate.Data;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace InvitationTemplate
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Screen03 : InvitationTemplate.Common.LayoutAwarePage
    {
        string title, Description;
        string src;
        public Screen03()
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
            try
            {
                ReviewData obj = navigationParameter as ReviewData;

                iDetail.Text = "Hi " +obj.Initive+ ", I'd like to celebrate my " + obj.Event + " with you on " +
                    obj.Day + "/" + obj.Month + "/" + obj.Year + ". The party shall begin on " +
                    obj.Hour + ":" + obj.Minute + " . A Warm Welcome at my (" + obj.Name + "'s) " + obj.Event + ".";
                this.title = obj.Name + " Birthday";
                iImage.Source = obj.Image;
                Description = "I'd like to celeberate my " + obj.Event + " with u.";
                src = (iImage.Source as BitmapImage).UriSource.AbsoluteUri.Replace("ms-appx:/", "ms-appx:///");
            }
            catch (Exception)
            {
                
            }
           // var item = (SampleDataItem)navigationParameter;
           // this.DefaultViewModel["Group"] = item.Group;
          //  this.DefaultViewModel["Items"] = item.Group.Items;
           // spMain.DataContext = item;

            DataTransferManager.GetForCurrentView().DataRequested += Screen03_DataRequested;
        }

        async void Screen03_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var request = args.Request;
            request.Data.Properties.Title = this.title;
            request.Data.Properties.Description = this.Description;
            request.Data.SetText(iDetail.Text);
            StorageFile imageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(src));
            RandomAccessStreamReference imageStreamRef = RandomAccessStreamReference.CreateFromFile(imageFile);

            List<IStorageItem> imageItems = new List<IStorageItem>();
            imageItems.Add(imageFile);
            request.Data.SetStorageItems(imageItems);

            request.Data.Properties.Thumbnail = imageStreamRef;
            request.Data.SetBitmap(imageStreamRef);            
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            DataTransferManager.GetForCurrentView().DataRequested -= Screen03_DataRequested;
        }

        private void ShareData(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }
    }
}
