using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using DotNetARX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class AcadFunc
    {
        /// <summary>
        /// 创建单列单晶硅组件
        /// </summary>
        /// <param name="columnCount">列数</param>
        /// <param name="rowCount">行数</param>
        /// <param name="cSpacing">列间距</param>
        /// <param name="rSpacing">行间距</param>
        /// <param name="columnWidth">列宽</param>
        /// <param name="rowHeight">行高</param>
        /// <param name="xMinPoint">阵列x最小坐标</param>
        /// <param name="yMinPoint">阵列y最小坐标</param>
        /// <param name="layerId">图层Id</param>
        /// <param name="txtStyleId">文字样式Id</param>
        //public static void CreateSingleCrystalSiliconModule(int columnCount, int rowCount, int cSpacing, int rSpacing, int columnWidth, int rowHeight, double xMinPoint, double yMinPoint,ObjectId layerId,ObjectId txtStyleId)
        //{
        //    Document doc = Application.DocumentManager.MdiActiveDocument;
        //    Database db = doc.Database;
        //    using (Transaction tx = db.TransactionManager.StartTransaction())
        //    {
        //        double yPoint = yMinPoint +(rowHeight * rowCount) + (rSpacing * (rowCount - 1) - (rowHeight / 2));
        //        double xPoint = xMinPoint + (columnWidth / 4);
        //        Polyline TriangleLine = new Polyline();
        //        Point2d Trianglep1 = new Point2d(xPoint, yPoint);
        //        Point2d Trianglep2 = new Point2d(xMinPoint, yPoint +(columnWidth / 8));
        //        Point2d Trianglep3 = new Point2d(xMinPoint, yPoint - (columnWidth / 8));
        //        TriangleLine.AddVertexAt(0, Trianglep1, 0, 0, 0);
        //        TriangleLine.AddVertexAt(0, Trianglep2, 0, 0, 0);
        //        TriangleLine.AddVertexAt(0, Trianglep3, 0, 0, 0);
        //        TriangleLine.Closed = true;
        //        ObjectId TriangleId = db.AddToModelSpace(TriangleLine);
        //        int count = 1;
        //        int lineCount = 1;

        //        Polyline pLine = new Polyline();
        //        Point2d p1 = Trianglep1;
        //        double xLinePt = xMinPoint + (columnWidth * columnCount) + (cSpacing * (columnCount - 1)) - (columnWidth / 2);
        //        Point2d p2 = new Point2d(xLinePt, yPoint);
        //        pLine.AddVertexAt(0, p1, 0, 0, 0);
        //        pLine.AddVertexAt(0, p2, 0, 0, 0);
        //        pLine.Closed = false;
        //        db.AddToModelSpace(pLine);
        //        for (int i = 0; i < columnCount; i++)
        //        {
        //            DBText textFirst = new DBText();
        //            double txPoint = xMinPoint + (columnWidth / 8) + (columnWidth * i) + (cSpacing * i);
        //            double tyPoint = yMinPoint + (rowHeight / 8);
        //            textFirst.Position = new Point3d(txPoint, tyPoint, 0);
        //            if (count > 9)
        //            {
        //                textFirst.TextString = count.ToString();
        //            }
        //            else
        //            {
        //                textFirst.TextString = "0" + count;
        //            }
        //            textFirst.HorizontalMode = TextHorizontalMode.TextLeft;
        //            textFirst.Height = (rowHeight / 8);
        //            db.AddToModelSpace(textFirst);
        //            count++;
        //        }

        //        if (rowCount > 1)
        //        {
        //            for (int i = rowCount; i > 1; i--)
        //            {
        //                if (i - 1 > 0)
        //                {
        //                    if (lineCount % 2 == 1)
        //                    {
        //                        Polyline polyLine = new Polyline();
        //                        double lxPoint1 = xMinPoint + (columnWidth * columnCount) + (cSpacing * (columnCount - 1)) - (columnWidth / 2);
        //                        double lyPoint1 = yMinPoint + (rowHeight * i) + (rSpacing * (i - 1)) - (rowHeight / 2);
        //                        Point2d pt1 = new Point2d(lxPoint1, lyPoint1);
        //                        double lxPoint2 = xMinPoint + (columnWidth * columnCount) + (cSpacing * (columnCount - 1)) - (columnWidth / 2);
        //                        double lyPoint2 = yMinPoint + (rowHeight * (i - 1)) + (rSpacing * (i - 2)) - (rowHeight / 2);
        //                        Point2d pt2 = new Point2d(lxPoint2, lyPoint2);
        //                        polyLine.AddVertexAt(0, pt1, 0, 0, 0);
        //                        polyLine.AddVertexAt(0, pt2, 0, 0, 0);
        //                        polyLine.Closed = false;
        //                        db.AddToModelSpace(polyLine);
        //                    }
        //                    else
        //                    {
        //                        Polyline polyLine = new Polyline();
        //                        double lxPoint1 = xMinPoint + (columnWidth / 2);
        //                        double lyPoint1 = yMinPoint + (rowHeight * i) + (rSpacing * (i - 1)) - (rowHeight / 2);
        //                        Point2d pt1 = new Point2d(lxPoint1, lyPoint1);
        //                        double lxPoint2 = xMinPoint + (columnWidth / 2);
        //                        double lyPoint2 = yMinPoint + (rowHeight * (i - 1)) + (rSpacing * (i - 2)) - (rowHeight / 2);
        //                        Point2d pt2 = new Point2d(lxPoint2, lyPoint2);
        //                        polyLine.AddVertexAt(0, pt1, 0, 0, 0);
        //                        polyLine.AddVertexAt(0, pt2, 0, 0, 0);
        //                        polyLine.Closed = false;
        //                        db.AddToModelSpace(polyLine);
        //                    }
        //                    lineCount++;
        //                    Polyline Line = new Polyline();
        //                    double linexPoint1 = xMinPoint + (columnWidth / 2);
        //                    double lineyPoint1 = yMinPoint + (rowHeight * (i - 1)) + (rSpacing * (i - 2)) - (rowHeight / 2);
        //                    Point2d linept1 = new Point2d(linexPoint1, lineyPoint1);
        //                    double linexPoint2 = xMinPoint + (columnWidth * columnCount) + (cSpacing * (columnCount - 1)) - (columnWidth / 2);
        //                    double lineyPoint2 = yMinPoint + (rowHeight * (i - 1)) + (rSpacing * (i - 2)) - (rowHeight / 2);
        //                    Point2d linept2 = new Point2d(linexPoint2, lineyPoint2);
        //                    Line.AddVertexAt(0, linept1, 0, 0, 0);
        //                    Line.AddVertexAt(0, linept2, 0, 0, 0);
        //                    Line.Closed = false;
        //                    db.AddToModelSpace(Line);
        //                }
        //            }
        //        }
        //        tx.Commit();
        //    }
        //}


        /// <summary>
        /// 创建单列单晶硅组件
        /// </summary>
        /// <param name="columnCount">列数</param>
        /// <param name="rowCount">行数</param>
        /// <param name="cSpacing">列间距</param>
        /// <param name="rSpacing">行间距</param>
        /// <param name="columnWidth">列宽</param>
        /// <param name="rowHeight">行高</param>
        /// <param name="xMinPoint">阵列x最小坐标</param>
        /// <param name="yMinPoint">阵列y最小坐标</param>
        /// <param name="layerId">图层Id</param>
        /// <param name="txtStyleId">文字样式Id</param>
        public static void CreateSingleCrystalSiliconModule(int columnCount, int rowCount, int cSpacing, int rSpacing, int columnWidth, int rowHeight, double xMinPoint, double yMinPoint, ObjectId layerId, ObjectId txtStyleId)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                double yPoint = yMinPoint + (rowHeight * rowCount) + (rSpacing * (rowCount - 1) - (rowHeight / 2));
                double xPoint = xMinPoint + (columnWidth / 4);
                Polyline TriangleLine = new Polyline();
                Point2d Trianglep1 = new Point2d(xPoint, yPoint);
                Point2d Trianglep2 = new Point2d(xMinPoint, yPoint + (columnWidth / 8));
                Point2d Trianglep3 = new Point2d(xMinPoint, yPoint - (columnWidth / 8));
                TriangleLine.AddVertexAt(0, Trianglep1, 0, 0, 0);
                TriangleLine.AddVertexAt(0, Trianglep2, 0, 0, 0);
                TriangleLine.AddVertexAt(0, Trianglep3, 0, 0, 0);
                TriangleLine.Closed = true;
                ObjectId TriangleId = db.AddToModelSpace(TriangleLine);
                int count = 1;

                if (rowCount > 1)
                {
                    Polyline pLine = new Polyline();
                    Point2d p1 = Trianglep1;
                    double xLinePt = xMinPoint + (columnWidth * columnCount) + (cSpacing * (columnCount - 1)) - (columnWidth / 2);
                    Point2d p2 = new Point2d(xLinePt, yPoint);
                    double xlinePoint3 = xMinPoint + (columnWidth * columnCount) + (cSpacing * (columnCount - 1)) - (columnWidth / 2);
                    double ylinePoint3 = yMinPoint + (rowHeight / 2);
                    Point2d p3 = new Point2d(xlinePoint3, ylinePoint3);
                    double xlinePoint4 = xMinPoint + (columnWidth / 2);
                    double ylinePoint4 = yMinPoint + (rowHeight / 2);
                    Point2d p4 = new Point2d(xlinePoint4, ylinePoint4);
                    pLine.AddVertexAt(0, p1, 0, 0, 0);
                    pLine.AddVertexAt(0, p2, 0, 0, 0);
                    pLine.AddVertexAt(0, p3, 0, 0, 0);
                    pLine.AddVertexAt(0, p4, 0, 0, 0);
                    pLine.Closed = false;
                    db.AddToModelSpace(pLine);

                    for (int j = 0; j < columnCount; j++)
                    {
                        DBText textFirst = new DBText();
                        double txPoint = xMinPoint + (columnWidth / 8) + (columnWidth * j) + (cSpacing * j);
                        double tyPoint = yMinPoint + (rowHeight / 8) + rowHeight  + rSpacing;
                        textFirst.Position = new Point3d(txPoint, tyPoint, 0);
                        if (count > 9)
                        {
                            textFirst.TextString = count.ToString();
                        }
                        else
                        {
                            textFirst.TextString = "0" + count;
                        }
                        textFirst.HorizontalMode = TextHorizontalMode.TextLeft;
                        textFirst.Height = (rowHeight / 8);
                        db.AddToModelSpace(textFirst);
                        count++;
                    }
                    for (int j = columnCount; j > 0; j--)
                    {
                        DBText textFirst = new DBText();
                        double txPoint = xMinPoint + (columnWidth / 8) + (columnWidth * (j - 1)) + (cSpacing * (j - 1));
                        double tyPoint = yMinPoint + (rowHeight / 8);
                        textFirst.Position = new Point3d(txPoint, tyPoint, 0);
                        if (count > 9)
                        {
                            textFirst.TextString = count.ToString();
                        }
                        else
                        {
                            textFirst.TextString = "0" + count;
                        }
                        textFirst.HorizontalMode = TextHorizontalMode.TextLeft;
                        textFirst.Height = (rowHeight / 8);
                        db.AddToModelSpace(textFirst);
                        count++;
                    }
                }
                else
                {
                    Polyline pLine = new Polyline();
                    Point2d p1 = Trianglep1;
                    double xLinePt = xMinPoint + (columnWidth * columnCount) + (cSpacing * (columnCount - 1)) - (columnWidth / 2);
                    Point2d p2 = new Point2d(xLinePt, yPoint);
                    pLine.AddVertexAt(0, p1, 0, 0, 0);
                    pLine.AddVertexAt(0, p2, 0, 0, 0);
                    pLine.Closed = false;
                    db.AddToModelSpace(pLine);
                    for (int i = 0; i < columnCount; i++)
                    {
                        DBText textFirst = new DBText();
                        double txPoint = xMinPoint + (columnWidth / 8) + (columnWidth * i) + (cSpacing * i);
                        double tyPoint = yMinPoint + (rowHeight / 8);
                        textFirst.Position = new Point3d(txPoint, tyPoint, 0);
                        if (count > 9)
                        {
                            textFirst.TextString = count.ToString();
                        }
                        else
                        {
                            textFirst.TextString = "0" + count;
                        }
                        textFirst.HorizontalMode = TextHorizontalMode.TextLeft;
                        textFirst.Height = (rowHeight / 8);
                        db.AddToModelSpace(textFirst);
                        count++;
                    }
                }
                tx.Commit();
            }
        }
    }
}
