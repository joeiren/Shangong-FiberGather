using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace ZhengJuyin.UI
{
    public partial class ZGraph : UserControl
    {
        /***************************************
         *  模块：公有绘图方法
         * 
         *  设计人：xf_z1988
         * 
         *  博客园：http://www.cnblogs.com/xf_z1988/
         * 
         *  CSDN：http://blog.csdn.net/xf_z1988
         * 
         *  相关文章说明请参考我的博文
         *  文章在博客园的位置：http://www.cnblogs.com/xf_z1988/archive/2010/05/11/CSharp_WinForm_Waveform.html
         * 
         *  联系方式：zhengxuanfan@Gmail.com
         * 
         *  设计时间：2009-9-26~2009-9-28
         * ************************************/
        #region **清空所有加载的波形数据 f_ClearAllPix():void **
        /// <summary>
        /// 清空所有加载的波形数据并清空显示
        /// </summary>
        public void f_ClearAllPix()
        {
            //重新初始化
            _listX.Clear();
            _listY.Clear();
            _listColor.Clear();
            _listWidth.Clear();
            _listLineJoin.Clear();
            _listLineCap.Clear();
            _listDrawStyle.Clear();
            //更新
            pictureBoxGraph.Refresh();
        }
        #endregion

        #region **重新初始化X轴和Y轴坐标 void f_reXY() **
        /// <summary>
        /// 重新初始化X轴和Y轴坐标
        /// </summary>
        public void f_reXY()
        {
            buttonReXY_Click(null, null);
            buttonAutoModeXY_Click(null, null);
        }
        #endregion

        #region **更新显示 f_Refresh():void **
        /// <summary>
        /// 更新显示
        /// </summary>
        public void f_Refresh()
        {
            pictureBoxGraph.Refresh();
        }
        #endregion

        #region **清空原有数据并加载一条波形数据 f_LoadOnePix(listX:ref List<float>, listY:ref List<float>, listColor:Color, listWidth:int, listLineJoin:LineJoin, listLineCap:LineCap, listDrawStyle:DrawStyle):void **
        /// <summary>
        /// 清空原有数据并加载一条波形数据
        /// </summary>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        /// <param name="listLineJoin">线条连接点</param>
        /// <param name="listLineCap">线条起始线帽</param>
        /// <param name="listDrawStyle">线条样式</param>
        public void f_LoadOnePix(ref List<float> listX, ref List<float> listY, Color listColor, int listWidth, LineJoin listLineJoin, LineCap listLineCap,DrawStyle listDrawStyle)
        {
            //重新初始化
            f_ClearAllPix();
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(listLineJoin);
            _listLineCap.Add(listLineCap);
            _listDrawStyle.Add(listDrawStyle);
            
        }
        /// <summary>
        /// 清空原有数据并加载一条波形数据，显示样式为线条
        /// </summary>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        public void f_LoadOnePix(ref List<float> listX, ref List<float> listY, Color listColor, int listWidth)
        {
            //重新初始化
            f_ClearAllPix();
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(LineJoin.Bevel);
            _listLineCap.Add(LineCap.NoAnchor);
            _listDrawStyle.Add(DrawStyle.Line);

        }
        #endregion

        #region **在原有波形上添加一条波形数据 f_DrawAddPix(listX:ref List<float>, listY:ref List<float>, listColor:Color, listWidth:int, listLineJoin:LineJoin, listLineCap:LineCap, listDrawStyle:DrawStyle):void **
        /// <summary>
        /// 在原有波形上添加一条线
        /// 不可动态循环
        /// </summary>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        /// <param name="listLineJoin">线条连接点</param>
        /// <param name="listLineCap">线条起始线帽</param>
        /// <param name="listDrawStyle">线条样式</param>
        public void f_AddPix(ref List<float> listX, ref List<float> listY, Color listColor, int listWidth, LineJoin listLineJoin, LineCap listLineCap, DrawStyle listDrawStyle)
        {
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(listLineJoin);
            _listLineCap.Add(listLineCap);
            _listDrawStyle.Add(listDrawStyle);
        }
        /// <summary>
        /// 在原有波形上添加一条线，显示样式为线条
        /// 不可动态循环
        /// </summary>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        public void f_AddPix(ref List<float> listX, ref List<float> listY, Color listColor, int listWidth)
        {
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(LineJoin.Bevel);
            _listLineCap.Add(LineCap.NoAnchor);
            _listDrawStyle.Add(DrawStyle.Line);
        }
        #endregion


    }
}
