using System.Collections.Generic;


namespace Mrf.Photovoltaic.Tools.Models
{

    /// <summary>
    /// 汇流区域
    /// </summary>
    public class ConfluenceItem
    {
        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConfluenceMode { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }



        /// <summary>
        /// 上级汇流设备编号
        /// </summary>
        public string PreCode { get; set; }


        /// <summary>
        /// 模型的Revit中的Id
        /// </summary>
        public int Id { get; set; }



        /// <summary>
        /// 接入容量
        /// </summary>
        public double AccessibleCapacity { get; set; }



        ///// <summary>
        ///// 
        ///// </summary>
        //public string Coord { get; set; }



        /// <summary>
        /// 汇流区域
        /// </summary>
        public List<ConfluenceItem> ConfluenceInfos { get; set; }
    }



}

