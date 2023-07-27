﻿using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using DotNetARX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class AcadClass
    {
        [CommandMethod("AcsArray")]
        public void AcsArray()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                Point3d pt1 = new Point3d(0, 0, 0);
                Point3d pt2 = new Point3d(1134, 2274, 0);
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
                ObjectId objectid = db.AddToModelSpace(polyline);
                // Create the parameters for our associative path array

                ObjectIdCollection basePt = new ObjectIdCollection();
                basePt.Add(objectid);
                VertexRef BasePoint = new VertexRef(Point3d.Origin);
                int ColumnCount = 26;
                int ColumnSpacing = 20 + Convert.ToInt32(polyline.GeometricExtents.MaxPoint.X - polyline.GeometricExtents.MinPoint.X);
                int RowCount = 2;
                int RowSpacing = 20 + Convert.ToInt32(polyline.GeometricExtents.MaxPoint.Y - polyline.GeometricExtents.MinPoint.Y);
                int LevelCount = 1;
                ArrayFunc.CreateArray(basePt, BasePoint, ColumnCount, ColumnSpacing, RowCount, RowSpacing, LevelCount);
                AssocManager.EvaluateTopLevelNetwork(db, null, 0);
                Entity entity = (Entity)objectid.GetObject(OpenMode.ForWrite);
                entity.Erase(true);
                trans.Commit();
            }
        }

        [CommandMethod("AcsBlock")]
        public void AcsBlock()
        {
            string filePath = @"D:\WxDoc\WeChat Files\wxid_mfa0u7d7ad3y22\FileStorage\File\2023-07\组件-带中心线.dwg";
            Dictionary<string, double> dictionary = new Dictionary<string, double>();
            dictionary.Add("高度", 30000);
            dictionary.Add("宽度", 40);
            var insertPoint = new Point3d(0, 437, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, Math.PI * 270 / 180, insertPoint, dictionary);
            dictionary["高度"] = 30000;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(0, 1837, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, Math.PI * 270 / 180, insertPoint, dictionary);
            dictionary["高度"] = 30000;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(0, 2731, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, Math.PI * 270 / 180, insertPoint, dictionary);
            dictionary["高度"] = 30000;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(0, 4131, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, Math.PI * 270 / 180, insertPoint, dictionary);


            dictionary["高度"] = 4600;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(992, 0, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, dictionary);
            dictionary["高度"] = 4600;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(4992, 0, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, dictionary);
            dictionary["高度"] = 4600;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(8992, 0, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, dictionary);
            dictionary["高度"] = 4600;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(12992, 0, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, dictionary);
            dictionary["高度"] = 4600;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(16992, 0, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, dictionary);
            dictionary["高度"] = 4600;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(20992, 0, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, dictionary);
            dictionary["高度"] = 4600;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(24992, 0, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, dictionary);
            dictionary["高度"] = 4600;
            dictionary["宽度"] = 40;
            insertPoint = new Point3d(28992, 0, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, dictionary);
        }

        [CommandMethod("AcsTextStyle")]
        public void AcsTextStyle()
        {
            string styleName = "SEPD_TJ";
            string FontName = "sepd_tss.shx";
            string BigFontName = "sepd_HZT.SHX";
            ObjectId objectid = TextStyleFunc.GetTextStyle(styleName, FontName, BigFontName);
        }

        [CommandMethod("AcsDimStyle")]
        public void AcsDimStyle()
        {
            DimStyleInfo dimInfo = new DimStyleInfo();
            dimInfo.Name = "Sepd_1_100";

            ObjectId objectid = DimStyleFunc.GetDimStyle(dimInfo.Name);
            if (objectid.IsNull)
            {
                //objectid = DimStyleFunc.AddDimStyle("Sepd_1_100", dimInfo);
            }
        }



    }
}
