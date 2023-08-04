using Mrf.CSharp.BaseTools;
using Mrf.CSharp.BaseTools.Extension;
using System.Collections.Generic;

namespace Mrf.Photovoltaic.Tools.Models
{

    /// <summary>
    /// 电缆
    /// </summary>
    public class CableItem
    {



        private string _code;

        /// <summary>
        /// 编号
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }






        private string _moduleCode;

        /// <summary>
        /// 编号
        /// </summary>
        public string ModuleCode
        {
            get { return _moduleCode; }
            set { _moduleCode = value; }
        }







        private string _comboCode;

        /// <summary>
        /// 编号
        /// </summary>
        public string ComboCode
        {
            get { return _comboCode; }
            set { _comboCode = value; }
        }





        private List<Point3d> _positivePath;

        /// <summary>
        /// 正向路径（单位：英尺）
        /// </summary>
        public List<Point3d> PositivePath
        {
            get { return _positivePath; }
            set { _positivePath = value; }
        }



        private List<Point3d> _negativePath;

        /// <summary>
        /// 逆向路径（单位：英尺）
        /// </summary>
        public List<Point3d> NegativePath
        {
            get { return _negativePath; }
            set { _negativePath = value; }
        }




        private List<Point3d> _positivePathInMM;

        /// <summary>
        /// 正向路径（单位：mm）
        /// </summary>
        public List<Point3d> PositivePathInMM
        {
            get { return _positivePathInMM; }
            set { _positivePathInMM = value; }
        }



        private List<Point3d> _negativePathInMM;

        /// <summary>
        /// 逆向路径（单位：mm）
        /// </summary>
        public List<Point3d> NegativePathInMM
        {
            get { return _negativePathInMM; }
            set { _negativePathInMM = value; }
        }
























        private double _positiveLength;

        /// <summary>
        /// 正向长度(单位:英尺)
        /// </summary>
        public double PositiveLength
        {
            get { return _positiveLength; }
            set { _positiveLength = value; }
        }



        private double _negativeLength;

        /// <summary>
        /// 逆向长度(单位:英尺)
        /// </summary>
        public double NegativeLength
        {
            get { return _negativeLength; }
            set { _negativeLength = value; }
        }







        private string _positiveCableModel;

        /// <summary>
        /// 正向
        /// </summary>
        public string PositiveCableModel
        {
            get { return _positiveCableModel; }
            set { _positiveCableModel = value; }
        }





        private string _negativeCableModel;

        /// <summary>
        /// 逆向
        /// </summary>
        public string NegativeCableModel
        {
            get { return _negativeCableModel; }
            set { _negativeCableModel = value; }
        }







        private double _ratio;

        /// <summary>
        /// 
        /// </summary>
        public double Ratio
        {
            get { return _ratio; }
            set { _ratio = value; }
        }




        private double _voltageLevel;

        /// <summary>
        /// 
        /// </summary>
        public double VoltageLevel
        {
            get { return _voltageLevel; }
            set { _voltageLevel = value; }
        }




        private List<int> _cableColor;

        /// <summary>
        /// 颜色
        /// </summary>
        public List<int> CableColor
        {
            get { return _cableColor; }
            set { _cableColor = value; }
        }




        /// <summary>
        /// 获取正向路径坐标列表（单位：mm）z值归0
        /// </summary>
        public void GetPositivePathInMM()
        {
            if (_positivePath != null && _positivePath.Count > 0)
            {
                _positivePathInMM = new List<Point3d>();
                foreach (var item in _positivePath)
                {




                    //double xValue = item.X;
                    //double yValue = item.Y;

                    double xValue = item.X.Foot2Millimeter();
                    double yValue = item.Y.Foot2Millimeter();




                    Point3d point3D = new Point3d(xValue, yValue, 0);
                    _positivePathInMM.Add(point3D);
                }
            }
        }






        /// <summary>
        /// 获取逆向路径坐标列表（单位：mm）z值归0
        /// </summary>
        public void GetNegativePathInMM()
        {
            if (_negativePath != null && _negativePath.Count > 0)
            {
                _negativePathInMM = new List<Point3d>();
                foreach (var item in _negativePath)
                {




                    //double xValue = item.X;
                    //double yValue = item.Y;

                    double xValue = item.X.Foot2Millimeter();
                    double yValue = item.Y.Foot2Millimeter();




                    Point3d point3D = new Point3d(xValue, yValue, 0);
                    _negativePathInMM.Add(point3D);
                }
            }
        }




























    }


}
