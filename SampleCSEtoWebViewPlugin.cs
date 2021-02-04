using System.Drawing;
using Rhino.PlugIns;
using Rhino.UI;

namespace SampleCSEtoWebView
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class SampleCSEtoWebViewPlugin : Rhino.PlugIns.PlugIn
    {
        ///<summary>Gets the only instance of the SampleCSEtoWebViewPlugin plug-in.</summary>
        public static SampleCSEtoWebViewPlugin Instance { get; private set; }

        public SampleCSEtoWebViewPlugin()
        {
            Instance = this;
        }

        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and mantain plug-in wide options in a document.

        protected override LoadReturnCode OnLoad(ref string errorMessage)
        {
            Panels.RegisterPanel(this, typeof(EtoPanel), "Test Eto Panel", new System.Drawing.Icon(SystemIcons.Exclamation, 40, 40), PanelType.System);
            return base.OnLoad(ref errorMessage);
        }
    }
}
