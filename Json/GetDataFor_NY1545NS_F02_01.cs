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




        #region CommandMethods


        /// <summary>
        /// 获取 NY1545NS-F02-01_1 中的参数数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetDataFor_NY1545NS_F02_01_1()
        {
            //返回值
            Dictionary<string, string> parameterNameAndValueMap = new Dictionary<string, string>();

            //获取参数：总发电单元数量
            int confluenceNumber = 0;

            if (m_nDPDocument.Confluence != null && m_nDPDocument.Confluence.Count > 0)
            {
                confluenceNumber = m_nDPDocument.Confluence.Count;
            }

            parameterNameAndValueMap["ConfluenceNumber"] = confluenceNumber.ToString().PadLeft(2, '0');


            //获取参数：总容量
            double accessibleCapacity = GetAccessibleCapacity(m_nDPDocument.Confluence);

            parameterNameAndValueMap["AccessibleCapacity"] = accessibleCapacity.ToString();



            //获取参数：组件型号列表
            string powerList = GetPowerList(m_nDPDocument.Pvp);
            if (!string.IsNullOrEmpty(powerList))
            {
                parameterNameAndValueMap["PowerList"] = powerList;
            }




            return parameterNameAndValueMap;
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


        /// <summary>
        /// 获取 NY1545NS-F02-01_2 中的参数数据
        /// </summary>
        /// <returns>如果失败，返回空的列表</returns>
        public List<PvpModule> GetDataFromPvp()
        {
            //返回值 用于光伏组串的表格 获取 NY1545NS-F02-01_2 中的参数数据  如果失败，返回空的列表
            List<PvpModule> photovoltaicStringList = new List<PvpModule>();

            //一次申请变量
            //光伏块
            string powerString = "";
            int count = 0;
            //注意：单位转换
            double accessibleCapacity = 0.0;
            string categoryOfsolarCells = "";
            double angle = 0.0;
            string angelString = "";
            string Azimuth = "";
            //string uniqueAzimuth = "";


            foreach (var ipvp in m_nDPDocument.Pvp)
            {
                #region CommandMethods 光伏组件板块
                //数据处理
                powerString = ipvp.PvpCompoInfo.Power + "Wp组件";
                count = ipvp.CNumberPerColumn * ipvp.CNumberPerRow;
                //注意：单位转换
                accessibleCapacity = count * ipvp.PvpCompoInfo.Power / 1000;
                categoryOfsolarCells = ipvp.PvComponents.CategoryOfsolarCells;
                angle = ipvp.Angle.AngleToDegree();
                angelString = GetAngleForModule(angle);
                Azimuth = GetAzimuthForModule(ipvp.Azimuth);

                PvpModule module = photovoltaicStringList.Find(x => x.PowerType == powerString && x.CategoryOfsolarCells == categoryOfsolarCells
                                                                 && x.AngleString == angelString && x.Azimuth == Azimuth);
                if (module != null)
                {
                    module.Count += count;
                    module.AccessibleCapacity += accessibleCapacity;
                }
                else
                {
                    PvpModule newModule = new PvpModule
                    {
                        PowerType = powerString,
                        Count = count,
                        AccessibleCapacity = accessibleCapacity,
                        CategoryOfsolarCells = categoryOfsolarCells,
                        Angle = angle,
                        AngleString = angelString,
                        Azimuth = Azimuth
                    };
                    photovoltaicStringList.Add(newModule);
                }
                #endregion

                #region CommandMethods  太阳电池块
                double powerList = 0.0;                                                     //需不需要判断是否存在该数据
                int sccount = 0;
                string overallDimensions = "";
                string moduleEfficiency = "";
                //数据处理
                powerList = ipvp.PvpCompoInfo.Power;                                                     //需不需要判断是否存在该数据
                sccount = ipvp.CNumberPerColumn * ipvp.CNumberPerRow;
                overallDimensions = ipvp.PvpCompoInfo.Length + "X" + ipvp.PvpCompoInfo.Width + "X" + ipvp.PvpCompoInfo.Thickness;
                moduleEfficiency = GetModuleEfficiencyForModule(powerList, ipvp.PvpCompoInfo.Length, ipvp.PvpCompoInfo.Width);
                //可能需要判断的。。。。
                PvpModule module4 = photovoltaicStringList.Find(x => x.Power == powerList && x.OverallDimensions == overallDimensions && x.ModuleEfficiency == moduleEfficiency);
                if (module4 != null)
                {
                    continue;
                }
                else
                {
                    PvpModule newSCModule = new PvpModule
                    {
                        CategoryOfsolarCells = categoryOfsolarCells,
                        BatteryModuleModel = ipvp.PvComponents.BatteryModuleModel,
                        StandardPeakValue = 0,
                        Power = powerList,
                        PeakVoltage = 0,
                        ShortCircuitCurrent = 0,
                        OpenCircuitVoltage = 0,
                        ModuleEfficiency = moduleEfficiency,
                        SystemVoltageMax = 0,
                        OverallDimensions = overallDimensions,
                        Weight = 0,
                        SCCount = sccount,
                        Factory = null,
                    };
                    photovoltaicStringList.Add(newSCModule);
                }
                #endregion
            }
            return photovoltaicStringList;
        }


        /// <summary>
        /// 获取组件效率
        /// </summary>
        /// <param name="powerlist"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        private string GetModuleEfficiencyForModule(double powerlist, double length, double width)
        {
            string result = (1000 * powerlist / (length * width) * 100).ToString("F1") + "%";
            return result;
        }


        /// <summary>
        /// 获取 NY1545NS-F02-01_3 中的参数数据
        /// </summary>
        /// <returns>如果失败，返回空的映射</returns>
        public Dictionary<string, string> GetDataFor_NY1545NS_F02_01_3(List<PvpModule> moduleLst)
        {
            //返回值
            Dictionary<string, string> parameterNameAndValueMap = new Dictionary<string, string>();

            if (moduleLst == null || moduleLst.Count == 0)
            {
                return parameterNameAndValueMap;
            }


            List<string> dataLst = new List<string>();

            foreach (var item in moduleLst)
            {

                if (!dataLst.Contains(item.AngleString))
                {
                    dataLst.Add(item.AngleString);
                }
            }

            if (dataLst.Count > 0)
            {
                string parameterName = "Angle";
                parameterNameAndValueMap[parameterName] = string.Join("、", dataLst);
            }

            return parameterNameAndValueMap;
        }



        /// <summary>
        ///获取组件倾角
        /// </summary>
        /// <param name="angel"></param>
        /// <returns></returns>
        private string GetAngleForModule(double angel)
        {
            //保留两位小数
            //string result = "固定式" + angel + "°";
            string result = "固定式" + angel.ToString("F0") + "°";

            return result;
        }



        /// <summary>
        /// 获取方位角
        /// </summary>
        /// <param name="azimuth"></param>
        /// <returns></returns>
        private string GetAzimuthForModule(double azimuth)
        {
            azimuth = azimuth.AngleToDegree();
            string azimuthString = azimuth.ToString("F0");

            //string 


            //用字符串，startwith
            string result;
            if (azimuthString == "0")
            {
                result = "南";
            }
            else if (azimuthString.StartsWith("-"))
            {
                result = "南偏东" + azimuthString + "°";
            }
            else
            {
                result = "南偏西" + azimuthString + "°";
            }
            return result;
        }



        public List<DeviceModule> GetDataFromDevice()
        {
            List<DeviceModule> deviceList = new List<DeviceModule>();
            List<string> codelist = new List<string>();
            try
            {
                if (m_nDPDocument.Device == null || m_nDPDocument.Device.Count == 0)
                {
                    return deviceList;
                }
                //string codes = "05,02,03,04,01,06,09";
                //foreach (var item in codes.Split(','))
                //{
                //    codelist.Add(item);
                //}
                foreach (var item in m_nDPDocument.Device)
                {
                    if (!codelist.Contains(item.Code))
                    {
                        codelist.Add(item.Code);
                    }
                }
                codelist.Sort();
                string MatrixCode = GetMatrixCode(codelist);
                DeviceModule dModule = new DeviceModule();
                dModule.Number = m_nDPDocument.CombinerBox.Count();//汇流箱
                dModule.MatrixCode = MatrixCode;
                deviceList.Add(dModule);
                dModule.Number = m_nDPDocument.Inverter.Count();//逆变器
                deviceList.Add(dModule);
            }
            catch (Exception e)
            {
            }
            return deviceList;
        }

        public string GetMatrixCode(List<string> codelist)
        {
            string MatrixCode = string.Empty;
            codelist.Sort();
            bool isContinuous = true;
            for (int i = 0; i < codelist.Count() - 1; i++)      //调用了using System.Linq;
            {
                if (Convert.ToInt32(codelist[i + 1]) - Convert.ToInt32(codelist[i]) != 1)
                {
                    isContinuous = false;
                    break;
                }
            }
            if (isContinuous)
            {
                MatrixCode = codelist.First() + "～" + codelist.Last();
            }
            else
            {
                MatrixCode = string.Join("、", codelist);
            }
            return MatrixCode;
        }






        /// <summary>
        /// 获取参数：组件型号列表
        /// </summary>
        /// <param name="pvp"></param>
        /// <returns></returns>
        private string GetPowerList(List<PvpItem> pvp)
        {
            string powerListString = "";

            if (pvp != null && pvp.Count > 0)
            {
                List<string> powerLst = new List<string>();

                foreach (var pvpItem in pvp)
                {
                    string power = pvpItem.PvpCompoInfo.Power.ToString() + "Wp";
                    if (!powerLst.Contains(power))
                    {
                        powerLst.Add(power);
                    }
                }

                powerListString = string.Join(",", powerLst);
            }

            return powerListString;
        }





















        #endregion



        #region Helper Methods






        /// <summary>
        /// 获取参数：总容量
        /// </summary>
        /// <param name="confluence"></param>
        /// <returns></returns>
        private double GetAccessibleCapacity(List<ConfluenceItem> confluence)
        {
            //返回值
            double accessibleCapacity = 0;

            if (confluence != null && confluence.Count > 0)
            {
                foreach (ConfluenceItem confluenceItem in confluence)
                {
                    accessibleCapacity += confluenceItem.AccessibleCapacity;
                }

                //单位由wp转换为kwp
                accessibleCapacity /= 1000;
            }

            return accessibleCapacity;
        }











        #endregion


        #region Properties


        #endregion




    }
}