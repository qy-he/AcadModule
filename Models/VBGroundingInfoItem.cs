using Mrf.CSharp.BaseTools;
using Mrf.CSharp.BaseTools.Extension;

namespace Mrf.Photovoltaic.Tools.Models
{
        public class VBGroundingInfoItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 圆钢
            /// </summary>
            public string Model { get; set; }
            /// <summary>
            /// 镀铜
            /// </summary>
            public string Material { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Specification { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double Depth { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double Length { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Point3d Coord { get; set; }




        /// <summary>
        /// 获取Coord坐标（单位：mm）,舍弃z坐标
        /// </summary>
        public void GetCoordInMM()
        {
            if (Coord != null)
            {
                Coord = new Point3d(Coord.X.Foot2Millimeter(), Coord.Y.Foot2Millimeter(), 0);
            }
        }

    }

}
