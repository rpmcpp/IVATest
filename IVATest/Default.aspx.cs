using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Data.OData;
using System.Data.Services.Client;
using IVATest.ODataService;

namespace IVATest
{
    public partial class _Default : Page
    {
        static readonly Uri uri = new Uri("http://api.internetvideoarchive.com/2.0/DataService");
        MediaEntitiesV21 container = new ODataService.MediaEntitiesV21(uri);

        protected void Page_Load(object sender, EventArgs e)
        {
            

            // Manually register the event-handling method for
            // the Click event of the Search Button control.
            SearchButton.Click += new EventHandler(this.SearchButton_Click);

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            String searchText = SearchText.Text;

            XDocument resultsFile =
                XDocument.Load(from e in container
                    where e.Title.Contains(searchText)
                    select e);
           
            var query = from c in resultsFile.Descendants("entry").Elements("content").Elements("m:properties")
                        select c;
            foreach (XElement x in query)
            {
                SearchResultsListBox.Items.Add(
                           new ListItem(x.Element("d:Publishedid").Value,
                           x.Element("d:Title").Value)
                         );
            }

            


        }

        private void SearchResultsListBox_Click(object sender, EventArgs e)
        {
            String vidUrl;
            
            ListBox lb = sender as ListBox;
            
            String pubId = lb.SelectedItem.Value;

            vidUrl =
                "'http://www.videodetective.com/embed/video/?publishedid={0}&options=false&autostart=false&playlist=none&width=400&height=300', pubId";

            frame1.Attributes.Add("src", vidUrl);
            
            
        }
    }
}