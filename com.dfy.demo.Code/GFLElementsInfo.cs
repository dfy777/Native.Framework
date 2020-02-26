using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dfy.demo.Code
{
    public class GFLElementsInfo
    {
        //枪支名字
        #region
        private string[] name_string = {
            "none",
            "柯尔特左轮",
            "M1911",
            "M9",
            "none",
            "纳甘左轮",
            "托卡列夫",
            "斯捷奇金",
            "马卡洛夫",
            "P38",
            "PPK",
            "P08",
            "C96",
            "92式",
            "阿斯特拉左轮",
            "none",
            "汤姆森",
            "M3",
            "MAC-10",
            "none",
            "Vector",
            "PPsh-41",
            "none",
            "PPS-43",
            "PP2000",
            "MP-40",
            "MP5",
            "蝎式",
            "MP7",
            "司登 MkⅡ",
            "none",
            "伯莱塔38型",
            "微型乌兹",
            "M45",
            "M1加兰德",
            "none",
            "春田",
            "M14",
            "none",
            "莫辛·纳甘",
            "SVT-38",
            "西蒙诺夫",
            "PTRD",
            "SVD",
            "SV-98",
            "none",
            "Kar98k",
            "G43",
            "WA2000",
            "none",
            "李·恩菲尔德",
            "FN-49",
            "BM-59",
            "NTW-20",
            "none",
            "none",
            "none",
            "none",
            "AK-47",
            "none",
            "AS Val",
            "StG44",
            "G41",
            "G3",
            "G36",
            "HK416",
            "56-1式",
            "none",
            "L85A1",
            "FAMAS",
            "FNC",
            "加利尔",
            "TAR-21",
            "none",
            "SIG-50",
            "M1918",
            "none",
            "M2HB",
            "M60",
            "none",
            "M1919A4",
            "LWMMG",
            "DP28",
            "none",
            "none",
            "PK",
            "MG42",
            "MG34",
            "MG3",
            "布伦",
            "FNP-9",
            "MP-446",
            "Spectre M4",
            "IDW",
            "64式",
            "汉阳造88式",
            "灰熊 MkV",
            "M950A",
            "none",
            "Mk23",
            "P7",
            "UMP9",
            "none",
            "UMP45",
            "G36C",
            "OTs-12",
            "FAL",
            "F2000",
            "none",
            "MG5",
            "FG-42",
            "AAT-52",
            "内格夫",
            "none",
            "维尔德MkⅡ",
            "索米",
            "Z-62",
            "PSG-1",
            "9A-91",
            "none",
            "none",
            "Mk48",
            "G11",
            "P99",
            "none",
            "MG4",
            "NZ75",
            "79式",
            "M99",
            "95式",
            "97式",
            "none",
            "none",
            "63式",
            "none",
            "SR-3MP",
            "none",
            "PP-19-01",
            "none",
            "Bren Ten",
            "none",
            "USP Compat",
            "none",
            "none",
            "none",
            "none",
            "G28",
            "none",
            "IWS2000",
            "AEK-999",
            "希普卡",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "Spitfire",
            "none",
            "none",
            "利贝罗勒",
            "RFB",
            "PKP",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "PzB39",
            "T-91",
            "none",
            "竞争者",
            "T-5000",
            "阿梅利",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "K2",
            "none",
            "Zas M21",
            "卡尔卡诺M1891",
            "卡尔卡诺M91/38",
            "80式",
            "none",
            "none",
            "none",
            "none",
            "none",
            "AN-94",
            "AK-12",
            "none",
            "none",
            "none",
            "none",
            "none",
            "K5",
            "C-MS",
            "ADS",
            "MDR",
            "XM8",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "樱花",
            "none",
            "none",
            "none",
            "none",
            "Px4风暴",
            "none",
            "SPR-A3G",
            "K11",
            "SAR-21",
            "88式",
            "none",
            "none",
            "none",
            "none",
            "64式自",
            "none",
            "P90",
            "none",
            "K31",
            "杰里科",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "M200",
            "none",
            "none",
            "PA-15",
            "QBU-88",
            "EM-2",
            "MG36",
            "绍沙",
            "none",
            "none",
            "none",
            "none",
            "P30",
            "四式",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none",
            "none" };
        #endregion

        private ArrayList withvoid_list;
        private ArrayList withinvoid_list;

        //属性访问器
        #region
        public ArrayList Withvoid_List
        {
            get
            {
                return withvoid_list;
            }
            
        }

        public ArrayList Withinvoid_List
        { 
            get
            {
                return withinvoid_list;
            }
        }
        #endregion

        public GFLElementsInfo()
        {
            withvoid_list = new ArrayList();
            withinvoid_list = new ArrayList();
            int cnt = 0;
            foreach (var i in name_string)
            {
                if (!i.Equals("none"))
                {
                    withinvoid_list.Add(new ArrayList() { cnt, i });
                }
                withvoid_list.Add(i);
                cnt++;
            }
        }

        public void PrintArr()
        {
            foreach (var i in withinvoid_list)
            {
                Console.Write($"{((ArrayList)i)[0]} ,");
                Console.WriteLine(((ArrayList)i)[1]);
            }
            foreach (var i in withvoid_list)
            {
                Console.WriteLine(i);
            }
        }

        public string IndexToName(int index)
        {
            return (string)withvoid_list[index];
        }

        public int NameToIndex(string name)
        {
            return withvoid_list.IndexOf(name);
        }
    }
}
