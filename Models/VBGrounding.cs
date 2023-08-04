using System.Collections.Generic;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 处置接地体
    /// </summary>
    public class VBGrounding
        {
            /// <summary>
            /// 
            /// </summary>
            public double TotalLength { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<VBGroundingInfoItem> VBGroundingInfos { get; set; }
        }



}
