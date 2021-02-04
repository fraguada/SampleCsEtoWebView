using System;
using System.IO;
using System.Reflection;
using Eto.Drawing;
using Eto.Forms;
using Rhino.UI;

namespace SampleCSEtoWebView
{
    /// <summary>
    /// Required class GUID, used as the panel Id
    /// </summary>
    [System.Runtime.InteropServices.Guid("f38b6571-076b-480d-8434-75c8abef4458")]
    public class EtoPanel: Panel, IPanel
    {
        /// <summary>
        /// Provide easy access to the SampleCsEtoPanel.GUID
        /// </summary>
        public static System.Guid PanelId => typeof(EtoPanel).GUID;

        private readonly uint m_document_sn;

        public WebView Browser { get; private set; }

        private string index;

        public EtoPanel(uint documentSerialNumber)
        {
            m_document_sn = documentSerialNumber;

            var path = Directory.GetParent(Assembly.GetExecutingAssembly().Location);
            index = string.Format(@"{0}\app\index.html", path);
            index = index.Replace("\\", "/");

            Browser = new WebView
            {
                Url = new Uri(index)
            };

            var layout = new DynamicLayout { DefaultSpacing = new Size(5, 5), Padding = new Padding(10) };
            layout.Add(Browser);

            Browser.DocumentLoaded += Browser_DocumentLoaded;
            Browser.DocumentLoading += Browser_DocumentLoading;

            Content = layout;
        }

        private void Browser_DocumentLoading(object sender, WebViewLoadingEventArgs e)
        {
            Rhino.RhinoApp.WriteLine("Browser: Document Loading");
            Rhino.RhinoApp.WriteLine(e.Uri.ToString());

            e.Cancel = true;
        }

        private void Browser_DocumentLoaded(object sender, WebViewLoadedEventArgs e)
        {
            Rhino.RhinoApp.WriteLine("Browser: Document Loaded");
        }

        public void PanelClosing(uint documentSerialNumber, bool onCloseDocument)
        {
            Rhino.RhinoApp.WriteLine($"Panel closing for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }

        public void PanelHidden(uint documentSerialNumber, ShowPanelReason reason)
        {
            Rhino.RhinoApp.WriteLine($"Panel hidden for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }

        public void PanelShown(uint documentSerialNumber, ShowPanelReason reason)
        {
            Rhino.RhinoApp.WriteLine($"Panel shown for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }
    }
}
