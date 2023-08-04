namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 光伏组件信息
    /// </summary>
    public class PvpCompoInfo
    {



        private int _id;

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        

        private double _power;

        /// <summary>
        /// 
        /// </summary>
        public double Power
        {
            get { return _power; }
            set { _power = value; }
        }


            

        private double _length;

        /// <summary>
        /// 组件长度，纵向布置时，沿着y方向，横向布置时，沿着x方向
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }


                

        private double _width;

        /// <summary>
        /// 组件宽度，纵向布置时，沿着x方向，横向布置时，沿着y方向
        /// </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }


                

        private double _thickness;

        /// <summary>
        /// 
        /// </summary>
        public double Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }




    }
}
