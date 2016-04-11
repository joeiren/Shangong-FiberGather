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
        private System.Windows.Forms.ColumnHeader _columnHeader0;
        private void InitListView()
        {
            _columnHeader0 = new ColumnHeader();
            this._columnHeader0.Text = "No.";
            this._columnHeader0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._columnHeader0.Width = 60;
            listViewQuantity.Columns.Add(_columnHeader0);
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
