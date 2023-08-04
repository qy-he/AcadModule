using Mrf.CSharp.BaseTools;
using System.Collections.Generic;

namespace Mrf.Photovoltaic.Tools.Models
{
 
        public class MNGroundingInfoItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string Mode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Label { get; set; }
        /// <summary>
        /// Revit中的Id
        /// </summary>
        public int Revit_Id { get; set; }
            /// <summary>
            /// 扁钢
            /// </summary>
            public string Model { get; set; }
            /// <summary>
            /// 铜
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





        private List<List<Point3d>> _path;

        /// <summary>
        /// 功能描述
        /// </summary>
        public List<List< Point3d>> Path
        {
            get { return _path; }
            set { _path = value; }
        }






        /// <summary>
        /// 获取Path坐标列表（单位：mm）,将英尺转换为mm，舍弃z坐标
        /// </summary>
        public void GetPathInMM()
        {

            if (Path != null && Path.Count > 0)
            {
                List<List< Point3d>> succeedPath = new List<List< Point3d>>();

                for (int i = 0; i < Path.Count; i++)
                {
                    var item=Path[i];

                    if(item==null || item.Count == 0)
                    {
                        continue;
                    }

                    for (int j = 0; j < item.Count; j++)
                    {
                        item[j]= item[j].Foot2Millimeter();
                        item[j].Z = 0;
                    }
                    succeedPath.Add(item);
                }

                Path = succeedPath;
            }
        }

    }


}
