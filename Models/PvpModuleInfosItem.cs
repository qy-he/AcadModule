using Mrf.CSharp.BaseTools;
using Mrf.CSharp.BaseTools.Extension;
using System;
using System.Collections.Generic;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 光伏组串
    /// </summary>
    public class PvpModuleInfosItem
    {


        private int _id;

        /// <summary>
        /// 在Revit中的Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }



        private string _code;

        /// <summary>
        /// 编号
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }



        private string _preCode;

        /// <summary>
        /// 上级汇流设备编号
        /// </summary>
        public string PreCode
        {
            get { return _preCode; }
            set { _preCode = value; }
        }





        private string _uniqueLabel;

        /// <summary>
        /// 
        /// </summary>
        public string UniqueLabel
        {
            get { return _uniqueLabel; }
            set { _uniqueLabel = value; }
        }



        private List<int> _color;

        /// <summary>
        /// 颜色
        /// </summary>
        public List<int> Color
        {
            get { return _color; }
            set { _color = value; }
        }




        private List<Point3d> _points;

        /// <summary>
        /// 边界的四个点，顺序貌似是下右 下左 上左 上右  按顺序连接（单位：英尺）
        /// </summary>
        public List<Point3d> Points
        {
            get { return _points; }
            set { _points = value; }
        }
















        /// <summary>
        /// 接入容量
        /// </summary>
        public double AccessibleCapacity { get; set; }




        private Point3d _centerPoint;

        /// <summary>
        /// 中心点，也就是插入点 （单位：mm）
        /// </summary>
        public Point3d CenterPoint
        {
            get { return _centerPoint; }
            set { _centerPoint = value; }
        }





        private double _length;

        /// <summary>
        /// 沿着x轴的长度（单位：mm)
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }




        private double _width;

        /// <summary>
        /// 沿着y轴的宽度（单位：mm)
        /// </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }





        private string _objectId = "-1";

        /// <summary>
        /// 在CAD中生成的对象的ObjectId对应的字符串，如果没有，则为"-1"
        /// </summary>
        public string ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }



        /// <summary>
        /// 获取中心点坐标（单位：mm）去掉了z的值
        /// </summary>
        public void GetCenterPoint()
        {
            if (_points == null && _points.Count != 4)
            {
                return;
            }

            ////注意英尺转换为mm

            //double centerX = ((_points[0].X + _points[2].X) / 2).Foot2Millimeter();
            //double centerY = ((_points[0].Y + _points[2].Y) / 2).Foot2Millimeter();

            //已经为mm了
            double centerX = ((_points[0].X + _points[2].X) / 2);
            double centerY = ((_points[0].Y + _points[2].Y) / 2);


            _centerPoint = new Point3d(centerX, centerY, 0);

        }

        /// <summary>
        /// 获取沿x轴的长度（单位：mm）
        /// </summary>
        public void GetLength()
        {
            if (_points == null && _points.Count != 4)
            {
                return;
            }

            //注意英尺转换为mm  四舍五入

            //_length = Math.Round(Math.Abs(_points[0].X - _points[2].X).Foot2Millimeter());

            //通过相邻的三个点来比较

            double length1 = Math.Abs(_points[0].X - _points[1].X);
            double length2 = Math.Abs(_points[1].X - _points[2].X);

            if (length1 < length2)
            {
                length1 = length2;
            }


            //14:15 2022/10/18  已经为mm了 不再需要转换
            //_length = Math.Round(length1.Foot2Millimeter());
            _length = Math.Round(length1);




        }



        /// <summary>
        /// 获取沿y轴的宽度（单位：mm）
        /// </summary>
        public void GetWidth()
        {
            if (_points == null && _points.Count != 4)
            {
                return;
            }



            //注意英尺转换为mm   四舍五入
            //_width = Math.Round(Math.Abs(_points[0].Y - _points[2].Y).Foot2Millimeter());


            double width1 = Math.Abs(_points[0].Y - _points[1].Y);
            double width2 = Math.Abs(_points[1].Y - _points[2].Y);

            if (width1 < width2)
            {
                width1 = width2;
            }


            //14:15 2022/10/18  已经为mm了 不再需要转换
            //_width = Math.Round(width1.Foot2Millimeter());
            _width = Math.Round(width1);

        }



        ///// <summary>
        ///// 如果长度、宽度和颜色相同，则认为两者相同
        ///// </summary>
        ///// <param name="b"></param>
        ///// <returns></returns>
        //public bool IsEqual(PvpModuleItem b)
        //{
        //    //返回值
        //    bool isEqual = false;
        //    if (b == null)
        //    {
        //        return isEqual;
        //    }

        //    if (_color == null || _color.Count != 3 || b.Color == null || b.Color.Count != 3)
        //    {
        //        return isEqual;
        //    }

        //    if (_length.AreEqual(b.Length, 0.5) &&  //长度一样
        //        _width.AreEqual(b.Width, 0.5) && //宽度一样
        //        _color[0] == b.Color[0] &&  //颜色一样
        //        _color[1] == b.Color[1] &&
        //        _color[2] == b.Color[2]
        //        )
        //    {
        //        isEqual = true;
        //    }

        //    return isEqual;
        //}



        /// <summary>
        /// 如果长度、宽度相同，则认为两者相同
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsEqual(PvpModuleInfosItem b)
        {
            //返回值
            bool isEqual = false;
            if (b == null)
            {
                return isEqual;
            }

            if (_length.AreEqual(b.Length, 0.5) &&  //长度一样
                _width.AreEqual(b.Width, 0.5)  //宽度一样
                )
            {
                isEqual = true;
            }

            return isEqual;
        }






    }


}
