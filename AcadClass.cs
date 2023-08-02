using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
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
            string styleName = "SEPD_TJ";
            string FontName = "sepd_tss.shx";
            string BigFontName = "sepd_HZT.SHX";
            DimStyleInfo dimInfo = new DimStyleInfo();
            dimInfo.Name = "Sepd_1_100_1";
            dimInfo.Dimblk = DimTools.GetArrowObjectId(Application.DocumentManager.MdiActiveDocument.Database, DimArrowBlock.ArchitecturalTick);
            dimInfo.Dimblk1 = DimTools.GetArrowObjectId(Application.DocumentManager.MdiActiveDocument.Database, DimArrowBlock.ClosedFilled);
            dimInfo.Dimaltf = 25;
            dimInfo.Dimaltu = 2;
            dimInfo.Dimarcsym = 0;
            dimInfo.Dimasz = 50;
            dimInfo.Dimatfit = 3;
            dimInfo.Dimalttd = 2;
            dimInfo.Dimadec = 2;
            dimInfo.Dimcen = 0;
            dimInfo.Dimazin = 2;
            dimInfo.Dimaltd = 2;
            dimInfo.Dimzin = 8;
            dimInfo.Dimclre = Color.FromColorIndex(ColorMethod.ByLayer, 2);
            dimInfo.Dimclrd = Color.FromColorIndex(ColorMethod.ByLayer, 2);
            dimInfo.Dimclrt = Color.FromRgb(255,255,255);
            dimInfo.Dimdec = 0;
            dimInfo.Dimdle = 100;
            dimInfo.Dimdli = 100;
            dimInfo.Dimdsep = '.';
            dimInfo.Dimexe = 100;
            dimInfo.Dimtdec = 0;
            dimInfo.Dimexo = 200;
            dimInfo.Dimfxlen = 600;
            dimInfo.Dimgap = 25;
            dimInfo.Dimjogang = Math.PI /4;
            dimInfo.Dimjust = 0;
            dimInfo.Dimldrblk = DimTools.GetArrowObjectId(Application.DocumentManager.MdiActiveDocument.Database, DimArrowBlock.ClosedFilled);
            dimInfo.Dimlfac = 1;
            dimInfo.Dimlunit = 2;
            dimInfo.Dimlwd = LineWeight.ByBlock;
            dimInfo.Dimlwe = LineWeight.ByBlock;
            dimInfo.Dimscale = 1;
            dimInfo.Dimtad = 1;
            dimInfo.Dimtmove = 2;
            dimInfo.Dimtolj = 1;
            dimInfo.Dimtxsty = TextStyleFunc.GetTextStyle(styleName, FontName, BigFontName);
            dimInfo.Dimtxt = 350;
            dimInfo.Dimtoh = false;
            dimInfo.Dimtix = true;
            dimInfo.Dimtih = false;
            dimInfo.Dimtofl = true;
            ObjectId objectid = DimStyleFunc.GetDimStyle(dimInfo.Name);
            if (objectid.IsNull)
            {
                try
                {
                    objectid = DimStyleFunc.AddDimStyle(dimInfo.Name, dimInfo);
                }
                catch (System.Exception)
                {
                }
                
            }
            
        }

        [CommandMethod("AcsMLeader")]
        public void AcsMLeader()
        {
            Point3d startPoint = new Point3d(100, 100, 0);
            Point3d lastPoint = new Point3d(60, 60, 0);
            string txt = "测试多重引线";
            string MLstyleName = "SEPD_TJ1";
            string txtstyleName = "SEPD_TJ";
            string FontName = "sepd_tss.shx";
            string BigFontName = "sepd_HZT.SHX";
            ObjectId txtObjectid = TextStyleFunc.GetTextStyle(txtstyleName, FontName, BigFontName);
            ObjectId objectId = MLeaderFunc.DrawMLeader(startPoint, lastPoint, txt, txtObjectid, MLstyleName);
        }

        [CommandMethod("AcsDevice")]
        public void AcsDevice()
        {
            DeviceBusiness device = new DeviceBusiness();
            device.GetDeviceModuleData(null, null);
        }

        [CommandMethod("AcsArraySilicon")]
        public void AcsArraySilicon()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                Point3d pt1 = new Point3d(0, 0, 0);
                Point3d pt2 = new Point3d(300, 300, 0);
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
                int CSpacing = 20;
                int RSpacing = 20;
                int ColumnWidth = Convert.ToInt32(polyline.GeometricExtents.MaxPoint.X - polyline.GeometricExtents.MinPoint.X);
                int RowHeight = Convert.ToInt32(polyline.GeometricExtents.MaxPoint.Y - polyline.GeometricExtents.MinPoint.Y);
                int ColumnSpacing = CSpacing + ColumnWidth;
                int RowCount = 2;
                int RowSpacing = RSpacing + RowHeight;
                int LevelCount = 1;
                ArrayFunc.CreateArray(basePt, BasePoint, ColumnCount, ColumnSpacing, RowCount, RowSpacing, LevelCount);
                AssocManager.EvaluateTopLevelNetwork(db, null, 0);
                Entity entity = (Entity)objectid.GetObject(OpenMode.ForWrite);
                entity.Erase(true);

                double rColumnSpacing = (polyline.GeometricExtents.MaxPoint.X - polyline.GeometricExtents.MinPoint.X) / 2;
                double rRowSpacing = (polyline.GeometricExtents.MaxPoint.Y - polyline.GeometricExtents.MinPoint.Y) / 2;

                AcadFunc.CreateSingleCrystalSiliconModule(ColumnCount, RowCount, CSpacing, RSpacing, ColumnWidth, RowHeight, polyline.GeometricExtents.MinPoint.X, polyline.GeometricExtents.MinPoint.Y, ObjectId.Null, ObjectId.Null);
                //BlockTable acBlkTbl = tx.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                //BlockTableRecord acBlkTblRec = tx.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                //ObjectIdCollection basePt = new ObjectIdCollection();
                //basePt.Add(objectid);
                //Hatch hatch = new Hatch();
                //acBlkTblRec.AppendEntity(hatch);
                //tx.AddNewlyCreatedDBObject(hatch, true);
                //hatch.SetDatabaseDefaults();
                //hatch.SetHatchPattern(HatchPatternType.PreDefined, "SOLID");
                //hatch.Associative = false;
                //hatch.AppendLoop(HatchLoopTypes.Outermost, basePt);
                //hatch.EvaluateHatch(true);



                tx.Commit();
            }
        }

        [CommandMethod("AcsListPoint")]
        public void AcsListPoint()
        {
            Point3d pt1 = new Point3d(600,100,0);
            Point3d pt2 = new Point3d(200, 200, 0);
            Point3d pt3 = new Point3d(100, 300, 0);
            Point3d pt4 = new Point3d(134, 400, 0);
            Point3d pt5 = new Point3d(124, 500, 0);
            Point3d pt6 = new Point3d(207, 600, 0);
            Point3d pt7 = new Point3d(420, 700, 0);
            Point3d pt8 = new Point3d(364, 800, 0);
            Point3d pt9 = new Point3d(236, 900, 0);
            List<Point3d> list = new List<Point3d>();
            list.Add(pt1);
            list.Add(pt2);
            list.Add(pt3);
            list.Add(pt4);
            list.Add(pt5);
            list.Add(pt6);
            list.Add(pt7);
            list.Add(pt8);
            list.Add(pt9);
            double height = 200;
            List<List<Point3d>> pList = AcadFunc.GetLinePointList(list, height);
            double tolerance = 20;
            List<ObjectId> idList = AcadFunc.CreatePolylines(pList, tolerance);
            Point3d basePoint = new Point3d(-1000, 900, 0);
            AcadFunc.CreateScalePolylines(pList, basePoint, 80, tolerance);
        }

        [CommandMethod("AcsLayout")]
        public void AcsLayout()
        {
            ObjectId spaceId = ObjectId.Null;
            string device = "acs_pdf.pc3";//绘图仪
            Point3d minPoint = new Point3d(0, 0, 0);
            Point3d maxPoint = new Point3d(841, 594, 0);
            AcadFunc.SetLayoutRange(spaceId, device, minPoint, maxPoint);
        }

    }
}
