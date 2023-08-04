using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mrf.Photovoltaic.Tools.Models
{
    public class PvComponents
    {
        private int _id;

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private double _power;

        /// <summary>
        /// 
        /// </summary>
        public double Power
        {
            get { return _power; }
            set { _power = value; }
        }

        private double _length;

        /// <summary>
        /// 
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }


        private double _width;

        /// <summary>
        /// 
        /// </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }


        private double _thickness;

        /// <summary>
        /// 
        /// </summary>
        public double Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }


        private int _RowN;

        /// <summary>
        /// 
        /// </summary>
        public int RowN
        {
            get { return _RowN; }
            set { _RowN = value; }
        }

        private int _ColumnN;

        /// <summary>
        /// 
        /// </summary>
        public int ColumnN
        {
            get { return _ColumnN; }
            set { _ColumnN = value; }
        }

        private double _RatedVoltage;

        /// <summary>
        /// 
        /// </summary>
        public double RatedVoltage
        {
            get { return _RatedVoltage; }
            set { _RatedVoltage = value; }
        }


        private double _RatedCurrent;

        /// <summary>
        /// 
        /// </summary>
        public double RatedCurrent
        {
            get { return _RatedCurrent; }
            set { _RatedCurrent = value; }
        }

        private string _CategoryOfsolarCells;

        /// <summary>
        /// 
        /// </summary>
        public string CategoryOfsolarCells
        {
            get { return _CategoryOfsolarCells; }
            set { _CategoryOfsolarCells = value; }
        }

        private string _BatteryModuleModel;

        /// <summary>
        /// 
        /// </summary>
        public string BatteryModuleModel
        {
            get { return _BatteryModuleModel; }
            set { _BatteryModuleModel = value; }
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

        private double _OpenCircuitVoltage;

        /// <summary>
        /// 
        /// </summary>
        public double OpenCircuitVoltage
        {
            get { return _OpenCircuitVoltage; }
            set { _OpenCircuitVoltage = value; }
        }

        private double _ShortCircuitCurrent;

        /// <summary>
        /// 
        /// </summary>
        public double ShortCircuitCurrent
        {
            get { return _ShortCircuitCurrent; }
            set { _ShortCircuitCurrent = value; }
        }

        private double _DoubleSidedFactor;

        /// <summary>
        /// 
        /// </summary>
        public double DoubleSidedFactor
        {
            get { return _DoubleSidedFactor; }
            set { _DoubleSidedFactor = value; }
        }

        private double _PeakPowerTemperatureCoefficient;

        /// <summary>
        /// 
        /// </summary>
        public double PeakPowerTemperatureCoefficient
        {
            get { return _PeakPowerTemperatureCoefficient; }
            set { _PeakPowerTemperatureCoefficient = value; }
        }

        private double _OpenCircuitVoltageTemperatureCoefficient;

        /// <summary>
        /// 
        /// </summary>
        public double OpenCircuitVoltageTemperatureCoefficient
        {
            get { return _OpenCircuitVoltageTemperatureCoefficient; }
            set { _OpenCircuitVoltageTemperatureCoefficient = value; }
        }

        private double _ShortCircuitCurrentTemperatureCoefficient;

        /// <summary>
        /// 
        /// </summary>
        public double ShortCircuitCurrentTemperatureCoefficient
        {
            get { return _ShortCircuitCurrentTemperatureCoefficient; }
            set { _ShortCircuitCurrentTemperatureCoefficient = value; }
        }

        private double _BatteryModuleEfficiency;

        /// <summary>
        /// 
        /// </summary>
        public double BatteryModuleEfficiency
        {
            get { return _BatteryModuleEfficiency; }
            set { _BatteryModuleEfficiency = value; }
        }

        private double _TenYearsOfPowerDegradation;

        /// <summary>
        /// 
        /// </summary>
        public double TenYearsOfPowerDegradation
        {
            get { return _TenYearsOfPowerDegradation; }
            set { _TenYearsOfPowerDegradation = value; }
        }

        private double _TwentyFiveYearsOfPowerDegradation;

        /// <summary>
        /// 
        /// </summary>
        public double TwentyFiveYearsOfPowerDegradation
        {
            get { return _TwentyFiveYearsOfPowerDegradation; }
            set { _TwentyFiveYearsOfPowerDegradation = value; }
        }
    }
}
