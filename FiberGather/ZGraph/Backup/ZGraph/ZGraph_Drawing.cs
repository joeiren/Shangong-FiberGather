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
         *  模块：私有绘图方法
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

        #region **私有函数 波形显示区域Paint **
        private void pictureBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            #region **绘图参数初始化**
            int width = pictureBoxGraph.Width;
            int height = pictureBoxGraph.Height;
            Graphics Grap = e.Graphics;
            #endregion

            using (Pen pe = new Pen(Color.White, 1f))
            {
                #region **坐标轴零点变换，以左下角为零点，右上方为正绘图**
                Grap.TranslateTransform(0, pictureBoxGraph.Height - 1);
                Grap.ScaleTransform(1, -1);
                #endregion

                #region **根据画图模式和数据调整坐标显示**
                if (_isBigModeXY)
                {
                    //【放大模式】下坐标不自动调整，使用当前坐标范围修改标定权值和标定坐标范围
                    #region **更新标定坐标权值和标定坐标范围**
                    _fXQuanBeginGO = _getQuan(_fXBegin);
                    _fXQuanEndGO = _getQuan(_fXEnd);
                    _fYQuanBeginGO = _getQuan(_fYBegin);
                    _fYQuanEndGO = _getQuan(_fYEnd);
                    _changXBegionOrEndGO(_fXBegin, true);
                    _changXBegionOrEndGO(_fXEnd, false);
                    _changYBegionOrEndGO(_fYBegin, true);
                    _changYBegionOrEndGO(_fYEnd, false);
                    #endregion
                }
                else if (_isAutoModeXY)
                {
                    //【非放大模式】，且为【自动坐标模式】，则保证画图的点在图形中显示
                    #region **获取数据集合的最大坐标范围，并修改标定坐标范围和标定权值，并修改坐标范围**
                    //遍历每条数据集合
                    for (int i = 0; i < _listX.Count; i++)
                    {
                        //遍历数据集合中的每个点
                        for (int j = 0; j < _listX[i].Count; j++)
                        {
                            if (_listX[i][j] < _fXBegin)
                            {
                                _changXBegionOrEndGO(_listX[i][j], true);
                                _fXBegin = _fXBeginGO;
                            }
                            else if (_listX[i][j] > _fXEnd)
                            {
                                _changXBegionOrEndGO(_listX[i][j], false);
                                _fXEnd = _fXEndGO;
                            }
                            if (_listY[i][j] < _fYBegin)
                            {
                                _changYBegionOrEndGO(_listY[i][j], true);
                                _fYBegin = _fYBeginGO;
                            }
                            else if (_listY[i][j] > _fYEnd)
                            {
                                _changYBegionOrEndGO(_listY[i][j], false);
                                _fYEnd = _fYEndGO;
                            } 
                        }
                    }
                    #endregion
                }
                //更新坐标显示
                pictureBoxLeft.Refresh();
                pictureBoxBottom.Refresh();
                #endregion

                #region **网格显示设置**
                if (_isLinesShowXY)
                {
                    #region **画网格线**
                    #region **参数初始化**
                    Grap.SmoothingMode = SmoothingMode.None;
                    pe.Width = 1;
                    float i = _fXpxGO;  //临时 计数
                    #endregion
                    #region **画垂直网格**
                    #region **第三段**
                    pe.Color = Color.FromArgb(_iLineShowColorAlpha / 3, _iLineShowColor);   //画笔颜色
                    if (_fXLinesShowThird != 0)
                    {
                        if (_bXLinesLBegin)
                        {
                            while (i < width)
                            {
                                Grap.DrawLine(pe, i, 0, i, height);
                                i = i + _fXLinesShowThird;
                            }
                        }
                        else
                        {
                            while (i > 0)
                            {
                                Grap.DrawLine(pe, i, 0, i, height);
                                i = i - _fXLinesShowThird;
                            }
                        }
                    }
                    #endregion
                    #region **第二段**
                    pe.Color = Color.FromArgb(_iLineShowColorAlpha / 2, _iLineShowColor);   //画笔颜色
                    i = _fXpxGO;
                    if (_fXLinesShowSecond != 0)
                    {
                        if (_bXLinesLBegin)
                        {
                            while (i < width)
                            {
                                Grap.DrawLine(pe, i, 0, i, height);
                                i = i + _fXLinesShowSecond;
                            }
                        }
                        else
                        {
                            while (i > 0)
                            {
                                Grap.DrawLine(pe, i, 0, i, height);
                                i = i - _fXLinesShowSecond;
                            }
                        }
                    }
                    #endregion
                    #region **第一段**
                    pe.Color = Color.FromArgb(_iLineShowColorAlpha, _iLineShowColor);
                    i = _fXpxGO;
                    if (_bXLinesLBegin)
                    {
                        while (i < width)
                        {
                            Grap.DrawLine(pe, i, 0, i, height);
                            i = i + _fXLinesShowFirst;
                        }
                    }
                    else
                    {
                        while (i > 0)
                        {
                            Grap.DrawLine(pe, i, 0, i, height);
                            i = i - _fXLinesShowFirst;
                        }
                    }
                    #endregion
                    #endregion
                    #region **画水平网格**
                    #region **第三段**
                    pe.Color = Color.FromArgb(_iLineShowColorAlpha / 3, _iLineShowColor);   //画笔颜色
                    if (_fYLinesShowThird != 0)
                    {
                        if (_bYLinesLBegin)
                        {
                            i = height + 29 - _fYpxGO;
                            while (i < height)
                            {
                                Grap.DrawLine(pe, 0, i, width, i);
                                i = i + _fYLinesShowThird;
                            }
                        }
                        else
                        {
                            i = 29 - _fYpxGO + height;
                            while (i > 0)
                            {
                                Grap.DrawLine(pe, 0, i, width, i);
                                i = i - _fYLinesShowThird;
                            }
                        }
                    }
                    #endregion
                    #region **第二段**
                    pe.Color = Color.FromArgb(_iLineShowColorAlpha / 2, _iLineShowColor);   //画笔颜色
                    if (_fYLinesShowSecond != 0)
                    {
                        if (_bYLinesLBegin)
                        {
                            i = height + 29 - _fYpxGO;
                            while (i < height)
                            {
                                Grap.DrawLine(pe, 0, i, width, i);
                                i = i + _fYLinesShowSecond;
                            }
                        }
                        else
                        {
                            i = 29 - _fYpxGO + height;
                            while (i > 0)
                            {
                                Grap.DrawLine(pe, 0, i, width, i);
                                i = i - _fYLinesShowSecond;
                            }
                        }
                    }
                    #endregion
                    #region **第一段**
                    pe.Color = Color.FromArgb(_iLineShowColorAlpha, _iLineShowColor);   //画笔颜色
                    if (_bYLinesLBegin)
                    {
                        i = height + 29 - _fYpxGO;
                        while (i < height)
                        {
                            Grap.DrawLine(pe, 0, i, width, i);
                            i = i + _fYLinesShowFirst;
                        }
                    }
                    else
                    {
                        i = 29 - _fYpxGO + height;
                        while (i > 0)
                        {
                            Grap.DrawLine(pe, 0, i, width, i);
                            i = i - _fYLinesShowFirst;
                        }
                    }
                    #endregion

                    #endregion
                    #endregion
                }
                #endregion

                #region **画波形线条**
                #region **参数初始化**
                Grap.SmoothingMode = SmoothingMode.AntiAlias;
                #endregion

                #region **遍历每条线并画出**
                for (int i = 0; i < _listX.Count; i++)
                {
                    _listDrawPoints.Clear();
                    //装载坐标
                    if (!_changeToDrawPoints(i, ref _listDrawPoints, width, height))
                    {
                        continue;
                    }
                    //装载颜色
                    pe.Color = _listColor[i];
                    //装载宽度
                    pe.Width = _listWidth[i];
                    //装载连接点
                    pe.LineJoin = _listLineJoin[i];
                    //装载起始线帽
                    pe.StartCap = _listLineCap[i];
                    try
                    {
                        if (_listDrawStyle[i] == DrawStyle.Line)
                        {
                            //绘制线
                            if (_listDrawPoints.Count == 1)
                                continue;
                            pe.LineJoin = LineJoin.Bevel;   //设置线条连接点样式，防止线宽在大于1的情况下导致的转折点不精确的问题
                            Grap.DrawLines(pe, _listDrawPoints.ToArray());
                        }
                        else if (_listDrawStyle[i] == DrawStyle.dot)
                        {
                            //绘制方形点
                            foreach (PointF points in _listDrawPoints)
                            {
                                Grap.DrawRectangle(pe, points.X, points.Y, 1, 1);
                            }
                        }
                        else
                        {
                            //绘制条形线
                            foreach (PointF points in _listDrawPoints)
                            {
                                Grap.DrawLine(pe, points.X, points.Y, points.X, 0);
                            }
                        }
                    }
                    catch(Exception)
                    {
                        //发生数据溢出错误
                    }
                }
                #endregion
                #endregion
            }
        }
        #endregion

        #region **私有函数 X轴区域Paint **
        private void pictureBoxBottom_Paint(object sender, PaintEventArgs e)
        {
            //左右留空50px，高45px
            #region **参数初始化**
            int width = pictureBoxBottom.Width;
            int height = pictureBoxBottom.Height;
            float linesQuan;                            //获得两权的大值
            float linesNum;                             //可以分成的线段
            float pxLine;                               //每段坐标线间隔
            float pxwidth;                              //所要画坐标的像素范围
            float pxGO;                                 //所要画坐标的起点像素位置
            int currentI;                               //临时，循环用变量
            float currentDraw;                          //临时，循环用变量，画坐标线和坐标值
            decimal showTextT;                          //要显示的坐标值，decimal能够精确显示坐标值
            float width50 = width - 50;                 //临时变量，为提高计算效率
            Graphics Grap = e.Graphics;
            #endregion

            using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, width, height),
                _backColorL, _backColorH, 90, false))
            using (Pen pe = new Pen(_coordinateLineColor, 2f))
            using (SolidBrush brushString = new SolidBrush(_coordinateStringColor))
            using (StringFormat format = new StringFormat())
            using (Font fo = new Font("宋体", 9))
            {
                #region **画背景色**
                Grap.FillRectangle(brush, e.ClipRectangle);
                #endregion

                #region **画坐标**
                //根据标定坐标权值判断画坐标的方向，从权值大的方向开始画
                if (_fXQuanBeginGO <= _fXQuanEndGO)
                {
                    //从右往左画

                    #region **参数初始化**
                    format.LineAlignment = StringAlignment.Near;    //文字垂直上对齐
                    format.Alignment = StringAlignment.Center;      //文字水平居中对齐
                    _bXLinesLBegin = false;                                                 //标记【X轴网格线从右往左画】
                    linesQuan = _fXQuanEndGO;                                                   //画图权值为X轴坐标标定结束权值
                    linesNum = (_fXEndGO - _fXBeginGO) / linesQuan;                             //当前权值下可分为多少段坐标
                    pxwidth = (float)(width - 100) / (_fXBegin - _fXEnd) * (_fXBeginGO - _fXEndGO);         //所要画坐标的像素范围
                    pxLine = pxwidth / linesNum;                                                //每段坐标线间隔
                    _fXLinesShowFirst = pxLine;                                             //标记【X轴第一层网格线间隔】
                    pxGO = (_fXEndGO - _fXBegin) / (_fXEnd - _fXBegin) * (width - 100) + 50;    //所要画坐标的起点像素位置
                    _fXpxGO = pxGO - 51;                                                    //标记【所要画X轴坐标的起点像素位置】
                    #endregion

                    #region **第一层坐标**
                    if (pxLine <= 250)  //若间距够画第二层坐标并显示坐标值的话，就不需要话第一层坐标
                    {
                        //开始画第一层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fXEndGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 6);                                  //画坐标线
                                Grap.DrawString(showTextT.ToString(), fo, brushString, currentDraw, 6, format);     //画坐标值
                            }
                            showTextT -= (decimal)linesQuan;    //更新要画的坐标值
                            currentDraw -= pxLine;              //更新坐标线和坐标值的位置
                        }
                    }
                    #endregion

                    #region **第二层坐标**
                    //第二层坐标,第一层坐标的基础上5等分，前提是间距大于10px，若间距大于50px则显示坐标值
                    if (pxLine > 250)
                    {
                        #region **参数初始化**
                        pe.Width = 2f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fXLinesShowSecond = pxLine;    //标记【X轴第二层网格线间隔】
                        #endregion
                        //开始画第二层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fXEndGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 6);  //画坐标线
                                Grap.DrawString(showTextT.ToString(), fo, brushString, currentDraw, 6, format); //画坐标值
                            }
                            showTextT -= (decimal)linesQuan;
                            currentDraw -= pxLine;
                        }
                    }
                    else if (pxLine > 50)
                    {
                        #region **参数初始化**
                        pe.Width = 2f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fXLinesShowSecond = pxLine;    //标记【X轴第二层网格线间隔】
                        #endregion
                        //开始画第二层坐标，不显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fXEndGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 6);  //画坐标线
                            }
                            currentDraw -= pxLine;
                        }
                    }
                    else
                    {
                        //标记第二层和第三层间隔
                        _fXLinesShowSecond = 0;
                        _fXLinesShowThird = 0;
                    }
                    #endregion

                    #region **第三层坐标**
                    //第三层坐标,第二层坐标的基础上5等分，前提是间距大于10px
                    if (pxLine > 50)
                    {
                        #region **参数初始化**
                        pe.Width = 1f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fXLinesShowThird = pxLine; //标记【X轴第三层网格线间隔】
                        #endregion
                        //开始画第三层坐标，不显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fXEndGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 5);  //画坐标线
                            }
                            currentDraw -= pxLine;
                        }
                    }
                    else if (pxLine > 20)   //不满足则2等分，前提是间距大于10px
                    {
                        #region **参数初始化**
                        pe.Width = 1f;
                        linesQuan = linesQuan / 2f;
                        linesNum = linesNum * 2f;
                        pxLine = pxLine / 2f;
                        _fXLinesShowThird = pxLine;     //标记【X轴第三层网格线间隔】
                        #endregion
                        //开始画第三层坐标，不显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fXEndGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 5);  //画坐标线
                            }
                            currentDraw -= pxLine;
                        }
                    }
                    else
                    {
                        //标记第三层间隔
                        _fXLinesShowThird = 0;
                    }
                    #endregion
                }
                else
                {
                    //从左往右画

                    #region **参数初始化**
                    format.LineAlignment = StringAlignment.Near;    //文字垂直上对齐
                    format.Alignment = StringAlignment.Center;      //文字水平居中对齐
                    _bXLinesLBegin = true;                                                  //标记【X轴网格线从左往右画】
                    linesQuan = _fXQuanBeginGO;                                                     //画图权值为X轴坐标标定起始权值
                    linesNum = (_fXEndGO - _fXBeginGO) / linesQuan;                                 //当前权值下可为为多少段坐标
                    pxwidth = (float)(width - 100) / (_fXBegin - _fXEnd) * (_fXBeginGO - _fXEndGO); //所要画坐标的像素范围
                    pxLine = pxwidth / linesNum;                                                    //每段坐标线间隔
                    _fXLinesShowFirst = pxLine;                                             //标记【X轴第一层网格线间隔】
                    pxGO = 50 - (_fXBegin - _fXBeginGO) / (_fXEnd - _fXBegin) * (width - 100);      //所要画坐标的起点像素位置
                    _fXpxGO = pxGO - 51;                                                    //标记【所要画X轴坐标的起点像素位置】
                    #endregion

                    #region **第一层坐标**
                    if (pxLine <= 250)  //若间距够画第二层坐标并显示坐标值的话，就不需要话第一层坐标
                    {
                        //开始画第一层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fXBeginGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 6);                                  //画坐标线
                                Grap.DrawString(showTextT.ToString(), fo, brushString, currentDraw, 6, format);     //画坐标值
                            }
                            showTextT += (decimal)linesQuan;    //更新要画的坐标值
                            currentDraw += pxLine;              //更新坐标线和坐标值的位置
                        }
                    }
                    #endregion

                    #region **第二层坐标**
                    //第二层坐标,第一层坐标的基础上5等分，前提是间距大于10px，若间距大于50px则显示坐标值
                    if (pxLine > 250)
                    {
                        #region **参数初始化**
                        pe.Width = 2f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fXLinesShowSecond = pxLine;    //标记【X轴第二层网格线间隔】
                        #endregion
                        //开始画第二层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fXBeginGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 6);  //画坐标线
                                Grap.DrawString(showTextT.ToString(), fo, brushString, currentDraw, 6, format); //画坐标值
                            }
                            showTextT += (decimal)linesQuan;
                            currentDraw += pxLine;
                        }
                    }
                    else if (pxLine > 50)
                    {
                        #region **参数初始化**
                        pe.Width = 2f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fXLinesShowSecond = pxLine;    //标记【X轴第二层网格线间隔】
                        #endregion
                        //开始画第二层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 6);  //画坐标线
                            }
                            currentDraw += pxLine;
                        }
                    }
                    else
                    {
                        //标记第二层和第三层间隔
                        _fXLinesShowSecond = 0;
                        _fXLinesShowThird = 0;
                    }
                    #endregion

                    #region **第三层坐标**
                    //第三层坐标,第二层坐标的基础上5等分，前提是间距大于10px
                    if (pxLine > 50)
                    {
                        #region **参数初始化**
                        pe.Width = 1f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fXLinesShowThird = pxLine;     //标记【X轴第三层网格线间隔】
                        #endregion
                        //开始画第三层坐标，不显示坐标值
                        currentI = (int)linesNum + 1;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 5);  //画坐标线
                            }
                            currentDraw += pxLine;
                        }
                    }
                    else if (pxLine > 20)   //不满足则2等分，前提是间距大于10px
                    {
                        #region **参数初始化**
                        pe.Width = 1f;
                        linesQuan = linesQuan / 2f;
                        linesNum = linesNum * 2f;
                        pxLine = pxLine / 2f;
                        _fXLinesShowThird = pxLine;     //标记【X轴第三层网格线间隔】
                        #endregion
                        //开始画第三层坐标，不显示坐标值
                        currentI = (int)linesNum + 1;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 50 && currentDraw < width50)
                            {
                                Grap.DrawLine(pe, currentDraw, 0, currentDraw, 5);  //画坐标线
                            }
                            currentDraw += pxLine;
                        }
                    }
                    else
                    {
                        //标记第三层间隔
                        _fXLinesShowThird = 0;
                    }
                    #endregion
                }
                #endregion

                #region **画两端基本坐标**
                pe.Width = 2;               //画笔线宽
                Grap.FillRectangle(brush, 28, 8, 46, 16);           //坐标背景色，用于遮盖
                Grap.FillRectangle(brush, width - 63, 8, 50, 16);   //坐标背景色，用于遮盖
                Grap.DrawLine(pe, 50, 0, 50, 10);                                               //X轴起始坐标线条
                Grap.DrawString(string.Format("{0}", Math.Round(_fXBegin, _iAccuracy)), fo, brushString, 51, 10, format);                      //X轴起始坐标值
                format.Alignment = StringAlignment.Near;      //文字水平居左对齐
                Grap.DrawLine(pe, width - 50, 0, width - 50, 10);                               //X轴结束坐标线条
                Grap.DrawString(string.Format("{0}", Math.Round(_fXEnd, _iAccuracy)).ToString(), fo, brushString, width - 60, 10, format);     //X轴结束坐标值
                #endregion

                #region **画X轴标签**
                brushString.Color = _coordinateStringTitleColor;
                Grap.DrawString(_SySnameX, fo, brushString, width / 2, 21, format);
                #endregion
            }
        }
        #endregion

        #region **私有函数 Y轴区域Paint **
        private void pictureBoxLeft_Paint(object sender, PaintEventArgs e)
        {
            #region **参数初始化**
            int width = pictureBoxLeft.Width;
            int height = pictureBoxLeft.Height;
            float linesQuan;                            //获得两权的大值
            float linesNum;                             //可以分成的线段
            float pxLine;                               //每段坐标线间隔
            float pxwidth;                              //所要画坐标的像素范围
            float pxGO;                                 //所要画坐标的起点像素位置
            int currentI;                               //临时，循环用变量
            float currentDraw;                          //临时，循环用变量，画坐标线和坐标值
            decimal showTextT;                          //要显示的坐标值，decimal能够精确显示坐标值
            Graphics Grap = e.Graphics;
            #endregion

            using (SolidBrush brush = new SolidBrush(_backColorL))
            using (Pen pe = new Pen(_coordinateLineColor, 2f))
            using (SolidBrush brushString = new SolidBrush(_coordinateStringColor))
            using (StringFormat format = new StringFormat())
            using (Font fo = new Font("宋体", 9))
            {
                #region **画背景色**
                Grap.FillRectangle(brush, e.ClipRectangle);
                #endregion

                #region **画坐标**
                //根据标定坐标权值判断画坐标的方向，从权大的方向开始画
                if (_fYQuanBeginGO <= _fYQuanEndGO)
                {
                    //从上往下画

                    #region **参数初始化**
                    format.Alignment = StringAlignment.Far;         //文字右对齐
                    format.LineAlignment = StringAlignment.Center;  //文字垂直居中对齐
                    _bYLinesLBegin = false;                                                         //标记【Y轴网格线从上往下画】
                    linesQuan = _fYQuanEndGO;                                                               //画图权值为Y轴坐标标定结束权值
                    linesNum = (_fYEndGO - _fYBeginGO) / linesQuan;                                         //当前权值下可为为多少段坐标
                    pxwidth = (float)(height - 30) / (_fYBegin - _fYEnd) * (_fYBeginGO - _fYEndGO);         //所要画坐标的像素范围
                    pxLine = pxwidth / linesNum;                                                            //每段坐标线间隔
                    _fYLinesShowFirst = pxLine;                                                     //标记【Y轴第一层网格线间隔】
                    pxGO = 30 - (_fYEnd - _fYEndGO) / (_fYBegin - _fYEnd) * (height - 30);                  //所要画坐标的起点像素位置
                    _fYpxGO = pxGO;                                                                 //标记【所要画Y轴坐标的起点像素位置】
                    #endregion

                    #region **第一层坐标**
                    if (pxLine <= 150)  //若间距够画第二层坐标并显示坐标值的话，就不需要话第一层坐标
                    {
                        //开始画第一层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fYEndGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);     //画坐标线
                                Grap.DrawString(showTextT.ToString(), fo, brushString, 44, currentDraw, format);    //画坐标值
                            }
                            showTextT -= (decimal)linesQuan;    //更新要画的坐标值
                            currentDraw += pxLine;              //更新坐标线和坐标值的位置
                        }
                    }
                    #endregion

                    #region **第二层坐标**
                    //第二层坐标,第一层坐标的基础上5等分，前提是间距大于10px，若间距大于30px则显示坐标值
                    if (pxLine > 150)
                    {
                        #region **参数初始化**
                        pe.Width = 2f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fYLinesShowSecond = pxLine;    //标记【Y轴第二层网格线间隔】
                        #endregion
                        //开始画第二层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fYEndGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);    //画坐标线
                                Grap.DrawString(showTextT.ToString(), fo, brushString, 44, currentDraw, format);    //画坐标值
                            }
                            showTextT -= (decimal)linesQuan;
                            currentDraw += pxLine;
                        }
                    }
                    else if (pxLine > 50)
                    {
                        #region **参数初始化**
                        pe.Width = 2f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fYLinesShowSecond = pxLine;    //标记【Y轴第二层网格线间隔】
                        #endregion
                        //开始画第二层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);    //画坐标线
                            }
                            currentDraw += pxLine;
                        }
                    }
                    else
                    {
                        //标记第二层和第三层间隔
                        _fYLinesShowSecond = 0;
                        _fYLinesShowThird = 0;
                    }
                    #endregion

                    #region **第三层坐标**
                    //第三层坐标,第二层坐标的基础上5等分，前提是间距大于10px
                    if (pxLine > 50)
                    {
                        #region **参数初始化**
                        pe.Width = 1f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fYLinesShowThird = pxLine; //标记【Y轴第三层网格线间隔】
                        #endregion
                        //开始画第三层坐标，不显示坐标值
                        currentI = (int)linesNum + 1;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);    //画坐标线
                            }
                            currentDraw += pxLine;
                        }
                    }
                    else if (pxLine > 20)   //不满足则2等分，前提是间距大于10px
                    {
                        #region **参数初始化**
                        pe.Width = 1f;
                        linesQuan = linesQuan / 2f;
                        linesNum = linesNum * 2f;
                        pxLine = pxLine / 2f;
                        _fYLinesShowThird = pxLine; //标记【Y轴第三层网格线间隔】
                        #endregion
                        //开始画第三层坐标，不显示坐标值
                        currentI = (int)linesNum + 1;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);    //画坐标线
                            }
                            currentDraw += pxLine;
                        }
                    }
                    else
                    {
                        //标记第三层间隔
                        _fYLinesShowThird = 0;
                    }
                    #endregion
                }
                else
                {
                    //从下往上画

                    #region **参数初始化**
                    format.Alignment = StringAlignment.Far;         //文字右对齐
                    format.LineAlignment = StringAlignment.Center;  //文字垂直居中对齐
                    _bYLinesLBegin = true;                                                          //标记【Y轴网格线从下往上画】
                    linesQuan = _fYQuanBeginGO;                                                             //画图权值为Y轴坐标标定起始权值
                    linesNum = (_fYEndGO - _fYBeginGO) / linesQuan;                                         //当前权值下可为为多少段坐标
                    pxwidth = (float)(height - 30) / (_fYBegin - _fYEnd) * (_fYBeginGO - _fYEndGO);         //所要画坐标的像素范围
                    pxLine = pxwidth / linesNum;                                                            //每段坐标线间隔
                    _fYLinesShowFirst = pxLine;                                                     //标记【Y轴第一层网格线间隔】
                    pxGO = (_fYBeginGO - _fYEnd) / (_fYBegin - _fYEnd) * (height - 30) + 30;                //所要画坐标的起点像素位置
                    _fYpxGO = pxGO;                                                                 //标记【所要画Y轴坐标的起点像素位置】
                    #endregion

                    #region **第一层坐标**
                    if (pxLine <= 150)  //若间距够画第二层坐标并显示坐标值的话，就不需要话第一层坐标
                    {
                        //开始画第一层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fYBeginGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);    //画坐标线
                                Grap.DrawString(showTextT.ToString(), fo, brushString, 44, currentDraw, format);    //画坐标值
                            }
                            showTextT += (decimal)linesQuan;    //更新要画的坐标值
                            currentDraw -= pxLine;              //更新坐标线和坐标值的位置
                        }
                    }
                    #endregion

                    #region **第二层坐标**
                    //第二层坐标,第一层坐标的基础上5等分，前提是间距大于10px，若间距大于30px则显示坐标值
                    if (pxLine > 150)
                    {
                        #region **参数初始化**
                        pe.Width = 2f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fYLinesShowSecond = pxLine;    //标记【Y轴第二层网格线间隔】
                        #endregion
                        //开始画第二层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        showTextT = (decimal)_fYBeginGO;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);    //画坐标线
                                Grap.DrawString(showTextT.ToString(), fo, brushString, 44, currentDraw, format);    //画坐标值
                            }
                            showTextT += (decimal)linesQuan;
                            currentDraw -= pxLine;
                        }
                    }
                    else if (pxLine > 50)
                    {
                        #region **参数初始化**
                        pe.Width = 2f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fYLinesShowSecond = pxLine;    //标记【Y轴第二层网格线间隔】
                        #endregion
                        //开始画第二层坐标，显示坐标值
                        currentI = (int)linesNum + 1;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);    //画坐标线
                            }
                            currentDraw -= pxLine;
                        }
                    }
                    else
                    {
                        //标记第二层和第三层间隔
                        _fYLinesShowSecond = 0;
                        _fYLinesShowThird = 0;
                    }
                    #endregion

                    #region **第三层坐标**
                    //第三层坐标,第二层坐标的基础上5等分，前提是间距大于10px
                    if (pxLine > 50)
                    {
                        #region **参数初始化**
                        pe.Width = 1f;
                        linesQuan = linesQuan / 5f;
                        linesNum = linesNum * 5f;
                        pxLine = pxLine / 5f;
                        _fYLinesShowThird = pxLine; //标记【Y轴第三层网格线间隔】
                        #endregion
                        //开始画第三层坐标，不显示坐标值
                        currentI = (int)linesNum + 1;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);    //画坐标线
                            }
                            currentDraw -= pxLine;
                        }
                    }
                    else if (pxLine > 20)   //不满足则2等分，前提是间距大于10px
                    {
                        #region **参数初始化**
                        pe.Width = 1f;
                        linesQuan = linesQuan / 2f;
                        linesNum = linesNum * 2f;
                        pxLine = pxLine / 2f;
                        _fYLinesShowThird = pxLine; //标记【Y轴第三层网格线间隔】
                        #endregion
                        //开始画第三层坐标，不显示坐标值
                        currentI = (int)linesNum + 1;
                        currentDraw = pxGO;
                        for (int i = 0; i < currentI; i++)
                        {
                            if (currentDraw > 30 && currentDraw < height)
                            {
                                Grap.DrawLine(pe, 44, currentDraw, 50, currentDraw);    //画坐标线
                            }
                            currentDraw -= pxLine;
                        }
                    }
                    else
                    {
                        //标记第三层间隔
                        _fYLinesShowThird = 0;
                    }
                    #endregion
                }
                #endregion

                #region **画两端基本坐标**
                format.Alignment = StringAlignment.Center;      //文字右对齐
                format.LineAlignment = StringAlignment.Far;     //文字下对齐
                pe.Width = 2;                   //画笔线宽
                Grap.FillRectangle(brush, 5, height - 17, 45, 16);  //坐标背景色，用于遮盖
                Grap.FillRectangle(brush, 5, 15, 45, 16);          //坐标背景色，用于遮盖
                Grap.DrawLine(pe, 26, height - 1, 50, height - 1);                                  //Y轴起始坐标线条
                Grap.DrawString(string.Format("{0}", Math.Round(_fYBegin, _iAccuracy)), fo, brushString, 26, height - 2, format);    //Y轴起始坐标值
                Grap.DrawLine(pe, 26, 31, 50, 31);                                                  //Y轴结束坐标线条
                Grap.DrawString(string.Format("{0}", Math.Round(_fYEnd, _iAccuracy)), fo, brushString, 26, 29, format);              //Y轴结束坐标值
                #endregion

            }
        }
        #endregion

        #region **私有函数 TOP区域Paint **
        private void pictureBoxTop_Paint(object sender, PaintEventArgs e)
        {
            #region **参数初始化**
            int width = pictureBoxTop.Width;
            int height = pictureBoxTop.Height;
            Graphics Grap = e.Graphics;
            #endregion

            using (SolidBrush brush = new SolidBrush(_backColorL))
            using (StringFormat format = new StringFormat())
            using (Font fo = new Font("宋体", 9))
            using (Font foTitle = new Font("宋体", _titleSize, FontStyle.Bold))
            {
                #region **画背景色**
                Grap.FillRectangle(brush, e.ClipRectangle);
                #endregion

                #region **画Y轴标签**
                format.LineAlignment = StringAlignment.Far;     //文字垂直下对齐
                format.Alignment = StringAlignment.Near;        //文字水平左对齐
                brush.Color = _coordinateStringTitleColor;
                Grap.DrawString(_SySnameY, fo, brush, 0, height - 3, format);   //画Y轴标签
                #endregion

                #region **画标题**
                brush.Color = _titleBorderColor;
                Grap.DrawString(_SyStitle, foTitle, brush, pictureBoxTop.Width * _titlePosition+1, height+1, format);
                Grap.DrawString(_SyStitle, foTitle, brush, pictureBoxTop.Width * _titlePosition-1, height-1, format);
                brush.Color = _titleColor;
                Grap.DrawString(_SyStitle, foTitle, brush, pictureBoxTop.Width * _titlePosition, height, format);
                #endregion
            }
        }
        #endregion

        #region **私有函数 Right区域Paint **
        private void pictureBoxRight_Paint(object sender, PaintEventArgs e)
        {
            #region **参数初始化**
            int width = pictureBoxRight.Width;
            int height = pictureBoxRight.Height;
            Graphics Grap = e.Graphics;
            #endregion

            using (SolidBrush brush = new SolidBrush(_backColorL))
            {
                #region **画背景色**
                Grap.FillRectangle(brush, e.ClipRectangle);
                #endregion
            }
        }
        #endregion

        #region **私有函数 波形显示控件大小改变时候触发**
        private void ZGraph_Resize(object sender, EventArgs e)
        {
            #region **放大框隐藏 更新相关联的标记和状态**
            pictureBoxBigXY.Visible = false;    //隐藏[波形放大框]
            panelBigXY.Visible = false;         //隐藏[波形放大操作框]
            _isShowBigSmallModeXY = false;
            放大选取框功能ToolStripMenuItem.Checked = false;
            pictureBoxGraph.Cursor = Cursors.Arrow;         //箭头光标
            #endregion
            //刷新界面 
            pictureBoxGraph.Refresh();
            pictureBoxTop.Refresh();
            panelItemsIN.Refresh();
        }
        #endregion
    }
}
