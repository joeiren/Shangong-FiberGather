#region **引用**
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
#endregion


namespace ZhengJuyin.UI
{
    public partial class ZGraph : UserControl
    {
        /***************************************
         *  模块：私有数据成员
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
         *  设计时间：2009-9-26~2009-9-29
         * ************************************/

        #region ** 私有成员 波形显示控件基本成员 **
        /**************************************************************
         * 
         * 波形显示控件基本成员
         * 
         * *************************************************************/
        /// <summary>
        /// 波形显示控件标题
        /// </summary>
        private string _SyStitle = "波形显示";  //公开
        /// <summary>
        /// X轴名称
        /// </summary>
        private string _SySnameX = "X轴坐标";   //公开
        /// <summary>
        /// Y轴名称
        /// </summary>
        private string _SySnameY = "Y轴坐标";   //公开
        /// <summary>
        /// 当前坐标是否自动调整以适合窗口大小
        /// </summary>
        private bool _isAutoModeXY = true;
        /// <summary>
        /// 当前是否处于放大查看模式
        /// </summary>
        private bool _isBigModeXY = false;
        /// <summary>
        /// 当前是否显示网格
        /// </summary>
        private bool _isLinesShowXY = true;
        /// <summary>
        /// 当前是否允许放大缩小选取框显示
        /// </summary>
        private bool _isShowBigSmallModeXY = false;
        /// <summary>
        /// 坐标精确度
        /// </summary>
        private float _fAccuracy = 0.05f;
        /// <summary>
        /// 坐标显示最多小数位数
        /// </summary>
        private int _iAccuracy = 2;
        #endregion


        #region ** 私有成员 波形显示控件数据相关 **
        /************************************************************
         * 
         * 波形显示控件数据相关
         * 
         * *********************************************************/
        /// <summary>
        /// 要显示的数据集合的X轴方向值集合的引用
        /// 若显示多条数据则依次添加X轴方向值集合的引用
        /// </summary>
        private List<List<float>> _listX = new List<List<float>>();
        /// <summary>
        /// 要显示的数据集合的Y轴方向值集合的引用
        /// 若显示多条数据则依次添加Y轴方向值集合的引用
        /// </summary>
        private List<List<float>> _listY = new List<List<float>>();
        /// <summary>
        /// 要显示数据集合的线条颜色
        /// </summary>
        private List<Color> _listColor = new List<Color>();
        /// <summary>
        /// 要显示数据集合的线条宽度
        /// </summary>
        private List<int> _listWidth = new List<int>();
        /// <summary>
        /// 要显示数据集合的连接点
        /// </summary>
        private List<LineJoin> _listLineJoin = new List<LineJoin>();
        /// <summary>
        /// 要显示数据集合的起始线帽
        /// </summary>
        private List<LineCap> _listLineCap = new List<LineCap>();
        /// <summary>
        /// 要显示数据集合的样式
        /// </summary>
        private List<DrawStyle> _listDrawStyle = new List<DrawStyle>();
        #endregion


        #region ** 私有成员 波形显示控件坐标相关 **
        /******************************************************************
         * 
         * 波形显示控件坐标相关
         * 
         * ****************************************************************/
        // 初始坐标
        private float _fXBeginSYS = 0f;     //公开
        private float _fXEndSYS = 60f;      //公开
        private float _fYBeginSYS = 0f;     //公开
        private float _fYEndSYS = 1f;       //公开

        // 当前要画的线的像素坐标
        private List<PointF> _listDrawPoints = new List<PointF>();

        // 当前显示波形的X轴起始坐标值
        private float _fXBegin;
        // 当前显示波形的X轴结束坐标值
        private float _fXEnd;
        // 当前显示波形的Y轴起始坐标值
        private float _fYBegin;
        // 当前显示波形的Y轴结束坐标值
        private float _fYEnd;

        // 当前显示波形的X轴坐标标定起始值
        private float _fXBeginGO;
        // 当前显示波形的X轴坐标标定结束值
        private float _fXEndGO;
        // 当前显示波形的Y轴坐标标定起始值
        private float _fYBeginGO;
        // 当前显示波形的Y轴坐标标定结束值
        private float _fYEndGO;

