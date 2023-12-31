﻿using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using DotNetARX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class DimensionFunc
    {

        /// <summary>
        /// 插入尺寸标注线
        /// </summary>
        /// <param name="pt1">起点</param>
        /// <param name="pt2">终点</param>
        /// <param name="pt2">终点</param>
        /// <param name="dimpoint">标注线坐标</param>
        /// <param name="layerId">图层</param>
        public static ObjectId InsertAlignedDimension(Point3d pt1, Point3d pt2,Point3d dimpoint, ObjectId Dimstyle,ObjectId layerId)
        {
            Database db = HostApplicationServices.WorkingDatabase;
            using (Transaction tx = db.TransactionManager.StartOpenCloseTransaction())
            {
                AlignedDimension dimension = new AlignedDimension();
                dimension.XLine1Point = pt1;
                dimension.XLine2Point = pt2;
                dimension.DimLinePoint = dimpoint;
                if (layerId != null)
                {
                    dimension.LayerId = layerId;
                }
                if (Dimstyle != null)
                {
                    dimension.DimensionStyle = Dimstyle;
                }
                else
                {
                    dimension.DimensionStyle = db.Dimstyle;
                }
                return db.AddToModelSpace(dimension);
            }
        }
    }
}
