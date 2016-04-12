using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.Presentation
{
    partial class FiberMainForm
    {
        private void InitListView()
        {
            listViewQuantity.Columns.Clear();
            System.Windows.Forms.ColumnHeader columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewQuantity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
            columnHeader1.Text = "No.";
            for (var i = 1; i <= GlobalSetting.Instance.ChannelWay; i++)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = @"CH" + i;
                ch.Width = 70;
                listViewQuantity.Columns.Add(ch);

            }
        }
    }
}
