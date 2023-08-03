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


        //public void a()
        //{
        //    //第一个参数是行
        //    //第二个参数列
        //    //第三个参数最后一行
        //    //第四个参数最后一列

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "图例", "名称", "型号及规范", "单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "图例", "名称", "型号及规范", "单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "名称", "型号及规范","单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "名称", "型号及规范","单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "序号", "名称", "材料或规范", "单位", "数量", "备注" },
        //    };


        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "名称", "规范", "材料", "单位", "数量", "重量（公斤）","","参见图号及备注" },
        //        new List<string>{ "", "", "", "", "", "", "单重","总重","" },
        //    };

        //    tableTool.MergeCellRange(tableId1, 0, 0, 1, 0);//编号
        //    tableTool.MergeCellRange(tableId1, 0, 1, 1, 1);//名称
        //    tableTool.MergeCellRange(tableId1, 0, 2, 1, 2);//规范
        //    tableTool.MergeCellRange(tableId1, 0, 3, 1, 3);//材料
        //    tableTool.MergeCellRange(tableId1, 0, 4, 1, 4);//单位
        //    tableTool.MergeCellRange(tableId1, 0, 5, 1, 5);//数量
        //    tableTool.MergeCellRange(tableId1, 0, 6, 0, 7);//重量（公斤）
        //    tableTool.MergeCellRange(tableId1, 0, 8, 1, 8);//参见图号及备注



        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "图例","名称", "型号及规范", "单位", "数量", "备注" },
        //    };


        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "图例","名称", "型号及规范", "单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "图例","名称", "型号及规范", "单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "图例","名称", "型号及规范", "单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "名称及规范", "总量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "序号", "名称", "材料或规范", "单位","数量","备注" },
        //    };





















        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "序号", "设备名称", "型号及规范", "单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "编号", "名称", "型号规格", "单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "序号", "名称", "型号及规范", "单位", "数量", "备注" },
        //    };

        //    List<List<string>> dataArrLst = new List<List<string>>
        //    {
        //        new List<string>{ "序号", "名称", "规格", "单位", "数量", "质量（Kg）","","","备注" },
        //        new List<string>{ "", "", "", "", "", "一件", "小计","合计","" },
        //    };


        //    tableTool.MergeCellRange(tableId1, 0, 0, 1, 0);//序号
        //    tableTool.MergeCellRange(tableId1, 0, 1, 1, 1);//名称
        //    tableTool.MergeCellRange(tableId1, 0, 2, 1, 2);//规格
        //    tableTool.MergeCellRange(tableId1, 0, 3, 1, 3);//单位
        //    tableTool.MergeCellRange(tableId1, 0, 4, 1, 4);//数量
        //    tableTool.MergeCellRange(tableId1, 0, 5, 1, 7);//质量（Kg）
        //    tableTool.MergeCellRange(tableId1, 0, 8, 1, 8);//备注









        //}






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
