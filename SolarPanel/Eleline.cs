using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    /// <summary>
    /// 线单元信息
    /// </summary>
    public class Eleline
    {
        /// <summary>
        /// 单元号
        /// </summary>
        public int unitNumber { get; set; }
        /// <summary>
        /// 单元类型
        /// </summary>
        public string unitType { get; set; }
        /// <summary>
        /// 材料号
        /// </summary>
        public int materialNumber { get; set; }
        /// <summary>
        /// 截面类型
        /// </summary>
        public int sectionType { get; set; }
        /// <summary>
        /// 截面号
        /// </summary>
        public int sectionNumber { get; set; }
        /// <summary>
        /// 节点1
        /// </summary>
        public int startNode { get; set; }
        /// <summary>
        /// 节点2
        /// </summary>
        public int endNode { get; set; }
    }
}
