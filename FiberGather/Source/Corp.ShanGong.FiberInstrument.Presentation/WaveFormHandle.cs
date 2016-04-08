using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace Corp.ShanGong.FiberInstrument.Presentation
{
    partial class FiberMainForm
    {
        private GraphPane _gPane;

        private PointPairList _pointList;
        private double _minY = double.MaxValue;
        private double _maxY =double.MinValue;
        private void InitWaveControl()
        {
            _gPane = zedGraphControl1.GraphPane;
            _pointList = new PointPairList();
            XDate start = new XDate();
            LineItem myCurve;
            myCurve = zedGraphControl1.GraphPane.AddCurve("My Curve", _pointList, Color.Lime, SymbolType.None);
            myCurve.Line.Width = 1.2F;
            _gPane.LineType = LineType.Stack;
            //            this.zedGraphControl1.GraphPane.YAxis.MinorGrid.IsVisible = true;
            //            this.zedGraphControl1.GraphPane.YAxis.MinorGrid.Color = Color.Red;
            _gPane.XAxis.Scale.FontSpec.Size = 10;
            _gPane.YAxis.Scale.FontSpec.Size = 10;
            //_gPane.YAxis.Scale.MinAuto = true;
            //_gPane.YAxis.Scale.MaxAuto = true;
       
  
            _gPane.XAxis.Type = AxisType.DateAsOrdinal;
            _gPane.Chart.Fill = new Fill(Color.Black);
            //            this.zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
            //            this.zedGraphControl1.GraphPane.XAxis.MajorGrid.Color = Color.WhiteSmoke;
            _gPane.YAxis.MajorGrid.IsVisible = true;
            _gPane.YAxis.MajorGrid.Color = Color.White;

            zedGraphControl1.IsShowPointValues = true;

            zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);
            zedGraphControl1.IsAutoScrollRange = true;
            zedGraphControl1.IsEnableSelection = false;
            zedGraphControl1.IsShowContextMenu = false;
            
            zedGraphControl1.IsEnableZoom = false;
            zedGraphControl1.IsEnableWheelZoom = false;
            this.zedGraphControl1.AxisChange();

            this.zedGraphControl1.Refresh();
        }

        private string MyPointValueHandler(ZedGraphControl aSender, GraphPane aPane, CurveItem aCurve, int aIpt)
        {
            return "111";
        }

        protected void ShowWaveForm()
        {
            //ControlRenderInvoke.SafeInvoke(zedGraphControl1, () =>
            {
                _pointList.Clear();
                var list = _waveViewData.DisplayChannelWaveQueue.ToList();
                //_waveViewData.TakeMoreChannelWaveData(10);
                XDate start = new XDate();
                for (var i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        start = new XDate(DateTime.Now);
                    }
                    start.AddMilliseconds(i * 10);
                    var val = (double)(list.ElementAt(i).ChannelValues[0].GratingValues[0].WaveLengthExtension ?? decimal.Zero);
                    _minY = Math.Min(val, _minY);
                    _maxY = Math.Max(val, _maxY);
                    _pointList.Add(start, val);
                }

                _gPane.YAxis.Scale.Max = _maxY + 0.005;
                _gPane.YAxis.Scale.Min = _minY - 0.005;
                _gPane.YAxis.Scale.MajorStep = 0.001;
                zedGraphControl1.GraphPane.CurveList.Clear();
                var line = zedGraphControl1.GraphPane.AddCurve("My Curve", _pointList, Color.Lime, SymbolType.None);
                line.Line.IsSmooth = true;
                this.zedGraphControl1.AxisChange();

                this.zedGraphControl1.Refresh();
            }
            //);
        }
    }
}
