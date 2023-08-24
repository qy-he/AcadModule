using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class Section
    {
        /// <summary>
        /// 截面类型号
        /// </summary>
        public int SectionTypeId { get; set; }
        /// <summary>
        /// 截面号
        /// </summary>
        public int SectionId { get; set; }
        /// <summary>
        /// 截面类型
        /// </summary>
        public string SectionType { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string SectionName { get; set; }
    }
}
