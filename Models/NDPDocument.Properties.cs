using Mrf.CSharp.BaseTools;
using Mrf.CSharp.BaseTools.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    ///  NDP文档
    /// </summary>
    public partial class NDPDocument
    {

        /// <summary>
        ///  版本
        /// </summary>
        public string Version { get; set; }



        
        /// <summary>
        ///  公共坐标点
        /// </summary>
        public Point3d CommonCoord { get; set; }



        public List<PvComponents> PvComponents { get; set; }

        /// <summary>
        /// 汇流模式，有四种：
        /// 组串式逆变器-箱变-升压站   4  》  组串—光伏板—组串式逆变器—箱变
        ///汇流箱-箱逆变一体机-升压站   4  》 组串—光伏板—汇流箱—箱逆变一体机
        ///汇流箱-集中式逆变器-箱变-升压站 5 》组串—光伏板—汇流箱—集中式逆变器—箱变
        ///汇流箱-集散式逆变器-箱变-升压站 5 》组串—光伏板—汇流箱—集散式逆变器—箱变
        /// </summary>
        public string ConfluenceMode { get; set; }

        /// <summary>
        /// 层级数量
        /// </summary>
        public int LevelCount { get; set; }
        /// <summary>
        /// 汇流结构
        /// </summary>
        public List<ConfluenceItem> Confluence { get; set; }

        /// <summary>
        /// 光伏组串
        /// </summary>
        public List<PvpItem> Pvp { get; set; }

        /// <summary>
        /// 设备
        /// </summary>
        public List<DeviceItem> Device { get; set; }

        
        /// <summary>
        /// 箱变 是设备中的一部分对象，主要用于出图
        /// </summary>
        public List<DeviceItem> Box { get; set; }= new List<DeviceItem>();


        /// <summary>
        /// 逆变器 是设备中的一部分对象，主要用于出图
        /// </summary>
        public List<DeviceItem> Inverter { get; set; } = new List<DeviceItem>();


        /// <summary>
        /// 汇流箱 是设备中的一部分对象，主要用于出图
        /// </summary>
        public List<DeviceItem> CombinerBox { get; set; } = new List<DeviceItem>();




        /// <summary>
        /// 电缆（小线）
        /// </summary>
        public List<CableItem> Cable { get; set; }


        /// <summary>
        /// 道路
        /// </summary>
        public RoadItem Road { get; set; }




        
        /// <summary>
        /// 主网接地
        /// </summary>
        public MNGrounding MNGrounding { get; set; }


        
        
        /// <summary>
        /// 设备接地
        /// </summary>
        public DvGrounding DvGrounding { get; set; }




        /// <summary>
        /// 垂直接地体
        /// </summary>
        public VBGrounding VBGrounding { get; set; }




        /// <summary>
        /// 信息列表
        /// </summary>
        public List<string> Messages { get; set; } = new List<string>();


        /// <summary>
        /// 
        /// </summary>
        public string TopoGraphy { get; set; }


    }


}
