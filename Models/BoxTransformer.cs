using Mrf.CSharp.BaseTools;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 箱变器
    /// </summary>
    public class BoxTransformer
    {

        private int _revitId;

        /// <summary>
        /// 在Revit中的Id
        /// </summary>
        public int RevitId
        {
            get { return _revitId; }
            set { _revitId = value; }
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





        private Point3d _centerPoint;

        /// <summary>
        /// 中心点，也就是插入点
        /// </summary>
        public Point3d CenterPoint
        {
            get { return _centerPoint; }
            set { _centerPoint = value; }
        }





        private double _width = 4000;

        /// <summary>
        /// 宽度（单位：mm)
        /// </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }




        private double _height = 2000;

        /// <summary>
        /// 高度（单位：mm)
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

    }
}
