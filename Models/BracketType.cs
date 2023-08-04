using System.ComponentModel;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 支架形式
    /// </summary>
    public enum BracketType
    {

        /// <summary>
        /// 单桩单立柱-焊接"
        /// </summary>
        [Description("单桩单立柱-焊接")]
        SinglePileSinglePillar_Welding,

        /// <summary>
        /// 单桩单立柱-抱箍
        /// </summary>
        [Description("单桩单立柱-抱箍")]
        SinglePileSinglePillar_AnchorEar,


        /// <summary>
        /// 单桩双立柱-抱箍
        /// </summary>

        [Description("单桩双立柱-抱箍")]
        SinglePileDoublePillar_AnchorEar,

        /// <summary>
        /// 双桩双立柱
        /// </summary>
        [Description("双桩双立柱")]
        DoublePileDoublePillar

    }
}
