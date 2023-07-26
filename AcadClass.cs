using Autodesk.AutoCAD.ApplicationServices;
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
            double height = 800;
            double width = 200;
            dictionary.Add("高度", height);
            dictionary.Add("宽度", width);
            var insertPoint = new Point3d(1000, 0, 0);
            BlockFunc.InsertDwgFile(filePath, Path.GetFileNameWithoutExtension(filePath), 1, 0, insertPoint, dictionary);
        }

    }
}
