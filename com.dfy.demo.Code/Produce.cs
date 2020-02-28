using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dfy.demo.Code
{
    public class Produce
    {
        //字段
        #region
        private GFLElementsInfo gflelementinfo;
        private int manpower;
        private int ammo;
        private int ration;
        private int parts;

        private double hg_mul = 1.0;
        private double ar_mul = 1.0;
        private double rf_mul = 1.0;
        private double mg_mul = 1.0;
        private double sg_mul = 1.0;
        private double smg_mul = 1.0;

        private int MAX_PRODUCE_NUM = 100;
        #endregion

        //属性
        #region
        private GFLElementsInfo GflElementinfo
        {
            get
            {
                return gflelementinfo;
            }
        }
        public int Manpower
        {
            get { return manpower; }
            set { manpower = value; }
        }

        public int Ammo
        {
            get { return ammo; }
            set { ammo = value; }
        }

        public int Ration
        {
            get { return ration; }
            set { ration = value; }
        }

        public int Parts
        {
            get { return parts; }
            set { parts = value; }
        }

            
        #endregion

        /// <summary>
        /// 构造函数
        /// 初始化可建造元素信息
        /// </summary>
        public Produce()
        {
            gflelementinfo = new GFLElementsInfo();
        }

        /// <summary>
        /// 该函数为建造算法的入口
        /// </summary>
        /// <param name="produce_type">建造类型
        /// 1--普通人形建造
        /// 2--重型人形建造
        /// 3--普通装备建造
        /// 4--重型装备建造</param>
        /// <param name="produce_num">建造次数</param>
        public void BeginToProduce(int produce_type, int produce_num)
        {
            if (ErrorDetection_type(produce_type))
            {
                throw new ArgumentException("非法资源数目");
            }

            if (ErrorDetection_num(produce_num))
            {
                throw new ArgumentException("非法建造次数");
            }

            
            
            int star_num;
            List<GFLElements> str_info = new List<GFLElements>();

            for (int i = 0; i <= produce_num; i++)
            {
                switch (produce_type)
                {
                    case 1:
                        star_num = GetStar_Tdoll(1);
                        str_info.Add(Make_Tdoll(star_num));
                        break;
                    case 2:
                        star_num = GetStar_Tdoll_Heavy(2);
                        //str_info = Make_Tdoll_Heavy(star_num);
                        break;
                    case 3:
                        star_num = GetStar_Equip(3);
                        //str_info = Make_Equip(star_num);
                        break;
                    case 4:
                        star_num = GetStar_Equip_Heavy(4);
                        //str_info = Make_Equip_Heavy(star_num);
                        break;
                    default:
                        throw new ArgumentException("produce_type error");
                }
            }

            for(int i = 0; i < str_info.Count(); i++)
            {
                Console.WriteLine(str_info[i].ToString());
            }
        }

        /// <summary>
        /// 设置建造资源
        /// </summary>
        /// <param name="mw">人力manpower</param>
        /// <param name="aw">弹药ammo</param>
        /// <param name="rw">配给ration</param>
        /// <param name="pw">零件parts</param>
        public void SetResources(int mw, int aw, int rw, int pw)
        {
            Manpower = mw;
            Ammo = aw;
            Ration = rw;
            Parts = pw;
        }

        /// <summary>
        /// 计算资源的总和
        /// </summary>
        /// <returns></returns>
        private int _sum()
        {
            return Manpower + Ammo + Ration + Parts;
        }

        private int GetStar_Tdoll(int produce_type)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int rd = random.Next(100);
            int sum = _sum();
            
            if (sum >= 420)
            {   
                //normal resources
                //posibility from[3, 10, 27, 60]
                if (rd < 3) { return 5; }
                else if (rd >= 3 && rd < 13) { return 4; }
                else if (rd >= 13 && rd < 40) { return 3; }
                else { return 2; }
            }
            else if (sum < 420 && sum >= 200)
            {
                //normal resources
                //posibility from[2, 8, 25, 65]
                if (rd < 2) { return 5; }
                else if (rd >= 2 && rd < 10) { return 4; }
                else if (rd >= 10 && rd < 35) { return 3; }
                else { return 2; }
            }
            else
            {
                //normal resources
                //posibility from[1, 7, 22, 70]
                if (rd < 1) { return 5; }
                else if (rd >= 1 && rd < 8) { return 4; }
                else if (rd >= 8 && rd < 30) { return 3; }
                else { return 2; }
            }
            //return 0;
        }

        private int GetStar_Tdoll_Heavy(int produce_type)
        {
            return 0;
        }

        private int GetStar_Equip(int produce_type)
        {
            return 0;
        }

        private int GetStar_Equip_Heavy(int produce_type)
        {
            return 0;
        }

        /// <summary>
        /// 根据资源数和星级返回人形信息
        /// HG——total <= 920
        /// </summary>
        /// <param name="star_num">星级数</param>
        /// <returns>人形信息</returns>
        private GFLElements Make_Tdoll(int star_num)
        {
            List<GFLElements> tdoll_list = new List<GFLElements>();
            GFLElements result_element = new GFLElements();

            //Hg---total < 920
            if (_sum() <= 920)
            {
                SetHg_Mul();

                if (star_num == 5)
                {
                    tdoll_list.Add(CreateTdollInfo_Hg(96, 200, star_num));  //灰熊
                    tdoll_list.Add(CreateTdollInfo_Hg(126, 110, star_num)); //NZ75
                    tdoll_list.Add(CreateTdollInfo_Hg(233, 30, star_num));  //PX4风暴
                    tdoll_list.Add(CreateTdollInfo_Hg(260, 30, star_num));  //PA-15
                   
                    //对资源有特殊要求的5星HG
                    if (manpower >= 130 && ammo >= 130 && ration >= 130 && parts >= 30)
                    {
                        tdoll_list.Add(CreateTdollInfo_Hg(97, 80, star_num));   //M950A
                        tdoll_list.Add(CreateTdollInfo_Hg(114, 100, star_num)); //维尔德
                        tdoll_list.Add(CreateTdollInfo_Hg(183, 30, star_num));  //竞争者
                    }
                }
                else if (star_num == 4)
                {
                    tdoll_list.Add(CreateTdollInfo_Hg(1, 367, star_num));   //柯尔特
                    tdoll_list.Add(CreateTdollInfo_Hg(99, 259, star_num));  //mk23
                    tdoll_list.Add(CreateTdollInfo_Hg(100, 263, star_num)); //P7
                    tdoll_list.Add(CreateTdollInfo_Hg(269, 260, star_num)); //p30

                    //对资源有特殊要求的5星HG
                    if (manpower >= 130 && ammo >= 130 && ration >= 130 && parts >= 30)
                    {
                        tdoll_list.Add(CreateTdollInfo_Hg(7, 87, star_num));    //斯捷奇金
                        tdoll_list.Add(CreateTdollInfo_Hg(168, 147, star_num)); //喷火
                        tdoll_list.Add(CreateTdollInfo_Hg(212, 140, star_num)); //K5
                        tdoll_list.Add(CreateTdollInfo_Hg(248, 80, star_num));  //杰里科
                    }
                }
                else if (star_num == 3)
                {
                    tdoll_list.Add(CreateTdollInfo_Hg(3, 366, star_num));   //M9
                    tdoll_list.Add(CreateTdollInfo_Hg(6, 267, star_num));   //托卡列夫
                    tdoll_list.Add(CreateTdollInfo_Hg(8, 186, star_num));   //马卡洛夫
                    tdoll_list.Add(CreateTdollInfo_Hg(11, 322, star_num));  //P08
                    tdoll_list.Add(CreateTdollInfo_Hg(12, 360, star_num));  //C96
                    tdoll_list.Add(CreateTdollInfo_Hg(13, 183, star_num));  //92式
                    tdoll_list.Add(CreateTdollInfo_Hg(14, 325, star_num));  //阿斯特拉左轮
                    tdoll_list.Add(CreateTdollInfo_Hg(123, 152, star_num)); //P99
                }
                else
                {
                    tdoll_list.Add(CreateTdollInfo_Hg(2, 570, star_num));   //M1911
                    tdoll_list.Add(CreateTdollInfo_Hg(5, 547, star_num));   //纳甘左轮
                    tdoll_list.Add(CreateTdollInfo_Hg(9, 572, star_num));   //P38
                    tdoll_list.Add(CreateTdollInfo_Hg(10, 563, star_num));  //PPK
                    tdoll_list.Add(CreateTdollInfo_Hg(90, 500, star_num));  //FNP-9
                    tdoll_list.Add(CreateTdollInfo_Hg(91, 544, star_num));  //MP446
                    tdoll_list.Add(CreateTdollInfo_Hg(139, 579, star_num)); //Bren Ten
                    tdoll_list.Add(CreateTdollInfo_Hg(141, 556, star_num)); //USP Compat
                }
            }

            //smg is everywhere!
            if (true)
            {
                SetSmg_Mul();
                if (star_num == 5)
                {
                    tdoll_list.Add(CreateTdollInfo_Smg(16, 160, star_num));   //汤姆森
                    if (ammo >= 400 && manpower >= 400)
                    {
                        tdoll_list.Add(CreateTdollInfo_Smg(20, 108, star_num));     //Vector
                        tdoll_list.Add(CreateTdollInfo_Smg(104, 24, star_num));     //G36C
                        tdoll_list.Add(CreateTdollInfo_Smg(115, 48, star_num));     //索米
                        tdoll_list.Add(CreateTdollInfo_Smg(127, 132, star_num));    //79式
                        tdoll_list.Add(CreateTdollInfo_Smg(135, 57, star_num));     //SR-3MP
                        tdoll_list.Add(CreateTdollInfo_Smg(213, 22, star_num));     //C-MS
                        tdoll_list.Add(CreateTdollInfo_Smg(245, 14, star_num));     //P90
                        tdoll_list.Add(CreateTdollInfo_Smg(228, 108, star_num));    //樱花
                    }
                }
                else if (star_num == 4)
                {
                    tdoll_list.Add(CreateTdollInfo_Smg(23, 114, star_num));     //PP-90
                    tdoll_list.Add(CreateTdollInfo_Smg(26, 220, star_num));     //MP5
                    tdoll_list.Add(CreateTdollInfo_Smg(137, 220, star_num));    //PP-19-01
                    if (ammo >= 400 && manpower >= 300)
                    {
                        tdoll_list.Add(CreateTdollInfo_Smg(101, 220, star_num));   //UMP9
                        tdoll_list.Add(CreateTdollInfo_Smg(103, 155, star_num));   //UMP45
                        tdoll_list.Add(CreateTdollInfo_Smg(150, 120, star_num));   //希普卡
                    }
                }
                else if (star_num == 3)
                {
                    tdoll_list.Add(CreateTdollInfo_Smg(18, 178, star_num)); //MAC-10
                    tdoll_list.Add(CreateTdollInfo_Smg(22, 99, star_num));  //PPS-43
                    tdoll_list.Add(CreateTdollInfo_Smg(27, 130, star_num)); //蝎式
                    tdoll_list.Add(CreateTdollInfo_Smg(29, 298, star_num)); //司登 MkⅡ
                    tdoll_list.Add(CreateTdollInfo_Smg(32, 188, star_num)); //微型乌兹
                }
                else
                {
                    tdoll_list.Add(CreateTdollInfo_Smg(93, 308, star_num));   //IDW
                    tdoll_list.Add(CreateTdollInfo_Smg(17, 344, star_num));   //M3
                    tdoll_list.Add(CreateTdollInfo_Smg(21, 308, star_num));   //PPsh-41
                    tdoll_list.Add(CreateTdollInfo_Smg(24, 432, star_num));   //PP2000
                    tdoll_list.Add(CreateTdollInfo_Smg(31, 342, star_num));   //伯莱塔38型
                    tdoll_list.Add(CreateTdollInfo_Smg(33, 376, star_num));   //M45
                    tdoll_list.Add(CreateTdollInfo_Smg(92, 444, star_num));   //Spectre M4
                    tdoll_list.Add(CreateTdollInfo_Smg(94, 316, star_num));   //64式
                }
            }

            //Ar---total >= 800
            if (_sum() >= 800)
            {
                SetAr_Mul();

                if(star_num == 5)
                {
                    tdoll_list.Add(CreateTdollInfo_Ar(65, 180, star_num));   //HK416
                    tdoll_list.Add(CreateTdollInfo_Ar(122, 50, star_num));   //G11
                    if (ammo >= 400 && ration >= 400)
                    {
                        tdoll_list.Add(CreateTdollInfo_Ar(62, 120, star_num));  //G41
                        tdoll_list.Add(CreateTdollInfo_Ar(106, 100, star_num)); //FAL
                        tdoll_list.Add(CreateTdollInfo_Ar(129, 100, star_num)); //95式
                        tdoll_list.Add(CreateTdollInfo_Ar(130, 100, star_num)); //97式
                        tdoll_list.Add(CreateTdollInfo_Ar(172, 80, star_num));  //RFB
                        tdoll_list.Add(CreateTdollInfo_Ar(181, 100, star_num)); //T-91
                        tdoll_list.Add(CreateTdollInfo_Ar(194, 100, star_num)); //K2
                        tdoll_list.Add(CreateTdollInfo_Ar(196, 190, star_num)); //Zas M21
                        tdoll_list.Add(CreateTdollInfo_Ar(205, 50, star_num));  //AN-94
                        tdoll_list.Add(CreateTdollInfo_Ar(206, 50, star_num));  //AK-12
                        tdoll_list.Add(CreateTdollInfo_Ar(215, 100, star_num)); //MDR
                        tdoll_list.Add(CreateTdollInfo_Ar(236, 180, star_num)); //K11
                        tdoll_list.Add(CreateTdollInfo_Ar(243, 100, star_num)); //64式自
                        tdoll_list.Add(CreateTdollInfo_Ar(214, 100, star_num)); //ADS
                    }
                }
                else if (star_num == 4)
                {
                    tdoll_list.Add(CreateTdollInfo_Ar(60, 200, star_num));   //AS Val
                    tdoll_list.Add(CreateTdollInfo_Ar(66, 200, star_num));   //56-1式
                    tdoll_list.Add(CreateTdollInfo_Ar(69, 200, star_num));   //FAMAS
                    tdoll_list.Add(CreateTdollInfo_Ar(118, 200, star_num));  //9A-91
                    tdoll_list.Add(CreateTdollInfo_Ar(216, 200, star_num));  //XM8
                    tdoll_list.Add(CreateTdollInfo_Ar(237, 200, star_num));  //SAR-21
                    tdoll_list.Add(CreateTdollInfo_Ar(262, 200, star_num));  //EM-2
                    if (ammo >= 400 && ration >= 400)
                    {
                        tdoll_list.Add(CreateTdollInfo_Ar(64, 100, star_num));   //G36
                        tdoll_list.Add(CreateTdollInfo_Ar(72, 200, star_num));   //TAR-21
                        tdoll_list.Add(CreateTdollInfo_Ar(171, 200, star_num));   //利贝罗勒
                    }
                }
                else if (star_num == 3)
                {
                    tdoll_list.Add(CreateTdollInfo_Ar(58, 290, star_num));   //AK-47
                    tdoll_list.Add(CreateTdollInfo_Ar(61, 315, star_num));   //StG44
                    tdoll_list.Add(CreateTdollInfo_Ar(70, 290, star_num));   //FNC
                    tdoll_list.Add(CreateTdollInfo_Ar(105, 270, star_num));  //OTs-12
                }
                else
                {
                    tdoll_list.Add(CreateTdollInfo_Ar(63, 350, star_num));   //G3
                    tdoll_list.Add(CreateTdollInfo_Ar(68, 300, star_num));   //L85A1
                    tdoll_list.Add(CreateTdollInfo_Ar(71, 300, star_num));   //加利尔
                    tdoll_list.Add(CreateTdollInfo_Ar(74, 300, star_num));   //SIG-50
                    tdoll_list.Add(CreateTdollInfo_Ar(107, 300, star_num));  //F2000
                    tdoll_list.Add(CreateTdollInfo_Ar(133, 350, star_num));  //63式
                }
            }

            //RF---manpower>=300 and ration >= 300
            if (manpower >= 300 && ration >= 300)
            {
                SetRf_Mul();
                if (star_num == 5)
                {
                    tdoll_list.Add(CreateTdollInfo_Rf(48, 85, star_num));   //WA2000
                    tdoll_list.Add(CreateTdollInfo_Rf(53, 90, star_num));   //NTW-20
                    tdoll_list.Add(CreateTdollInfo_Rf(197, 60, star_num));  //卡尔卡诺M1891
                    if (manpower >= 400 && ration >= 400)
                    {
                        tdoll_list.Add(CreateTdollInfo_Rf(46, 28, star_num));   //Kar98k
                        tdoll_list.Add(CreateTdollInfo_Rf(50, 60, star_num));   //李·恩菲尔德
                        tdoll_list.Add(CreateTdollInfo_Rf(128, 28, star_num));  //M99
                        tdoll_list.Add(CreateTdollInfo_Rf(148, 16, star_num));  //IWS2000
                        tdoll_list.Add(CreateTdollInfo_Rf(198, 14, star_num));  //卡尔卡诺M91/38
                        tdoll_list.Add(CreateTdollInfo_Rf(257, 85, star_num));  //M200
                        tdoll_list.Add(CreateTdollInfo_Rf(261, 30, star_num));  //QBU-88
                    }
                }
                else if (star_num == 4)
                {
                    tdoll_list.Add(CreateTdollInfo_Rf(36, 300, star_num));   //春田
                    tdoll_list.Add(CreateTdollInfo_Rf(39, 260, star_num));   //莫辛·纳甘
                    tdoll_list.Add(CreateTdollInfo_Rf(42, 160, star_num));   //PTRD
                    tdoll_list.Add(CreateTdollInfo_Rf(43, 110, star_num));   //SVD
                    tdoll_list.Add(CreateTdollInfo_Rf(184, 100, star_num));  //T-5000
                    tdoll_list.Add(CreateTdollInfo_Rf(235, 100, star_num));  //SPR-A3G
                    tdoll_list.Add(CreateTdollInfo_Rf(247, 100, star_num));  //K31
                    tdoll_list.Add(CreateTdollInfo_Rf(270, 100, star_num));  //四式
                }
                else if (star_num == 3)
                {
                    tdoll_list.Add(CreateTdollInfo_Rf(34, 400, star_num));   //M1加兰德
                    tdoll_list.Add(CreateTdollInfo_Rf(37, 370, star_num));   //M14
                    tdoll_list.Add(CreateTdollInfo_Rf(44, 300, star_num));   //SV-98
                    if (manpower >= 400 && ration >= 400)
                    {
                        tdoll_list.Add(CreateTdollInfo_Rf(95, 90, star_num)); //汉阳造88式
                    }
                }
                else
                {
                    tdoll_list.Add(CreateTdollInfo_Rf(40, 500, star_num));   //SVT-38
                    tdoll_list.Add(CreateTdollInfo_Rf(41, 500, star_num));   //西蒙诺夫
                    tdoll_list.Add(CreateTdollInfo_Rf(47, 440, star_num));   //G43
                    tdoll_list.Add(CreateTdollInfo_Rf(51, 430, star_num));   //FN-49
                    tdoll_list.Add(CreateTdollInfo_Rf(52, 460, star_num));   //BM-59
                }
            }

            // MG---manpower>=400 && ammo>=600 && parts>=300
            if (manpower >= 400 && ammo >= 600 && parts >= 300)
            {
                SetMG_Mul();
                if (star_num == 5)
                {
                    tdoll_list.Add(CreateTdollInfo_Mg(109, 90, star_num));   //MG5
                    if (manpower >= 600 && ammo >= 600 && ration >= 100 && parts >= 400)
                    {
                        tdoll_list.Add(CreateTdollInfo_Mg(112, 40, star_num));   //内格夫
                        tdoll_list.Add(CreateTdollInfo_Mg(125, 50, star_num));   //MG4
                        tdoll_list.Add(CreateTdollInfo_Mg(173, 70, star_num));   //PKP
                        tdoll_list.Add(CreateTdollInfo_Mg(238, 70, star_num));   //88式
                        tdoll_list.Add(CreateTdollInfo_Mg(263, 70, star_num));   //MG36
                    }
                }
                else if (star_num == 4)
                {
                    tdoll_list.Add(CreateTdollInfo_Mg(75, 230, star_num));   //M1918
                    tdoll_list.Add(CreateTdollInfo_Mg(78, 150, star_num));   //M60
                    tdoll_list.Add(CreateTdollInfo_Mg(88, 200, star_num));   //MG3
                    tdoll_list.Add(CreateTdollInfo_Mg(185, 55, star_num));   //阿梅利
                    if (manpower >= 600 && ammo >= 600 && ration >= 100 && parts >= 400)
                    {
                        tdoll_list.Add(CreateTdollInfo_Mg(85, 80, star_num));    //PK
                        tdoll_list.Add(CreateTdollInfo_Mg(121, 80, star_num));   //Mk48
                        tdoll_list.Add(CreateTdollInfo_Mg(149, 80, star_num));   //AEK-999
                        tdoll_list.Add(CreateTdollInfo_Mg(199, 70, star_num));   //80式
                        tdoll_list.Add(CreateTdollInfo_Mg(264, 80, star_num));   //绍沙
                    }
                }
                else if (star_num == 3)
                {
                    tdoll_list.Add(CreateTdollInfo_Mg(77, 170, star_num));   //M2HB
                    tdoll_list.Add(CreateTdollInfo_Mg(80, 350, star_num));   //M1919A4
                    tdoll_list.Add(CreateTdollInfo_Mg(86, 350, star_num));   //MG42
                    tdoll_list.Add(CreateTdollInfo_Mg(89, 380, star_num));   //布伦
                }
                else if (star_num == 2)
                {
                    tdoll_list.Add(CreateTdollInfo_Mg(81, 590, star_num));   //LWMMG
                    tdoll_list.Add(CreateTdollInfo_Mg(82, 790, star_num));   //DP28
                    tdoll_list.Add(CreateTdollInfo_Mg(87, 650, star_num));   //MG34
                    tdoll_list.Add(CreateTdollInfo_Mg(110, 630, star_num));  //FG-42
                    tdoll_list.Add(CreateTdollInfo_Mg(111, 680, star_num));  //AAT-52
                }
            }


            Random random = new Random(Guid.NewGuid().GetHashCode());
            double total_possibility = 0;

            for (int item = 0; item < tdoll_list.Count(); item++)
            {
                total_possibility += tdoll_list[item].Possibility;
            }

            //随机取点
            total_possibility *= random.NextDouble();

            for (int item = 0; item < tdoll_list.Count(); item++)
            {
                total_possibility -= tdoll_list[item].Possibility;
                if (total_possibility <= 0)
                {
                    result_element = tdoll_list[item];
                    break;
                }
            }

            return result_element;
        }

        private ArrayList Make_Tdoll_Heavy(int star_num)
        {
            return new ArrayList();
        }

        private ArrayList Make_Equip(int star_num)
        {
            return new ArrayList();
        }

        private ArrayList Make_Equip_Heavy(int star_num)
        {
            return new ArrayList();
        }

        /// <summary>
        /// 资源数目是否符合要求
        /// </summary>
        /// <param name="produce_type">4种建造类型</param>
        /// <returns>符合要求返回false</returns>
        private bool ErrorDetection_type(int produce_type)
        {
            if (produce_type == 1)
            {
                if (manpower >= 30 && manpower <= 999 &&
                    ammo >= 30 && ammo <= 999 &&
                    ration >= 30 && ration <= 999 &&
                    parts >= 30 && parts <= 999)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            } 
            else if (produce_type == 2)
            {
                if (manpower >= 1000 && manpower <= 9999 &&
                    ammo >= 1000 && ammo <= 9999 &&
                    ration >= 1000 && ration <= 9999 &&
                    parts >= 1000 && parts <= 9999)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (produce_type == 3)
            {
                if (manpower >= 10 && manpower <= 999 &&
                    ammo >= 10 && ammo <= 999 &&
                    ration >= 10 && ration <= 999 &&
                    parts >= 10 && parts <= 999)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (manpower >= 500 && manpower <= 9999 &&
                    ammo >= 500 && ammo <= 9999 &&
                    ration >= 500 && ration <= 9999 &&
                    parts >= 500 && parts <= 9999)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// 建造次数是否符合要求
        /// </summary>
        /// <param name="produce_num">建造次数</param>
        /// <returns>符合要求返回false</returns>
        private bool ErrorDetection_num(int produce_num)
        {
            if (produce_num >= 1 && produce_num <= MAX_PRODUCE_NUM)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// set hg_mul depend on sum of resources
        /// [820, 920)---0.37
        /// [420, 820)---1
        /// [220, 420)---0.7
        /// [0, 220)---0.37
        /// </summary>
        private void SetHg_Mul()
        {
            int sum = _sum();
            if (sum >= 820 && sum < 920) { hg_mul = 0.37; }
            else if (sum >= 420 && sum < 820) { hg_mul = 1; }
            else if (sum >= 220 && sum < 420) { hg_mul = 0.7; }
            else { hg_mul = 0.37; }
        }

        /// <summary>
        /// set smg_mul depend on sum of resources
        /// [1800, 4000)---0.9
        /// [1000, 1800)---1
        /// [600, 1000---0.6
        /// [0,600]---0.3
        /// </summary>
        private void SetSmg_Mul()
        {
            int sum = _sum();
            if (sum >= 1800) { smg_mul = 0.9; }
            else if (sum >= 1000 && sum < 1800) { smg_mul = 1; }
            else if (sum >= 600 && sum < 1000) { smg_mul = 0.6; }
            else { smg_mul = 0.3; }
        }

        /// <summary>
        /// set ar_mul depend on sum of resources
        /// [1000, 4000)---1
        /// [0, 1000)---0.8
        /// Ammo or Ration < 400 --- *= 0.9
        /// </summary>
        private void SetAr_Mul()
        {
            int sum = _sum();
            if (sum >= 1000) { ar_mul = 1; }
            else { ar_mul = 0.8; }
            
            if(Ammo < 400) { ar_mul *= 0.9; }
            if(Ration < 400) { ar_mul *= 0.9; }
        }


        /// <summary>
        /// set rf_mul depend on sum of resources
        /// [1100, 4000)---1
        /// [800, 1100)---0.7
        /// [0, 800)---0.5
        /// Manpower or Ration < 400 --- *= 0.8
        /// </summary>
        private void SetRf_Mul()
        {
            int sum = _sum();
            if (sum >= 1100) { rf_mul = 1; }
            else if (sum >= 800 && sum < 1100) { rf_mul = 0.7; }
            else { rf_mul = 0.5; }

            if (Manpower < 400) { rf_mul *= 0.8; }
            if (Ration < 400) { rf_mul *= 0.8; }
        }


        /// <summary>
        /// set mg_mul depend on sum of resources
        /// [1700, 4000)---1
        /// [0, 1700)---0.8
        /// </summary>
        private void SetMG_Mul()
        {
            if (_sum() >= 1700)
            {
                mg_mul = 1.0;
            }
            else
            {
                mg_mul = 0.8;
            }
        }

        /// <summary>
        /// set sg_mul depend on sum of resources
        /// [18000, 40000)---1
        /// [17000, 18000)---0.8
        /// [0, 17000)---0.6
        /// 
        /// Ammo <= 3000 --- *= 1
        /// (3000, 5000] --- *= 0.9
        /// (5000, 9999] --- *= 0.8
        /// </summary>
        private void SetSg_Mul_Heavy()
        {
            int sum = _sum();
            
            if (sum >= 18000) { sg_mul = 1; }
            else if (sum >= 17000 && sum < 18000) { sg_mul = 0.8; }
            else { sg_mul = 0.6; }

            if (Ammo <= 3000) { sg_mul *= 1; }
            else if (Ammo > 3000 && Ammo <= 5000) { sg_mul *= 0.9; }
            else { sg_mul *= 0.8; }
        }

        /// <summary>
        /// set smg_mul depend on sum of resources in Heavy Produce
        /// default = 3
        /// [22000, 40000)--- *= 0.2
        /// [18000, 22000)--- *= 0.4
        /// [10000, 18000)--- *= 0.6
        /// [7000, 10000)--- *= 0.8
        /// [0, 7000)--- *= 1
        /// </summary>
        private void SetSmg_Mul_Heavy()
        {
            smg_mul = 3;
            int sum = _sum();

            if (sum >= 22000) { smg_mul *= 0.2; }
            else if (sum >= 18000 && sum < 22000) { smg_mul *= 0.4; }
            else if (sum >= 10000 && sum < 18000) { smg_mul *= 0.6; }
            else if (sum >= 7000 && sum < 10000) { smg_mul *= 0.8; }
            else { smg_mul *= 1; }
        }

        /// <summary>
        /// set ar_mul depend on sum of resources in Heavy Produce
        /// default = 3
        /// [22000, 40000)--- *= 0.15
        /// [18000, 22000)--- *= 0.2
        /// [15000, 18000)--- *= 0.3
        /// [12000, 15000)--- *= 0.4
        /// [10000, 12000)--- *= 0.6
        /// [7000, 10000)--- *= 0.8
        /// [0, 7000)--- *= 1
        /// </summary>
        private void SetAr_Mul_Heavy()
        {
            ar_mul = 3;
            int sum = _sum();

            if (sum >= 22000) { ar_mul *= 0.15; }
            else if (sum >= 18000 && sum < 22000) { ar_mul *= 0.2; }
            else if (sum >= 15000 && sum < 18000) { ar_mul *= 0.3; }
            else if (sum >= 12000 && sum < 15000) { ar_mul *= 0.4; }
            else if (sum >= 10000 && sum < 12000) { ar_mul *= 0.6; }
            else if (sum >= 7000 && sum < 10000) { ar_mul *= 0.8; }
            else { ar_mul *= 1; }
        }

        /// <summary>
        /// set rf_mul depend on sum of resources in Heavy Produce
        /// default = 3
        /// [22000, 40000)--- *= 0.25
        /// [18000, 22000)--- *= 0.35
        /// [14000, 18000)--- *= 0.5
        /// [12000, 14000)--- *= 0.7
        /// [0, 12000)--- *= 1
        /// </summary>
        private void SetRf_Mul_Heavy()
        {
            rf_mul = 3;
            int sum = _sum();

            if (sum >= 22000) { rf_mul *= 0.25; }
            else if (sum >= 18000 && sum < 22000) { rf_mul *= 0.35; }
            else if (sum >= 14000 && sum < 18000) { rf_mul *= 0.5; }
            else if (sum >= 12000 && sum < 14000) { rf_mul *= 0.7; }
            else { rf_mul *= 1; }
        }

        /// <summary>
        /// set mg_mul depend on sum of resources in Heavy Produce
        /// default = 3
        /// [22000, 40000)--- *= 0.4
        /// [20000, 22000)--- *= 0.6
        /// [18000, 20000)--- *= 0.8
        /// [17000, 18000)--- *= 1
        /// [0, 17000)--- *= 0.8
        /// </summary>
        private void SetMg_Mul_Heavy()
        {
            mg_mul = 3;
            int sum = _sum();

            if (sum >= 22000) { mg_mul *= 0.4; }
            else if (sum >= 20000 && sum < 22000) { mg_mul *= 0.6; }
            else if (sum >= 18000 && sum < 20000) { mg_mul *= 0.8; }
            else if (sum >= 17000 && sum < 18000) { mg_mul *= 1; }
            else { mg_mul *= 0.8; }
        }

        /// <summary>
        /// 创建人形信息对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="possibility"></param>
        /// <param name="tdoll_type"></param>
        /// <returns></returns>
        private GFLElements CreateTdollInfo_Hg(int index, double possibility, int starnum)
        {
            possibility *= hg_mul;
            string name = gflelementinfo.IndexToName(index);

            return new GFLElements(index, possibility, starnum, name, "HG");
        }

        private GFLElements CreateTdollInfo_Ar(int index, double possibility, int starnum)
        {
            possibility *= ar_mul;
            string name = gflelementinfo.IndexToName(index);

            return new GFLElements(index, possibility, starnum, name, "AR");
        }

        private GFLElements CreateTdollInfo_Rf(int index, double possibility, int starnum)
        {
            possibility *= rf_mul;
            string name = gflelementinfo.IndexToName(index);

            return new GFLElements(index, possibility, starnum, name, "RF");
        }

        private GFLElements CreateTdollInfo_Sg(int index, double possibility, int starnum)
        {
            possibility *= sg_mul;
            string name = gflelementinfo.IndexToName(index);

            return new GFLElements(index, possibility, starnum, name, "SG");
        }

        private GFLElements CreateTdollInfo_Mg(int index, double possibility, int starnum)
        {
            possibility *= mg_mul;
            string name = gflelementinfo.IndexToName(index);

            return new GFLElements(index, possibility, starnum, name, "MG");
        }

        private GFLElements CreateTdollInfo_Smg(int index, double possibility, int starnum)
        {
            possibility *= smg_mul;
            string name = gflelementinfo.IndexToName(index);

            return new GFLElements(index, possibility, starnum, name, "SMG");
        }
    }
}