        // 当前显示波形的X轴坐标标定起始权值
        private float _fXQuanBeginGO;
        // 当前显示波形的X轴坐标标定结束权值
        private float _fXQuanEndGO;
        // 当前显示波形的Y轴坐标标定起始权值
        private float _fYQuanBeginGO;
        // 当前显示波形的Y轴坐标标定结束权值
        private float _fYQuanEndGO;
        #endregion


        #region ** 私有成员 波形显示控件网格相关 **
        /*********************************************************
         * 
         * 波形显示控件网格相关
         * 
         * *******************************************************/
        // X轴网格线是否从左开始画
        private bool _bXLinesLBegin;
        // Y轴网格线是否从下开始画
        private bool _bYLinesLBegin;
        // 所要画X轴坐标的起点像素位置
        private float _fXpxGO;
        // 所要画Y轴坐标的起点像素位置
        private float _fYpxGO;
        // X轴第一层网格线间隔
        private float _fXLinesShowFirst = 0;
        // X轴第二层网格线间隔
        private float _fXLinesShowSecond = 0;
        // X轴第三层网格线间隔
        private float _fXLinesShowThird = 0;
        // Y轴第一层网格线间隔
        private float _fYLinesShowFirst = 0;
        // Y轴第二层网格线间隔
        private float _fYLinesShowSecond = 0;
        // Y轴第三层网格线间隔
        private float _fYLinesShowThird = 0;
        #endregion


        #region ** 私有成员 波形显示控件外观样式方案 **
        /*********************************************************
         * 
         * 波形显示控件外观样式方案
         * 
         * *******************************************************/
        //控件标题字体大小
        private int _titleSize = 14;
        //控件标题位置
        private float _titlePosition = 0.4f;
        //控件标题颜色
        private Color _titleColor = Color.FromArgb(0, 0, 0);
        //控件标题描边颜色
        private Color _titleBorderColor = Color.FromArgb(250, 250, 250);

        //背景色渐进起始颜色
        private Color _backColorL = Color.FromArgb(255, 255, 255);
        //背景色渐进终止颜色
        private Color _backColorH = Color.FromArgb(200, 200, 200);

        //坐标线颜色
        private Color _coordinateLineColor = Color.FromArgb(0, 0, 0);
        //坐标值颜色
        private Color _coordinateStringColor = Color.FromArgb(0, 0, 0);
        //坐标标题颜色
        private Color _coordinateStringTitleColor = Color.FromArgb(0, 0, 0);

        //网格线的透明度
        private int _iLineShowColorAlpha = 100;
        //网格线的颜色
        private Color _iLineShowColor = Color.FromArgb(255, 255, 255);

        //波形显示区域背景色
        private Color _GraphBackColor = Color.FromArgb(0, 0, 0);

        //工具栏背景色
        private Color ControlItemBackColor = Color.FromArgb(0, 0, 0);
        //工具栏按钮背景颜色
        private Color ControlButtonBackColor = Color.FromArgb(0, 0, 0);
        //工具栏按钮前景选中颜色
        private Color ControlButtonForeColorL = Color.FromArgb(250, 250, 250);
        //工具栏按钮前景未选中颜色
        private Color ControlButtonForeColorH = Color.FromArgb(100, 100, 100);

        //标签说明框背景颜色
        private Color DirectionBackColor = Color.FromArgb(32, 32, 32);
        //标签说明框文字颜色
        private Color DirectionForeColor = Color.FromArgb(255, 255, 255);

        //放大选取框背景颜色
        private Color BigXYBackColor = Color.FromArgb(255, 255, 255);
        //放大选取框按钮背景颜色
        private Color BigXYButtonBackColor = Color.FromArgb(200,255, 255, 255);
        //放大选取框按钮文字颜色
        private Color BigXYButtonForeColor = Color.FromArgb(0, 0, 0);
        #endregion
    }
}
