using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class DimStyleInfo
    {
        /// <summary>
        /// 样式名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 固定的尺寸界线长度
        /// </summary>
        public double Dimfxlen { get; set; }
        /// <summary>
        /// 圆心标记大小
        /// </summary>
        public double Dimcen { get; set; }
        /// <summary>
        /// 标注折弯角度
        /// </summary>
        public double Dimjogang { get; set; }
        /// <summary>
        /// 小数分隔符
        /// </summary>
        public char Dimdsep { get; set; }
        /// <summary>
        /// 公差位置垂直
        /// </summary>
        public int Dimtolj { get; set; }
        /// <summary>
        /// 全局比例
        /// </summary>
        public double Dimscale { get; set; }
        /// <summary>
        /// 尺寸界线偏移
        /// </summary>
        public double Dimexo { get; set; }
        /// <summary>
        /// 尺寸界线超出量
        /// </summary>
        public double Dimexe { get; set; }
        /// <summary>
        /// 尺寸界线颜色
        /// </summary>
        public Color Dimclre { get; set; }
        /// <summary>
        /// 尺寸界线线宽
        /// </summary>
        public LineWeight Dimlwe { get; set; }
        /// <summary>
        /// 尺寸线线宽
        /// </summary>
        public LineWeight Dimlwd { get; set; }
        /// <summary>
        /// 尺寸线超出量
        /// </summary>
        public double Dimdle { get; set; }
        /// <summary>
        /// 尺寸线间距
        /// </summary>
        public double Dimdli { get; set; }
        /// <summary>
        /// 尺寸线颜色
        /// </summary>
        public Color Dimclrd { get; set; }
        /// <summary>
        /// 引线箭头
        /// </summary>
        public ObjectId Dimldrblk { get; set; }
        /// <summary>
        /// 弧长符号
        /// </summary>
        public int Dimarcsym { get; set; }
        /// <summary>
        /// 换算公差消零
        /// </summary>
        public int Dimalttz { get; set; }
        /// <summary>
        /// 换算公差精度
        /// </summary>
        public int Dimalttd { get; set; }
        /// <summary>
        /// 换算前缀和后缀
        /// </summary>
        public string Dimapost { get; set; }
        /// <summary>
        /// 换算单位
        /// </summary>
        public int Dimaltu { get; set; }
        /// <summary>
        /// 换算比例因子
        /// </summary>
        public double Dimaltf { get; set; }
        /// <summary>
        /// 换算消零
        /// </summary>
        public int Dimaltz { get; set; }
        /// <summary>
        /// 换算精度
        /// </summary>
        public int Dimaltd { get; set; }
        /// <summary>
        /// 换算舍入
        /// </summary>
        public double Dimaltrnd { get; set; }
        /// <summary>
        /// 文字位置垂直
        /// </summary>
        public int Dimtad { get; set; }
        /// <summary>
        /// 文字位置水平
        /// </summary>
        public int Dimjust { get; set; }
        /// <summary>
        /// 文字偏移
        /// </summary>
        public double Dimgap { get; set; }
        /// <summary>
        /// 文字样式
        /// </summary>
        public ObjectId Dimtxsty { get; set; }
        /// <summary>
        /// 文字颜色
        /// </summary>
        public Color Dimclrt { get; set; }
        /// <summary>
        /// 文字高度
        /// </summary>
        public double Dimtxt { get; set; }
        /// <summary>
        /// 箭头
        /// </summary>
        public ObjectId Dimblk { get; set; }
        /// <summary>
        /// 箭头1
        /// </summary>
        public ObjectId Dimblk1 { get; set; }
        /// <summary>
        /// 箭头2
        /// </summary>
        public ObjectId Dimblk2 { get; set; }
        /// <summary>
        /// 箭头大小
        /// </summary>
        public double Dimasz { get; set; }
        /// <summary>
        /// 精度
        /// </summary>
        public int Dimdec { get; set; }
        /// <summary>
        /// 调整: 文字移动
        /// </summary>
        public int Dimtmove { get; set; }
        /// <summary>
        /// 调整: 箭头和文字
        /// </summary>
        public int Dimatfit { get; set; }
        /// <summary>
        /// 长度单位
        /// </summary>
        public int Dimlunit { get; set; }
        /// <summary>
        /// 公差精度
        /// </summary>
        public int Dimtdec { get; set; }
        /// <summary>
        /// 角度精度
        /// </summary>
        public int Dimadec { get; set; }
        /// <summary>
        /// 角度消零
        /// </summary>
        public int Dimazin { get; set; }
        /// <summary>
        /// 消零
        /// </summary>
        public int Dimzin { get; set; }
        /// <summary>
        /// 长度比例
        /// </summary>
        public double Dimlfac { get; set; }
        /// <summary>
        /// 尺寸线强制
        /// </summary>
        public bool Dimtofl { get; set; }
        /// <summary>
        /// 文字外部对齐
        /// </summary>
        public bool Dimtoh { get; set; }
        /// <summary>
        /// 文字在内
        /// </summary>
        public bool Dimtix { get; set; }
        /// <summary>
        /// 文字在内对齐
        /// </summary>
        public bool Dimtih { get; set; }
    }
}
