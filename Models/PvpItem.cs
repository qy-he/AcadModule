using Mrf.CSharp.BaseTools;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 光伏方阵对象，  光伏组件组成光伏组串，光伏组串组成光伏方阵
    /// </summary>
    public class PvpItem
    {

        private double _angleEW;

        /// <summary>
        /// 东西方向的角度，即绕y轴的角度（单位：弧度制)
        /// </summary>
        public double AngleEW
        {
            get { return _angleEW; }
            set { _angleEW = value; }
        }


        private double _angleNS;

        /// <summary>
        /// 南北方向的角度，即绕x轴的角度（单位：弧度制)
        /// </summary>
        public double AngleNS
        {
            get { return _angleNS; }
            set { _angleNS = value; }
        }


        private double _azimuth;

        /// <summary>
        /// 水平方向的角度，即绕z轴的角度（单位：弧度制)
        /// </summary>
        public double Azimuth
        {
            get { return _azimuth; }
            set { _azimuth = value; }
        }






          private double _angle;

        /// <summary>
        /// 角度（单位：弧度制)
        /// </summary>
        public double Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }



           private double _absoluteAzimuth;

        /// <summary>
        ///  新增
        /// </summary>
        public double AbsoluteAzimuth
        {
            get { return _absoluteAzimuth; }
            set { _absoluteAzimuth = value; }
        }



           private double _powerArea;

        /// <summary>
        /// 新增
        /// </summary>
        public double PowerArea
        {
            get { return _powerArea; }
            set { _powerArea = value; }
        }

     

        private double _width;

        /// <summary>
        /// 沿y方向的宽度（单位：mm）
        /// </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }


        private double _length;

        /// <summary>
        /// 沿x方向的长度（单位：mm)
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }




        private double _widthPerPvpModule;

        /// <summary>
        /// 每个光伏组串沿y方向的宽度（单位：mm）
        /// </summary>
        public double WidthPerPvpModule
        {
            get { return _widthPerPvpModule; }
            set { _widthPerPvpModule = value; }
        }




        private double _lengthPerPvpModule;

        /// <summary>
        /// 每个光伏组串沿x方向的长度（单位：mm)
        /// </summary>
        public double LengthPerPvpModule
        {
            get { return _lengthPerPvpModule; }
            set { _lengthPerPvpModule = value; }
        }



        private double _xlengthPerPvpModuleCell;

        /// <summary>
        /// 每个光伏组件沿x方向的长度（单位：mm)
        /// </summary>
        public double XLengthPerPvpModuleCell
        {
            get { return _xlengthPerPvpModuleCell; }
            set { _xlengthPerPvpModuleCell = value; }
        }





        private double _ylengthPerPvpModuleCell;

        /// <summary>
        /// 每个光伏组件沿y方向的长度（单位：mm)
        /// </summary>
        public double YLengthPerPvpModuleCell
        {
            get { return _ylengthPerPvpModuleCell; }
            set { _ylengthPerPvpModuleCell = value; }
        }







        private double _widthProjectionPerPvpModule;

        /// <summary>
        /// 每个光伏组串沿y方向的宽度在水平方向投影的宽度（单位：mm）
        /// </summary>
        public double WidthProjectionPerPvpModule
        {
            get { return _widthProjectionPerPvpModule; }
            set { _widthProjectionPerPvpModule = value; }
        }







        private int _cNumberPerColumn = 2;

        /// <summary>
        /// 表示每个光伏组串中每列光伏组件的数量(沿着y方向）
        /// </summary>
        public int CNumberPerColumn
        {
            get { return _cNumberPerColumn; }
            set { _cNumberPerColumn = value; }
        }






        private int _cNumberPerRow = 13;

        /// <summary>
        /// 表示每个光伏组串中每行光伏组件的数量(沿着x方向）
        /// </summary>
        public int CNumberPerRow
        {
            get { return _cNumberPerRow; }
            set { _cNumberPerRow = value; }
        }




        private double _lateralClearance = 20.0;

        /// <summary>
        /// 表示光伏板中相邻光伏组串的横向间距(沿着x方向，单位：mm)
        /// </summary>
        public double LateralClearance
        {
            get { return _lateralClearance; }
            set { _lateralClearance = value; }
        }


        private double _longitudinalGap = 20.0;

        /// <summary>
        /// 表示光伏板中相邻光伏组串的纵向间距(沿着y方向，单位：mm)
        /// </summary>
        public double LongitudinalGap
        {
            get { return _longitudinalGap; }
            set { _longitudinalGap = value; }
        }






        private int _numberOfStringsPerLine = 3;

        /// <summary>
        /// 表示光伏板中每行光伏组串数量（沿着x方向)
        /// </summary>
        public int NumberOfStringsPerLine
        {
            get { return _numberOfStringsPerLine; }
            set { _numberOfStringsPerLine = value; }
        }




        private int _numberOfStringsPerColumn = 2;

        /// <summary>
        /// 表示光伏板中每列光伏组串数量（沿着y方向)
        /// </summary>
        public int NumberOfStringsPerColumn
        {
            get { return _numberOfStringsPerColumn; }
            set { _numberOfStringsPerColumn = value; }
        }







        private string _cDirection = "竖向布置";

        /// <summary>
        /// 光伏板中光伏组串的布置方式,有"竖向布置" 和"横向布置" 两种
        /// </summary>
        public string CDirection
        {
            get { return _cDirection; }
            set { _cDirection = value; }
        }





        private string _outDirection = "同侧出线";

        /// <summary>
        /// 表示小线从两侧出还是单侧，值有  "同侧出线", "+两侧出线-（西正东负）", "-两侧出线+（东正西负）"
        /// </summary>
        public string OutDirection
        {
            get { return _outDirection; }
            set { _outDirection = value; }
        }








        private List<Point3d> _points;

        /// <summary>
        /// 四周的边界点，方向应该为左下、右下、右上、左上（单位：英尺）
        /// </summary>
        public List<Point3d> Points
        {
            get { return _points; }
            set { _points = value; }
        }




        private List<PvpModuleInfosItem> _pvpModuleInfos;

        /// <summary>
        /// 光伏组串列表
        /// </summary>
        public List<PvpModuleInfosItem> PvpModuleInfos
        {
            get { return _pvpModuleInfos; }
            set { _pvpModuleInfos = value; }
        }


        private int _PvpCompoInfoId;

        /// <summary>
        /// 光伏组串列表
        /// </summary>
        public PvpCompoInfo PvpCompoInfo
        {
            get { return _pvpCompoInfo; }
            set { _pvpCompoInfo = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int PvpCompoInfoId
        {
            get { return _PvpCompoInfoId; }
            set { _PvpCompoInfoId = value; }
        }



        private PvpCompoInfo _pvpCompoInfo;






        private double _ratedCapacity;

        /// <summary>
        /// 
        /// </summary>
        public double RatedCapacity
        {
            get { return _ratedCapacity; }
            set { _ratedCapacity = value; }
        }







        private double _groundClearance;

        /// <summary>
        /// 组件实际最低点离地高(单位：英尺)
        /// </summary>
        public double GroundClearance
        {
            get { return _groundClearance; }
            set { _groundClearance = value; }
        }



        private double _setGroundClearance;

        /// <summary>
        /// 组件理论最低点离地高(单位：英尺) 由用户输入  14:05 2023/4/14 单位改为：m
        /// </summary>
        public double SetGroundClearance
        {
            get { return _setGroundClearance; }
            set { _setGroundClearance = value; }
        }














        private int _id;

        /// <summary>
        /// 在Revit中的Id json中没有提供 只是为了传到桩位图中，组成其的光伏组串可能有一个或多个，取其中第一个的Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }



        private string _code;

        /// <summary>
        /// 编号 json中没有提供 只是为了传到桩位图中，组成其的光伏组串可能有一个或多个，取其中第一个的Code
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }













        /// <summary>
        /// 获取 每个光伏组串沿y方向的宽度（在角度方向上）（单位：mm）,化为整数
        /// </summary>
        /// <returns>如果成功，返回true,否则，返回false</returns>
        public bool GetWidthPerPvpModule(out string message)
        {
            message = "";

            if (NumberOfStringsPerColumn <= 0)
            {

                //MessageBox.Show("GetWidthPerPvpModule() 出错：\nNumberOfStringsPerColumn 只能为正整数", "Tips");

                message = "GetWidthPerPvpModule() 出错：\nNumberOfStringsPerColumn 只能为正整数";

                return false;
            }

            double width = (Width - (NumberOfStringsPerColumn - 1) * LongitudinalGap) / NumberOfStringsPerColumn;

            WidthPerPvpModule = Math.Round(width);

            return true;
        }




        /// <summary>
        /// 获取 每个光伏组串沿x方向的长度（单位：mm）,化为整数
        /// </summary>
        /// <returns>如果成功，返回true,否则，返回false</returns>
        public bool GetLengthPerPvpModule(out string message)
        {
            message = "";

            if (NumberOfStringsPerLine <= 0)
            {

                //MessageBox.Show("GetLengthPerPvpModule() 出错：\nNumberOfStringsPerLine 只能为正整数", "Tips");
                message = "GetLengthPerPvpModule() 出错：\nNumberOfStringsPerLine 只能为正整数";
                return false;
            }

            double length = (Length - (NumberOfStringsPerLine - 1) * LateralClearance) / NumberOfStringsPerLine;

            //化为整数
            LengthPerPvpModule = Math.Round(length);
            return true;
        }




        /// <summary>
        /// 获取 每个光伏组串沿y方向在水平方向投影的宽度（单位：mm）,化为整数
        /// </summary>
        /// <returns>如果成功，返回true,否则，返回false</returns>
        public void GetWidthProjectionPerPvpModule()
        {
            double widthProjection = WidthPerPvpModule * Math.Abs(Math.Cos(AngleNS));

            //化为整数
            WidthProjectionPerPvpModule = Math.Round(widthProjection);
        }


        ///// <summary>
        ///// 获取 每个光伏组串沿y方向的宽度以及在水平方向投影的宽度（单位：mm）
        ///// </summary>
        ///// <returns>如果成功，返回true,否则，返回false</returns>
        //public bool GetWidthProjectionPerPvpModule(out string message)
        //{
        //    bool isSucceed = GetWidthPerPvpModule(out message);
        //    if (!isSucceed)
        //    {
        //        return false;
        //    }

        //    double widthProjection = WidthPerPvpModule * Math.Abs(Math.Cos(AngleNS));

        //    //化为整数
        //    WidthProjectionPerPvpModule = Math.Round(widthProjection);

        //    return true;
        //}


    }
}
