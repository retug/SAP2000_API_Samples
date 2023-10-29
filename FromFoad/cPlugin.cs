using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP2000v1;

namespace MyFirstSap2000Plugin
{
    public class cPlugin
    {
        public void Main(ref SAP2000v1.cSapModel sapModel, ref SAP2000v1.cPluginCallback pluginCallback)
        {
            Form1 Frm = new Form1(ref sapModel,ref pluginCallback);  
            Frm.Show();
        }
        public long Info(ref String Text)
        {
            try
            {
                Text = "in this plugin select nods to exporl max load on it.";
            }
            catch (Exception)
            {
                Text = "its not ok.";
                throw;
            }

            return 0;
        }


    }
}
