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
        private double _maxY = double.MinValue;
        private void InitWaveControl()
        {
            _gPane = zedGraphControl1.GraphPane;
            _pointList = new PointPairList();
            LineItem myCurve;
            myCurve = zedGraphControl1.GraphPane.AddCurve("My Curve", _pointList, Color.Lime, SymbolType.None);
            myCurve.Line.Width = 1.2F;
            myCurve.Line.IsSmooth = true;

            _gPane.Chart.Fill = new Fill(Color.Black);

            _gPane.LineType = LineType.Stack;
            _gPane.XAxis.Scale.FontSpec.Size = 10;
            _gPane.XAxis.Scale.Max = 100;
            _gPane.XAxis.Scale.Min = 1;
            _gPane.XAxis.Scale.IsVisible = false;
            _gPane.XAxis.Title.Text = "时间";
            _gPane.XAxis.Title.FontSpec.FontColor = Color.Blue;

            _gPane.YAxis.Scale.FontSpec.Size = 12;

            _gPane.YAxis.MajorGrid.IsVisible = true;
            _gPane.YAxis.MajorGrid.Color = Color.White;
            _gPane.YAxis.IsVisible = true;
            _gPane.YAxis.Scale.IsVisible = true;
            _gPane.YAxis.Title.Text = "波长";
            _gPane.YAxis.Title.FontSpec.FontColor = Color.Blue;

//            zedGraphControl1.IsShowPointValues = true;
//            zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

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
               /* var list = _waveViewData.DisplayChannelWaveQueue.ToList();
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
                }*/

                PointListMock();
                _gPane.YAxis.Scale.Max = _maxY + 0.05;
                _gPane.YAxis.Scale.Min = _minY - 0.05;
                _gPane.YAxis.Scale.MajorStep = 0.05;
                
         
                zedGraphControl1.GraphPane.CurveList.Clear();
                var line = zedGraphControl1.GraphPane.AddCurve("波长变化图", _pointList, Color.Green, SymbolType.None);
                line.Line.IsSmooth = true;
                this.zedGraphControl1.AxisChange();

                this.zedGraphControl1.Refresh();
            }
            //);
        }

        private static Queue<double> _listMock = new Queue<double>(); 

        public static List<double> _listRange = new List<double>()
        {
            1538.0199,1537.9199,1538.0299,1537.9542,1538.1085
        };
        static Random random = new Random();
        protected static void LoopPlusTestMock()
        {
            while (_listMock.Count >= 100)
            {
                _listMock.Dequeue();
            }
            
            double val = _listRange.ElementAt(random.Next() % 5);
            _listMock.Enqueue(val);
        }

        protected  void PointListMock()
        {
            LoopPlusTestMock();
            for (var i = 0; i < _listMock.Count; i++)
            {
                var val = _listMock.ElementAt(i);
                _minY = Math.Min(val, _minY);
                _maxY = Math.Max(val, _maxY);
                _pointList.Add(i, val);
            }
        }
    }
}
