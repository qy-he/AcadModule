using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class SolarPanel
    {
        /// <summary>
        /// P:\西藏仁布支架\2-13-3-0726.3D3S
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int YNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int XNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SpanNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ATotalWidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BTotalWidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double InclineAngle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BracketType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BoltLengthDistance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BoltWidthDistance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double APanelDistanceValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BPanelDistanceValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PileDiameter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalHeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ConstantForce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PositiveWindForce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double NegativeWindForce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double SnowForce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsConstructionLoad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsReliableStandard { get; set; }
        /// <summary>
        /// 薄壁卷边槽钢
        /// </summary>
        public string PurlinSectionType { get; set; }
        /// <summary>
        /// 薄壁卷边槽钢
        /// </summary>
        public string BeamSectionType { get; set; }
        /// <summary>
        /// 薄壁卷边槽钢
        /// </summary>
        public string PillarSectionType { get; set; }
        /// <summary>
        /// 薄壁槽钢
        /// </summary>
        public string FrontBraceSectionType { get; set; }
        /// <summary>
        /// 薄壁槽钢
        /// </summary>
        public string BackBraceSectionType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PurlinSectionMaterial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BeamSectionMaterial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PillarSectionMaterial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FrontBraceSectionMaterial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BackBraceSectionMaterial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<double> MinThickness1Lst { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<double> MinThickness2Lst { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PurlinMinThickness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BeamMinThickness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PillarMinThickness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double FrontBraceMinThickness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BackBraceMinThickness { get; set; }
    }
}
