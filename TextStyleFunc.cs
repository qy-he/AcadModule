using Autodesk.AutoCAD.ApplicationServices;
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
    public class TextStyleFunc
    {

        /// <summary>
        /// 获取对应字体样式ObjectId
        /// </summary>
        /// <param name="styleName">样式名称</param>
        /// <param name="fontName">字体</param>
        /// <param name="bigFontName">大字体</param>
        /// <returns></returns>
        public static ObjectId GetTextStyle(string styleName, string fontName, string bigFontName)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            TextStyleTable ts;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                ts = (TextStyleTable)tx.GetObject(db.TextStyleTableId, OpenMode.ForWrite);
                if (!ts.Has(styleName))
                {
                    TextStyleTableRecord tstr = new TextStyleTableRecord();
                    tstr.Name = styleName;
                    tstr.FileName = fontName;
                    tstr.BigFontFileName = bigFontName;
                    tstr.TextSize = 0;
                    tstr.XScale = 1;
                    ts.Add(tstr);
                    db.TransactionManager.AddNewlyCreatedDBObject(tstr, true);
                    ts.DowngradeOpen();
                }
                tx.Commit();
            }
            return ts[styleName];
        }
    }
}
