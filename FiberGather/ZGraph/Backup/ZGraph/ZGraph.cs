#region **引用**
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
#endregion

namespace ZhengJuyin.UI
{
    /// <summary>
    /// 波形显示控件
    /// 坐标最小差值：1.0
    /// </summary>
    public partial class ZGraph : UserControl
    {
        /***************************************
         *  模块：波形显示控件
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
        /// <summary>
        /// 构造
        /// 初始化坐标值，坐标标定值，坐标标定权值
        /// </summary>
        public ZGraph()
        {
            InitializeComponent();
            //初始化默认坐标值，坐标标定值和坐标标定权值
            _fXBegin = _fXBeginGO = _fXBeginSYS;
            _fYBegin = _fYBeginGO = _fYBeginSYS;
            _fXEnd = _fXEndGO = _fXEndSYS;
            _fYEnd = _fYEndGO = _fYEndSYS;
            _fXQuanBeginGO = _getQuan(_fXBeginGO);
            _fXQuanEndGO = _getQuan(_fXEndGO);
            _fYQuanBeginGO = _getQuan(_fYBeginGO);
            _fYQuanEndGO = _getQuan(_fYEndGO);

            //配色方案初始化

            //波形显示区域背景色
            pictureBoxGraph.BackColor = _GraphBackColor;
            //工具栏相关样式
            panelControlItem.BackColor = ControlItemBackColor;
            buttonItemsDown.ForeColor = ControlItemBackColor;
            buttonControlItemUP.ForeColor = ControlItemBackColor;
            //工具栏按钮相关样式
            buttonItemsDown.BackColor = ControlButtonBackColor;//Color.FromArgb(200, ControlButtonBackColor);
            buttonControlItemUP.BackColor = ControlButtonBackColor;//Color.FromArgb(200, ControlButtonBackColor);
            buttonLinesShowXY.BackColor = ControlButtonBackColor;
            buttonBigModeXY.BackColor = ControlButtonBackColor;
            buttonAutoModeXY.BackColor = ControlButtonBackColor;
            buttonReXY.BackColor = ControlButtonBackColor;
            //标签说明框样式
            labelItemShuoMing.BackColor = DirectionBackColor;
            labelItemShuoMing.ForeColor = DirectionForeColor;
            //放大选取框样式
            pictureBoxBigXY.BackColor = Color.FromArgb(50, BigXYBackColor);
            //放大选取框按钮样式
            buttonBigXYBig.BackColor = BigXYButtonBackColor;
            buttonBigXYQuit.BackColor = BigXYButtonBackColor;
            buttonBigXYBig.ForeColor = BigXYButtonForeColor;
            buttonBigXYQuit.ForeColor = BigXYButtonForeColor;
            //右键菜单样式
            MenuRightClick.BackColor = _backColorL;
            MenuRightClick.ForeColor = _coordinateStringTitleColor;
            toolStripTextBoxX.BackColor = toolStripTextBoxY.BackColor = _backColorL;
            toolStripTextBoxX.ForeColor = toolStripTextBoxY.ForeColor = _coordinateStringColor;
            
        }



    }
}
