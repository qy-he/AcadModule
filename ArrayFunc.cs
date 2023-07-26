using Autodesk.AutoCAD.ApplicationServices;
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
    public class ArrayFunc
    {
        /// <summary>
        /// 创建阵列
        /// </summary>
        /// <param name="basePt">阵列图形对象</param>
        /// <param name="BasePoint">基点</param>
        /// <param name="ColumnCount">列数</param>
        /// <param name="ColumnSpacing">列间距</param>
        /// <param name="RowCount">行数</param>
        /// <param name="RowSpacing">行间距</param>
        /// <param name="LevelCount">级别</param>
        public static void CreateArray(ObjectIdCollection basePt, VertexRef BasePoint, int ColumnCount, int ColumnSpacing, int RowCount, int RowSpacing, int LevelCount)
        {
            AssocArrayRectangularParameters rectParams = new AssocArrayRectangularParameters()
            {
                ColumnCount = ColumnCount,
                ColumnSpacing = ColumnSpacing,
                RowCount = RowCount,
                RowSpacing = RowSpacing,
                RowElevation = 0,
                LevelCount = LevelCount,
                XAxisDirection = Vector3d.XAxis,
                YAxisDirection = Vector3d.YAxis,
                BasePoint = BasePoint,
            };

            AssocArray array = AssocArray.CreateArray(basePt, BasePoint, rectParams);
        }
    }
}
