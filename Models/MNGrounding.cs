using System.Collections.Generic;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 主网接地
    /// </summary>
    public class MNGrounding
        {
            /// <summary>
            /// 
            /// </summary>
            public double TotalLength { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<MNGroundingInfoItem> MNGroundingInfos { get; set; }
        }
}
