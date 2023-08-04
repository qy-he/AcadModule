using Mrf.CSharp.BaseTools;
using Mrf.CSharp.BaseTools.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 道路
    /// </summary>
    public class RoadInfoItem
    {
        private int _id;
        /// <summary>
        /// 序号
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private List<Point3d> _centerLine;
        /// <summary>
        /// 中心线（单位：英尺）
        /// </summary>
        public List<Point3d> CenterLine
        {
            get { return _centerLine; }
            set { _centerLine = value; }
        }




        private List<Point3d> _centerLineInMM;
        /// <summary>
        /// 中心线（单位：mm） z为0
        /// </summary>
        public List<Point3d> CenterLineInMM
        {
            get { return _centerLineInMM; }
            set { _centerLineInMM = value; }
        }










        private List<Point3d> _leftLine;
        /// <summary>
        /// 左边线（单位：英尺）
        /// </summary>
        public List<Point3d> LeftLine
        {
            get { return _leftLine; }
            set { _leftLine = value; }
        }






        private List<Point3d> _leftLineInMM;
        /// <summary>
        /// 左边线（单位：mm） z为0
        /// </summary>
        public List<Point3d> LeftLineInMM
        {
            get { return _leftLineInMM; }
            set { _leftLineInMM = value; }
        }












        private List<Point3d> _rightLine;
        /// <summary>
        /// 右边线（单位：英尺）
        /// </summary>
        public List<Point3d> RightLine
        {
            get { return _rightLine; }
            set { _rightLine = value; }
        }





        private List<Point3d> _rightLineInMM;
        /// <summary>
        /// 右边线（单位：mm） z为0
        /// </summary>
        public List<Point3d> RightLineInMM
        {
            get { return _rightLineInMM; }
            set { _rightLineInMM = value; }
        }














        private double _w;
        /// <summary>
        /// 宽度
        /// </summary>
        public double W
        {
            get { return _w; }
            set { _w = value; }
        }


        private double _length;
        /// <summary>
        /// 长度
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private int _revitId;
        /// <summary>
        /// Revit的Id
        /// </summary>
        public int Revit_Id
        {
            get { return _revitId; }
            set { _revitId = value; }
        }


        /// <summary>
        /// 获取长度（三维长度）(单位：英尺）
        /// </summary>
        public void GetLength3D()
        {
            Length = 0;
            if (_centerLine != null && _centerLine.Count() > 0)
            {
                for (int i = 0; i < _centerLine.Count() - 1; i++)
                {
                    Length += _centerLine[i].DistanceTo(_centerLine[i + 1]);
                }
            }
        }




        /// <summary>
        /// 获取中心线坐标列表（单位：mm）z值归0
        /// </summary>
        public void GetCenterLineInMM()
        {
            if (_centerLine != null && _centerLine.Count > 0)
            {
                _centerLineInMM = new List<Point3d>();
                foreach (var item in _centerLine)
                {


                    //double xValue = item.X;
                    //double yValue = item.Y;


                    double xValue = item.X.Foot2Millimeter();
                    double yValue = item.Y.Foot2Millimeter();






                    Point3d point3D = new Point3d(xValue, yValue, 0);
                    _centerLineInMM.Add(point3D);
                }
            }
        }







        /// <summary>
        /// 获取左边线坐标列表（单位：mm）
        /// </summary>
        public void GetLeftLineInMM()
        {
            if (_leftLine != null && _leftLine.Count > 0)
            {
                _leftLineInMM = new List<Point3d>();
                foreach (var item in _leftLine)
                {




                    //double xValue = item.X;
                    //double yValue = item.Y;

                    double xValue = item.X.Foot2Millimeter();
                    double yValue = item.Y.Foot2Millimeter();




                    Point3d point3D = new Point3d(xValue, yValue, 0);
                    _leftLineInMM.Add(point3D);
                }
            }
        }




        /// <summary>
        /// 获取右边线坐标列表（单位：mm）
        /// </summary>
        public void GetRightLineInMM()
        {
            if (_rightLine != null && _rightLine.Count > 0)
            {
                _rightLineInMM = new List<Point3d>();
                foreach (var item in _rightLine)
                {


                    //double xValue = item.X;
                    //double yValue = item.Y;

                    double xValue = item.X.Foot2Millimeter();
                    double yValue = item.Y.Foot2Millimeter();




                    Point3d point3D = new Point3d(xValue, yValue, 0);
                    _rightLineInMM.Add(point3D);
                }
            }
        }


















    }
}
