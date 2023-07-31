using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class DeviceModule
    {
        /// <summary>
        /// 厂家、型号名称
        /// </summary>
        public string ManufacturerName { get; set; } = "";
        /// <summary>
        /// 最大光伏阵列电压（V）
        /// </summary>
        public int Voltage { get; set; }
        /// <summary>
        /// 最大直流输入功率（kW）
        /// </summary>
        public double PowerWork { get; set; }
        /// <summary>
        /// 熔芯额定电流
        /// </summary>
        public int Electricity { get; set; }
        /// <summary>
        /// 工作电压范围（V）
        /// </summary>
        public string VoltageRange { get; set; } = "";
        /// <summary>
        /// MPPT输入电压范围（V）
        /// </summary>
        public string MPPTVoltageRange { get; set; } = "";
        /// <summary>
        /// 型号和规格
        /// </summary>
        public string ModelSpecification { get; set; } = "";
        /// <summary>
        /// 运行环境温度范围（℃）
        /// </summary>
        public string TemperatureRange { get; set; } = "";
        /// <summary>
        /// 外形尺寸 （mm）
        /// </summary>
        public string Dimensions { get; set; } = "";
        /// <summary>
        /// 重量（kg）
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// 对应方阵编号
        /// </summary>
        public string MatrixCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// MPPT数量
        /// </summary>
        public int MPPTNumber { get; set; }
        /// <summary>
        /// 最大交流输出电流（A）
        /// </summary>
        public int MaximumOutputCurrent { get; set; }
        /// <summary>
        /// 额定交流输出电压（V）
        /// </summary>
        public int RatedACOutputVoltage { get; set; }
    }
}
