using System.Collections.Generic;

namespace Mrf.Photovoltaic.Tools.Models
{

    /// <summary>
    /// 道路
    /// </summary>
    public class RoadItem
    {
        private double _totalLength;
        /// <summary>
        /// 总长度(单位：mm)
        /// </summary>
        public double TotalLength
        {
            get { return _totalLength; }
            set { _totalLength = value; }
        }

        private List<RoadInfoItem> _roadInfos;
        /// <summary>
        /// 道路
        /// </summary>
        public List<RoadInfoItem> RoadInfos
        {
            get { return _roadInfos; }
            set { _roadInfos = value; }
        }
    }
}
