using Mrf.Photovoltaic.Tools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class DeviceBusiness
    {
        public List<DeviceModule> GetDeviceModuleData(NDPDocument nDPDocument, List<DeviceItem> deviceItemList)
        {
            List<DeviceModule> deviceList = new List<DeviceModule>();
            List<string> codelist = new List<string>();
            try
            {
                if (deviceItemList == null || nDPDocument == null)
                {
                    return deviceList;
                }
                //string codes = "05,02,03,04,01,06,09";
                //foreach (var item in codes.Split(','))
                //{
                //    codelist.Add(item);
                //}
                foreach (var item in deviceItemList)
                {
                    if (!codelist.Contains(item.Code))
                    {
                        codelist.Add(item.Code);
                    }
                }
                codelist.Sort();
                string MatrixCode = GetMatrixCode(codelist);
                DeviceModule dModule = new DeviceModule();
                dModule.Number = nDPDocument.CombinerBox.Count();//汇流箱
                dModule.MatrixCode = MatrixCode;
                deviceList.Add(dModule);
                dModule.Number = nDPDocument.Inverter.Count();//逆变器
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
            for (int i = 0; i < codelist.Count() - 1; i++)
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
    }
}
