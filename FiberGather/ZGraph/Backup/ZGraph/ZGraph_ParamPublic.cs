#region **引用**
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
#endregion


namespace ZhengJuyin.UI
{
    public partial class ZGraph : UserControl
    {
        /***************************************
         *  模块：公有属性
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
        #region **公有属性**
        /// <summary>
        /// 波形显示控件标题
        /// </summary>
        public string m_SyStitle
        {
            set { _SyStitle = value; }
            get { return _SyStitle; }
        }
        /// <summary>
        /// X轴名称
        /// </summary>
        public string m_SySnameX
        {
            set { _SySnameX = value; }
            get { return _SySnameX; }
        }
        /// <summary>
        /// Y轴名称
        /// </summary>
        public string m_SySnameY
        {
            set { _SySnameY = value; }
            get { return _SySnameY; }
        }
        /// <summary>
        /// 初始X轴起始坐标
        /// </summary>
        public float m_fXBeginSYS
        {
            set { _fXBeginSYS = value; }
            get { return _fXBeginSYS; }
        }
        /// <summary>
        /// 初始X轴结束坐标
        /// </summary>
        public float m_fXEndSYS
        {
            set { _fXEndSYS = value; }
            get { return _fXEndSYS; }
        }
        /// <summary>
        /// 初始Y轴起始坐标
        /// </summary>
        public float m_fYBeginSYS
        {
            set { _fYBeginSYS = value; }
            get { return _fYBeginSYS; }
        }
        /// <summary>
        /// 初始Y轴结束坐标
        /// </summary>
        public float m_fYEndSYS
        {
            set { _fYEndSYS = value; }
            get { return _fYEndSYS; }
        }
        #endregion
        
        
        #region **公有属性 控件外观样式**
        /*********************************************************
         * 
         * 波形显示控件外观样式方案
         * 
         * *******************************************************/
        /// <summary>
        /// 控件标题字体大小
        /// </summary>
        public int m_titleSize
        {
            set { _titleSize = value; }
            get { return _titleSize; }
        }
        /// <summary>
        /// 控件标题位置
        /// </summary>
        public float m_titlePosition
        {
            set { _titlePosition = value; }
            get { return _titlePosition; }
        }
        /// <summary>
        /// 控件标题颜色
        /// </summary>
        public Color m_titleColor
        {
            set { _titleColor = value; }
            get { return _titleColor; }
        }
        /// <summary>
        /// 控件标题描边颜色
        /// </summary>
        public Color m_titleBorderColor
        {
            set { _titleBorderColor = value; }
            get { return _titleBorderColor; }
        }
        /// <summary>
        /// 背景色渐进起始颜色
        /// </summary>
        public Color m_backColorL
        {
            set { _backColorL = value; }
            get { return _backColorL; }
        }
        /// <summary>
        /// 背景色渐进终止颜色
        /// </summary>
        public Color m_backColorH
        {
            set { _backColorH = value; }
            get { return _backColorH; }
        }
        /// <summary>
        /// 坐标线颜色
        /// </summary>
        public Color m_coordinateLineColor
        {
            set { _coordinateLineColor = value; }
            get { return _coordinateLineColor; }
        }
        /// <summary>
        /// 坐标值颜色
        /// </summary>
        public Color m_coordinateStringColor
        {
            set { _coordinateStringColor = value; }
            get { return _coordinateStringColor; }
        }
        /// <summary>
        /// 坐标标题颜色
        /// </summary>
        public Color m_coordinateStringTitleColor
        {
            set { _coordinateStringTitleColor = value; }
            get { return _coordinateStringTitleColor; }
        }
        /// <summary>
        /// 网格线的透明度
        /// </summary>
        public int m_iLineShowColorAlpha
        {
            set { _iLineShowColorAlpha = value; }
            get { return _iLineShowColorAlpha; }
        }
        /// <summary>
        /// 网格线的颜色
        /// </summary>
        public Color m_iLineShowColor
        {
            set { _iLineShowColor = value; }
            get { return _iLineShowColor; }
        }
        /// <summary>
        /// 波形显示区域背景色
        /// </summary>
        public Color m_GraphBackColor
        {
            set
            {
                _GraphBackColor = value;
                pictureBoxGraph.BackColor = _GraphBackColor;
            }
            get { return _GraphBackColor; }
        }
        /// <summary>
        /// 工具栏背景色
        /// </summary>
        public Color m_ControlItemBackColor
        {
            set 
            {
                ControlItemBackColor = value;
                panelControlItem.BackColor = ControlItemBackColor;
                buttonItemsDown.ForeColor = ControlItemBackColor;
                buttonControlItemUP.ForeColor = ControlItemBackColor;

            }
            get { return ControlItemBackColor; }
        }
        /// <summary>
        /// 工具栏按钮背景颜色
        /// </summary>
        public Color m_ControlButtonBackColor
        {
            set 
            {
                ControlButtonBackColor = value;
                buttonItemsDown.BackColor = ControlButtonBackColor;//Color.FromArgb(200, ControlButtonBackColor);
                buttonControlItemUP.BackColor = ControlButtonBackColor;//Color.FromArgb(200, ControlButtonBackColor);
                buttonLinesShowXY.BackColor = ControlButtonBackColor;
                buttonBigModeXY.BackColor = ControlButtonBackColor;
                buttonAutoModeXY.BackColor = ControlButtonBackColor;
                buttonReXY.BackColor = ControlButtonBackColor;
            }
            get { return ControlButtonBackColor; }
        }
        /// <summary>
        /// 工具栏按钮前景选中颜色
        /// </summary>
        public Color m_ControlButtonForeColorL
        {
            set { ControlButtonForeColorL = value; }
            get { return ControlButtonForeColorL; }
        }
        /// <summary>
        /// 工具栏按钮前景未选中颜色
        /// </summary>
        public Color m_ControlButtonForeColorH
        {
            set { ControlButtonForeColorH = value; }
            get { return ControlButtonForeColorH; }
        }
        /// <summary>
        /// 标签说明框背景颜色
        /// </summary>
        public Color m_DirectionBackColor
        {
            set {
                DirectionBackColor = value;
                labelItemShuoMing.BackColor = DirectionBackColor;
            }
            get { return DirectionBackColor; }
        }
        /// <summary>
        /// 标签说明框文字颜色
        /// </summary>
        public Color m_DirectionForeColor
        {
            set {
                DirectionForeColor = value;
                labelItemShuoMing.ForeColor = DirectionForeColor;
            }
            get { return DirectionForeColor; }
        }
        /// <summary>
        /// 放大选取框背景颜色
        /// </summary>
        public Color m_BigXYBackColor
        {
            set 
            {
                BigXYBackColor = value;
                pictureBoxBigXY.BackColor = Color.FromArgb(50, BigXYBackColor);
            }
            get { return BigXYBackColor; }
        }
        /// <summary>
        /// 放大选取框按钮背景颜色
        /// </summary>
        public Color m_BigXYButtonBackColor
        {
            set 
            {
                BigXYButtonBackColor = value;
                buttonBigXYBig.BackColor = BigXYButtonBackColor;
                buttonBigXYQuit.BackColor = BigXYButtonBackColor;
            }
            get { return BigXYButtonBackColor; }
        }
        /// <summary>
        /// 放大选取框按钮文字颜色
        /// </summary>
        public Color m_BigXYButtonForeColor
        {
            set 
            { 
                BigXYButtonForeColor = value;
                buttonBigXYBig.ForeColor = BigXYButtonForeColor;
                buttonBigXYQuit.ForeColor = BigXYButtonForeColor;

            }
            get { return BigXYButtonForeColor; }
        }
        #endregion


        /// <summary>
        /// 画图样式
        /// </summary>
        public enum DrawStyle
        {
            /// <summary>
            /// 线条
            /// </summary>
            Line,
            /// <summary>
            /// 点
            /// </summary>
            dot,
            /// <summary>
            /// 条形
            /// </summary>
            bar
        }
    }
}
