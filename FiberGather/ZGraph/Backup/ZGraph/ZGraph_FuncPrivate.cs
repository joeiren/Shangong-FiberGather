using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace ZhengJuyin.UI
{
    public partial class ZGraph : UserControl
    {
        /***************************************
         *  模块：私有辅助计算方法
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

        #region **私有方法 计算一个浮点数的权值 _getQuan(m:float):float **
        /// <summary>
        /// 计算一个浮点数的权值
        /// 如234.53返回100
        /// </summary>
        /// <param name="m">要计算权值的浮点数</param>
        /// <returns>权值</returns>
        private float _getQuan(float m)
        {
            float quan = 1f;        //临时，权值
            m = (m < 0) ? -m : m;   //取绝对值
            if (m == 0)
            {
                return 1f;          //默认0的权值为1
            }
            else if (m < 1)
            {
                do { quan /= 10f; }
                while ((m = m * 10f) < 1);
                return quan;
            }
            else
            {
                while ((m /= 10f) >= 1) { quan *= 10f; }
                return quan;
            }
        }
        #endregion

        #region **私有方法 根据溢出坐标范围的浮点数，改变X轴的坐标标定权值和坐标标定值 _changXBegionOrEndGO(m:float,isL:bool):void **
        /// <summary>
        /// 根据溢出坐标范围的浮点数，改变X轴的坐标标定权值和坐标标定值
        /// </summary>
        /// <param name="m">溢出坐标范围的浮点数</param>
        /// <param name="isL">是否从左边溢出</param>
        private void _changXBegionOrEndGO(float m, bool isL)
        {
            float quan = _getQuan(m);   //获得该溢出数的权值
            if (isL)
            {
                //如果值是从左边溢出
                #region **修改权值存入标定权值,控制权差在10倍以内**
                if (quan < _fXQuanEndGO)
                {
                    _fXQuanBeginGO = _fXQuanEndGO / 10f;
                }
                else if (quan > _fXQuanEndGO)
                {
                    _fXQuanBeginGO = quan;
                    _fXQuanEndGO = _fXQuanBeginGO / 10f;
                }
                else
                {
                    _fXQuanBeginGO = _fXQuanEndGO;
                }
                #endregion
                #region **根据新的权值修改坐标标定值**
                if (m <= _fXQuanBeginGO && m >= -_fXQuanBeginGO)
                {
                    _fXBeginGO = -_fXQuanBeginGO;
                }
                else
                {
                    _fXBeginGO = ((int)(m / _fXQuanBeginGO) - 1) * _fXQuanBeginGO;
                }
                #endregion
            }
            else
            {
                //如果值是从右边溢出
                #region **修改权值存入标定权值，控制权差在10倍以内**
                if (quan < _fXQuanBeginGO)
                {
                    _fXQuanEndGO = _fXQuanBeginGO / 10f;
                }
                else if (quan > _fXQuanBeginGO)
                {
                    _fXQuanEndGO = quan;
                    _fXQuanBeginGO = _fXQuanEndGO / 10f;
                }
                else
                {
                    _fXQuanEndGO = _fXQuanBeginGO;
                }
                #endregion
                #region **根据新的权值修改坐标标定值**
                if (m <= _fXQuanEndGO && m >= _fXQuanBeginGO)
                {
                    _fXEndGO = _fXQuanEndGO;
                }
                else
                {
                    _fXEndGO = ((int)(m / _fXQuanEndGO) + 1) * _fXQuanEndGO;
                }
                #endregion
            }
        }
        #endregion

        #region **私有方法 根据溢出坐标范围的浮点数，改变Y轴的坐标标定权值和坐标标定值 _changYBegionOrEndOGO(m:float, isL:bool):void **
        /// <summary>
        /// 根据溢出坐标范围的浮点数，改变Y轴的坐标标定权值和坐标标定值
        /// </summary>
        /// <param name="m">溢出坐标范围的浮点数</param>
        /// <param name="isL">是否从下边溢出</param>
        private void _changYBegionOrEndGO(float m, bool isL)
        {
            float quan = _getQuan(m);   //获得该溢出数的权值
            if (isL)
            {
                //如果值是从左边溢出
                #region **修改权值存入标定权值,控制权差在10倍以内**
                if (quan < _fYQuanEndGO)
                {
                    _fYQuanBeginGO = _fYQuanEndGO / 10f;
                }
                else if (quan > _fYQuanEndGO)
                {
                    _fYQuanBeginGO = quan;
                    _fYQuanEndGO = _fYQuanBeginGO / 10f;
                }
                else
                {
                    _fYQuanBeginGO = _fYQuanEndGO;
                }
                #endregion
                #region **根据新的权值修改坐标标定值**
                if (m <= _fYQuanBeginGO && m >= -_fYQuanBeginGO)
                {
                    _fYBeginGO = -_fYQuanBeginGO;
                }
                else
                {
                    _fYBeginGO = ((int)(m / _fYQuanBeginGO) - 1) * _fYQuanBeginGO;
                }
                #endregion
            }
            else
            {
                //如果值是从右边溢出
                #region **修改权值存入标定权值，控制权差在10倍以内**
                if (quan < _fYQuanBeginGO)
                {
                    _fYQuanEndGO = _fYQuanBeginGO / 10f;
                }
                else if (quan > _fYQuanBeginGO)
                {
                    _fYQuanEndGO = quan;
                    _fYQuanBeginGO = _fYQuanEndGO / 10f;
                }
                else
                {
                    _fYQuanEndGO = _fYQuanBeginGO;
                }
                #endregion
                #region **根据新的权值修改坐标标定值**
                if (m <= _fYQuanEndGO && m >= _fYQuanBeginGO)
                {
                    _fYEndGO = _fYQuanEndGO;
                }
                else
                {
                    _fYEndGO = ((int)(m / _fYQuanEndGO) + 1) * _fYQuanEndGO;
                }
                #endregion
            }
        }
        #endregion

        #region **私有方法 遍历要画的数据集合，并转换为坐标值 _changeToDrawPoints(index:int, listDrawPoints:ref List<PointF>, width:int, height:int):bool **
        /// <summary>
        /// 遍历要画的数据集合，并转换为坐标值
        /// </summary>
        /// <param name="index">要遍历的数据集合的编号</param>
        /// <param name="listDrawPoints">转后后的坐标集合</param>
        /// <param name="width">画布像素宽度</param>
        /// <param name="height">画布像素高度</param>
        /// <returns></returns>
        private bool _changeToDrawPoints(int index, ref List<PointF> listDrawPoints, int width, int height)
        {
            int length = _listX[index].Count;
            PointF currentPointF = new PointF(0, 0);
            //坐标起始和结束值之差小于精度范围则返回false
            if ((_fXEnd - _fXBegin) < _fAccuracy || (_fYEnd - _fYBegin) < _fAccuracy)
            {
                return false;
            }
            //遍历并转换为坐标值
            for (int i = 0; i < length; i++)
            {
                //非数字则跳过
                if (float.IsNaN(_listX[index][i]) || float.IsNaN(_listY[index][i]))
                {
                    continue;
                }
                //转换为像素坐标
                currentPointF.X = (_listX[index][i] - _fXBegin) * (width - 1) / (_fXEnd - _fXBegin);
                currentPointF.Y = (_listY[index][i] - _fYBegin) * (height - 1) / (_fYEnd - _fYBegin);
                //装载坐标
                listDrawPoints.Add(currentPointF);
            }
            //无数据则返回false
            if (listDrawPoints.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region **私有方法 波形显示中矩形区域的坐标转换为数据值 _changeXYPointsToNum(xB:float, xE:float, yB:float, yE:float, outxB:ref float, outxE:ref float, outyB:ref float, outyE:ref float):void **
        /// <summary>
        /// 波形显示中矩形区域的坐标转换为数据值
        /// </summary>
        /// <param name="xB">矩形区域左上角X轴坐标</param>
        /// <param name="xE">矩形区域右下角X轴坐标</param>
        /// <param name="yB">矩形区域左上角Y轴坐标</param>
        /// <param name="yE">矩形区域右下角Y轴坐标</param>
        /// <param name="outxB">转换后的左上角X轴数据值</param>
        /// <param name="outxE">转换后的右下角X轴数据值</param>
        /// <param name="outyB">转换后的左上角Y轴数据值</param>
        /// <param name="outyE">转换后的右下角Y轴数据值</param>
        private void _changeXYPointsToNum(float xB, float xE, float yB, float yE,
            ref float outxB, ref float outxE, ref float outyB, ref float outyE)
        {
            float currentB, currentE;
            currentB = xB / (pictureBoxGraph.Width - 1) * (_fXEnd - _fXBegin) + _fXBegin;
            currentE = xE / (pictureBoxGraph.Width - 1) * (_fXEnd - _fXBegin) + _fXBegin;
            outxB = currentB;
            outxE = currentE;
            currentB = _fYEnd - yB / (pictureBoxGraph.Height - 1) * (_fYEnd - _fYBegin);
            currentE = _fYEnd - yE / (pictureBoxGraph.Height - 1) * (_fYEnd - _fYBegin);
            outyE = currentB;
            outyB = currentE;
        }
        /// <summary>
        /// 波形显示中一个点的坐标转换为数据值
        /// </summary>
        /// <param name="x">要转换的点的X轴坐标</param>
        /// <param name="y">要转换的点的Y轴坐标</param>
        /// <param name="outX">转换后的X轴坐标</param>
        /// <param name="outY">转换后的Y轴坐标</param>
        private void _changeXYPointsToNum(float x, float y, ref float outX, ref float outY)
        {
            outX = x / (pictureBoxGraph.Width - 1) * (_fXEnd - _fXBegin) + _fXBegin;
            outY = _fYEnd - y / (pictureBoxGraph.Height - 1) * (_fYEnd - _fYBegin);
        }
        #endregion
    }
}
