using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class AdaptingPieceFunc
    {

        public AdaptingPieceFunc()
        {
        }

        public AdaptingPiece GetAdaptingPieceInfo(JointPositionOption joint)
        {
            AdaptingPiece adaptingPiece = new AdaptingPiece();
            adaptingPiece.BoltName = "外六角螺栓";
            switch (joint)
            {
                case JointPositionOption.ModuleandPurline:
                    adaptingPiece.JointPart = "组件与檩条";
                    adaptingPiece.AdaptingPieceDetail = "M8*25配一母一平一大平一弹垫";
                    adaptingPiece.PieceWeight = 0.03055;
                    adaptingPiece.Remark = "不锈钢螺栓";
                    return adaptingPiece;
                case JointPositionOption.PurlinBracketandPurline:
                    adaptingPiece.JointPart = "角钢檩托与檩条";
                    adaptingPiece.AdaptingPieceDetail = "M12*40配一母二大平垫一弹垫";
                    adaptingPiece.PieceWeight = 0.1159;
                    adaptingPiece.Remark = "8.8级热镀锌";
                    return adaptingPiece;
                case JointPositionOption.PurlinConnectors:
                    adaptingPiece.JointPart = "檩条连接件";
                    adaptingPiece.AdaptingPieceDetail = "M12*40配一母二大平垫一弹垫";
                    adaptingPiece.PieceWeight = 0.1159;
                    adaptingPiece.Remark = "8.8级热镀锌";
                    return adaptingPiece;
                case JointPositionOption.PurlinBracketandCantBeam:
                    adaptingPiece.JointPart = "角钢檩托与斜梁";
                    adaptingPiece.AdaptingPieceDetail = "M10*30配一母二大平垫一弹垫";
                    adaptingPiece.PieceWeight = 0.0663;
                    adaptingPiece.Remark = "8.8级热镀锌";
                    return adaptingPiece;
                case JointPositionOption.InclinedStrutandCantBeam:
                    adaptingPiece.JointPart = "斜撑与斜梁";
                    adaptingPiece.AdaptingPieceDetail = "M12*40配一母二大平垫一弹垫";
                    adaptingPiece.PieceWeight = 0.1159;
                    adaptingPiece.Remark = "8.8级热镀锌";
                    return adaptingPiece;
                case JointPositionOption.InclinedStrutandBeamClamp:
                    adaptingPiece.JointPart = "斜撑与抱箍";
                    adaptingPiece.AdaptingPieceDetail = "M12*40配一母二平垫一弹垫";
                    adaptingPiece.PieceWeight = 0.08414;
                    adaptingPiece.Remark = "8.8级热镀锌";
                    return adaptingPiece;
                case JointPositionOption.BeamClampandStandColumn:
                    adaptingPiece.JointPart = "抱箍与立柱";
                    adaptingPiece.AdaptingPieceDetail = "M16*80配一母二平垫一弹垫";
                    adaptingPiece.PieceWeight = 0.23482;
                    adaptingPiece.Remark = "8.8级热镀锌";
                    return adaptingPiece;
                case JointPositionOption.StandColumnandCantBeam:
                    adaptingPiece.JointPart = "立柱与斜梁";
                    adaptingPiece.AdaptingPieceDetail = "M12*40配一母二大平垫一弹垫";
                    adaptingPiece.PieceWeight = 0.1159;
                    adaptingPiece.Remark = "8.8级热镀锌";
                    return adaptingPiece;
                default:
                    return adaptingPiece;
            }
        }

    }

    public enum JointPositionOption
    {
        /// <summary>
        /// 组件与檩条
        /// </summary>
        ModuleandPurline = 0,
        /// <summary>
        /// 角钢檩托与檩条
        /// </summary>
        PurlinBracketandPurline = 1,
        /// <summary>
        /// 檩条连接件
        /// </summary>
        PurlinConnectors = 2,
        /// <summary>
        /// 角钢檩托与斜梁
        /// </summary>
        PurlinBracketandCantBeam = 3,
        /// <summary>
        /// 斜撑与斜梁
        /// </summary>
        InclinedStrutandCantBeam = 4,
        /// <summary>
        /// 斜撑与抱箍
        /// </summary>
        InclinedStrutandBeamClamp = 5,
        /// <summary>
        /// 抱箍与立柱
        /// </summary>
        BeamClampandStandColumn = 6,
        /// <summary>
        /// 立柱与斜梁
        /// </summary>
        StandColumnandCantBeam = 7
    }




    public class AdaptingPiece
    {
        public string BoltName { get; set; }
        /// <summary>
        /// 连接部位
        /// </summary>
        public string JointPart { get; set; }
        /// <summary>
        /// 连接件明细
        /// </summary>
        public string AdaptingPieceDetail { get; set; }
        /// <summary>
        /// 单重（kg）
        /// </summary>
        public double PieceWeight { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
