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
    public class DimStyleFunc
    {
        public static ObjectId GetDimStyle(string dimStyleName)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            DimStyleTable ds;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                ds = (DimStyleTable)tx.GetObject(db.DimStyleTableId, OpenMode.ForWrite);
                if (!ds.Has(dimStyleName))
                {
                    return ObjectId.Null;
                }
                tx.Commit();
            }
            return ds[dimStyleName];
        }

        public static ObjectId AddDimStyle(string dimStyleName, DimStyleInfo dsinfo)
        {
            try
            {
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Database db = doc.Database;
                DimStyleTable ds;
                using (Transaction tx = db.TransactionManager.StartTransaction())
                {
                    ds = (DimStyleTable)tx.GetObject(db.DimStyleTableId, OpenMode.ForWrite);
                    DimStyleTableRecord dstr = new DimStyleTableRecord();
                    #region 标注样式赋值
                    dstr.Name = dsinfo.Name;
                    dstr.Dimfxlen = dsinfo.Dimfxlen;
                    dstr.Dimcen = dsinfo.Dimcen;
                    dstr.Dimjogang = dsinfo.Dimjogang;
                    dstr.Dimdsep = dsinfo.Dimdsep;
                    dstr.Dimtolj = dsinfo.Dimtolj;
                    dstr.Dimscale = dsinfo.Dimscale;
                    dstr.Dimexo = dsinfo.Dimexo;
                    dstr.Dimexe = dsinfo.Dimexe;
                    dstr.Dimclre = dsinfo.Dimclre;
                    dstr.Dimlwe = dsinfo.Dimlwe;
                    dstr.Dimlwd = dsinfo.Dimlwd;
                    dstr.Dimazin = dsinfo.Dimazin;
                    dstr.Dimdle = dsinfo.Dimdle;
                    dstr.Dimdli = dsinfo.Dimdli;
                    dstr.Dimclrd = dsinfo.Dimclrd;
                    dstr.Dimldrblk = dsinfo.Dimldrblk;
                    dstr.Dimarcsym = dsinfo.Dimarcsym;
                    dstr.Dimalttz = dsinfo.Dimalttz;
                    dstr.Dimalttd = dsinfo.Dimalttd;
                    dstr.Dimapost = dsinfo.Dimapost;
                    dstr.Dimaltu = dsinfo.Dimaltu;
                    dstr.Dimaltf = dsinfo.Dimaltf;
                    dstr.Dimaltz = dsinfo.Dimaltz;
                    dstr.Dimaltd = dsinfo.Dimaltd;
                    dstr.Dimzin = dsinfo.Dimzin;
                    dstr.Dimaltrnd = dsinfo.Dimaltrnd;
                    dstr.Dimtad = dsinfo.Dimtad;
                    dstr.Dimjust = dsinfo.Dimjust;
                    dstr.Dimgap = dsinfo.Dimgap;
                    dstr.Dimtxsty = dsinfo.Dimtxsty;
                    dstr.Dimclrt = dsinfo.Dimclrt;
                    dstr.Dimtxt = dsinfo.Dimtxt;
                    dstr.Dimblk = dsinfo.Dimblk;
                    dstr.Dimblk1 = dsinfo.Dimblk1;
                    dstr.Dimblk2 = dsinfo.Dimblk2;
                    dstr.Dimasz = dsinfo.Dimasz;
                    dstr.Dimdec = dsinfo.Dimdec;
                    dstr.Dimtmove = dsinfo.Dimtmove;
                    dstr.Dimatfit = dsinfo.Dimatfit;
                    dstr.Dimlunit = dsinfo.Dimlunit;
                    dstr.Dimlfac = dsinfo.Dimlfac;
                    dstr.Dimtofl = dsinfo.Dimtofl;
                    dstr.Dimadec = dsinfo.Dimadec;
                    dstr.DimfxlenOn = true;
                    dstr.Dimtoh = dsinfo.Dimtoh;
                    dstr.Dimtix = dsinfo.Dimtix;
                    dstr.Dimtih = dsinfo.Dimtih;
                    dstr.Dimtdec = dsinfo.Dimtdec;
                    #endregion
                    ds.Add(dstr);
                    db.TransactionManager.AddNewlyCreatedDBObject(dstr, true);
                    ds.DowngradeOpen();
                    tx.Commit();
                }
                return ds[dimStyleName];
            }
            catch (System.Exception e)
            {
                return ObjectId.Null;
            }
        }
    }
}
