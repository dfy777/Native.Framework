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
        #endregion

        //属性
        #region
        public GFLElementsInfo GflElementinfo
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
            if (ErrorDetection(produce_type))
            {
                throw new ArgumentException("非法资源数目");
            }
            

            
            for(int i = 0; i < produce_num; i++)
            {
                int star_num;
                ArrayList str_info;

                switch(produce_type)
                {
                    case 1:
                        star_num = GetStar_Tdoll(1);
                        str_info = Make_Tdoll(star_num);
                        break;
                    case 2:
                        star_num = GetStar_Tdoll_Heavy(2);
                        str_info = Make_Tdoll_Heavy(star_num);
                        break;
                    case 3:
                        star_num = GetStar_Equip(3);
                        str_info = Make_Equip(star_num);
                        break;
                    case 4:
                        star_num = GetStar_Equip_Heavy(4);
                        str_info = Make_Equip_Heavy(star_num);
                        break;
                    default:
                        throw new ArgumentException("produce_type error");
                }
            }
        }

        /// <summary>
        /// 计算资源的总和
        /// </summary>
        /// <returns></returns>
        public int _sum()
        {
            return Manpower + Ammo + Ration + Parts;
        }

        public void SetResources(int mw, int aw, int rw, int pw)
        {
            Manpower = mw;
            Ammo = aw;
            Ration = rw;
            Parts = pw;
        }

        public int GetStar_Tdoll(int produce_type)
        {
            Random random = new Random();
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

        public int GetStar_Tdoll_Heavy(int produce_type)
        {
            return 0;
        }

        public int GetStar_Equip(int produce_type)
        {
            return 0;
        }

        public int GetStar_Equip_Heavy(int produce_type)
        {
            return 0;
        }

        /// <summary>
        /// 根据资源数和星级返回人形信息
        /// HG——total <= 920
        /// </summary>
        /// <param name="star_num">星级数</param>
        /// <returns>人形信息</returns>
        public ArrayList Make_Tdoll(int star_num)
        {
            if (_sum() <= 920)
            {
                
            }

            return new ArrayList();
        }

        public ArrayList Make_Tdoll_Heavy(int star_num)
        {
            return new ArrayList();
        }

        public ArrayList Make_Equip(int star_num)
        {
            return new ArrayList();
        }

        public ArrayList Make_Equip_Heavy(int star_num)
        {
            return new ArrayList();
        }

        /// <summary>
        /// 资源数目是否符合要求
        /// </summary>
        /// <param name="produce_type">4种建造类型</param>
        /// <returns>符合要求返回false</returns>
        public bool ErrorDetection(int produce_type)
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
        /// set hg_mul depend on sum of resources
        /// [820, 920)---0.37
        /// [420, 820)---1
        /// [220, 420)---0.7
        /// [0, 220)---0.37
        /// </summary>
        public void SetHg_Mul()
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
        public void SetSmg_Mul()
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
        public void SetAr_Mul()
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
        public void SetRf_Mul()
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
        public void SetMG_Mul()
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
        public void SetSg_Mul_Heavy()
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
        public void SetSmg_Mul_Heavy()
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
        public void SetAr_Mul_Heavy()
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
        public void SetRf_Mul_Heavy()
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
        public void SetMg_Mul_Heavy()
        {
            mg_mul = 3;
            int sum = _sum();

            if (sum >= 22000) { mg_mul *= 0.4; }
            else if (sum >= 20000 && sum < 22000) { mg_mul *= 0.6; }
            else if (sum >= 18000 && sum < 20000) { mg_mul *= 0.8; }
            else if (sum >= 17000 && sum < 18000) { mg_mul *= 1; }
            else { mg_mul *= 0.8; }
        }
    }
}
