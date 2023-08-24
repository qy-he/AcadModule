using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public static class LayerFunc
    {
        public static ObjectId GetLayerId(string layerName,short colorindex = 7)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            LayerTable lt;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                lt = tx.GetObject(db.LayerTableId, OpenMode.ForWrite) as LayerTable;
                if (!lt.Has(layerName))
                {
                    LayerTableRecord ltr = new LayerTableRecord();
                    ltr.Name = layerName;
                    ltr.Color = Color.FromColorIndex(ColorMethod.ByAci, colorindex);
                    lt.Add(ltr);
                    tx.AddNewlyCreatedDBObject(ltr, true);
                    ltr.DowngradeOpen();
                }
                tx.Commit();
            }
            return lt[layerName];
        }
    }
}
