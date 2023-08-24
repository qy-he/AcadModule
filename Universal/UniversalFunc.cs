using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadModule
{
    public class UniversalFunc
    {
        public Dictionary<int, List<List<int>>> GetTheSameInformationMap(List<List<string>> dataArrLst)
        {
            //返回值
            Dictionary<int, List<List<int>>> theSameInformationMap = new Dictionary<int, List<List<int>>>();
            for (int i = 0; i < dataArrLst.FirstOrDefault().Count; i++)
            {
                theSameInformationMap.Add(i, GetTheSameLineInformationInOneColumn(dataArrLst, i));
            }
            return theSameInformationMap;

        }


        public List<List<int>> GetTheSameLineInformationInOneColumn(List<List<string>> dataArrLst, int columnIndex)
        {

            //返回值
            List<List<int>> theSameLineLst = new List<List<int>>();
            for (int i = 0; i < dataArrLst.Count;i++)
            {
                int startrow = i;
                int endrow = 0;//结束行
                string columnValue = dataArrLst[i][columnIndex];
                for (int j = 1 + i; j < dataArrLst.Count; j++)
                {
                    if (columnValue == dataArrLst[j][columnIndex])
                    {
                        endrow = j;
                    }
                    else
                    {
                        i = --j;
                        break;
                    }
                }
                if (endrow != 0)
                {
                    List<int> rowlist = new List<int>();
                    rowlist.Add(startrow);
                    rowlist.Add(endrow);
                    theSameLineLst.Add(rowlist);
                    if (endrow == dataArrLst.Count -1)
                    {
                        break;
                    }
                }
            }
            return theSameLineLst;
        }
    }
}
