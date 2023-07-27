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
    public class BlockFunc
    {
        /// <summary>
        /// 插入dwg图纸
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="blockName">块名</param>
        /// <param name="Scale">缩放比例</param>
        /// <param name="rotation">旋转度</param>
        /// <param name="insertPoint">插入点</param>
        public static ObjectId InsertDwgFile(string filePath, string blockName, double Scale, double rotation, Point3d insertPoint, Dictionary<string, double> propertyNameAndValueMap)
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (doc.LockDocument())
            {
                using (Transaction tx = db.TransactionManager.StartTransaction())
                {
                    BlockTable blktbl = tx.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    LayerTable laytbl = tx.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    ObjectId blkId = ObjectId.Null;
                    BlockTableRecord btrSpace = tx.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                    foreach (ObjectId btobjid in blktbl)
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
                        using (var dbInsert = new Database(false, true))
                        {
                            dbInsert.ReadDwgFile(filePath, FileShare.Read, true, "");
                            dbInsert.CloseInput(true);
                            blkId = db.Insert(blockName, dbInsert, false);
                        }
                    }
                    var blkRef = new BlockReference(insertPoint, blkId);
                    blkRef.ScaleFactors = new Scale3d(Scale, Scale, 1);
                    blkRef.Rotation = rotation;
                    btrSpace.AppendEntity(blkRef);
                    blkRef.SetDatabaseDefaults();
                    tx.AddNewlyCreatedDBObject(blkRef, true);
                    ChangeDynBlockProperties(blkRef, propertyNameAndValueMap);
                    tx.Commit();
                    return blkId;
                }
            }
        }

        /// <summary>
        /// 修改块自定义值
        /// </summary>
        /// <param name="br"></param>
        /// <param name="propertyNameAndValueMap"></param>
        private static void ChangeDynBlockProperties(BlockReference br, Dictionary<string, double> propertyNameAndValueMap)
        {
            DynamicBlockReferencePropertyCollection pc = br.DynamicBlockReferencePropertyCollection;

            foreach (DynamicBlockReferenceProperty prop in pc)
            {
                string name = prop.PropertyName.ToUpper();

                if (!propertyNameAndValueMap.TryGetValue(name, out double value))
                {
                    continue;
                }
                //以下为需要修改
                prop.Value = value;
            }
        }
    }
}
