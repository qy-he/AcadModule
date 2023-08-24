using AutoCAD;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using DotNetARX;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AcadModule
{
    public class SolarPanelFunc
    {
        #region 测试代码
        ///// <summary>
        ///// 创建光伏支架
        ///// </summary>
        //public static void CreateSolarPanelBracket(string jsonFile)
        //{
        //    Point3d basePoint = new Point3d(0, 0, 0);
        //    PointTool pointTool = new PointTool();
        //    SolarPanel solarPanel = Parsingjson(jsonFile);
        //    double InclineAngle = solarPanel.InclineAngle;
        //    if (solarPanel == null)
        //    {
        //        return;
        //    }
        //    Dictionary<string, List<string>> dictionary = GetSectionAndValueMapFromFile(solarPanel.FileName);
        //    if (dictionary.Count == 0)
        //    {
        //        return;
        //    }
        //    Dictionary<int, Point3d> pdict = new Dictionary<int, Point3d>();
        //    if (dictionary.ContainsKey("*NODE"))
        //    {
        //        List<string> list = dictionary["*NODE"];
        //        foreach (var item in list)
        //        {
        //            string[] nodes = item.Split(',');
        //            if (nodes.Count() > 3)
        //            {
        //                pdict.Add(Convert.ToInt32(nodes[0]), new Point3d(Convert.ToDouble(nodes[1]), Convert.ToDouble(nodes[2]), Convert.ToDouble(nodes[3])));
        //            }
        //        }
        //    }
        //    List<Eleline> Linelist = new List<Eleline>();
        //    if (dictionary.ContainsKey("*ELE_LINE"))
        //    {
        //        List<string> list = dictionary["*ELE_LINE"];
        //        foreach (var item in list)
        //        {
        //            string[] Lines = item.Split(',');
        //            if (Lines.Count() > 7)
        //            {
        //                Eleline line = new Eleline();
        //                line.unitNumber = Convert.ToInt32(Lines[0]);
        //                line.unitType = Lines[1].Trim();
        //                line.materialNumber = Convert.ToInt32(Lines[2]);
        //                line.sectionType = Convert.ToInt32(Lines[3]);
        //                line.sectionNumber = Convert.ToInt32(Lines[4]);
        //                line.startNode = Convert.ToInt32(Lines[5]);
        //                line.endNode = Convert.ToInt32(Lines[6]);
        //                Linelist.Add(line);
        //            }
        //        }
        //    }
        //    List<Layeraxis> Layeraxislist = new List<Layeraxis>();
        //    if (dictionary.ContainsKey("*LAYERAXIS"))
        //    {
        //        List<string> list = dictionary["*LAYERAXIS"];
        //        foreach (var item in list)
        //        {
        //            string[] Layeraxiss = item.Split(',');
        //            if (Layeraxiss.Count() > 2)
        //            {
        //                Layeraxis layeraxis = new Layeraxis();
        //                layeraxis.unitNumber = Convert.ToInt32(Layeraxiss[0]);
        //                layeraxis.levelNumber = Layeraxiss[1].Trim();
        //                Layeraxislist.Add(layeraxis);
        //            }
        //        }
        //    }
        //    List<Section> sectionList = new List<Section>();
        //    if (dictionary.ContainsKey("*SECTION"))
        //    {
        //        List<string> list = dictionary["*SECTION"];
        //        foreach (var item in list)
        //        {
        //            string[] Sections = item.Split(',');
        //            if (Sections.Count() > 5)
        //            {
        //                Section section = new Section();
        //                section.SectionTypeId = Convert.ToInt32(Sections[0]);
        //                section.SectionId = Convert.ToInt32(Sections[1]);
        //                section.SectionType = Sections[2];
        //                section.Specification = Sections[3];
        //                section.SectionName = Sections[4];
        //                sectionList.Add(section);
        //            }
        //        }
        //    }

        //    double height = 0;

        //    List<Eleline> eleList = Linelist.Where(x => x.unitNumber == 21).ToList();
        //    if (eleList.Count > 0)
        //    {
        //        Point3d startNode = pdict[eleList[0].startNode];
        //        Point3d endNode = pdict[eleList[0].endNode];
        //        height = GetDistanceBetweenTwoPoint(startNode, endNode);
        //        string filePath = @"C:\Users\heqianyong\Desktop\光伏支架\组件-带中心线厚度.dwg";
        //        Dictionary<string, double> propertyNameAndValueMap = new Dictionary<string, double>();
        //        propertyNameAndValueMap.Add("高度", height);
        //        propertyNameAndValueMap.Add("宽度", 160);
        //        propertyNameAndValueMap.Add("厚度", 140);
        //        BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, basePoint, propertyNameAndValueMap);
        //        filePath = @"C:\Users\heqianyong\Desktop\光伏支架\组件.dwg";
        //        propertyNameAndValueMap = new Dictionary<string, double>();
        //        propertyNameAndValueMap.Add("高度", 10);
        //        propertyNameAndValueMap.Add("宽度", 200);
        //        Point3d insertPoint = new Point3d(basePoint.X, basePoint.Y - 5, 0);
        //        BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, propertyNameAndValueMap);
        //    }
        //    List<double> ltList = new List<double>();
        //    List<Layeraxis> xlList = Layeraxislist.Where(x => x.unitNumber == 1).ToList();
        //    if (xlList.Count > 0)
        //    {
        //        List<Eleline> elList = Linelist.Where(x => x.unitNumber == xlList[0].unitNumber).ToList();
        //        if (elList.Count > 0)
        //        {
        //            List<Section> sList = sectionList.Where(x => x.SectionTypeId == elList[0].sectionType && x.SectionId == elList[0].sectionNumber).ToList();
        //            if (sList.Count > 0)
        //            {
        //                string Specification = sList[0].Specification.Trim().Substring(1);
        //                string[] Specifications = Specification.Split('x');
        //                for (int i = 0; i < Specifications.Count(); i++)
        //                {
        //                    ltList.Add(Convert.ToDouble(Specifications[i]));
        //                }
        //            }
        //        }
        //    }

        //    Point3d qpoint = new Point3d();
        //    Point3d hpoint = new Point3d();
        //    xlList = Layeraxislist.Where(x => x.unitNumber >= 49 && x.unitNumber <= 54).ToList();
        //    if (xlList.Count > 0)
        //    {
        //        double sumdistance = 0;
        //        List<double> xldistance = new List<double>();
        //        foreach (var item in xlList)
        //        {
        //            List<Eleline> elList = Linelist.Where(x => x.unitNumber == item.unitNumber).ToList();
        //            if (elList.Count > 0)
        //            {

        //                Point3d startNode = pdict[elList[0].startNode];
        //                Point3d endNode = pdict[elList[0].endNode];
        //                double distance = GetDistanceBetweenTwoPoint(startNode, endNode);
        //                sumdistance += distance;
        //                xldistance.Add(distance);
        //            }
        //        }
        //        string filePath = @"C:\Users\heqianyong\Desktop\光伏支架\组件-斜梁.dwg";
        //        Dictionary<string, double> propertyNameAndValueMap = new Dictionary<string, double>();
        //        propertyNameAndValueMap.Add("距离1", sumdistance + 240);
        //        Point3d insertPoint = new Point3d(basePoint.X, basePoint.Y+ height - 53, 0);
        //        BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, Math.PI * InclineAngle / 180, insertPoint, propertyNameAndValueMap);

        //        double lsdistance = sumdistance / 2.0  - xldistance[5];
        //        qpoint = pointTool.GetPolarPoint(insertPoint,lsdistance, Math.PI * (180+ InclineAngle) / 180);
        //        lsdistance = sumdistance / 2.0 - xldistance[0];
        //        hpoint = pointTool.GetPolarPoint(insertPoint, lsdistance, Math.PI * InclineAngle / 180);



        //        filePath = @"C:\Users\heqianyong\Desktop\光伏支架\檩条剖面.dwg";
        //        string jdltFilePath = @"C:\Users\heqianyong\Desktop\光伏支架\组件-檩托.dwg";
        //        string lsFilePath = @"C:\Users\heqianyong\Desktop\光伏支架\螺栓1.dwg";
        //        string gfFilePath = @"C:\Users\heqianyong\Desktop\光伏支架\组件.dwg";
        //        double ltdistance = sumdistance / 2.0;
        //        Point3d ltpmpoint = InsertQLtDwgFile(filePath, ltdistance, insertPoint, propertyNameAndValueMap, pointTool, InclineAngle, ltList);
        //        double jgltdistance = ltList[1] / 2.0;
        //        Point3d jdltpoint = pointTool.GetPolarPoint(ltpmpoint, jgltdistance, Math.PI * (180 + InclineAngle) / 180);
        //        double jgltdistance1 = ltList[0] / 2.0+ 10;
        //        jdltpoint = pointTool.GetPolarPoint(jdltpoint, jgltdistance1, Math.PI * (180 + InclineAngle + 90) / 180);
        //        propertyNameAndValueMap = new Dictionary<string, double>();
        //        propertyNameAndValueMap.Add("距离1", jgltdistance1);
        //        BlockFunc.InsertDwgFile(jdltFilePath, Path.GetFileNameWithoutExtension(jdltFilePath), 0.1, Math.PI * InclineAngle / 180, jdltpoint, propertyNameAndValueMap);

        //        //螺栓1
        //        propertyNameAndValueMap.Add("长度", ltList[3]);
        //        lsdistance = ltList[0] / 2.0 - ltList[3];
        //        Point3d lsPoint = pointTool.GetPolarPoint(ltpmpoint, lsdistance, Math.PI * (InclineAngle + 90) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * (180 + InclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);
        //        propertyNameAndValueMap["长度"] =10+ltList[3];
        //        lsdistance = ltList[1] / 2.0 - ltList[3];
        //        lsPoint = pointTool.GetPolarPoint(ltpmpoint, lsdistance, Math.PI * (180 + InclineAngle) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * InclineAngle / 180, lsPoint, propertyNameAndValueMap);
        //        propertyNameAndValueMap["长度"] = 10;
        //        lsdistance = 56;
        //        lsPoint = pointTool.GetPolarPoint(jdltpoint, lsdistance, Math.PI * (180 + InclineAngle) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * (180 + InclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);

        //        //光伏组件
        //        double gfzjwidth = solarPanel.ATotalWidth - solarPanel.BoltLengthDistance;
        //        double gfzjdistance = solarPanel.BoltLengthDistance / 2.0;
        //        Point3d gfpoint = pointTool.GetPolarPoint(ltpmpoint, (ltList[0] + 30)/ 2.0, Math.PI * (InclineAngle + 90) / 180);
        //        gfpoint = pointTool.GetPolarPoint(gfpoint, gfzjdistance, Math.PI * InclineAngle / 180);
        //        propertyNameAndValueMap.Add("高度",30);
        //        propertyNameAndValueMap.Add("宽度", gfzjwidth + solarPanel.BoltLengthDistance);
        //        BlockFunc.InsertDwgFile(gfFilePath, Path.GetFileNameWithoutExtension(gfFilePath), 1, Math.PI * InclineAngle / 180, gfpoint, propertyNameAndValueMap);


        //        ltdistance = xldistance[3];
        //        ltpmpoint =InsertQLtDwgFile(filePath, ltdistance, insertPoint, propertyNameAndValueMap, pointTool, InclineAngle, ltList);
        //        jgltdistance = ltList[1] / 2.0;
        //        jdltpoint = pointTool.GetPolarPoint(ltpmpoint, jgltdistance, Math.PI * (180 + InclineAngle) / 180);
        //        jgltdistance1 = ltList[0] / 2.0 + 10;
        //        jdltpoint = pointTool.GetPolarPoint(jdltpoint, jgltdistance1, Math.PI * (180 + InclineAngle + 90) / 180);
        //        propertyNameAndValueMap = new Dictionary<string, double>();
        //        propertyNameAndValueMap.Add("距离1", jgltdistance1);
        //        BlockFunc.InsertDwgFile(jdltFilePath, Path.GetFileNameWithoutExtension(jdltFilePath), 0.1, Math.PI * InclineAngle / 180, jdltpoint, propertyNameAndValueMap);

        //        propertyNameAndValueMap.Add("长度", ltList[3]);
        //        lsdistance = ltList[0] / 2.0 - ltList[3];
        //        lsPoint = pointTool.GetPolarPoint(ltpmpoint, lsdistance, Math.PI * (InclineAngle + 90) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * (180 + InclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);
        //        propertyNameAndValueMap["长度"] = 10 + ltList[3];
        //        lsdistance = ltList[1] / 2.0 - ltList[3];
        //        lsPoint = pointTool.GetPolarPoint(ltpmpoint, lsdistance, Math.PI * (180 + InclineAngle) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * InclineAngle / 180, lsPoint, propertyNameAndValueMap);
        //        propertyNameAndValueMap["长度"] = 10;
        //        lsdistance = 56;
        //        lsPoint = pointTool.GetPolarPoint(jdltpoint, lsdistance, Math.PI * (180 + InclineAngle) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * (180 + InclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);


        //        ltdistance = xldistance[2];
        //        ltpmpoint =InsertHLtDwgFile(filePath, ltdistance, insertPoint, propertyNameAndValueMap, pointTool, InclineAngle, ltList);
        //        jgltdistance = ltList[1] / 2.0;
        //        jdltpoint = pointTool.GetPolarPoint(ltpmpoint, jgltdistance, Math.PI * (180 + InclineAngle) / 180);
        //        jgltdistance1 = ltList[0] / 2.0 + 10;
        //        jdltpoint = pointTool.GetPolarPoint(jdltpoint, jgltdistance1, Math.PI * (180 + InclineAngle + 90) / 180);
        //        propertyNameAndValueMap = new Dictionary<string, double>();
        //        propertyNameAndValueMap.Add("距离1", jgltdistance1);
        //        BlockFunc.InsertDwgFile(jdltFilePath, Path.GetFileNameWithoutExtension(jdltFilePath), 0.1, Math.PI * InclineAngle / 180, jdltpoint, propertyNameAndValueMap);

        //        propertyNameAndValueMap.Add("长度", ltList[3]);
        //        lsdistance = ltList[0] / 2.0 - ltList[3];
        //        lsPoint = pointTool.GetPolarPoint(ltpmpoint, lsdistance, Math.PI * (InclineAngle + 90) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * (180 + InclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);
        //        propertyNameAndValueMap["长度"] = 10 + ltList[3];
        //        lsdistance = ltList[1] / 2.0 - ltList[3];
        //        lsPoint = pointTool.GetPolarPoint(ltpmpoint, lsdistance, Math.PI * (180 + InclineAngle) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * InclineAngle / 180, lsPoint, propertyNameAndValueMap);
        //        propertyNameAndValueMap["长度"] = 10;
        //        lsdistance = 56;
        //        lsPoint = pointTool.GetPolarPoint(jdltpoint, lsdistance, Math.PI * (180 + InclineAngle) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * (180 + InclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);

        //        ltdistance = sumdistance / 2.0;
        //        ltpmpoint =InsertHLtDwgFile(filePath, ltdistance, insertPoint, propertyNameAndValueMap, pointTool, InclineAngle, ltList);
        //        jgltdistance = ltList[1] / 2.0;
        //        jdltpoint = pointTool.GetPolarPoint(ltpmpoint, jgltdistance, Math.PI * (180 + InclineAngle) / 180);
        //        jgltdistance1 = ltList[0] / 2.0 + 10;
        //        jdltpoint = pointTool.GetPolarPoint(jdltpoint, jgltdistance1, Math.PI * (180 + InclineAngle + 90) / 180);
        //        propertyNameAndValueMap = new Dictionary<string, double>();
        //        propertyNameAndValueMap.Add("距离1", jgltdistance1);
        //        BlockFunc.InsertDwgFile(jdltFilePath, Path.GetFileNameWithoutExtension(jdltFilePath), 0.1, Math.PI * InclineAngle / 180, jdltpoint, propertyNameAndValueMap);

        //        //螺栓1
        //        propertyNameAndValueMap.Add("长度", ltList[3]);
        //        lsdistance = ltList[0] / 2.0 - ltList[3];
        //        lsPoint = pointTool.GetPolarPoint(ltpmpoint, lsdistance, Math.PI * (InclineAngle + 90) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * (180 + InclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);
        //        propertyNameAndValueMap["长度"] = 10 + ltList[3];
        //        lsdistance = ltList[1] / 2.0 - ltList[3];
        //        lsPoint = pointTool.GetPolarPoint(ltpmpoint, lsdistance, Math.PI * (180 + InclineAngle) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * InclineAngle / 180, lsPoint, propertyNameAndValueMap);
        //        propertyNameAndValueMap["长度"] = 10;
        //        lsdistance = 56;
        //        lsPoint = pointTool.GetPolarPoint(jdltpoint, lsdistance, Math.PI * (180 + InclineAngle) / 180);
        //        BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 0.1, Math.PI * (180 + InclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);


        //        //光伏组件
        //        gfpoint = pointTool.GetPolarPoint(ltpmpoint, (ltList[0] + 30) / 2.0, Math.PI * (InclineAngle + 90) / 180);
        //        gfpoint = pointTool.GetPolarPoint(gfpoint, gfzjdistance, Math.PI * (InclineAngle+180) / 180);
        //        propertyNameAndValueMap.Add("高度", 30);
        //        propertyNameAndValueMap.Add("宽度", gfzjwidth + solarPanel.BoltLengthDistance);
        //        BlockFunc.InsertDwgFile(gfFilePath, Path.GetFileNameWithoutExtension(gfFilePath), 1, Math.PI * InclineAngle / 180, gfpoint, propertyNameAndValueMap);
        //    }

        //    List<double> lzlist = new List<double>();
        //    xlList = Layeraxislist.Where(x => x.unitNumber >= 25 && x.unitNumber <= 26).ToList();
        //    if (xlList.Count > 0)
        //    {
        //        double sumdistance = 0;
        //        foreach (var item in xlList)
        //        {
        //            List<Eleline> elList = Linelist.Where(x => x.unitNumber == item.unitNumber).ToList();
        //            if (elList.Count > 0)
        //            {
        //                Point3d startNode = pdict[elList[0].startNode];
        //                Point3d endNode = pdict[elList[0].endNode];
        //                double distance = GetDistanceBetweenTwoPoint(startNode, endNode);
        //                sumdistance += distance;
        //                lzlist.Add(distance);
        //            }
        //        }
        //        string filePath = @"C:\Users\heqianyong\Desktop\光伏支架\基础.dwg";
        //        Dictionary<string, double> propertyNameAndValueMap = new Dictionary<string, double>();
        //        propertyNameAndValueMap.Add("距离1", 300);
        //        propertyNameAndValueMap.Add("距离2", sumdistance);
        //        Point3d insertPoint = new Point3d(basePoint.X, basePoint.Y - 10 + 3000 - sumdistance, 0);
        //        BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1.0/3, 0, insertPoint, propertyNameAndValueMap);


        //        filePath = @"C:\Users\heqianyong\Desktop\光伏支架\组件-抱箍.dwg";
        //        propertyNameAndValueMap = new Dictionary<string, double>();
        //        propertyNameAndValueMap.Add("距离1", 380);
        //        propertyNameAndValueMap.Add("距离2", 90);
        //        propertyNameAndValueMap.Add("距离3", 55);
        //        propertyNameAndValueMap.Add("距离4", 90);
        //        propertyNameAndValueMap.Add("距离5", 55);
        //        propertyNameAndValueMap.Add("距离6", 70);
        //        insertPoint = new Point3d(basePoint.X, basePoint.Y - lzlist[0], 0);
        //        BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1.0 / 3.0, 0, insertPoint, propertyNameAndValueMap);
        //    }


        //    xlList = Layeraxislist.Where(x => x.unitNumber == 33).ToList();
        //    if (xlList.Count > 0)
        //    {
        //        double distance = 0;
        //        foreach (var item in xlList)
        //        {
        //            List<Eleline> elList = Linelist.Where(x => x.unitNumber == item.unitNumber).ToList();
        //            if (elList.Count > 0)
        //            {
        //                Point3d startNode = pdict[elList[0].startNode];
        //                Point3d endNode = pdict[elList[0].endNode];
        //                distance += GetDistanceBetweenTwoPoint(startNode, endNode);
        //            }
        //        }
        //        string filePath = @"C:\Users\heqianyong\Desktop\光伏支架\组件-前斜撑.dwg";
        //        Dictionary<string, double> propertyNameAndValueMap = new Dictionary<string, double>();
        //        Point3d insertPoint = new Point3d(basePoint.X - 190 - 90, basePoint.Y - lzlist[0], 0);

        //        distance = GetDistanceBetweenTwoPoint(insertPoint, qpoint);
        //        propertyNameAndValueMap.Add("距离1", distance + 80);
        //        double rotation = Math.PI * (180 - Getrotation(insertPoint, qpoint)) / 180;
        //        BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1.0/3, rotation, insertPoint, propertyNameAndValueMap);
        //    }
        //    xlList = Layeraxislist.Where(x => x.unitNumber == 37).ToList();
        //    if (xlList.Count > 0)
        //    {
        //        double distance = 0;
        //        foreach (var item in xlList)
        //        {
        //            List<Eleline> elList = Linelist.Where(x => x.unitNumber == item.unitNumber).ToList();
        //            if (elList.Count > 0)
        //            {
        //                Point3d startNode = pdict[elList[0].startNode];
        //                Point3d endNode = pdict[elList[0].endNode];
        //                distance += GetDistanceBetweenTwoPoint(startNode, endNode) * 3;
        //            }
        //        }
        //        string filePath = @"C:\Users\heqianyong\Desktop\光伏支架\组件-后斜撑.dwg";
        //        Dictionary<string, double> propertyNameAndValueMap = new Dictionary<string, double>();
        //        Point3d insertPoint = new Point3d(basePoint.X + 190 + 90, basePoint.Y - lzlist[0], 0);
        //        distance = GetDistanceBetweenTwoPoint(insertPoint, hpoint);
        //        propertyNameAndValueMap.Add("距离1", distance + 80);
        //        double rotation = Math.PI * Getrotation(insertPoint, hpoint) / 180;
        //        BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1.0/3, rotation, insertPoint, propertyNameAndValueMap);
        //    }
        //}
        #endregion

        private static double qxcLength = 0;
        private static double hxcLength = 0;
        /// <summary>
        /// 创建单立柱光伏支架二维模型图
        /// </summary>
        /// <param name="jsonFile">json文件路径</param>
        /// <param name="basePoint">图形生成基点</param>
        /// <param name="filePath">图形块目录</param>
        /// <param name="tableRow">表单行数</param>
        /// <param name="tableColum">表单列数</param>
        public static void CreateSolarPanelBracket(string jsonFile, Point3d basePoint,string filePath,Point3d tablePoint,int tableRow,int tableColum,Point3d arrayPoint)
        {
            PointTool pointTool = new PointTool();
            string LZfilePath = Path.Combine(filePath,"组件-立柱.dwg"); //立柱块
            string gfZjfilePath = Path.Combine(filePath, "组件.dwg"); //组件
            string XlfilePath = Path.Combine(filePath, "组件-斜梁.dwg"); //斜梁;
            string LtfilePath = Path.Combine(filePath, "檩条剖面.dwg"); //檩条剖面
            string PurlinefilePath = Path.Combine(filePath, "檩条.dwg"); //檩条
            string jdltFilePath = Path.Combine(filePath, "组件-檩托.dwg"); //檩托
            string lsFilePath = Path.Combine(filePath, "螺栓1.dwg"); //螺栓1
            string zFilePath = Path.Combine(filePath, "桩.dwg"); //桩
            string bgFilePath = Path.Combine(filePath, "组件-抱箍.dwg"); //组件-抱箍
            string qxcFilePath = Path.Combine(filePath, "组件-前斜撑.dwg"); //组件-前斜撑
            string hxcFilePath = Path.Combine(filePath, "组件-后斜撑.dwg"); //组件-后斜撑
            string jdFilePath = Path.Combine(filePath, "角度.dwg"); //组件-后斜撑
            Dictionary<string, double> propertyNameAndValueMap = new Dictionary<string, double>();//动态块样式
            propertyNameAndValueMap.Add("高度", 0);
            propertyNameAndValueMap.Add("高度1", 0);
            propertyNameAndValueMap.Add("高度2", 0);
            propertyNameAndValueMap.Add("高度3", 0);
            propertyNameAndValueMap.Add("厚度", 0);
            propertyNameAndValueMap.Add("宽度", 0);
            propertyNameAndValueMap.Add("长度", 0);
            propertyNameAndValueMap.Add("宽度1", 0);
            propertyNameAndValueMap.Add("宽度2", 0);
            propertyNameAndValueMap.Add("厚度1", 0);
            propertyNameAndValueMap.Add("厚度2", 0);
            propertyNameAndValueMap.Add("间距", 0);
            propertyNameAndValueMap.Add("角度", 0);
            propertyNameAndValueMap.Add("螺栓间距1", 0);
            propertyNameAndValueMap.Add("螺栓间距2", 0);
            propertyNameAndValueMap.Add("顶部长度1", 0);
            propertyNameAndValueMap.Add("顶部长度2", 0);
            SolarPanel solarPanel = Parsingjson(jsonFile);
            if (solarPanel == null)
            {
                return;
            }
            double InclineAngle = solarPanel.InclineAngle;//角度
            Dictionary<string, List<string>> dictionary = GetSectionAndValueMapFromFile(solarPanel.FileName);
            if (dictionary.Count == 0)
            {
                return;
            }
            Dictionary<int, Point3d> pdict = new Dictionary<int, Point3d>();
            List<Eleline> Linelist = new List<Eleline>();
            List<Layeraxis> Layeraxislist = new List<Layeraxis>();
            List<Section> sectionList = new List<Section>();
            List<Materialcs> materialList = new List<Materialcs>();
            List<string> dictList = GetdictionaryValue(dictionary, "*NODE");
            foreach (var item in dictList)
            {
                string[] nodes = item.Split(',');
                if (nodes.Count() > 3)
                {
                    pdict.Add(Convert.ToInt32(nodes[0]), new Point3d(Convert.ToDouble(nodes[1]), Convert.ToDouble(nodes[2]), Convert.ToDouble(nodes[3])));
                }
            }
            dictList = GetdictionaryValue(dictionary, "*ELE_LINE");
            foreach (var item in dictList)
            {
                string[] Lines = item.Split(',');
                if (Lines.Count() > 7)
                {
                    Eleline line = new Eleline();
                    line.unitNumber = Convert.ToInt32(Lines[0]);
                    line.unitType = Lines[1].Trim();
                    line.materialNumber = Convert.ToInt32(Lines[2]);
                    line.sectionType = Convert.ToInt32(Lines[3]);
                    line.sectionNumber = Convert.ToInt32(Lines[4]);
                    line.startNode = Convert.ToInt32(Lines[5]);
                    line.endNode = Convert.ToInt32(Lines[6]);
                    Linelist.Add(line);
                }
            }
            dictList = GetdictionaryValue(dictionary, "*LAYERAXIS");
            foreach (var item in dictList)
            {
                string[] Layeraxiss = item.Split(',');
                if (Layeraxiss.Count() > 2)
                {
                    Layeraxis layeraxis = new Layeraxis();
                    layeraxis.unitNumber = Convert.ToInt32(Layeraxiss[0]);
                    layeraxis.levelNumber = Layeraxiss[1].Trim();
                    Layeraxislist.Add(layeraxis);
                }
            }
            if (dictionary.ContainsKey("*SECTION"))
            {
                List<string> list = dictionary["*SECTION"];
                foreach (var item in list)
                {
                    string[] Sections = item.Split(',');
                    if (Sections.Count() > 5)
                    {
                        Section section = new Section();
                        section.SectionTypeId = Convert.ToInt32(Sections[0]);
                        section.SectionId = Convert.ToInt32(Sections[1]);
                        section.SectionType = Sections[2];
                        section.Specification = Sections[3];
                        section.SectionName = Sections[4];
                        sectionList.Add(section);
                    }
                }
            }
            dictList = GetdictionaryValue(dictionary, "*MATERIAL");
            foreach (var item in dictList)
            {
                string[] Materials = item.Split(',');
                if (Materials.Count() > 2)
                {
                    Materialcs material = new Materialcs();
                    material.materialNumber = Convert.ToInt32(Materials[0]);
                    material.materialName = Materials[1].Trim();
                    materialList.Add(material);
                }
            }

            string styleName = "SEPD_TJ";
            string FontName = "sepd_tss.shx";
            string BigFontName = "sepd_HZT.SHX";
            ObjectId Fontobjectid = TextStyleFunc.GetTextStyle(styleName, FontName, BigFontName);
            ObjectId layerobjectid = LayerFunc.GetLayerId("DIM", 3);
            ObjectId dimobjectid = DimStyleFunc.GetDimStyle("TSSD_25_25");


            List<double> ltList = new List<double>();
            #region 檩条类型
            List<Layeraxis> layeraxisList = Layeraxislist.Where(x => x.levelNumber == "檩条").ToList();
            if (layeraxisList.Count > 0)
            {
                List<Eleline> elList = Linelist.Where(x => x.unitNumber == layeraxisList[0].unitNumber).ToList();
                if (elList.Count > 0)
                {
                    List<Section> sList = sectionList.Where(x => x.SectionTypeId == elList[0].sectionType && x.SectionId == elList[0].sectionNumber).ToList();
                    if (sList.Count > 0)
                    {
                        string Specification = sList[0].Specification.Trim().Substring(1);
                        string[] Specifications = Specification.Split('x');
                        for (int i = 0; i < Specifications.Count(); i++)
                        {
                            ltList.Add(Convert.ToDouble(Specifications[i]));
                        }
                    }
                }
            }
            #endregion
            double height = 0; //立柱高度
            int num = 0;//图形数量
            #region 立柱生成
            List<Layeraxis> lzList = Layeraxislist.Where(x => x.levelNumber == "立柱").ToList();
            if (lzList.Count > 0)
            {
                num = lzList.Count;
                List<Eleline> eleList = Linelist.Where(x => x.unitNumber == lzList[0].unitNumber).ToList();
                if (eleList.Count > 0)
                {
                    Point3d startNode = pdict[eleList[0].startNode];
                    Point3d endNode = pdict[eleList[0].endNode];
                    height = GetDistanceBetweenTwoPoint(startNode, endNode);
                    propertyNameAndValueMap["高度"] = height;
                    propertyNameAndValueMap["宽度"] = 160;
                    propertyNameAndValueMap["厚度"] = 140;
                    BlockFunc.InsertDwgFile(LZfilePath, Path.GetFileNameWithoutExtension(LZfilePath), 1, 0, basePoint, propertyNameAndValueMap);

                    //立柱标注
                    Point3d dimpoint = new Point3d(basePoint.X + 200, basePoint.Y, basePoint.Z);
                    DimensionFunc.InsertAlignedDimension(basePoint, new Point3d(basePoint.X, basePoint.Y + height, basePoint.Z), dimpoint, dimobjectid, layerobjectid);


                    propertyNameAndValueMap["高度"] = 10;
                    propertyNameAndValueMap["宽度"] = 200;
                    Point3d insertPoint = new Point3d(basePoint.X, basePoint.Y - 5, 0);
                    BlockFunc.InsertDwgFile(gfZjfilePath, Path.GetFileNameWithoutExtension(gfZjfilePath), 1, 0, insertPoint, propertyNameAndValueMap);

                    //立柱底板标注
                    dimpoint = new Point3d(insertPoint.X + 400, insertPoint.Y, insertPoint.Z);
                    DimensionFunc.InsertAlignedDimension(new Point3d(insertPoint.X, insertPoint.Y+5, insertPoint.Z), new Point3d(insertPoint.X, insertPoint.Y - 5, insertPoint.Z), dimpoint, dimobjectid, layerobjectid);

                    propertyNameAndValueMap["高度"] = 100;
                    propertyNameAndValueMap["宽度"] = 6;
                    insertPoint = new Point3d(basePoint.X, basePoint.Y + 50, 0);
                    BlockFunc.InsertDwgFile(gfZjfilePath, Path.GetFileNameWithoutExtension(gfZjfilePath), 1, 0, insertPoint, propertyNameAndValueMap);

                    //立柱底板加劲板标注
                    dimpoint = new Point3d(insertPoint.X, insertPoint.Y + 200, insertPoint.Z);
                    DimensionFunc.InsertAlignedDimension(new Point3d(insertPoint.X -3, insertPoint.Y, insertPoint.Z), new Point3d(insertPoint.X+3, insertPoint.Y, insertPoint.Z), dimpoint, dimobjectid, layerobjectid);
                }
            }
            #endregion

            Point3d qpoint = new Point3d();//前斜撑坐标点
            Point3d hpoint = new Point3d();//后斜撑坐标点
            Dictionary<string, Point3d> qxczjdicList = new Dictionary<string, Point3d>();
            Dictionary<string, Point3d> hxczjdicList = new Dictionary<string, Point3d>();
            #region 生成斜梁、檩条剖面、檩托、螺栓、组件
            List<Layeraxis> xlList = Layeraxislist.Where(x => x.levelNumber == "斜梁").ToList();
            if (xlList.Count > 0)
            {
                int xlnum = xlList.Count / num;
                double sumdistance = 0;
                List<double> xldistance = new List<double>();

                for (int i = 0; i < xlnum; i++)
                {
                    List<Eleline> elList = Linelist.Where(x => x.unitNumber == xlList[i].unitNumber).ToList();
                    if (elList.Count > 0)
                    {
                        Point3d startNode = pdict[elList[0].startNode];
                        Point3d endNode = pdict[elList[0].endNode];
                        double distance = GetDistanceBetweenTwoPoint(startNode, endNode);
                        sumdistance += distance;
                        xldistance.Add(distance);
                    }
                }

                //插入斜梁
                propertyNameAndValueMap["长度"] = sumdistance + 240;
                propertyNameAndValueMap["宽度"] = 80;
                propertyNameAndValueMap["厚度"] = 60;
                Point3d insertPoint = new Point3d(basePoint.X, basePoint.Y + height - 53, 0);
                BlockFunc.InsertDwgFile(XlfilePath, Path.GetFileNameWithoutExtension(XlfilePath), 1, Math.PI * solarPanel.InclineAngle / 180, insertPoint, propertyNameAndValueMap);

                //斜梁总长标注
                Point3d dimpoint = new Point3d(insertPoint.X, insertPoint.Y - 350, basePoint.Z);
                Point3d startPoint = pointTool.GetPolarPoint(insertPoint, sumdistance / 2 + 120, Math.PI * solarPanel.InclineAngle / 180);
                Point3d endPoint = pointTool.GetPolarPoint(insertPoint, sumdistance / 2 + 120, Math.PI * (solarPanel.InclineAngle + 180) / 180);
                DimensionFunc.InsertAlignedDimension(startPoint, endPoint, dimpoint, dimobjectid, layerobjectid);


                //斜梁固定增长标注
                dimpoint = new Point3d(startPoint.X, startPoint.Y - 200, startPoint.Z);
                Point3d hfixedpoint = pointTool.GetPolarPoint(startPoint, 120, Math.PI * (solarPanel.InclineAngle + 180) / 180);
                DimensionFunc.InsertAlignedDimension(startPoint, hfixedpoint, dimpoint, dimobjectid, layerobjectid);

                dimpoint = new Point3d(endPoint.X, endPoint.Y - 200, endPoint.Z);
                Point3d qfixedpoint = pointTool.GetPolarPoint(endPoint, 120, Math.PI * solarPanel.InclineAngle / 180);
                DimensionFunc.InsertAlignedDimension(endPoint, qfixedpoint, dimpoint, dimobjectid, layerobjectid);


                //计算出前后斜撑坐标点
                double lsdistance = sumdistance / 2.0 - xldistance[xldistance.Count -1];
                qpoint = pointTool.GetPolarPoint(insertPoint, lsdistance, Math.PI * (180 + InclineAngle) / 180);

                //斜梁中心点到前斜撑标注
                dimpoint = new Point3d(insertPoint.X, insertPoint.Y - 200, insertPoint.Z);
                DimensionFunc.InsertAlignedDimension(insertPoint, qpoint, dimpoint, dimobjectid, layerobjectid);

                //前斜撑到前固定距离标注
                dimpoint = new Point3d(qpoint.X, qpoint.Y - 200, qpoint.Z);
                DimensionFunc.InsertAlignedDimension(qpoint, qfixedpoint, dimpoint, dimobjectid, layerobjectid);


                lsdistance = sumdistance / 2.0 - xldistance[0];
                hpoint = pointTool.GetPolarPoint(insertPoint, lsdistance, Math.PI * InclineAngle / 180);

                //斜梁中心点到后斜撑标注
                dimpoint = new Point3d(insertPoint.X, insertPoint.Y - 200, insertPoint.Z);
                DimensionFunc.InsertAlignedDimension(insertPoint, hpoint, dimpoint, dimobjectid, layerobjectid);

                //后斜撑到固定距离标注
                dimpoint = new Point3d(hpoint.X, hpoint.Y - 200, hpoint.Z);
                DimensionFunc.InsertAlignedDimension(hpoint, hfixedpoint, dimpoint, dimobjectid, layerobjectid);





                //生成檩条剖面、檩托、螺栓、组件

                qxczjdicList = InsertQxcAllDwgFile(LtfilePath, jdltFilePath, lsFilePath, gfZjfilePath, sumdistance, insertPoint, pointTool, InclineAngle, ltList, propertyNameAndValueMap, num, solarPanel, xldistance, dimobjectid, layerobjectid);
                hxczjdicList =  InsertHxcAllDwgFile(LtfilePath, jdltFilePath, lsFilePath, gfZjfilePath, sumdistance, insertPoint, pointTool, InclineAngle, ltList, propertyNameAndValueMap, num, solarPanel, xldistance,dimobjectid,layerobjectid);

                //生成组件总长度标注
                Point3d qxczjstartpoint = qxczjdicList["start"];
                Point3d qxczjendpoint = qxczjdicList["end"];

                Point3d hxczjstartpoint = hxczjdicList["start"];
                Point3d hxczjendpoint = hxczjdicList["end"];

                dimpoint = new Point3d(qxczjstartpoint.X, qxczjstartpoint.Y + 400, qxczjstartpoint.Z);
                DimensionFunc.InsertAlignedDimension(qxczjstartpoint, hxczjendpoint, dimpoint, dimobjectid, layerobjectid);

                dimpoint = new Point3d(qxczjendpoint.X, qxczjendpoint.Y + 250, qxczjendpoint.Z);
                DimensionFunc.InsertAlignedDimension(qxczjendpoint, hxczjstartpoint, dimpoint, dimobjectid, layerobjectid);
            }
            #endregion


            #region 生成基础和抱箍
            List<double> lzlist = new List<double>();
            xlList = Layeraxislist.Where(x => x.levelNumber == "桩").ToList();
            if (xlList.Count > 0)
            {
                int Znum = xlList.Count / num;
                double sumdistance = 0;
                for (int i = 0; i < Znum; i++)
                {
                    List<Eleline> elList = Linelist.Where(x => x.unitNumber == xlList[i].unitNumber).ToList();
                    if (elList.Count > 0)
                    {
                        Point3d startNode = pdict[elList[0].startNode];
                        Point3d endNode = pdict[elList[0].endNode];
                        double distance = GetDistanceBetweenTwoPoint(startNode, endNode);
                        sumdistance += distance;
                        lzlist.Add(distance);
                    }
                }

                //桩
                propertyNameAndValueMap["高度"] = sumdistance;
                propertyNameAndValueMap["宽度"] = 300;
                Point3d insertPoint = new Point3d(basePoint.X, basePoint.Y - 10, 0);
                BlockFunc.InsertDwgFile(zFilePath, Path.GetFileNameWithoutExtension(zFilePath), 1, 0, insertPoint, propertyNameAndValueMap);
                Point3d dimpoint = new Point3d(insertPoint.X + 600, insertPoint.Y, insertPoint.Z);
                DimensionFunc.InsertAlignedDimension(insertPoint, new Point3d(insertPoint.X, insertPoint.Y - sumdistance, insertPoint.Z), dimpoint, dimobjectid, layerobjectid);


                //抱箍
                propertyNameAndValueMap["间距"] = 380;
                propertyNameAndValueMap["螺栓间距1"] = 90;
                propertyNameAndValueMap["顶部长度1"] = 55;
                propertyNameAndValueMap["螺栓间距2"] = 90;
                propertyNameAndValueMap["顶部长度2"] = 55;
                propertyNameAndValueMap["宽度"] = 70;
                insertPoint = new Point3d(basePoint.X, basePoint.Y - lzlist[0], 0);
                BlockFunc.InsertDwgFile(bgFilePath, Path.GetFileNameWithoutExtension(bgFilePath), 1, 0, insertPoint, propertyNameAndValueMap);

                //抱箍总长度标注
                Point3d bgstartpoint = pointTool.GetPolarPoint(insertPoint, 190 + 90 + 55, Math.PI);
                Point3d bgendpoint = pointTool.GetPolarPoint(insertPoint, 190 + 90 + 55, 0);
                dimpoint = new Point3d(bgstartpoint.X, bgstartpoint.Y - 300, bgstartpoint.Z);
                DimensionFunc.InsertAlignedDimension(bgstartpoint, bgendpoint, dimpoint, dimobjectid, layerobjectid);
                //大抱箍标注
                Point3d DbgPoint1 = pointTool.GetPolarPoint(bgstartpoint, 55, 0);
                Point3d DbgPoint2 = pointTool.GetPolarPoint(bgendpoint, 55, Math.PI);
                dimpoint = new Point3d(DbgPoint1.X, DbgPoint1.Y - 200, DbgPoint1.Z);
                DimensionFunc.InsertAlignedDimension(bgstartpoint, DbgPoint1, dimpoint, dimobjectid, layerobjectid);
                dimpoint = new Point3d(DbgPoint2.X, DbgPoint2.Y - 200, DbgPoint2.Z);
                DimensionFunc.InsertAlignedDimension(bgendpoint, DbgPoint2, dimpoint, dimobjectid, layerobjectid);
                //小抱箍标注
                Point3d XbgPoint1 = pointTool.GetPolarPoint(DbgPoint1, 90, 0);
                Point3d XbgPoint2 = pointTool.GetPolarPoint(DbgPoint2, 90, Math.PI);
                dimpoint = new Point3d(XbgPoint1.X, XbgPoint1.Y - 200, XbgPoint1.Z);
                DimensionFunc.InsertAlignedDimension(DbgPoint1, XbgPoint1, dimpoint, dimobjectid, layerobjectid);
                dimpoint = new Point3d(XbgPoint2.X, XbgPoint2.Y - 200, XbgPoint2.Z);
                DimensionFunc.InsertAlignedDimension(DbgPoint2, XbgPoint2, dimpoint, dimobjectid, layerobjectid);
                dimpoint = new Point3d(XbgPoint1.X, XbgPoint1.Y - 200, XbgPoint1.Z);
                DimensionFunc.InsertAlignedDimension(XbgPoint1, XbgPoint2, dimpoint, dimobjectid, layerobjectid);
                //抱箍宽标注
                Point3d bgwidthPoint1 = pointTool.GetPolarPoint(bgendpoint, 35, Math.PI * 0.5);
                Point3d bgwidthPoint2 = pointTool.GetPolarPoint(bgwidthPoint1, 70, Math.PI * 1.5);
                dimpoint = new Point3d(bgwidthPoint1.X + 100, bgwidthPoint1.Y, bgwidthPoint1.Z);
                DimensionFunc.InsertAlignedDimension(bgwidthPoint1, bgwidthPoint2, dimpoint, dimobjectid, layerobjectid);
            }
            #endregion



            #region 斜撑
            xlList = Layeraxislist.Where(x => x.levelNumber == "前斜撑").ToList();
            if (xlList.Count > 0)
            {
                double distance = 0;
                foreach (var item in xlList)
                {
                    List<Eleline> elList = Linelist.Where(x => x.unitNumber == item.unitNumber).ToList();
                    if (elList.Count > 0)
                    {
                        Point3d startNode = pdict[elList[0].startNode];
                        Point3d endNode = pdict[elList[0].endNode];
                        distance += GetDistanceBetweenTwoPoint(startNode, endNode);
                    }
                }
                Point3d insertPoint = new Point3d(basePoint.X - 190 - 90, basePoint.Y - lzlist[0], 0);
                distance = GetDistanceBetweenTwoPoint(insertPoint, qpoint);
                propertyNameAndValueMap["长度"] = distance + 80;
                propertyNameAndValueMap["宽度"] = 70;
                qxcLength = distance + 80;
                double rotation = Math.PI * (180 - Getrotation(insertPoint, qpoint)) / 180;
                BlockFunc.InsertDwgFile(qxcFilePath, Path.GetFileNameWithoutExtension(qxcFilePath), 1, rotation, insertPoint, propertyNameAndValueMap);

                //前斜撑标注
                Point3d dimpoint = pointTool.GetPolarPoint(insertPoint, 200, 0);
                DimensionFunc.InsertAlignedDimension(insertPoint, qpoint, dimpoint, dimobjectid, layerobjectid);

                //前斜撑固定距离标注
                DimensionFunc.InsertAlignedDimension(insertPoint, pointTool.GetPolarPoint(insertPoint, 40, (rotation+ Math.PI)), dimpoint, dimobjectid, layerobjectid);
                dimpoint = pointTool.GetPolarPoint(qpoint, 200, 0);
                DimensionFunc.InsertAlignedDimension(qpoint, pointTool.GetPolarPoint(qpoint, 40, rotation), dimpoint, dimobjectid, layerobjectid);
            }

            xlList = Layeraxislist.Where(x => x.levelNumber == "后斜撑").ToList();
            if (xlList.Count > 0)
            {
                double distance = 0;
                foreach (var item in xlList)
                {
                    List<Eleline> elList = Linelist.Where(x => x.unitNumber == item.unitNumber).ToList();
                    if (elList.Count > 0)
                    {
                        Point3d startNode = pdict[elList[0].startNode];
                        Point3d endNode = pdict[elList[0].endNode];
                        distance += GetDistanceBetweenTwoPoint(startNode, endNode);
                    }
                }
                Point3d insertPoint = new Point3d(basePoint.X + 190 + 90, basePoint.Y - lzlist[0], 0);
                distance = GetDistanceBetweenTwoPoint(insertPoint, hpoint);
                propertyNameAndValueMap["长度"] = distance + 80;
                propertyNameAndValueMap["宽度"] = 70;
                hxcLength = distance + 80;
                double rotation = Math.PI * Getrotation(insertPoint, hpoint) / 180;
                BlockFunc.InsertDwgFile(hxcFilePath, Path.GetFileNameWithoutExtension(hxcFilePath), 1, rotation, insertPoint, propertyNameAndValueMap);
                //后斜撑标注
                Point3d dimpoint = pointTool.GetPolarPoint(insertPoint, 200, 0);
                DimensionFunc.InsertAlignedDimension(insertPoint, hpoint, dimpoint, dimobjectid, layerobjectid);

                //后斜撑固定距离标注
                DimensionFunc.InsertAlignedDimension(insertPoint, pointTool.GetPolarPoint(insertPoint, 40, (rotation - Math.PI)), dimpoint, dimobjectid, layerobjectid);
                dimpoint = pointTool.GetPolarPoint(hpoint, 200, 0);
                DimensionFunc.InsertAlignedDimension(hpoint, pointTool.GetPolarPoint(hpoint, 40, rotation), dimpoint, dimobjectid, layerobjectid);

            }
            #endregion

            //#region 角度
            //Point3d jdpoint = new Point3d(basePoint.X - 1000, basePoint.Y + 2000, basePoint.Z);
            //propertyNameAndValueMap["角度"] = InclineAngle;
            //BlockFunc.InsertDwgFile(jdFilePath, Path.GetFileNameWithoutExtension(jdFilePath), 1, 0, jdpoint, propertyNameAndValueMap);
            //#endregion


            CreateSolarPanelBracketForm(pdict, Linelist, Layeraxislist, sectionList, materialList, tablePoint, pointTool,tableRow, tableColum, Fontobjectid,solarPanel);

            CreateSolarPanelArray(solarPanel, pointTool, arrayPoint, dimobjectid,layerobjectid, qxczjdicList, hxczjdicList, PurlinefilePath, ltList, propertyNameAndValueMap, pdict, Linelist, Layeraxislist, XlfilePath);
        }




        private static void CreateSolarPanelArray(SolarPanel solarPanel,PointTool pointTool, Point3d insertPoint,ObjectId dimobjectid,ObjectId layerobjectid, Dictionary<string, Point3d> qxczjdicList, Dictionary<string, Point3d> hxczjdicList, string purlinefilePath, List<double> ltList, Dictionary<string, double> propertyNameAndValueMap, Dictionary<int, Point3d> pdict, List<Eleline> linelist, List<Layeraxis> layeraxislist, string xlfilePath)
        {
            ObjectId zjlayerid = LayerFunc.GetLayerId("组件", 4);
            int ColumnCount = solarPanel.XNumber;
            int ColumnSpacing = Convert.ToInt32(solarPanel.BPanelDistanceValue + solarPanel.BTotalWidth);
            int RowCount = solarPanel.YNumber;
            int RowSpacing = Convert.ToInt32(solarPanel.APanelDistanceValue + solarPanel.ATotalWidth);
            int LevelCount = 1;
            Point3d pt1 = new Point3d(insertPoint.X, insertPoint.Y, insertPoint.Z);
            Point3d pt2 = new Point3d(insertPoint.X + solarPanel.BTotalWidth, insertPoint.Y+ solarPanel.ATotalWidth, insertPoint.Z);
            Polyline polyline = new Polyline();
            Point2d p1 = new Point2d(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y));
            Point2d p2 = new Point2d(Math.Max(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y));
            Point2d p3 = new Point2d(Math.Max(pt1.X, pt2.X), Math.Max(pt1.Y, pt2.Y));
            Point2d p4 = new Point2d(Math.Min(pt1.X, pt2.X), Math.Max(pt1.Y, pt2.Y));
            polyline.AddVertexAt(0, p1, 0, 0, 0);
            polyline.AddVertexAt(0, p2, 0, 0, 0);
            polyline.AddVertexAt(0, p3, 0, 0, 0);
            polyline.AddVertexAt(0, p4, 0, 0, 0);
            polyline.Closed = true;
            polyline.LayerId = zjlayerid;

            #region 生成阵列
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                ObjectId objectid = db.AddToModelSpace(polyline);
                ObjectIdCollection basePt = new ObjectIdCollection();
                basePt.Add(objectid);
                VertexRef BasePoint = new VertexRef(insertPoint);
                ArrayFunc.CreateArray(basePt, BasePoint, ColumnCount, ColumnSpacing, RowCount, RowSpacing, LevelCount);
                AssocManager.EvaluateTopLevelNetwork(db, null, 0);
                Entity entity = (Entity)objectid.GetObject(OpenMode.ForWrite);
                entity.Erase(true);
                trans.Commit();
            }
            #endregion

            //阵列宽度标注
            Point3d dimpoint = new Point3d(insertPoint.X -500, insertPoint.Y, insertPoint.Z);
            Point3d zjheightPoint = pointTool.GetPolarPoint(insertPoint, solarPanel.ATotalWidth * 2 + solarPanel.APanelDistanceValue, Math.PI * 0.5);
            DimensionFunc.InsertAlignedDimension(insertPoint, zjheightPoint, dimpoint, dimobjectid, layerobjectid);

            //阵列单个组件长度
            dimpoint = new Point3d(insertPoint.X - 350, insertPoint.Y, insertPoint.Z);
            zjheightPoint = pointTool.GetPolarPoint(insertPoint, solarPanel.ATotalWidth, Math.PI * 0.5);
            DimensionFunc.InsertAlignedDimension(insertPoint, zjheightPoint, dimpoint, dimobjectid, layerobjectid);

            //阵列间标注
            Point3d gdpoint = pointTool.GetPolarPoint(zjheightPoint, solarPanel.APanelDistanceValue, Math.PI * 0.5);
            DimensionFunc.InsertAlignedDimension(zjheightPoint, gdpoint, dimpoint, dimobjectid, layerobjectid);

            //阵列单个组长宽度
            zjheightPoint = pointTool.GetPolarPoint(gdpoint, solarPanel.ATotalWidth, Math.PI * 0.5);
            DimensionFunc.InsertAlignedDimension(gdpoint, zjheightPoint, dimpoint, dimobjectid, layerobjectid);

            //阵列每个组件宽度标注
            for (int i = 0; i < ColumnCount; i++)
            {
                Point3d zjheightPoint1 = new Point3d(zjheightPoint.X + (i * solarPanel.BTotalWidth) + (i * solarPanel.BPanelDistanceValue), zjheightPoint.Y, zjheightPoint.Z);
                Point3d zjheightPoint2 = new Point3d(zjheightPoint1.X + solarPanel.BTotalWidth, zjheightPoint1.Y, zjheightPoint1.Z);
                dimpoint = new Point3d(zjheightPoint1.X, zjheightPoint1.Y + 150, zjheightPoint1.Z);
                DimensionFunc.InsertAlignedDimension(zjheightPoint1, zjheightPoint2, dimpoint, dimobjectid, layerobjectid);
                if (ColumnCount - i > 1)
                {
                    gdpoint = pointTool.GetPolarPoint(zjheightPoint2, solarPanel.BPanelDistanceValue, 0);
                    DimensionFunc.InsertAlignedDimension(zjheightPoint2, gdpoint, dimpoint, dimobjectid, layerobjectid);
                }
            }

            //阵列长度标注
            dimpoint = new Point3d(zjheightPoint.X, zjheightPoint.Y + 450, zjheightPoint.Z);
            Point3d zjheightendpoint = pointTool.GetPolarPoint(zjheightPoint, ColumnCount* solarPanel.BTotalWidth + solarPanel.BPanelDistanceValue * (ColumnCount - 1), 0);
            DimensionFunc.InsertAlignedDimension(zjheightPoint, zjheightendpoint, dimpoint, dimobjectid, layerobjectid);

            double Overalllength = GetDistanceBetweenTwoPoint(zjheightPoint, zjheightendpoint);//组件总长

            Point3d zjstartPoint = qxczjdicList["start"];
            Point3d zjendPoint = hxczjdicList["end"];
            Point3d ltstartPoint = qxczjdicList["lt2"];
            double distance = GetDistanceBetweenTwoPoint(zjstartPoint, ltstartPoint);

            Point3d bzpoint1 = pointTool.GetPolarPoint(insertPoint, distance, Math.PI * 0.5);
            Point3d ltpoint1 = pointTool.GetPolarPoint(bzpoint1, Overalllength / 2.0, 0);

            //檩条长度标注
            propertyNameAndValueMap["长度"] = Overalllength + 200;
            propertyNameAndValueMap["宽度"] = ltList[1];
            BlockFunc.InsertDwgFile(purlinefilePath, Path.GetFileNameWithoutExtension(purlinefilePath), 1, 0, ltpoint1, propertyNameAndValueMap);
            dimpoint = new Point3d(bzpoint1.X - 200, bzpoint1.Y, bzpoint1.Z);
            DimensionFunc.InsertAlignedDimension(insertPoint, bzpoint1, dimpoint, dimobjectid, layerobjectid);


            //檩条间距标注
            distance = GetDistanceBetweenTwoPoint(qxczjdicList["lt2"], qxczjdicList["lt1"]);
            Point3d bzpoint2 = pointTool.GetPolarPoint(bzpoint1, distance, Math.PI * 0.5);
            Point3d ltpoint2 = pointTool.GetPolarPoint(ltpoint1, distance, Math.PI * 0.5);
            BlockFunc.InsertDwgFile(purlinefilePath, Path.GetFileNameWithoutExtension(purlinefilePath), 1, 0, ltpoint2, propertyNameAndValueMap);
            dimpoint = new Point3d(bzpoint2.X - 200, bzpoint2.Y, bzpoint2.Z);
            DimensionFunc.InsertAlignedDimension(bzpoint1, bzpoint2, dimpoint, dimobjectid, layerobjectid);


            distance = GetDistanceBetweenTwoPoint(qxczjdicList["lt1"], hxczjdicList["lt2"]);
            Point3d bzpoint3 = pointTool.GetPolarPoint(bzpoint2, distance, Math.PI * 0.5);
            Point3d ltpoint3 = pointTool.GetPolarPoint(ltpoint2, distance, Math.PI * 0.5);
            BlockFunc.InsertDwgFile(purlinefilePath, Path.GetFileNameWithoutExtension(purlinefilePath), 1, 0, ltpoint3, propertyNameAndValueMap);
            dimpoint = new Point3d(bzpoint3.X - 200, bzpoint3.Y, bzpoint3.Z);
            DimensionFunc.InsertAlignedDimension(bzpoint2, bzpoint3, dimpoint, dimobjectid, layerobjectid);


            distance = GetDistanceBetweenTwoPoint(hxczjdicList["lt1"], hxczjdicList["lt2"]);
            Point3d bzpoint4 = pointTool.GetPolarPoint(bzpoint3, distance, Math.PI * 0.5);
            Point3d ltpoint4 = pointTool.GetPolarPoint(ltpoint3, distance, Math.PI * 0.5);
            BlockFunc.InsertDwgFile(purlinefilePath, Path.GetFileNameWithoutExtension(purlinefilePath), 1, 0, ltpoint4, propertyNameAndValueMap);
            dimpoint = new Point3d(bzpoint4.X - 200, bzpoint4.Y, bzpoint4.Z);
            DimensionFunc.InsertAlignedDimension(bzpoint3, bzpoint4, dimpoint, dimobjectid, layerobjectid);

            distance = GetDistanceBetweenTwoPoint(hxczjdicList["lt1"], zjendPoint);
            Point3d bzpoint5 = pointTool.GetPolarPoint(bzpoint4, distance, Math.PI * 0.5);
            dimpoint = new Point3d(bzpoint5.X - 200, bzpoint5.Y, bzpoint5.Z);
            DimensionFunc.InsertAlignedDimension(bzpoint4, bzpoint5, dimpoint, dimobjectid, layerobjectid);

            List<double> ltdistance = new List<double>();
            List<Layeraxis> LTList = layeraxislist.Where(x => x.levelNumber == "檩条").ToList();
            if (LTList.Count > 0)
            {
                for (int i = 0; i < LTList.Count; i++)
                {
                    List<Eleline> eleList = linelist.Where(x => x.unitNumber == LTList[i].unitNumber).ToList();
                    List<Eleline> eleList1 = linelist.Where(x => x.unitNumber == LTList[i + 1].unitNumber).ToList();
                    if (eleList.Count > 0)
                    {
                        ltdistance.Add(GetDistanceBetweenTwoPoint(pdict[eleList[0].startNode], pdict[eleList[0].endNode]));
                        if (eleList[0].endNode != eleList1[0].startNode)
                        {
                            break;
                        }
                    }
                }
            }
            distance = 0;
            for (int i = 1; i < ltdistance.Count - 1; i++)
            {
                distance += ltdistance[i];
            }
            distance = (Overalllength + 200 - distance) / 2.0;
            Point3d xlpoint = pointTool.GetPolarPoint(ltpoint4, (Overalllength + 200) / 2.0, Math.PI);
            xlpoint = pointTool.GetPolarPoint(xlpoint, distance, 0);
            xlpoint = pointTool.GetPolarPoint(xlpoint, GetDistanceBetweenTwoPoint(ltpoint4, ltpoint1) / 2.0, Math.PI * 1.5);

            List<Layeraxis> xlList = layeraxislist.Where(x => x.levelNumber == "斜梁").ToList();
            double xldistance = 240;
            if (xlList.Count > 0)
            {
                for (int i = 0; i < xlList.Count; i++)
                {
                    List<Eleline> eleList = linelist.Where(x => x.unitNumber == xlList[i].unitNumber).ToList();
                    List<Eleline> eleList1 = linelist.Where(x => x.unitNumber == xlList[i + 1].unitNumber).ToList();
                    if (eleList.Count > 0)
                    {
                        xldistance += GetDistanceBetweenTwoPoint(pdict[eleList[0].startNode], pdict[eleList[0].endNode]);
                        if (eleList[0].endNode != eleList1[0].startNode)
                        {
                            break;
                        }
                    }
                }
                //插入斜梁
                propertyNameAndValueMap["长度"] = xldistance;
                propertyNameAndValueMap["宽度"] = 80;
                propertyNameAndValueMap["厚度"] = 60;
                BlockFunc.InsertDwgFile(xlfilePath, Path.GetFileNameWithoutExtension(xlfilePath), 1, Math.PI * 0.5, xlpoint, propertyNameAndValueMap);

                for (int i = 1; i < ltdistance.Count - 1; i++)
                {
                    xlpoint = pointTool.GetPolarPoint(xlpoint, ltdistance[i], 0);
                    BlockFunc.InsertDwgFile(xlfilePath, Path.GetFileNameWithoutExtension(xlfilePath), 1, Math.PI * 0.5, xlpoint, propertyNameAndValueMap);
                }
            }

        }

        /// <summary>
        /// 生成前斜梁的檩条剖面、檩托、螺栓、组件
        /// </summary>
        /// <param name="ltfilePath">檩条文件</param>
        /// <param name="jdltFilePath">檩托文件</param>
        /// <param name="lsFilePath">螺栓</param>
        /// <param name="gfZjfilePath">组件</param>
        /// <param name="sumdistance">斜梁总长</param>
        /// <param name="insertPoint">斜梁插入点</param>
        /// <param name="pointTool">坐标工具类</param>
        /// <param name="inclineAngle">角度</param>
        /// <param name="ltList">檩条尺寸</param>
        /// <param name="propertyNameAndValueMap">块自定义值</param>
        /// <param name="num">图形数量</param>
        private static Dictionary<string, Point3d> InsertQxcAllDwgFile(string ltfilePath, string jdltFilePath, string lsFilePath, string gfZjfilePath, double sumdistance, Point3d insertPoint, PointTool pointTool, double inclineAngle, List<double> ltList, Dictionary<string, double> propertyNameAndValueMap, int num, SolarPanel solarPanel, List<double> xldistance, ObjectId dimobjectid, ObjectId layerobjectid)
        {
            Point3d ltdimPoint1 = new Point3d();
            Point3d ltdimPoint2 = new Point3d();
            Point3d zjdimPoint = new Point3d();
            for (int i = 0; i < num/2; i++)
            {
                double ltdistance = sumdistance / 2.0;
                Point3d ltpoint = pointTool.GetPolarPoint(insertPoint, ltdistance, Math.PI * (180 + inclineAngle) / 180);
                Point3d LtInsertPoint = ltdimPoint2 = pointTool.GetPolarPoint(ltpoint, ltList[0] / 2.0 + 10 + 40, Math.PI * (90 + inclineAngle) / 180);
                if (i > 0)
                {
                    ltdistance = xldistance[3];
                    ltpoint = pointTool.GetPolarPoint(insertPoint, ltdistance, Math.PI * (180 + inclineAngle) / 180);
                    LtInsertPoint = ltdimPoint1 = pointTool.GetPolarPoint(ltpoint, ltList[0] / 2.0 + 10 + 40, Math.PI * (90 + inclineAngle) / 180);
                }
                //檩条
                propertyNameAndValueMap["高度1"] = ltList[0];
                propertyNameAndValueMap["高度2"] = ltList[0] - ltList[3] * 2;
                propertyNameAndValueMap["宽度1"] = ltList[1];
                propertyNameAndValueMap["宽度2"] = ltList[1] - ltList[3] * 2;
                propertyNameAndValueMap["高度3"] = ltList[0] - ltList[2] * 2;
                //propertyNameAndValueMap["厚度1"] = ltList[3];
                //propertyNameAndValueMap["厚度2"] = ltList[3];
                BlockFunc.InsertDwgFile(ltfilePath, Path.GetFileNameWithoutExtension(ltfilePath), 1, Math.PI * inclineAngle / 180, LtInsertPoint, propertyNameAndValueMap);

                //檩托
                double jgltdistance = ltList[1] / 2.0;
                Point3d jdltpoint = pointTool.GetPolarPoint(LtInsertPoint, jgltdistance, Math.PI * (180 + inclineAngle) / 180);
                double jgltdistance1 = ltList[0] / 2.0 + 10;
                jdltpoint = pointTool.GetPolarPoint(jdltpoint, jgltdistance1, Math.PI * (180 + inclineAngle + 90) / 180);
                propertyNameAndValueMap = new Dictionary<string, double>();
                propertyNameAndValueMap["高度"] = jgltdistance1 + 40;
                BlockFunc.InsertDwgFile(jdltFilePath, Path.GetFileNameWithoutExtension(jdltFilePath), 1, Math.PI * inclineAngle / 180, jdltpoint, propertyNameAndValueMap);

                //螺栓
                propertyNameAndValueMap["宽度"] =ltList[3];
                double lsdistance = ltList[0] / 2.0 - ltList[3];
                Point3d lsPoint = pointTool.GetPolarPoint(LtInsertPoint, lsdistance, Math.PI * (inclineAngle + 90) / 180);
                BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath),1, Math.PI * (180 + inclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);
                propertyNameAndValueMap["宽度"] = 5 + ltList[3];
                lsdistance = ltList[1] / 2.0 - ltList[3];
                lsPoint = pointTool.GetPolarPoint(LtInsertPoint, lsdistance, Math.PI * (180 + inclineAngle) / 180);
                BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 1, Math.PI * inclineAngle / 180, lsPoint, propertyNameAndValueMap);
                propertyNameAndValueMap["宽度"] = 5;
                lsdistance = 28;
                lsPoint = pointTool.GetPolarPoint(jdltpoint, lsdistance, Math.PI * (180 + inclineAngle) / 180);
                BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 1, Math.PI * (180 + inclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);

                if (i == 0)
                {
                    //组件
                    double gfzjwidth = solarPanel.ATotalWidth - solarPanel.BoltLengthDistance;
                    double gfzjdistance = solarPanel.BoltLengthDistance / 2.0;
                    Point3d gfpoint = pointTool.GetPolarPoint(LtInsertPoint, (ltList[0] + 30) / 2.0, Math.PI * (inclineAngle + 90) / 180);
                    zjdimPoint = gfpoint = pointTool.GetPolarPoint(gfpoint, gfzjdistance, Math.PI * inclineAngle / 180);
                    propertyNameAndValueMap["高度"] = 30;
                    propertyNameAndValueMap["宽度"] = gfzjwidth + solarPanel.BoltLengthDistance;
                    BlockFunc.InsertDwgFile(gfZjfilePath, Path.GetFileNameWithoutExtension(gfZjfilePath), 1, Math.PI * inclineAngle / 180, gfpoint, propertyNameAndValueMap);


                }

            }
            ltdimPoint1 = pointTool.GetPolarPoint(ltdimPoint1, (ltList[0] + 30) / 2.0, Math.PI * (inclineAngle + 90) / 180);
            ltdimPoint2 = pointTool.GetPolarPoint(ltdimPoint2, (ltList[0] + 30) / 2.0, Math.PI * (inclineAngle + 90) / 180);
            Point3d startPoint = pointTool.GetPolarPoint(zjdimPoint, solarPanel.ATotalWidth / 2, Math.PI * (inclineAngle + 180) / 180);
            Point3d endPoint = pointTool.GetPolarPoint(zjdimPoint, solarPanel.ATotalWidth / 2, Math.PI * inclineAngle / 180);
            //组件标注
            Point3d dimpoint = new Point3d(startPoint.X, startPoint.Y + 250, startPoint.Z);
            DimensionFunc.InsertAlignedDimension(startPoint, endPoint, dimpoint, dimobjectid, layerobjectid);
            //组件到檩条标注
            dimpoint = new Point3d(startPoint.X, startPoint.Y + 100, startPoint.Z);
            DimensionFunc.InsertAlignedDimension(startPoint, ltdimPoint2, dimpoint, dimobjectid, layerobjectid);
            dimpoint = new Point3d(endPoint.X, endPoint.Y + 100, endPoint.Z);
            DimensionFunc.InsertAlignedDimension(endPoint, ltdimPoint1, dimpoint, dimobjectid, layerobjectid);
            //檩条之间的标注
            dimpoint = new Point3d(ltdimPoint1.X, ltdimPoint1.Y + 100, ltdimPoint1.Z);
            DimensionFunc.InsertAlignedDimension(ltdimPoint1, ltdimPoint2, dimpoint, dimobjectid, layerobjectid);

            Dictionary<string, Point3d> zjdiclist = new Dictionary<string, Point3d>();
            zjdiclist.Add("start", startPoint);
            zjdiclist.Add("end", endPoint);
            zjdiclist.Add("lt1", ltdimPoint1);
            zjdiclist.Add("lt2", ltdimPoint2);
            return zjdiclist;
        }


        /// <summary>
        /// 生成后斜梁的檩条剖面、檩托、螺栓、组件
        /// </summary>
        /// <param name="ltfilePath">檩条文件</param>
        /// <param name="jdltFilePath">檩托文件</param>
        /// <param name="lsFilePath">螺栓</param>
        /// <param name="gfZjfilePath">组件</param>
        /// <param name="sumdistance">斜梁总长</param>
        /// <param name="insertPoint">斜梁插入点</param>
        /// <param name="pointTool">坐标工具类</param>
        /// <param name="inclineAngle">角度</param>
        /// <param name="ltList">檩条尺寸</param>
        /// <param name="propertyNameAndValueMap">块自定义值</param>
        /// <param name="num">图形数量</param>
        private static Dictionary<string, Point3d> InsertHxcAllDwgFile(string ltfilePath, string jdltFilePath, string lsFilePath, string gfZjfilePath, double sumdistance, Point3d insertPoint, PointTool pointTool, double inclineAngle, List<double> ltList, Dictionary<string, double> propertyNameAndValueMap, int num, SolarPanel solarPanel, List<double> xldistance,ObjectId dimobjectid,ObjectId layerobjectid)
        {
            Point3d ltdimPoint1 = new Point3d();
            Point3d ltdimPoint2 = new Point3d();
            Point3d zjdimPoint = new Point3d();
            for (int i = 0; i < num / 2; i++)
            {
                double ltdistance = sumdistance / 2.0;
                //檩条
                Point3d ltpoint = pointTool.GetPolarPoint(insertPoint, ltdistance, Math.PI * inclineAngle / 180);
                Point3d LtInsertPoint = ltdimPoint1 = pointTool.GetPolarPoint(ltpoint, ltList[0] / 2.0 + 10 + 40, Math.PI * (90 + inclineAngle) / 180);
                if (i > 0)
                {
                    ltdistance = xldistance[2];
                    ltpoint = pointTool.GetPolarPoint(insertPoint, ltdistance, Math.PI * inclineAngle / 180);
                    LtInsertPoint = ltdimPoint2 = pointTool.GetPolarPoint(ltpoint, ltList[0] / 2.0 + 10 + 40, Math.PI * (90 + inclineAngle) / 180);
                }
                propertyNameAndValueMap["高度1"] = ltList[0];
                propertyNameAndValueMap["高度2"] = ltList[0] - ltList[3] * 2;
                propertyNameAndValueMap["宽度1"] = ltList[1];
                propertyNameAndValueMap["宽度2"] = ltList[1] - ltList[3] * 2;
                propertyNameAndValueMap["高度3"] = ltList[0] - ltList[2] * 2;
                //propertyNameAndValueMap["厚度1"] = ltList[3];
                //propertyNameAndValueMap["厚度2"] = ltList[3];
                BlockFunc.InsertDwgFile(ltfilePath, Path.GetFileNameWithoutExtension(ltfilePath), 1, Math.PI * inclineAngle / 180, LtInsertPoint, propertyNameAndValueMap);

                //檩托
                double jgltdistance = ltList[1] / 2.0;
                Point3d jdltpoint = pointTool.GetPolarPoint(LtInsertPoint, jgltdistance, Math.PI * (180 + inclineAngle) / 180);
                double jgltdistance1 = ltList[0] / 2.0 + 10;
                jdltpoint = pointTool.GetPolarPoint(jdltpoint, jgltdistance1, Math.PI * (180 + inclineAngle + 90) / 180);
                propertyNameAndValueMap = new Dictionary<string, double>();
                propertyNameAndValueMap["高度"] = jgltdistance1 + 40;
                BlockFunc.InsertDwgFile(jdltFilePath, Path.GetFileNameWithoutExtension(jdltFilePath), 1, Math.PI * inclineAngle / 180, jdltpoint, propertyNameAndValueMap);

                //螺栓
                propertyNameAndValueMap["宽度"] = ltList[3];
                double lsdistance = ltList[0] / 2.0 - ltList[3];
                Point3d lsPoint = pointTool.GetPolarPoint(LtInsertPoint, lsdistance, Math.PI * (inclineAngle + 90) / 180);
                BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 1, Math.PI * (180 + inclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);
                propertyNameAndValueMap["宽度"] = 5 + ltList[3];
                lsdistance = ltList[1] / 2.0 - ltList[3];
                lsPoint = pointTool.GetPolarPoint(LtInsertPoint, lsdistance, Math.PI * (180 + inclineAngle) / 180);
                BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 1, Math.PI * inclineAngle / 180, lsPoint, propertyNameAndValueMap);
                propertyNameAndValueMap["宽度"] = 5;
                lsdistance = 28;
                lsPoint = pointTool.GetPolarPoint(jdltpoint, lsdistance, Math.PI * (180 + inclineAngle) / 180);
                BlockFunc.InsertDwgFile(lsFilePath, Path.GetFileNameWithoutExtension(lsFilePath), 1, Math.PI * (180 + inclineAngle + 90) / 180, lsPoint, propertyNameAndValueMap);

                if (i == 0)
                {
                    //组件
                    double gfzjwidth = solarPanel.ATotalWidth - solarPanel.BoltLengthDistance;
                    double gfzjdistance = solarPanel.BoltLengthDistance / 2.0;
                    Point3d gfpoint = pointTool.GetPolarPoint(LtInsertPoint, (ltList[0] + 30) / 2.0, Math.PI * (inclineAngle + 90) / 180);
                    zjdimPoint = gfpoint = pointTool.GetPolarPoint(gfpoint, gfzjdistance, Math.PI * (inclineAngle + 180) / 180);
                    propertyNameAndValueMap["高度"] = 30;
                    propertyNameAndValueMap["宽度"] = gfzjwidth + solarPanel.BoltLengthDistance;
                    BlockFunc.InsertDwgFile(gfZjfilePath, Path.GetFileNameWithoutExtension(gfZjfilePath), 1, Math.PI * inclineAngle / 180, gfpoint, propertyNameAndValueMap);
                }
            }
            ltdimPoint1 = pointTool.GetPolarPoint(ltdimPoint1, (ltList[0] + 30) / 2.0, Math.PI * (inclineAngle + 90) / 180);
            ltdimPoint2 = pointTool.GetPolarPoint(ltdimPoint2, (ltList[0] + 30) / 2.0, Math.PI * (inclineAngle + 90) / 180);
            Point3d startPoint = pointTool.GetPolarPoint(zjdimPoint, solarPanel.ATotalWidth / 2, Math.PI * (inclineAngle + 180) / 180);
            Point3d endPoint = pointTool.GetPolarPoint(zjdimPoint, solarPanel.ATotalWidth / 2, Math.PI * inclineAngle / 180);
            //组件标注
            Point3d dimpoint = new Point3d(startPoint.X, startPoint.Y + 250, startPoint.Z);
            DimensionFunc.InsertAlignedDimension(startPoint, endPoint, dimpoint, dimobjectid, layerobjectid);
            //组件到檩条标注
            dimpoint = new Point3d(startPoint.X, startPoint.Y + 100, startPoint.Z);
            DimensionFunc.InsertAlignedDimension(startPoint, ltdimPoint2, dimpoint, dimobjectid, layerobjectid);
            dimpoint = new Point3d(endPoint.X, endPoint.Y + 100, endPoint.Z);
            DimensionFunc.InsertAlignedDimension(endPoint, ltdimPoint1, dimpoint, dimobjectid, layerobjectid);
            //檩条之间的标注
            dimpoint = new Point3d(ltdimPoint1.X, ltdimPoint1.Y + 100, ltdimPoint1.Z);
            DimensionFunc.InsertAlignedDimension(ltdimPoint1, ltdimPoint2, dimpoint, dimobjectid, layerobjectid);

            Dictionary<string, Point3d> zjdiclist = new Dictionary<string, Point3d>();
            zjdiclist.Add("start", startPoint);
            zjdiclist.Add("end", endPoint);
            zjdiclist.Add("lt1", ltdimPoint1);
            zjdiclist.Add("lt2", ltdimPoint2);
            return zjdiclist;
        }



        public static List<string> GetdictionaryValue(Dictionary<string, List<string>> dictionary,string key)
        {
            List<string> list = new List<string>();
            if (dictionary.ContainsKey(key))
            {
                list = dictionary[key];
            }
            return list;
        }



        /// <summary>
        /// 根据两点坐标计算距离
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public static double GetDistanceBetweenTwoPoint(Point3d startpoint,Point3d endpoint)
        {
            return Math.Sqrt(Math.Pow(startpoint.X - endpoint.X, 2) + Math.Pow(startpoint.Y - endpoint.Y, 2) + Math.Pow(startpoint.Z - endpoint.Z, 2));
        }

        /// <summary>
        /// 根据两点坐标返回角度
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public static double Getrotation(Point3d startpoint,Point3d endpoint)
        {
            return Math.Atan2(Math.Abs(endpoint.Y - startpoint.Y), Math.Abs(endpoint.X - startpoint.X)) * 180 / Math.PI;
        }


        /// <summary>
        /// 读取json
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        public static SolarPanel Parsingjson(string jsonPath)
        {
            SolarPanel solarPanel = null;
            if (File.Exists(jsonPath))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string line;
                FileStream fstream = new FileStream(jsonPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sreader = new StreamReader(fstream, Encoding.UTF8);
                string json = "";
                while ((line = sreader.ReadLine()) != null)
                {
                    json = json + line.ToString();
                }
                sreader.Close();
                fstream.Close();
                solarPanel = js.Deserialize<SolarPanel>(json);
            }
            return solarPanel;
        }

        //
        // 摘要:
        //     读取txt文件内容,判断文件是否存在
        //
        // 返回结果:
        //     节点和相应内容列表的映射，如果读取失败，返回空的映射
        private static Dictionary<string, List<string>> GetSectionAndValueMapFromFile(string m_pathName)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            if (!File.Exists(m_pathName))
            {
                return dictionary;
            }


            StreamReader streamReader = new StreamReader(m_pathName, Encoding.UTF8);
            string text;
            while ((text = streamReader.ReadLine()) != null && text != "*END")
            {
                string text2 = text.Trim();
                if (string.IsNullOrEmpty(text2))
                {
                    continue;
                }

                if (text == "*END")
                {
                    break;
                }

                if (text2[0] == '*')
                {
                    List<string> list = new List<string>();
                    while (!string.IsNullOrEmpty(text = streamReader.ReadLine()))
                    {
                        list.Add(text);
                    }

                    if (list.Count > 0)
                    {
                        dictionary[text2] = list;
                    }
                }
            }

            return dictionary;
        }



        /// <summary>
        /// 创建光伏支架表单
        /// </summary>
        /// <param name="pdict">坐标集合</param>
        /// <param name="Linelist">线段信息集合</param>
        /// <param name="Layeraxislist">层面和轴号线集合</param>
        /// <param name="sectionList">截面集合</param>
        /// <param name="materialList">材料集合</param>
        /// <param name="insertPoint">表单插入点</param>
        /// <param name="pointTool">坐标工具类</param>
        /// <param name="row">行数</param>
        /// <param name="colum">列数</param>
        public static void CreateSolarPanelBracketForm(Dictionary<int, Point3d> pdict, List<Eleline> Linelist, List<Layeraxis> Layeraxislist, List<Section> sectionList, List<Materialcs> materialList, Point3d insertPoint, PointTool pointTool,int row,int colum,ObjectId fontobjectid,SolarPanel solarPanel)
        {
            Table table = new Table();
            table.SetSize(row, colum); //表格大小
            table.Position = insertPoint;//插入点
            table.SetColumnWidth(5000);//列宽
            table.SetRowHeight(1000);//行高
            table.Columns[0].Width = 1000;//第一列宽度
            table.Cells[0, 0].TextString = "第一部分：主材料清单";
            table.Cells[1, 0].TextString = "序号";
            table.Cells[1, 1].TextString = "名称";
            table.Cells[1, 2].TextString = "规格与型号";
            table.Cells[1, 3].TextString = "长度(mm)";
            table.Cells[1, 4].TextString = "校核单重(kg/m)";
            table.Cells[1, 5].TextString = "单重(kg)";
            table.Cells[1, 6].TextString = "数量(根/件）";
            table.Cells[1, 7].TextString = "重量(kg)";
            table.Cells[1, 8].TextString = "材料";
            double sumTotalWeight = 0;


            Dictionary<int,List<string>> dicttable = new Dictionary<int, List<string>>();
            int serial = 1;//序号

            #region 檩条、檩条连接件、角钢檩托
            int ltNum = 0;//檩条数量
            double LTLingth = 0; //檩条长度
            int ltljjNum = 0;//檩条连接件
            int jgltNum = 0;//角钢檩托
            List<double> ltdistance = new List<double>();
            List<Layeraxis> LTList = Layeraxislist.Where(x => x.levelNumber == "檩条").ToList();
            if (LTList.Count > 0)
            {
                string name = "檩条";
                for (int i = 0; i < LTList.Count; i++)
                {
                    List<Eleline> eleList = Linelist.Where(x => x.unitNumber == LTList[i].unitNumber).ToList();
                    List<Eleline> eleList1 = Linelist.Where(x => x.unitNumber == LTList[i+1].unitNumber).ToList();
                    if (eleList.Count > 0)
                    {
                        if (eleList[0].endNode != eleList1[0].startNode)
                        {
                            ltNum = i + 1;
                            break;
                        }
                        ltdistance.Add(GetDistanceBetweenTwoPoint(pdict[eleList[0].startNode], pdict[eleList[0].endNode]));
                    }
                }
                ltNum = LTList.Count / ltNum;
                string specification = string.Empty;
                List<double> ltList = GetSpecification(Linelist, sectionList, LTList[0].unitNumber,ref specification); //型号
                for (int i = 0; i < LTList.Count / ltNum; i++)
                {
                    LTLingth += GetNodePoint3d(Linelist, pdict, LTList[i].unitNumber, pointTool);
                }
                double Acreage = ((ltList[3] * ltList[2]) * 2) + ((ltList[3] * (ltList[1] - (ltList[3] * 2))) * 2) + (ltList[3] * ltList[0]);//面积
                double SingleWeight = Math.Round(Acreage / 1000 / 1000 * 7850, 5);//校核单重
                double PieceWeight = Math.Round(LTLingth * SingleWeight / 1000,5);//单重
                double TotalWeight = Math.Round(PieceWeight * ltNum, 5);//总重
                sumTotalWeight += TotalWeight;
                string materialcs = GetMaterial(Linelist, materialList, LTList[0].unitNumber);
                TableDataAdd(dicttable, serial, name, specification, LTLingth.ToString("f0"), SingleWeight.ToString("f2"), PieceWeight.ToString("f2"), ltNum.ToString(), TotalWeight.ToString("f2"), materialcs);
                serial++;

                name = "檩条连接件";
                double length = ltList[0] + 8;
                double width = ltList[1] + 4;
                double thickness = 4;
                Acreage = (length * 4) + ((width - 4) * 4 * 2);
                SingleWeight = Math.Round(Acreage / 1000 / 1000 * 7850,5);
                PieceWeight = Math.Round(210 * SingleWeight / 1000,5);
                List<double> list = GetPurlinConnectionDistanceLst(LTLingth, ltdistance[1], ltdistance[0]);
                ltljjNum = list.Count() * ltNum;


                TotalWeight = Math.Round(PieceWeight * ltljjNum, 5);
                sumTotalWeight += TotalWeight;
                specification = "C" + length + "x" + width + "x" + thickness;
                TableDataAdd(dicttable, serial, name, specification, "210", SingleWeight.ToString("f2"), PieceWeight.ToString("f2"), ltljjNum.ToString(), TotalWeight.ToString("f2"), materialcs);
                serial++;

                name = "角钢檩托";
                specification = "L" + (ltList[0] / 2 + 40 + 10)  + "x56x5";
                Acreage = (((ltList[0] / 2) + 40 + 10) * 5) + 56 * 5 - 5 * 5;
                SingleWeight = Math.Round( Acreage / 1000 / 1000 * 7850,5);
                PieceWeight = Math.Round(50 * SingleWeight / 1000,5);
                jgltNum = Convert.ToInt32(Math.Floor(LTLingth / 4000)) * ltljjNum;
                TotalWeight = Math.Round(PieceWeight * jgltNum, 5);
                sumTotalWeight += TotalWeight;
                TableDataAdd(dicttable, serial, name, specification, "50", SingleWeight.ToString("f2"), PieceWeight.ToString("f2"), jgltNum.ToString(), TotalWeight.ToString("f2"), materialcs);
                serial++;
            }
            #endregion


            #region 立柱、立柱底板、立柱底板加劲板
            int lzNum = 0;//立柱数量
            int lzdbNum = 0;//立柱底板数量
            int lzdbjjbNum = 0;//立柱底板加劲板数量
            LTList = Layeraxislist.Where(x => x.levelNumber == "立柱").ToList();
            if (LTList.Count > 0)
            {
                lzNum = LTList.Count;//数量
                string name = "立柱";
                string specification = string.Empty;
                List<double> ltList = GetSpecification(Linelist, sectionList, LTList[0].unitNumber, ref specification); //型号
                List<Eleline> eleList = Linelist.Where(x => x.unitNumber == LTList[0].unitNumber).ToList();
                double height = 0.0;//长度
                double Acreage = 0.0;
                if (eleList.Count > 0)
                {
                    Point3d startNode = pdict[eleList[0].startNode];
                    Point3d endNode = pdict[eleList[0].endNode];
                    height = GetDistanceBetweenTwoPoint(startNode, endNode);
                }
                if (ltList.Count == 2)
                {
                    Acreage = ltList[0] * ltList[1];//面积
                }
                else if (ltList.Count == 4)
                {
                    Acreage = ((ltList[3] * ltList[2]) * 2) + ((ltList[3] * (ltList[1] - (ltList[3] * 2))) * 2) + (ltList[3] * ltList[0]);//面积

                }
                else if (ltList.Count == 3)
                {
                    Acreage = ((ltList[1] - ltList[2]) * ltList[2] * 2) + ltList[0] * ltList[2];//面积
                }
                double SingleWeight = Math.Round(Acreage / 1000 / 1000 * 7850,5);//校核单重
                double PieceWeight = Math.Round(height * SingleWeight / 1000,5);//单重
                double TotalWeight = Math.Round(PieceWeight * lzNum, 5);//总重
                sumTotalWeight += TotalWeight;
                string materialcs = GetMaterial(Linelist, materialList, LTList[0].unitNumber);

                TableDataAdd(dicttable, serial, name, specification, height.ToString("f0"), SingleWeight.ToString("f2"), PieceWeight.ToString("f2"), lzNum.ToString(), TotalWeight.ToString("f2"), materialcs);
                serial++;

                name = "立柱底板";
                lzdbNum = lzNum;
                TableDataAdd(dicttable, serial, name, "230×190×10", "", "", "3.43", lzdbNum.ToString(), "13.72", materialcs);
                sumTotalWeight += 13.7218;
                serial++;

                name = "立柱底板加劲板";
                lzdbjjbNum = lzNum * 2;
                TableDataAdd(dicttable, serial, name, "200×50×5", "", "", "0.39", lzdbjjbNum.ToString(), "6.28", materialcs);
                sumTotalWeight += 6.28;
                serial++;
            }

            #endregion

            #region 斜梁
            int xlNum = 0;//斜梁数量
            LTList = Layeraxislist.Where(x => x.levelNumber == "斜梁").ToList();
            if (LTList.Count > 0)
            {
                string Name = "斜梁";
                for (int i = 0; i < LTList.Count; i++)
                {
                    List<Eleline> eleList = Linelist.Where(x => x.unitNumber == LTList[i].unitNumber).ToList();
                    List<Eleline> eleList1 = Linelist.Where(x => x.unitNumber == LTList[i + 1].unitNumber).ToList();
                    if (eleList[0].endNode != eleList1[0].startNode)
                    {
                        xlNum = i + 1;
                        break;
                    }
                }
                xlNum = LTList.Count / xlNum;
                string specification = string.Empty;
                List<double> ltList = GetSpecification(Linelist, sectionList, LTList[0].unitNumber, ref specification); //型号
                double XLlingth = 240; //长度
                for (int i = 0; i < LTList.Count / xlNum; i++)
                {
                    XLlingth += GetNodePoint3d(Linelist, pdict, LTList[i].unitNumber, pointTool);
                }
                double Acreage = ((ltList[3] * ltList[2]) * 2) + ((ltList[3] * (ltList[1] - (ltList[3] * 2))) * 2) + (ltList[3] * ltList[0]);//面积
                double SingleWeight = Math.Round(Acreage / 1000 / 1000 * 7850,5);//校核单重
                double PieceWeight = Math.Round(XLlingth * SingleWeight / 1000,5);//单重
                double TotalWeight = Math.Round(PieceWeight * xlNum, 5);//总重
                sumTotalWeight += TotalWeight;
                string materialcs = GetMaterial(Linelist, materialList, LTList[0].unitNumber);
                TableDataAdd(dicttable, serial, Name, specification, XLlingth.ToString("f0"), SingleWeight.ToString("f2"), PieceWeight.ToString("f2"), xlNum.ToString(), TotalWeight.ToString("f2"), materialcs);
                serial++;
            }


            #endregion

            #region 前斜撑、后斜撑
            int qxcNum = 0;//前斜撑数量
            LTList = Layeraxislist.Where(x => x.levelNumber == "前斜撑").ToList();
            if (LTList.Count > 0)
            {
                string Name = "前斜撑";//名称
                qxcNum = LTList.Count;//数量
                string specification = string.Empty;
                List<double> ltList = GetSpecification(Linelist, sectionList, LTList[0].unitNumber, ref specification); //型号
                List<Eleline> eleList = Linelist.Where(x => x.unitNumber == LTList[0].unitNumber).ToList();
                double height = qxcLength;//长度
                //if (eleList.Count > 0)
                //{
                //    Point3d startNode = pdict[eleList[0].startNode];
                //    Point3d endNode = pdict[eleList[0].endNode];
                //    height += GetDistanceBetweenTwoPoint(startNode, endNode);
                //}
                double Acreage = ((ltList[1] - ltList[2])* ltList[2] * 2) + ltList[0] * ltList[2];//面积
                double SingleWeight = Math.Round(Acreage / 1000 / 1000 * 7850,5);//校核单重
                double PieceWeight = Math.Round(height * SingleWeight / 1000,5);//单重
                double TotalWeight = Math.Round(PieceWeight * qxcNum, 5);//总重
                sumTotalWeight += TotalWeight;
                string materialcs = GetMaterial(Linelist, materialList, LTList[0].unitNumber);
                TableDataAdd(dicttable, serial, Name, specification, height.ToString("f0"), SingleWeight.ToString("f2"), PieceWeight.ToString("f2"), qxcNum.ToString(), TotalWeight.ToString("f2"), materialcs);
                serial++;
            }
            int hxcNum = 0;//后斜撑数量
            LTList = Layeraxislist.Where(x => x.levelNumber == "后斜撑").ToList();
            if (LTList.Count > 0)
            {
                string Name = "后斜撑";//名称
                hxcNum = LTList.Count;//数量
                string specification = string.Empty;
                List<double> ltList = GetSpecification(Linelist, sectionList, LTList[0].unitNumber, ref specification); //型号
                List<Eleline> eleList = Linelist.Where(x => x.unitNumber == LTList[0].unitNumber).ToList();
                double height = hxcLength;//长度
                //if (eleList.Count > 0)
                //{
                //    Point3d startNode = pdict[eleList[0].startNode];
                //    Point3d endNode = pdict[eleList[0].endNode];
                //    height += GetDistanceBetweenTwoPoint(startNode, endNode);
                //}
                double Acreage = ((ltList[1] - ltList[2]) * ltList[2] * 2) + ltList[0] * ltList[2];//面积
                double SingleWeight = Math.Round(Acreage / 1000 / 1000 * 7850,5);//校核单重
                double PieceWeight = Math.Round(height * SingleWeight / 1000,5);//单重
                double TotalWeight = Math.Round(PieceWeight * hxcNum, 5);//总重
                sumTotalWeight += TotalWeight;
                string materialcs = GetMaterial(Linelist, materialList, LTList[0].unitNumber);
                TableDataAdd(dicttable, serial,Name, specification, height.ToString("f0"), SingleWeight.ToString("f2"), PieceWeight.ToString("f2"), hxcNum.ToString(), TotalWeight.ToString("f2"), materialcs);
                serial++;
            }
            #endregion

            #region 大抱箍、小抱箍
            int dbgNum = 0;//大抱箍数量
            int xbgNum = 0;//小抱箍数量
            LTList = Layeraxislist.Where(x => x.levelNumber == "抱箍").ToList();
            if (LTList.Count > 0)
            {
                string name = "大抱箍";
                xbgNum = dbgNum = lzNum;
                TableDataAdd(dicttable, serial, name, "670×70×5", "", "", "2.20", dbgNum.ToString(), "8.79", "Q235");
                sumTotalWeight += 8.792;
                serial++;
                name = "小抱箍";
                TableDataAdd(dicttable, serial, name, "450×70×5", "", "", "1.56", xbgNum.ToString(), "6.22", "Q235");
                sumTotalWeight += 6.224;
                serial++;
            }
            #endregion

            

            int totalrow = dicttable.Count + 2;
            var mcells = CellRange.Create(table, totalrow, 0, totalrow, 2);
            table.MergeCells(mcells);
            table.Cells[totalrow, 0].TextString = "单阵列支架构件合计";
            table.Cells[totalrow, 7].TextString = sumTotalWeight.ToString("f2");
            totalrow++;
            var cell = CellRange.Create(table, totalrow, 0, totalrow, colum-1);
            table.MergeCells(cell);
            table.Cells[totalrow, 0].TextString = "第二部分：连接件清单";
            totalrow++;

            table.Cells[totalrow, 0].TextString = "序号";
            table.Cells[totalrow, 1].TextString = "名称";
            table.Cells[totalrow, 2].TextString = "规格与型号";
            table.Cells[totalrow, 3].TextString = "单重(kg)";
            table.Cells[totalrow, 4].TextString = "数量(套）";
            table.Cells[totalrow, 5].TextString = "重量(kg)";
            table.Cells[totalrow, 6].TextString = "材料";
            var cell2 = CellRange.Create(table, totalrow, 7, totalrow, colum-1);
            table.MergeCells(cell2);
            table.Cells[totalrow, 7].TextString = "连接位置";
            totalrow++;
            serial = 1;
            Dictionary<int, List<string>> dicAdaptingPiece = new Dictionary<int, List<string>>();
            AdaptingPieceFunc pieceFunc = new AdaptingPieceFunc();
            AdaptingPiece piece;
            #region 立柱与斜梁连接件
            int lzlscount = lzNum;
            piece = pieceFunc.GetAdaptingPieceInfo(JointPositionOption.StandColumnandCantBeam);
            TableDataAdd(dicAdaptingPiece, serial, totalrow, piece.BoltName, piece.AdaptingPieceDetail, piece.PieceWeight.ToString(), lzlscount.ToString(), (piece.PieceWeight * lzlscount).ToString(), piece.Remark, piece.JointPart);
            #endregion
            totalrow++;
            serial++;
            #region 斜梁与斜撑连接件、斜撑与抱箍连接件
            lzlscount = qxcNum + hxcNum;
            piece = pieceFunc.GetAdaptingPieceInfo(JointPositionOption.InclinedStrutandCantBeam);
            TableDataAdd(dicAdaptingPiece, serial, totalrow, piece.BoltName, piece.AdaptingPieceDetail, piece.PieceWeight.ToString(), lzlscount.ToString(), (piece.PieceWeight * lzlscount).ToString(), piece.Remark, piece.JointPart);
            totalrow++;
            serial++;
            piece = pieceFunc.GetAdaptingPieceInfo(JointPositionOption.InclinedStrutandBeamClamp);
            TableDataAdd(dicAdaptingPiece, serial, totalrow, piece.BoltName, piece.AdaptingPieceDetail, piece.PieceWeight.ToString(), lzlscount.ToString(), (piece.PieceWeight * lzlscount).ToString(), piece.Remark, piece.JointPart);
            #endregion
            totalrow++;
            serial++;
            #region 抱箍与立柱连接件
            lzlscount = xbgNum * 2;
            piece = pieceFunc.GetAdaptingPieceInfo(JointPositionOption.BeamClampandStandColumn);
            TableDataAdd(dicAdaptingPiece, serial, totalrow, piece.BoltName, piece.AdaptingPieceDetail, piece.PieceWeight.ToString(), lzlscount.ToString(), (piece.PieceWeight * lzlscount).ToString(), piece.Remark, piece.JointPart);
            #endregion
            totalrow++;
            serial++;
            #region 角钢檩托
            lzlscount = jgltNum;
            piece = pieceFunc.GetAdaptingPieceInfo(JointPositionOption.PurlinBracketandPurline);
            TableDataAdd(dicAdaptingPiece, serial, totalrow, piece.BoltName, piece.AdaptingPieceDetail, piece.PieceWeight.ToString(), lzlscount.ToString(), (piece.PieceWeight * lzlscount).ToString(), piece.Remark, piece.JointPart);
            totalrow++;
            serial++;
            piece = pieceFunc.GetAdaptingPieceInfo(JointPositionOption.PurlinBracketandCantBeam);
            TableDataAdd(dicAdaptingPiece, serial, totalrow, piece.BoltName, piece.AdaptingPieceDetail, piece.PieceWeight.ToString(), lzlscount.ToString(), (piece.PieceWeight * lzlscount).ToString(), piece.Remark, piece.JointPart);
            #endregion
            totalrow++;
            serial++;
            #region 檩条连接件
            lzlscount = ltljjNum * 12;
            piece = pieceFunc.GetAdaptingPieceInfo(JointPositionOption.PurlinConnectors);
            TableDataAdd(dicAdaptingPiece, serial, totalrow, piece.BoltName, piece.AdaptingPieceDetail, piece.PieceWeight.ToString(), lzlscount.ToString(), (piece.PieceWeight * lzlscount).ToString(), piece.Remark, piece.JointPart);
            #endregion
            totalrow++;
            serial++;
            #region 组件与檩条连接件
            lzlscount = ltNum * solarPanel.YNumber  * solarPanel.XNumber;
            piece = pieceFunc.GetAdaptingPieceInfo(JointPositionOption.ModuleandPurline);
            TableDataAdd(dicAdaptingPiece, serial, totalrow, piece.BoltName, piece.AdaptingPieceDetail, piece.PieceWeight.ToString(), lzlscount.ToString(), (piece.PieceWeight * lzlscount).ToString(), piece.Remark, piece.JointPart);
            #endregion
            totalrow++;
            mcells = CellRange.Create(table, totalrow, 0, totalrow, 2);
            table.MergeCells(mcells);
            table.Cells[totalrow, 0].TextString = "单阵列支架螺栓合计";


            int key = 1;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    table.Cells[i, j].TextHeight = 300;
                    table.Cells[i, j].Alignment = CellAlignment.MiddleCenter;
                    table.Cells[i, j].TextStyleId = fontobjectid;
                    if (i > 1)
                    {
                        if (dicttable.ContainsKey(key))
                        {
                            table.Cells[i, j].TextString = dicttable[key][j];
                        }
                        if (dicAdaptingPiece.ContainsKey(i))
                        {
                            if (dicAdaptingPiece[i].Count > j)
                            {
                                if (dicAdaptingPiece[i].Count - 1 == j)
                                {
                                    var hbcolum = CellRange.Create(table, i, j, i, colum - 1);
                                    table.MergeCells(hbcolum);
                                }
                                table.Cells[i, j].TextString = dicAdaptingPiece[i][j];
                            }
                        }
                    }
                }
                if (i > 1)
                {
                    key++;
                }
            }


            Database database = HostApplicationServices.WorkingDatabase;
            using (Transaction trans = database.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)trans.GetObject(database.BlockTableId, OpenMode.ForRead);
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                btr.AppendEntity(table);
                trans.AddNewlyCreatedDBObject(table, true);
                trans.Commit();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dicttable"></param>
        /// <param name="serial">序号</param>
        /// <param name="name">名称</param>
        /// <param name="specification">规格</param>
        /// <param name="height">长度</param>
        /// <param name="singleWeight">校核单重</param>
        /// <param name="pieceWeight">单重</param>
        /// <param name="num">数量</param>
        /// <param name="totalWeight">总重</param>
        /// <param name="materialcs">材料</param>
        private static void TableDataAdd(Dictionary<int, List<string>> dicttable, int serial, string name, string specification, string height, string singleWeight, string pieceWeight, string num, string totalWeight, string materialcs)
        {
            List<string> tableList = new List<string>();
            tableList.Add(serial.ToString());
            tableList.Add(name);
            tableList.Add(specification);
            tableList.Add(height);
            tableList.Add(singleWeight);
            tableList.Add(pieceWeight);
            tableList.Add(num);
            tableList.Add(totalWeight);
            tableList.Add(materialcs);
            dicttable.Add(serial, tableList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dicttable"></param>
        /// <param name="serial">序号</param>
        /// <param name="key">key</param>
        /// <param name="name">名称</param>
        /// <param name="specification">规格</param>
        /// <param name="singleWeight">单重</param>
        /// <param name="num">数量</param>
        /// <param name="totalWeight">总重</param>
        /// <param name="materialcs">材料</param>
        /// <param name="describe">描述</param>
        private static void TableDataAdd(Dictionary<int, List<string>> dicttable,int serial,int key,string name, string specification, string singleWeight, string num, string totalWeight,string materialcs, string describe)
        {
            List<string> tableList = new List<string>();
            tableList.Add(serial.ToString());
            tableList.Add(name);
            tableList.Add(specification);
            tableList.Add(singleWeight);
            tableList.Add(num);
            tableList.Add(totalWeight);
            tableList.Add(materialcs);
            tableList.Add(describe);
            dicttable.Add(key, tableList);
        }

        /// <summary>
        /// 获取材料名称
        /// </summary>
        /// <param name="linelist"></param>
        /// <param name="materialList"></param>
        /// <param name="unitNumber"></param>
        /// <returns></returns>
        private static string GetMaterial(List<Eleline> linelist, List<Materialcs> materialList, int unitNumber)
        {
            string materialName = string.Empty;
            List<Eleline> elList = linelist.Where(x => x.unitNumber == unitNumber).ToList();
            if (elList.Count > 0)
            {
                List<Materialcs> materialcs = materialList.Where(x => x.materialNumber == elList[0].materialNumber).ToList();
                if (materialcs.Count > 0)
                {
                    materialName = materialcs[0].materialName;
                }
            }
            return materialName;
        }

        /// <summary>
        /// 获取坐标
        /// </summary>
        /// <param name="linelist"></param>
        /// <param name="pdict"></param>
        /// <param name="unitNumber"></param>
        /// <returns></returns>
        private static double GetNodePoint3d(List<Eleline> linelist, Dictionary<int, Point3d> pdict, int unitNumber, PointTool pointTool)
        {
            double lenght = 0;
            List<Eleline> elList = linelist.Where(x => x.unitNumber == unitNumber).ToList();
            if (elList.Count > 0)
            {
                lenght = GetDistanceBetweenTwoPoint(pdict[elList[0].startNode], pdict[elList[0].endNode]);
            }
            return lenght;
        }

        /// <summary>
        /// 获取型号
        /// </summary>
        /// <param name="Linelist"></param>
        /// <param name="sectionList"></param>
        /// <param name="unitNumber"></param>
        /// <returns></returns>
        public static List<double> GetSpecification(List<Eleline> Linelist, List<Section> sectionList, int unitNumber, ref string specification)
        {
            List<double> ltList = new List<double>();
            List<Eleline> elList = Linelist.Where(x => x.unitNumber == unitNumber).ToList();
            if (elList.Count > 0)
            {
                List<Section> sList = sectionList.Where(x => x.SectionTypeId == elList[0].sectionType && x.SectionId == elList[0].sectionNumber).ToList();
                if (sList.Count > 0)
                {
                    specification = sList[0].Specification.Trim();
                    string Specification = sList[0].Specification.Trim().Substring(1);
                    string[] Specifications = Specification.Split('x');
                    for (int i = 0; i < Specifications.Count(); i++)
                    {
                        ltList.Add(Convert.ToDouble(Specifications[i]));
                    }
                }
            }
            return ltList;
        }

        /// <summary>
        /// 获取檩条连接件距离所在檩条起点的距离的列表
        /// </summary>
        /// <param name="purlinLength">檩条总长度</param>
        /// <param name="span">支座间距</param>
        /// <param name="remainDistance">悬挑长度</param>
        /// <returns>间距列表，如果计算有误，返回空的列表</returns>
        private static List<double> GetPurlinConnectionDistanceLst(double purlinLength = 14000, double span = 2000, double remainDistance = 200)
        {
            //返回值
            List<double> distanceLst = new List<double>();

            //第一段长度
            double distance = remainDistance + span * 4 / 3;

            //确保取单位为mm时，整五
            int num = (Convert.ToInt32(distance) + 5) / 10;
            if (num % 10 == 0)
            {
                distance = num * 10 - 5;
            }
            else
            {
                distance = num * 10;
            }


            //最后一段：不能在t + l / 2范围内
            double minRemainLength = remainDistance + span / 2;


            //剩下的长度
            double remainLength = purlinLength - distance;

            //相邻两段檩条连接件之间的步长
            double stepLength = 2 * span;

            while (remainLength > minRemainLength)
            {
                distanceLst.Add(distance);

                distance += stepLength;

                //确保取单位为mm时，整五
                num = (Convert.ToInt32(distance) + 5) / 10;
                if (num % 10 == 0)
                {
                    distance = num * 10 - 5;
                }
                else
                {
                    distance = num * 10;
                }

                remainLength = purlinLength - distance;

            }

            return distanceLst;
        }

    }
}
