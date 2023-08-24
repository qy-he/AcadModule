using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.PlottingServices;
using DotNetARX;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
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

                Point3d basePoint = new Point3d(xMinPoint, yMinPoint, 0);
                List<Point3d> list = GetLinePosition(basePoint, columnCount, rowCount, columnWidth, rowHeight, cSpacing, rSpacing);
                if (list.Count > 0)
                {
                    Polyline pLine = new Polyline();
                    foreach (var item in list)
                    {
                        Point2d pt = new Point2d(item.X, item.Y);
                        pLine.AddVertexAt(0, pt, 0, 0, 0);
                    }
                    pLine.Closed = false;
                    db.AddToModelSpace(pLine);
                }

                Dictionary<string, Point3d> textdict = GetTextPosition(basePoint, columnCount, rowCount, columnWidth, rowHeight, cSpacing, rSpacing);
                if (textdict.Count() > 0)
                {
                    foreach (var item in textdict)
                    {
                        DBText textFirst = new DBText();
                        textFirst.Position = new Point3d(item.Value.X, item.Value.Y, 0);
                        textFirst.TextString = item.Key;
                        textFirst.HorizontalMode = TextHorizontalMode.TextLeft;
                        textFirst.Height = (rowHeight / 8);
                        db.AddToModelSpace(textFirst);
                    }
                }
                tx.Commit();
            }
        }

        /// <summary>
        /// 获取文字坐标
        /// </summary>
        /// <param name="basePoint">基点</param>
        /// <param name="columnCount">列数</param>
        /// <param name="rowCount">行数</param>
        /// <param name="columnWidth">列宽</param>
        /// <param name="rowHeight">行宽</param>
        /// <param name="cSpacing">列间距</param>
        /// <param name="rSpacing">行间距</param>
        /// <returns></returns>
        public static Dictionary<string,Point3d> GetTextPosition(Point3d basePoint,int columnCount,int rowCount, int columnWidth,int rowHeight, int cSpacing,int rSpacing)
        {
            Dictionary<string, Point3d> dict = new Dictionary<string, Point3d>();
            if (rowCount > 1)
            {
                int count = 1;
                for (int i = 0; i < columnCount; i++)
                {
                    double txPoint = basePoint.X + (columnWidth / 8) + (columnWidth * i) + (cSpacing * i);
                    double tyPoint = basePoint.Y + (rowHeight / 8) + rowHeight + rSpacing;
                    string key = count.ToString().PadLeft(2, '0');
                    Point3d pt = new Point3d(txPoint, tyPoint, 0);
                    dict.Add(key, pt);
                    count++;
                }
                for (int j = columnCount; j > 0; j--)
                {
                    double txPoint = basePoint.X + (columnWidth / 8) + (columnWidth * (j - 1)) + (cSpacing * (j - 1));
                    double tyPoint = basePoint.Y + (rowHeight / 8);
                    string key = count.ToString().PadLeft(2, '0');
                    Point3d pt = new Point3d(txPoint, tyPoint, 0);
                    dict.Add(key, pt);
                    count++;
                }
            }
            else
            {
                for (int i = 0; i < columnCount; i++)
                {
                    double txPoint = basePoint.X + (columnWidth / 8) + (columnWidth * i) + (cSpacing * i);
                    double tyPoint = basePoint.Y + (rowHeight / 8);
                    string key = i.ToString().PadLeft(2, '0');
                    Point3d pt = new Point3d(txPoint, tyPoint, 0);
                    dict.Add(key, pt);
                }
            }
            return dict;
        }

        /// <summary>
        /// 获取多段线点坐标
        /// </summary>
        /// <param name="basePoint"></param>
        /// <param name="columnCount"></param>
        /// <param name="rowCount"></param>
        /// <param name="columnWidth"></param>
        /// <param name="rowHeight"></param>
        /// <param name="cSpacing"></param>
        /// <param name="rSpacing"></param>
        /// <returns></returns>
        public static List<Point3d> GetLinePosition(Point3d basePoint, int columnCount, int rowCount, int columnWidth, int rowHeight, int cSpacing, int rSpacing)
        {
            List<Point3d> list = new List<Point3d>();
            double linexPoint = basePoint.X + (columnWidth / 4);
            double lineyPoint = basePoint.Y + (rowHeight * rowCount) + (rSpacing * (rowCount - 1) - (rowHeight / 2));
            Point3d pt = new Point3d(linexPoint, lineyPoint, 0);
            list.Add(pt);
            linexPoint = basePoint.X + (columnWidth * columnCount) + (cSpacing * (columnCount - 1)) - (columnWidth / 2);
            pt = new Point3d(linexPoint, lineyPoint, 0);
            list.Add(pt);
            if (rowCount > 1)
            {
                lineyPoint = basePoint.Y + (rowHeight / 2);
                pt = new Point3d(linexPoint, lineyPoint, 0);
                list.Add(pt);
                linexPoint = basePoint.X + (columnWidth / 2);
                pt = new Point3d(linexPoint, lineyPoint, 0);
                list.Add(pt);
            }
            return list;
        }

        /// <summary>
        /// 创建多段线，并偏移一定距离
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static List<ObjectId> CreatePolylines(List<List<Point3d>> pList, double tolerance)
        {
            List<ObjectId> lineList = new List<ObjectId>();
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                PointTool pTool = new PointTool();
                foreach (var list in pList)
                {
                    List<Point3d> newList = pTool.GetNewBoundingBox(list, tolerance);
                    if (newList != null)
                    {
                        Polyline pLine = new Polyline();
                        foreach (var item in newList)
                        {
                            Point2d pt = new Point2d(item.X, item.Y);
                            pLine.AddVertexAt(0, pt, 0, 0, 0);
                        }
                        pLine.Closed = true;
                        ObjectId lineObjectId = db.AddToModelSpace(pLine);
                        lineList.Add(lineObjectId);
                    }
                }
                tx.Commit();
            }
            return lineList;
        }





        /// <summary>
        /// 清除所有属性
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        internal static bool ClearAllAttributes(ObjectId blockId)
        {
            bool isClear = true;
            Document doc = Application.DocumentManager.MdiActiveDocument;
            //Editor ed = doc.Editor;
            Database db = doc.Database;
            //PromptNestedEntityOptions pneo = new PromptNestedEntityOptions("\nSelect attribute to erase");
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                try
                {
                    //ObjectId arId;
                    //while (true)
                    //{
                    //    PromptEntityResult per = ed.GetNestedEntity(pneo);
                    //    if (per.Status != PromptStatus.OK) return false;
                    //    arId = per.ObjectId;
                    //    if (tr.GetObject(arId, OpenMode.ForRead).GetType() == typeof(AttributeReference))
                    //        break;
                    //    ed.WriteMessage("\nNot an AttributeReference");
                    //    break;
                    //}
                    //AttributeReference ar = (AttributeReference)tr.GetObject(arId, OpenMode.ForWrite);


                    //BlockReference br = (BlockReference)tr.GetObject(ar.OwnerId, OpenMode.ForRead);
                    //BlockTableRecord btr = (BlockTableRecord)tr.GetObject(br.BlockTableRecord, OpenMode.ForWrite);
                    BlockTableRecord btr = blockId.GetObject(OpenMode.ForWrite) as BlockTableRecord;
                    foreach (ObjectId id in btr)
                    {
                        AttributeDefinition ad = tr.GetObject(id, OpenMode.ForRead) as AttributeDefinition;
                        if (ad == null)
                            continue;
                        //if (ad.Tag != ar.Tag)
                        //    continue;
                        ad.UpgradeOpen();
                        ad.Erase();
                    }

                    foreach (ObjectId id in btr.GetBlockReferenceIds(true, true))
                    {
                        BlockReference br = (BlockReference)tr.GetObject(id, OpenMode.ForWrite);
                        if (br != null)
                        {
                            foreach (ObjectId attId in br.AttributeCollection)
                            {
                                AttributeReference attref = attId.GetObject(OpenMode.ForRead) as AttributeReference;
                                attref.UpgradeOpen();
                                attref.Erase();
                            }
                        }
                    }
                    tr.Commit();
                }
                catch (Exception e)
                {
                    isClear = false;
                }
            }
            return isClear;
        }



        /// <summary>
        /// 创建缩放后的多段线
        /// </summary>
        /// <param name="lpList"></param>
        /// <param name="list"></param>
        /// <param name="basePoint"></param>
        /// <param name="maxHeight"></param>
        /// <param name="tolerance"></param>
        public static void CreateScalePolylines(List<List<Point3d>> lpList, Point3d basePoint,double maxHeight,double tolerance)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                PointTool pTool = new PointTool();
                double scale = GetScaling(lpList, maxHeight, pTool);
                foreach (var pList in lpList)
                {
                    List<Point3d> newList = pTool.GetNewBoundingBox(pList, tolerance);
                    if (newList != null)
                    {
                        Polyline pLine = new Polyline();
                        foreach (var item in newList)
                        {
                            Point2d pt = new Point2d(item.X, item.Y);
                            pLine.AddVertexAt(0, pt, 0, 0, 0);
                            
                        }
                        pLine.Closed = true;
                        EntTools.Scale(pLine, basePoint, scale);
                        ObjectId objectId = db.AddToModelSpace(pLine);
                    }
                }

                Dictionary<string, Point3d> textdict = GetTextPosition(lpList, pTool);
                foreach (var item in textdict)
                {
                    DBText textFirst = new DBText();
                    textFirst.Position = item.Value;
                    textFirst.TextString = item.Key;
                    textFirst.HorizontalMode = TextHorizontalMode.TextLeft;
                    textFirst.Height = 20;
                    textFirst.Scale(basePoint, scale);
                    db.AddToModelSpace(textFirst);
                }
                tx.Commit();
            }
        }

        private static Dictionary<string, Point3d> GetTextPosition(List<List<Point3d>> lpList, PointTool pTool)
        {
            Dictionary<double, Point3d> dictPoint = new Dictionary<double, Point3d>();
            Dictionary<string, Point3d> textdict = new Dictionary<string, Point3d>();
            foreach (var pList in lpList)
            {
                Point3d maxPt = pTool.GetMaxPoint(pList);
                Point3d minPt = pTool.GetMinPoint(pList);
                dictPoint.Add(maxPt.Y, minPt);
            }
            dictPoint.OrderByDescending(x => x.Key);
            int count = 1;
            foreach (var item in dictPoint)
            {
                string key = count + "区";
                Point3d pt = new Point3d(item.Value.X, item.Value.Y, 0);
                textdict.Add(key, pt);
                count++;
            }
            return textdict;
        }

        /// <summary>
        /// 获取缩放比例
        /// </summary>
        /// <param name="list"></param>
        /// <param name="maxHeight"></param>
        /// <param name="pTool"></param>
        /// <returns></returns>
        private static double GetScaling(List<List<Point3d>> lplist, double maxHeight, PointTool pTool)
        {
            List<Point3d> ptlist = new List<Point3d>();
            Point3d maxPt;
            Point3d minPt;
            foreach (var list in lplist)
            {
                maxPt = pTool.GetMaxPoint(list);
                minPt = pTool.GetMinPoint(list);
                ptlist.Add(maxPt);
                ptlist.Add(minPt);
            }
            maxPt = pTool.GetMaxPoint(ptlist);
            minPt = pTool.GetMinPoint(ptlist);
            double maxheight = maxPt.Y - minPt.Y;
            return maxHeight / maxheight;
        }

        /// <summary>
        /// 获取最大范围内的坐标点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static List<List<Point3d>> GetLinePointList(List<Point3d> list, double height)
        {
            List<List<Point3d>> pLists = new List<List<Point3d>>();

            PointTool pTool = new PointTool();
            Point3d maxPt = pTool.GetMaxPoint(list);
            double maxheight = pTool.GetMaxHeight(list);
            int rowCount = (int) Math.Ceiling( maxheight / height);
            double actualheight = maxheight / rowCount;
            int i = 0;
            while(list.Count() > 0)
            {
                List<Point3d> pList = new List<Point3d>();
                pList = list.FindAll(x => x.Y >= (maxPt.Y - (actualheight * (i + 1))) && x.Y <=(maxPt.Y - (i * actualheight)));
                if (pList.Count > 0)
                {
                    pList = pTool.GetBoundingBox(pList);
                    pLists.Add(pList);
                }
                list.RemoveAll(x => x.Y >= (maxPt.Y - (actualheight * (i + 1))) && x.Y <= (maxPt.Y - (i * actualheight)));
                i++;
            }
            return pLists;
        }

        /// <summary>
        /// 设置视图范围
        /// </summary>
        /// <param name="spaceId"></param>
        /// <param name="minPoint"></param>
        /// <param name="maxPoint"></param>
        public static bool SetLayoutRange(ObjectId spaceId, Point3d minPoint, Point3d maxPoint, string device = "")
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                LayoutManager layoutMgr = LayoutManager.Current;
                Layout aclayout = tx.GetObject(layoutMgr.GetLayoutId(layoutMgr.CurrentLayout), OpenMode.ForWrite) as Layout;
                PlotSettingsValidator psv = PlotSettingsValidator.Current;
                StringCollection devlist = psv.GetPlotDeviceList();
                if (string.IsNullOrEmpty(device))
                {
                    if (devlist.Count > 0)
                    {
                        device = devlist[1];
                    }
                    else
                    {
                        return false;
                    }
                }
                double pageWidth = maxPoint.Y - minPoint.Y;
                double pageHeight = maxPoint.X - minPoint.X;


                setClosestMediaName(psv, device, aclayout, pageWidth, pageHeight, PlotPaperUnit.Millimeters, true);
                ed.Regen();
                tx.Commit();
            }
            return true;
        }

        private static void setClosestMediaName(PlotSettingsValidator psv, string device, Layout aclayout, double pageWidth, double pageHeight, PlotPaperUnit units, bool matchPrintableArea)
        {
            try
            {
                psv.SetPlotType(aclayout, Autodesk.AutoCAD.DatabaseServices.PlotType.Extents);
                psv.SetPlotPaperUnits(aclayout, units);
                psv.SetUseStandardScale(aclayout, false);
                psv.SetStdScaleType(aclayout, StdScaleType.ScaleToFit);
                psv.SetPlotConfigurationName(aclayout, device, null);
                psv.RefreshLists(aclayout);
                //psv.SetClosestMediaName(aclayout, pageWidth, pageHeight, PlotPaperUnit.Millimeters, true);
                //psv.SetCanonicalMediaName(aclayout, medias);
                PlotRotation selectedRot = PlotRotation.Degrees090;
                psv.SetPlotRotation(aclayout, selectedRot);

                StringCollection mediaList = psv.GetCanonicalMediaNameList(aclayout);
                string medias = "ISO full bleed A1 (841.00 x 594.00 毫米)";
                mediaList.Add(medias);
                double smallestOffset = 0.0;
                string selectedMedia = string.Empty;

                foreach (string media in mediaList)
                {
                    //psv.SetCanonicalMediaName(aclayout, media);
                    psv.SetPlotPaperUnits(aclayout, units);

                    double mediaPageWidth = aclayout.PlotPaperSize.X;
                    double mediaPageHeight = aclayout.PlotPaperSize.Y;

                    if (matchPrintableArea)
                    {
                        mediaPageWidth -=
                            (aclayout.PlotPaperMargins.MinPoint.X +
                             aclayout.PlotPaperMargins.MaxPoint.X);

                        mediaPageHeight -=
                            (aclayout.PlotPaperMargins.MinPoint.Y +
                             aclayout.PlotPaperMargins.MaxPoint.Y);
                    }

                    PlotRotation rotationType = PlotRotation.Degrees090;

                    //Check that we are not outside the media print area
                    if (mediaPageWidth < pageWidth ||
                       mediaPageHeight < pageHeight)
                    {
                        //Check if 90°Rot will fit, otherwise check next media
                        if (mediaPageHeight < pageWidth ||
                           mediaPageWidth >= pageHeight)
                        {
                            //Too small, let's check next media
                            continue;
                        }
                        //That's ok 90°Rot will fit
                        rotationType = PlotRotation.Degrees090;
                    }
                    double offset = Math.Abs(
                        mediaPageWidth * mediaPageHeight -
                        pageWidth * pageHeight);

                    if (selectedMedia == string.Empty || offset < smallestOffset)
                    {
                        selectedMedia = media;
                        smallestOffset = offset;
                        selectedRot = rotationType;

                        //Found perfect match so we can quit early
                        if (smallestOffset == 0)
                            break;
                    }
                }
                psv.SetCanonicalMediaName(aclayout, selectedMedia);
                psv.SetPlotRotation(aclayout, selectedRot);
            }
            catch (Exception e)
            {
            }
        }

        /// <summary>
        /// 在指定表单中插入块
        /// </summary>
        /// <param name="tbId">表单Id</param>
        /// <param name="rowindex">行</param>
        /// <param name="columnindex">列</param>
        /// <param name="blockName">块名</param>
        /// <returns></returns>
        public static bool CreateTbBlock(ObjectId tbId, int rowindex, int columnindex, string blockName)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using(Transaction tx = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tx.GetObject(db.BlockTableId,OpenMode.ForRead);
                BlockTableRecord btr = tx.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                ObjectId blkId = ObjectId.Null;
                foreach (ObjectId btobjid in bt)
                {
                    if (btobjid.IsEffectivelyErased) continue;
                    BlockTableRecord blkrd = tx.GetObject(btobjid, OpenMode.ForRead) as BlockTableRecord;
                    if (blkrd.Name == blockName)
                    {
                        blkId = btobjid;
                        break;
                    }
                }
                if (blkId.IsNull)
                {
                    return false;
                }
                Entity entity = tx.GetObject(tbId, OpenMode.ForWrite) as Entity;
                if (entity is Table)
                {
                    Table tb = entity as Table;
                    if (tb.Rows.Count > rowindex && tb.Columns.Count > columnindex)
                    {
                        if (tb.Cells[rowindex, columnindex].Contents.Count > 0)
                        {
                            tb.Cells[rowindex, columnindex].Contents[0].BlockTableRecordId = blkId;
                        }
                        else
                        {
                            tb.Cells[rowindex, columnindex].Contents.Add();
                            tb.Cells[rowindex, columnindex].Contents[0].BlockTableRecordId = blkId;
                        }
                    }
                }
                else
                {
                    return false;
                }
                tx.Commit();
            }
            return true;
        }



        public static void CreateSolarPanel()
        {
            Dictionary<string, List<string>> dictionary = GetSectionAndValueMapFromFile(@"C:\Users\heqianyong\Desktop\光伏支架\单桩单立柱-抱箍.3D3S");
            Dictionary<int,Point3d> pdict = new Dictionary<int, Point3d>();
            List<Eleline> Linelist = new List<Eleline>();
            if (dictionary.ContainsKey("*NODE"))
            {
                List<string> list = dictionary["*NODE"];
                foreach (var item in list)
                {
                    string[] nodes = item.Split(',');
                    if (nodes.Count() > 3)
                    {
                        pdict.Add(Convert.ToInt32(nodes[0]), new Point3d(Convert.ToDouble(nodes[1]), Convert.ToDouble(nodes[2]), Convert.ToDouble(nodes[3])));
                    }
                }
            }
            if (dictionary.ContainsKey("*ELE_LINE"))
            {
                List<string> list = dictionary["*ELE_LINE"];
                foreach (var item in list)
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
            }

            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                foreach (var item in Linelist)
                {
                    Poly3dType poly3DType = Poly3dType.SimplePoly;
                    Point3dCollection point3DCollection = new Point3dCollection();
                    point3DCollection.Add(pdict[item.startNode]);
                    point3DCollection.Add(pdict[item.endNode]);
                    bool isClosed = false;
                    Polyline3d polyline3D = new Polyline3d(poly3DType, point3DCollection, isClosed);
                    db.AddToModelSpace(polyline3D);
                }
                tx.Commit();
            }
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


            StreamReader streamReader = new StreamReader(m_pathName);
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

    }
}
