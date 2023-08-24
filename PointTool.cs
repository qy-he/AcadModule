using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;

namespace AcadModule
{

    /// <summary>
    /// 点坐标工具
    /// </summary>
    public class PointTool
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public PointTool()
        {

        }






        /// <summary>
        /// 从点列表中分别找出最小的x值、y值和z值，组成最小的点
        /// </summary>
        /// <param name="points">点列表</param>
        /// <returns>最小的点,即左下角的点</returns>
        public Point3d GetMinPoint(List<Point3d> points)
        {
            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double minZ = double.MaxValue;

            foreach (Point3d each in points)
            {
                minX =Math.Min(minX, each.X);
                minY =Math.Min(minY, each.Y);
                minZ =Math.Min(minZ, each.Z);

            }

            return new Point3d(minX, minY, minZ);

        }






        /// <summary>
        /// 从点列表中分别找出最大的x值、y值和z值，组成最大的点
        /// </summary>
        /// <param name="points">点列表</param>
        /// <returns>最大的点,即右上角的点</returns>
        public Point3d GetMaxPoint(List<Point3d> points)
        {
            double maxX = double.MinValue;
            double maxY = double.MinValue;
            double maxZ = double.MinValue;

            foreach (Point3d each in points)
            {

                maxX =Math.Max(maxX, each.X);
                maxY =Math.Max(maxY, each.Y);
                maxZ =Math.Max(maxZ, each.Z);
            }

            return new Point3d(maxX, maxY, maxZ);

        }


        /// <summary>
        /// 包住所有点的最大长度
        /// </summary>
        /// <param name="points">点列表</param>
        /// <returns>最大的高度</returns>
        public double GetMaxLength(List<Point3d> points)
        {
            Point3d minPoint = GetMinPoint(points);
            Point3d maxPoint = GetMaxPoint(points);

            double maxLength = maxPoint.X - minPoint.X;

            return maxLength;
        }



        /// <summary>
        /// 包住所有点的最大高度
        /// </summary>
        /// <param name="points">点列表</param>
        /// <returns>最大的高度</returns>
        public double GetMaxHeight(List<Point3d> points)
        {
            Point3d minPoint = GetMinPoint(points);
            Point3d maxPoint = GetMaxPoint(points);

            double maxHeight = maxPoint.Y-minPoint.Y;

            return maxHeight;
        }



        /// <summary>
        /// 包住所有点的最大边界
        /// </summary>
        /// <param name="points">点列表</param>
        /// <returns>点列表，分别为左下角点、左上角点、右上角点、右下角点</returns>
        public List<Point3d> GetBoundingBox(List<Point3d> points)
        {
            //左下角的点
            Point3d minPoint = GetMinPoint(points);

            //右上角的点
            Point3d maxPoint = GetMaxPoint(points);


            //左上角的点
            Point3d leftUpPoint = new Point3d(minPoint.X, maxPoint.Y, minPoint.Z);

            //右下角的点
            Point3d rightDownPoint = new Point3d(maxPoint.X, minPoint.Y, minPoint.Z);


            List<Point3d> boundingBox = new List<Point3d>
         {
             minPoint,
             leftUpPoint,
             maxPoint,
             rightDownPoint
         };

            return boundingBox;
        }


        /// <summary>
        /// 由边界向外偏移一定的距离，得到的新的边界
        /// </summary>
        /// <param name="boundingBox">原边界点列表，分别为左下角点、左上角点、右上角点、右下角点，会自动判断是否符合要求</param>
        /// <param name="tolerance">偏移的水平距离</param>
        /// <returns>新边界点列表，分别为左下角点、左上角点、右上角点、右下角点，如果原边界点列表有问题，返回null</returns>
        public List<Point3d> GetNewBoundingBox(List<Point3d> boundingBox, double tolerance)
        {
            List<Point3d> newBoundingBox = null;


            if (boundingBox == null || boundingBox.Count!=4)
            {
                return newBoundingBox;
            }

            //左下角
            Point3d leftDownPoint = boundingBox[0];
            //左上角
            Point3d leftUpPoint = boundingBox[1];
            //右上角
            Point3d rightUpPoint = boundingBox[2];
            //右下角
            Point3d rightDownPoint = boundingBox[3];



            //这个tolerance是水平偏移，需要找到极轴半径
            double distance = tolerance/Math.Sin(Math.PI/4);



            //左下角
            double angle = Math.PI*5/4;
            Point3d newLeftDownPoint = GetPolarPoint(leftDownPoint, distance, angle);

            //左上角
            angle = Math.PI*3/4;
            Point3d newLeftUpPoint = GetPolarPoint(leftUpPoint, distance, angle);

            //右上角
            angle = Math.PI/4;

            Point3d newRightUpPoint = GetPolarPoint(rightUpPoint, distance, angle);

            //右下角
            angle =-Math.PI/4;
            Point3d newRightDownPoint = GetPolarPoint(rightDownPoint, distance, angle);

            newBoundingBox=new List<Point3d>
            {
                newLeftDownPoint,
                newLeftUpPoint,
                newRightUpPoint,
                newRightDownPoint
            };

            return newBoundingBox;

        }





        /// <summary>
        /// 在xy平面获取极坐标
        /// </summary>
        /// <param name="point">起始点的坐标</param>
        /// <param name="distance">距离</param>
        /// <param name="angle">角度，弧度制</param>
        /// <returns></returns>
        public Point3d GetPolarPoint(Point3d point, double distance, double angle)
        {
            return new Point3d(point.X + distance * Math.Cos(angle), point.Y + distance * Math.Sin(angle), point.Z);
        }


    }

}

