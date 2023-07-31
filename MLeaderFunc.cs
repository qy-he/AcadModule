using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using DotNetARX;

namespace AcadModule
{
    public class MLeaderFunc
    {
        public static ObjectId DrawMLeader(Point3d startPoint, Point3d lastPoint, string txt, ObjectId txtObjectid, string mLstyleName)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            ObjectId MLStyleId = CreateMLeaderStyle(mLstyleName, txtObjectid);
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = tx.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blkRef = tx.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                MLeader leader = new MLeader();
                leader.SetDatabaseDefaults();
                leader.MLeaderStyle = MLStyleId;
                var sn = leader.AddLeaderLine(startPoint);
                leader.AddFirstVertex(sn, startPoint);
                leader.SetFirstVertex(sn, startPoint);
                leader.SetLastVertex(sn, lastPoint);

                MText mText = new MText();
                mText.Contents = txt;
                //mText.TextHeight = 1;
                mText.TextStyleId = txtObjectid;
                mText.Location = lastPoint;
                leader.MText = mText;

                blkRef.AppendEntity(leader);
                tx.AddNewlyCreatedDBObject(leader, true);

                tx.Commit();
            }
            doc.Editor.Regen();
            return MLStyleId;
        }

        public static ObjectId CreateMLeaderStyle(string mLstyleName, ObjectId txtObjectid)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                DBDictionary dBDictionary = tx.GetObject(db.MLeaderStyleDictionaryId, OpenMode.ForWrite) as DBDictionary;
                if (dBDictionary.Contains(mLstyleName))
                {
                    return dBDictionary.GetAt(mLstyleName);
                }
                MLeaderStyle newMleadStyle = new MLeaderStyle();
                //newMleadStyle.TextAlignAlwaysLeft = true;//文本是否始终向左对齐
                //newMleadStyle.Annotative = AnnotativeStates.True;//注释
                //newMleadStyle.DrawMLeaderOrderType = DrawMLeaderOrderType.DrawLeaderFirst;
                newMleadStyle.SetTextAttachmentType(TextAttachmentType.AttachmentBottomLine,LeaderDirectionType.LeftLeader); //Text连接方式
                newMleadStyle.SetTextAttachmentType(TextAttachmentType.AttachmentBottomLine, LeaderDirectionType.RightLeader); //Text连接方式
                //newMleadStyle.TextAttachmentDirection = TextAttachmentDirection.AttachmentVertical; //文字水平排
                //newMleadStyle.TextAlignmentType = TextAlignmentType.CenterAlignment; //Text排列方式
                newMleadStyle.TextAngleType = TextAngleType.HorizontalAngle;//文本角度
                newMleadStyle.LeaderLineColor = Color.FromColorIndex(ColorMethod.ByLayer, 256);
                newMleadStyle.ArrowSymbolId = DimTools.GetArrowObjectId(db, "_NONE");
                //newMleadStyle.LeaderLineType = LeaderType.StraightLeader;
                newMleadStyle.ContentType = ContentType.MTextContent;//文本类型
                newMleadStyle.ArrowSize = 0.18;//能头大小
                newMleadStyle.BreakSize = 0.13; //基线断大小
                newMleadStyle.DoglegLength = 0.36; //基线距离
                newMleadStyle.EnableDogleg = false; //显示基线
                //newMleadStyle.EnableFrameText = true; //显不文在
                newMleadStyle.LandingGap = 0.09; //基线间隙
                newMleadStyle.MaxLeaderSegmentsPoints = 2; //最大引线点敬
                newMleadStyle.TextStyleId = txtObjectid; //文字样式
                newMleadStyle.TextHeight = 0;
                newMleadStyle.PostMLeaderStyleToDb(db, mLstyleName);
                newMleadStyle.DowngradeOpen();
                tx.Commit();
                return newMleadStyle.ObjectId;
            }
        }
    }
}
