using System.Collections.Generic;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 设备接地
    /// </summary>
    public class DvGrounding
        {
            /// <summary>
            /// 
            /// </summary>
            public double TotalLength { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<DvGroundingInfoItem> JvbroundingInfos { get; set; }
        }



}
