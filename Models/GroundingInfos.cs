using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mrf.Photovoltaic.Tools.Models
{
    public class GroundingInfos
    {
        /// <summary>
        /// 唯一编号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 图例
        /// </summary>
        public string legeng { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string GroundingName { get; set; }

        /// <summary>
        /// 型号规范
        /// </summary>
        public string ModelSpecification { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string units { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public double TotalLength { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
