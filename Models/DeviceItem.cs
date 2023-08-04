using Mrf.CSharp.BaseTools;
using Mrf.CSharp.BaseTools.Extension;
using System.Collections.Generic;

namespace Mrf.Photovoltaic.Tools.Models
{
    /// <summary>
    /// 设备
    /// </summary>
    public class DeviceItem
    {
        /// <summary>
        /// Revit中的Id
        /// </summary>
        public int Id { get; set; }


        private string _Name;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }





        /// <summary>
        /// 汇流模式，有四种：
        /// 组串式逆变器-箱变-升压站   4  》  组串—光伏板—组串式逆变器—箱变
        ///汇流箱-箱逆变一体机-升压站   4  》 组串—光伏板—汇流箱—箱逆变一体机
        ///汇流箱-集中式逆变器-箱变-升压站 5 》组串—光伏板—汇流箱—集中式逆变器—箱变
        ///汇流箱-集散式逆变器-箱变-升压站 5 》组串—光伏板—汇流箱—集散式逆变器—箱变
        /// </summary>
        public string ConfluenceMode { get; set; }



        /// <summary>
        /// 汇流模式，用枚举方法表示
        /// </summary>
        public ConfluenceType ConfluenceType { get; set; }




        private Point3d _coord;


        /// <summary>
        /// 插入点（单位：英尺）
        /// </summary>

        public Point3d Coord
        {
            get { return _coord; }
            set { _coord = value; }
        }







        private List<Point3d> _cablePath;

        /// <summary>
        /// 出线路径（单位：英尺）
        /// </summary>
        public List<Point3d> CablePath
        {
            get { return _cablePath; }
            set { _cablePath = value; }
        }





        private List<Point3d> _cablePathInMM;

        /// <summary>
        /// 出线路径（单位：mm）
        /// </summary>
        public List<Point3d> CablePathInMM
        {
            get { return _cablePathInMM; }
            set { _cablePathInMM = value; }
        }





        private List<int> _cableColor;

        /// <summary>
        /// 颜色
        /// </summary>
        public List<int> CableColor
        {
            get { return _cableColor; }
            set { _cableColor = value; }
        }




        //private double _length = 1600;
        private double _length;

