using cad01;
using cad01.module;
using Mrf.CSharp.BaseTools.Extension;
using Mrf.Photovoltaic.Tools.Models;
//using RevitCAD.光伏工具.OutputDrawing.PowerGenerationDrawing.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RevitCAD.光伏工具.OutputDrawing.PowerGenerationDrawing.Utils
{
    /// <summary>
    ///获取 NY1545NS-F02-01 相关的数据
    /// </summary>
    public class GetDataFor_NY1545NS_F02_01
    {



        #region Private Variables

        NDPDocument m_nDPDocument;


        #endregion



        #region Default Constructor




        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nDPDocument">文档对象</param>
        public GetDataFor_NY1545NS_F02_01(NDPDocument nDPDocument)
        {
            m_nDPDocument = nDPDocument;
        }

        #endregion




        public Dictionary<string, List<string>> GetCrystalSilicon()
        {
            Dictionary<string, List<string>> dictlist = new Dictionary<string, List<string>>();
            List<PvComponents> pvList = m_nDPDocument.PvComponents;
            Dictionary<int, string> pvdict = new Dictionary<int, string>();
            foreach (PvComponents pv in pvList)
            {
                pvdict.Add(pv.Id, pv.CategoryOfsolarCells + "组件");
            }



            List<PvpItem> PvpList = m_nDPDocument.Pvp;
            foreach (PvpItem pvp in PvpList)
            {
                string key = pvp.CNumberPerColumn + "x" + pvp.CNumberPerRow;
                if (!pvdict.ContainsKey(pvp.Id))
                {
                    continue;
                }
                string value = key + pvdict[pvp.Id];
                if (!dictlist.ContainsKey(key))
                {
                    List<string> list = new List<string>();
                    list.Add(value);
                    dictlist.Add(key, list);
                }
                else if (!dictlist[key].Contains(value))
                {
                    dictlist[key].Add(value);
                }
            }
            return dictlist;
        }



        //"2x14"    "2x14单列单晶硅组件"
//2x28长单列单晶硅组件


















        public Dictionary<string,string> GetConfiuence(List<DeviceItem> deviceItems)
        {
            Dictionary<string, string> Confiuence = new Dictionary<string, string>();
            List<string> ModeList = new List<string>();
            foreach (DeviceItem item in deviceItems)
            {
                string ConfluenceMode = item.ConfluenceMode.Substring(item.ConfluenceMode.IndexOf('-') + 1);
                if (!ModeList.Contains(ConfluenceMode))
                {
                    ModeList.Add(ConfluenceMode);
                }
            }
            Confiuence.Add("ConfluenceMode", string.Join("、", ModeList));

            double accessibleCapacity = 0;
            List<ConfluenceItem> confluenceList = m_nDPDocument.Confluence;
            foreach (ConfluenceItem item in confluenceList)
            {
                accessibleCapacity += item.AccessibleCapacity;
            }
            Confiuence.Add("AccessibleCapacity", accessibleCapacity.ToString());
            Confiuence.Add("ConfluenceCount", confluenceList.Count.ToString());

            return Confiuence;
        }


        public Dictionary<string, string> GetDeviceItem(DeviceItem deviceItem)
        {
            Dictionary<string, string> DeviceItem = new Dictionary<string, string>();
            DeviceItem.Add("ConfluenceMode", "");
            DeviceItem.Add("SubDeviceCount", "");
            DeviceItem.Add("TransformerPower", "");
            DeviceItem.Add("Code", "");
            if (deviceItem != null)
            {
                string ConfluenceMode = deviceItem.ConfluenceMode.Substring(deviceItem.ConfluenceMode.IndexOf('-') + 1);
                DeviceItem["ConfluenceMode"] = ConfluenceMode;
                DeviceItem["SubDeviceCount"] = deviceItem.SubDeviceItems.Count.ToString();
                DeviceItem["TransformerPower"] = deviceItem.TransformerPower.ToString();
                DeviceItem["Code"] = deviceItem.Code;
            }
            return DeviceItem;
        }

        public Dictionary<string, string> GetDeviceItemCode(DeviceItem deviceItem)
        {
            Dictionary<string, string> DeviceItem = new Dictionary<string, string>();
            DeviceItem.Add("Code", "");
            DeviceItem.Add("ConfluenceMode", "");
            if (deviceItem != null)
            {
                string ConfluenceMode = deviceItem.ConfluenceMode.Substring(deviceItem.ConfluenceMode.IndexOf('-') + 1);
                DeviceItem["ConfluenceMode"] = ConfluenceMode;
                DeviceItem["Code"] = deviceItem.Code;
            }
            return DeviceItem;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetDepth()
        {
            //返回值
            Dictionary<string, string> GroundingDepth = new Dictionary<string, string>();

            GroundingDepth.Add("MNGroundingDepth", "");
            GroundingDepth.Add("VBGroundingDepth", "");
            DvGrounding dvGrounding = m_nDPDocument.DvGrounding;
            if (dvGrounding != null)
            {
                if (dvGrounding.JvbroundingInfos != null && dvGrounding.JvbroundingInfos.Count > 0)
                {
                    DvGroundingInfoItem dvGroundingInfoItem = dvGrounding.JvbroundingInfos[0];
                    GroundingDepth["MNGroundingDepth"] = dvGroundingInfoItem.Depth.ToString();
                }
            }

            VBGrounding vBGrounding = m_nDPDocument.VBGrounding;
            if (vBGrounding != null)
            {
                if (vBGrounding.VBGroundingInfos != null && vBGrounding.VBGroundingInfos.Count > 0)
                {
                    VBGroundingInfoItem vBGroundingInfoItem = vBGrounding.VBGroundingInfos[0];
                    GroundingDepth["VBGroundingDepth"] = vBGroundingInfoItem.Depth.ToString();
                }
            }

            return GroundingDepth;
        }


        public List<GroundingInfos> GetGroundingInfos()
        {
            List<GroundingInfos> groundinglist = new List<GroundingInfos>();
            GroundingInfos groundingInfos;

            //主网接地体
            MNGrounding mNGrounding = m_nDPDocument.MNGrounding;
            groundingInfos = new GroundingInfos();
            if (mNGrounding != null)
            {
                if (mNGrounding.MNGroundingInfos != null && mNGrounding.MNGroundingInfos.Count > 0)
                {
                    MNGroundingInfoItem mNGroundingInfoItem = mNGrounding.MNGroundingInfos[0];
                    groundingInfos = SetGroundingInfos("主网接地体", mNGroundingInfoItem.Material + mNGroundingInfoItem.Model + mNGroundingInfoItem.Specification, "米", mNGrounding.TotalLength, "");
                    groundinglist.Add(groundingInfos);
                }
                else
                {
                    groundinglist.Add(groundingInfos);
                }
            }
            else
            {
                groundinglist.Add(groundingInfos);
            }

            //设备接地体
            DvGrounding dvGrounding = m_nDPDocument.DvGrounding;
            groundingInfos = new GroundingInfos();
            if (dvGrounding != null)
            {
                if (dvGrounding.JvbroundingInfos != null && dvGrounding.JvbroundingInfos.Count > 0)
                {
                    DvGroundingInfoItem dvGroundingInfoItem = dvGrounding.JvbroundingInfos[0];
                    groundingInfos = SetGroundingInfos("设备接地体", dvGroundingInfoItem.Material + dvGroundingInfoItem.Model + dvGroundingInfoItem.Specification, "米", dvGrounding.TotalLength, "包含箱变侧数量");
                    groundinglist.Add(groundingInfos);
                }
                else
                {
                    groundinglist.Add(groundingInfos);
                }
            }
            else
            {
                groundinglist.Add(groundingInfos);
            }

            //垂直接地体
            VBGrounding vBGrounding = m_nDPDocument.VBGrounding;
            groundingInfos = new GroundingInfos();
            if (vBGrounding != null)
            {
                if (vBGrounding.VBGroundingInfos != null && vBGrounding.VBGroundingInfos.Count > 0)
                {
                    VBGroundingInfoItem vBGroundingInfoItem = vBGrounding.VBGroundingInfos[0];
                    groundingInfos = SetGroundingInfos("垂直接地体", vBGroundingInfoItem.Material + vBGroundingInfoItem.Model + vBGroundingInfoItem.Specification, "根", vBGrounding.TotalLength, "包含相应的配套附件");
                    groundinglist.Add(groundingInfos);
                }
                else
                {
                    groundinglist.Add(groundingInfos);
                }
            }
            else
            {
                groundinglist.Add(groundingInfos);
            }

            return groundinglist;
        }


        public GroundingInfos SetGroundingInfos(string GroundingName,string ModelSpecification,string units,double TotalLength,string Remark)
        {
            GroundingInfos groundingInfos = new GroundingInfos();
            groundingInfos.SerialNumber = "";
            groundingInfos.legeng = "";
            groundingInfos.GroundingName = GroundingName;
            groundingInfos.ModelSpecification = ModelSpecification;
            groundingInfos.units = units;
            groundingInfos.TotalLength = TotalLength;
            groundingInfos.Remark = Remark;
            return groundingInfos;
        }
    }
}