        /// <summary>
        /// 沿x轴的长度（单位：mm）
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }







        //private double _width = 1600;
        private double _width;
        /// <summary>
        /// 沿y轴的宽度（单位：mm）
        /// </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private double _High;
        /// <summary>
        /// 沿z轴的高度（单位：mm）
        /// </summary>
        public double High
        {
            get { return _High; }
            set { _High = value; }
        }

        private double _Weight;
        /// <summary>
        /// 
        /// </summary>
        public double Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        private string _Dimensions;
        /// <summary>
        /// 
        /// </summary>
        public string Dimensions
        {
            get { return _Dimensions; }
            set { _Dimensions = value; }
        }

        private string _PreCode;
        /// <summary>
        /// 
        /// </summary>
        public string PreCode
        {
            get { return _PreCode; }
            set { _PreCode = value; }
        }

        private double _Capacity;
        /// <summary>
        /// 
        /// </summary>
        public double Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }

        private double _CombinerBoxPower;
        /// <summary>
        /// 
        /// </summary>
        public double CombinerBoxPower
        {
            get { return _CombinerBoxPower; }
            set { _CombinerBoxPower = value; }
        }

        private double _DCVoltageOfCombinerBox;
        /// <summary>
        /// 
        /// </summary>
        public double DCVoltageOfCombinerBox
        {
            get { return _DCVoltageOfCombinerBox; }
            set { _DCVoltageOfCombinerBox = value; }
        }

        private double _TransformerPower;
        /// <summary>
        /// 
        /// </summary>
        public double TransformerPower
        {
            get { return _TransformerPower; }
            set { _TransformerPower = value; }
        }

        private double _TransformerVoltage;
        /// <summary>
        /// 
        /// </summary>
        public double TransformerVoltage
        {
            get { return _TransformerVoltage; }
            set { _TransformerVoltage = value; }
        }



        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 电压等级
        /// </summary>
        public double VoltageLevel { get; set; }

        /// <summary>
        /// 电缆名称
        /// </summary>
        public string CableName { get; set; }

        /// <summary>
        /// 电缆截面
        /// </summary>
        public string CableSection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CableSpliceNumber { get; set; }

        /// <summary>
        /// 电缆材质
        /// </summary>
        public string CableMaterial { get; set; }

        /// <summary>
        /// 电缆终点设备编号
        /// </summary>
        public string CableEndDeviceCode { get; set; }

        /// <summary>
        /// 电缆起点设备编号
        /// </summary>
        public string CableStartDeviceCode { get; set; }

        /// <summary>
        /// 电缆规格
        /// </summary>
        public string CableSpecification { get; set; }

        /// <summary>
        /// 电缆载流量
        /// </summary>
        public double CableAmpacity { get; set; }

        /// <summary>
        /// 电缆长度
        /// </summary>
        public double CableLength { get; set; }

        /// <summary>
        /// 电缆编号
        /// </summary>
        public string CableNumber { get; set; }


        private string _PvpModuleDisplayCode;

        /// <summary>
        /// 
        /// </summary>
        public string PvpModuleDisplayCode
        {
            get { return _PvpModuleDisplayCode; }
            set { _PvpModuleDisplayCode = value; }
        }

        private double _ACPowerOfSeriesInverter;

        /// <summary>
        /// 
        /// </summary>
        public double ACPowerOfSeriesInverter
        {
            get { return _ACPowerOfSeriesInverter; }
            set { _ACPowerOfSeriesInverter = value; }
        }

        private string _DeviceSpecification;

        /// <summary>
        /// 
        /// </summary>
        public string DeviceSpecification
        {
            get { return _DeviceSpecification; }
            set { _DeviceSpecification = value; }
        }

        private int _SettingModuleNumber;

        /// <summary>
        /// 
        /// </summary>
        public int SettingModuleNumber
        {
            get { return _SettingModuleNumber; }
            set { _SettingModuleNumber = value; }
        }

        private double _ACVoltageOfSeriesInverter;

        /// <summary>
        /// 
        /// </summary>
        public double ACVoltageOfSeriesInverter
        {
            get { return _ACVoltageOfSeriesInverter; }
            set { _ACVoltageOfSeriesInverter = value; }
        }


        private string _ElectricalLoopCode;

        /// <summary>
        /// 
        /// </summary>
        public string ElectricalLoopCode
        {
            get { return _ElectricalLoopCode; }
            set { _ElectricalLoopCode = value; }
        }

        private string _Manufacturer;

        /// <summary>
        /// 
        /// </summary>
        public string Manufacturer
        {
            get { return _Manufacturer; }
            set { _Manufacturer = value; }
        }

        private double _MaximumPhotovoltaicSystemVoltage;

        /// <summary>
        /// 
        /// </summary>
        public double MaximumPhotovoltaicSystemVoltage
        {
            get { return _MaximumPhotovoltaicSystemVoltage; }
            set { _MaximumPhotovoltaicSystemVoltage = value; }
        }


        private double _RatedCurrentOfMoltenCore;

        /// <summary>
        /// 
        /// </summary>
        public double RatedCurrentOfMoltenCore
        {
            get { return _RatedCurrentOfMoltenCore; }
            set { _RatedCurrentOfMoltenCore = value; }
        }

        private string _OperatingVoltageRange;

        /// <summary>
        /// 
        /// </summary>
        public string OperatingVoltageRange
        {
            get { return _OperatingVoltageRange; }
            set { _OperatingVoltageRange = value; }
        }

        private string _OperatingAmbientTemperatureRange;

        /// <summary>
        /// 
        /// </summary>
        public string OperatingAmbientTemperatureRange
        {
            get { return _OperatingAmbientTemperatureRange; }
            set { _OperatingAmbientTemperatureRange = value; }
        }

        private double _MaximumDCInputPower;

        /// <summary>
        /// 
        /// </summary>
        public double MaximumDCInputPower
        {
            get { return _MaximumDCInputPower; }
            set { _MaximumDCInputPower = value; }
        }

        private double _MaximumInputVoltage;

        /// <summary>
        /// 
        /// </summary>
        public double MaximumInputVoltage
        {
            get { return _MaximumInputVoltage; }
            set { _MaximumInputVoltage = value; }
        }

        private string _InputVoltageRangeMPPT;

        /// <summary>
        /// 
        /// </summary>
        public string InputVoltageRangeMPPT
        {
            get { return _InputVoltageRangeMPPT; }
            set { _InputVoltageRangeMPPT = value; }
        }

        private int _NumberOfMPPT;

        /// <summary>
        /// 
        /// </summary>
        public int NumberOfMPPT
        {
            get { return _NumberOfMPPT; }
            set { _NumberOfMPPT = value; }
        }




        private Point3d _centerPoint;

        /// <summary>
        /// 中心点，也就是插入点（单位：mm）
        /// </summary>
        public Point3d CenterPoint
        {
            get { return _centerPoint; }
            set { _centerPoint = value; }
        }


        private double _MaximumACOutputCurrent;

        /// <summary>
        /// 
        /// </summary>
        public double MaximumACOutputCurrent
        {
            get { return _MaximumACOutputCurrent; }
            set { _MaximumACOutputCurrent = value; }
        }

        private double _RatedACOutputVoltage;

        /// <summary>
        /// 
        /// </summary>
        public double RatedACOutputVoltage
        {
            get { return _RatedACOutputVoltage; }
            set { _RatedACOutputVoltage = value; }
        }

        private double _CableLoadCapacity;

        /// <summary>
        /// 
        /// </summary>
        public double CableLoadCapacity
        {
            get { return _CableLoadCapacity; }
            set { _CableLoadCapacity = value; }
        }

        private string _objectId = "-1";

        /// <summary>
        /// 在CAD中生成的对象的ObjectId对应的字符串，如果没有，则为"-1"
        /// </summary>
        public string ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }





        /// <summary>
        /// 通过Coord获取中心点（单位：mm）z值归0
        /// </summary>
        public void GetCenterPoint()
        {
            if (_coord == null)
            {
                return;
            }


            //10:32 2022/10/20 已经转换为mm，不再需要转换了

            ////注意英尺转换为mm

            //double centerX = ((_coord.X + _coord.X) / 2).Foot2Millimeter();
            //double centerY = ((_coord.Y + _coord.Y) / 2).Foot2Millimeter();

            double centerX = ((_coord.X + _coord.X) / 2);
            double centerY = ((_coord.Y + _coord.Y) / 2);


            _centerPoint = new Point3d(centerX, centerY, 0);

        }


        /// <summary>
        /// 包含的子设备，比如箱变下含有逆变器
        /// </summary>
        public List<DeviceItem> SubDeviceItems { get; set; } = new List<DeviceItem>();


        /// <summary>
        /// 包含的子光伏组串，比如逆变器下含有光伏组串
        /// </summary>
        public List<PvpModuleInfosItem> SubPvpModuleItems { get; set; } = new List<PvpModuleInfosItem>();













        /// <summary>
        /// 获取逆向路径坐标列表（单位：mm）,z值归0
        /// </summary>
        public void GetCablePathInMM()
        {
            if (_cablePath != null && _cablePath.Count > 0)
            {
                _cablePathInMM = new List<Point3d>();
                foreach (var item in _cablePath)
                {




                    //double xValue = item.X;
                    //double yValue = item.Y;

                    double xValue = item.X.Foot2Millimeter();
                    double yValue = item.Y.Foot2Millimeter();




                    Point3d point3D = new Point3d(xValue, yValue, 0);
                    _cablePathInMM.Add(point3D);
                }
            }
        }














        /// <summary>
        /// 如果长度、宽度相同，则认为两者相同
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsEqual(DeviceItem b)
        {
            //返回值
            bool isEqual = false;
            if (b == null)
            {
                return isEqual;
            }

            if (_length.AreEqual(b.Length, 0.5) &&  //长度一样
                _width.AreEqual(b.Width, 0.5)  //宽度一样
                )
            {
                isEqual = true;
            }

            return isEqual;
        }




    }


}
