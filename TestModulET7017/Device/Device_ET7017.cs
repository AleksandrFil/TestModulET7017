using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NModbus.Device;
using NModbus.IO;
using System.Xml.Linq;
using System.Windows.Forms;

namespace TestModulET7017
{
    enum DOOtput : ushort
    {
        DO01 = 0,
        DO02 = 1,
        DO03 = 2,
        DO04 = 3
    }

    enum RegistrRange : ushort
    {
        Chanel_1 = 427,
        Chanel_2 = 428,
        Chanel_3,
        Chanel_4,
        Chanel_5,
        Chanel_6,
        Chanel_7,
        Chanel_8
    }

    enum Range_TableCod : ushort
    {
        mA4_20 = 7,
        V10_10 = 8,
        V5_5 = 9,
        V1_1 = 10,
        mV500_500 = 11,
        mV150_150 = 12,
        mA20_20 = 13,
        mA0_20 = 26
    }

    enum AIInput : ushort
    {
        Chanel_1 = 0,
        Chanel_2 = 1,
        Chanel_3,
        Chanel_4,
        Chanel_5,
        Chanel_6,
        Chanel_7,
        Chanel_8
    }



    class Device_ET7017
    {
        static string _ipAddress = "192.168.12.3";     // ip aдресс
        static byte _slave = 3;                         // Адресс устройства

        static ushort _startAddress = 0;                // Стартовый регистр с которого надо начинанать читать значение
        static ushort _numOfPoints = 10;                // Количество регистров читаемых со стартового

        ushort _registerAddress = 0;    // регистр для записи
        ushort _value = 0;              // значение для записи

        static ushort potentialP1 = 55000;      // напряжение на ПОСТ1
        static ushort potentialP2 = 55000;      // напряжение на ПОСТ2
        static ushort tokP1 = 55000;            // ток на ПОСТ1
        static ushort tokP2 = 55000;            // ток на ПОСТ2

        static double _koefTokP1 = 1;           // коеффициент для амперметра на посту 1
        static double _koefTokP2 = 1;           // коеффициент для амперметра на посту 2
        static double _koefPotP1 = 1;           // коеффициент для вольтметра на посту 1
        static double _koefPotP2 = 1;           // коеффициент для вольтметра на посту 2 

        static ushort constantFormat = 65535;   // Значение для диапозона в инженерном формате


        private Timer timer = null;

        DeviceTCPSlave con = new DeviceTCPSlave();


        #region Чтение параметров модуля из XML
        public Device_ET7017()
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XML_Modul.xml");
            XDocument xdoc = XDocument.Load("Device\\XML_Modul.xml");
            foreach (XElement ETmodulElement in xdoc.Element("ModulTCP").Elements("ET7017"))
            {
                XElement ipAddressElement = ETmodulElement.Element("ipAddress");
                XElement startAddressElement = ETmodulElement.Element("startAddress");
                XElement numOfPointsElement = ETmodulElement.Element("numOfPoints");
                XElement slaveElement = ETmodulElement.Element("slave");

                XElement koefTokP1 = ETmodulElement.Element("koefTokP1");
                XElement koefTokP2 = ETmodulElement.Element("koefTokP2");
                XElement koefPotP1 = ETmodulElement.Element("koefPotP1");
                XElement koefPotP2 = ETmodulElement.Element("koefPotP2");

                if (ipAddressElement != null && startAddressElement != null && numOfPointsElement != null && slaveElement != null && koefTokP1 != null && koefTokP2 != null && koefPotP1 != null && koefPotP2 != null)
                {
                    _ipAddress = ipAddressElement.Value;
                    _startAddress = Convert.ToUInt16(startAddressElement.Value);
                    _numOfPoints = Convert.ToUInt16(numOfPointsElement.Value);
                    _slave = Convert.ToByte(slaveElement.Value);

                    _koefTokP1 = Convert.ToDouble(koefTokP1.Value);
                    _koefTokP2 = Convert.ToDouble(koefTokP2.Value);
                    _koefPotP1 = Convert.ToDouble(koefPotP1.Value);
                    _koefPotP2 = Convert.ToDouble(koefPotP2.Value);

                }
            }
            this.timer = new Timer();
            this.timer.Interval = 500;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Enabled = true;
        }


        #endregion

        #region Working with the module

        /// <summary>
        /// Метод подключения к сети
        /// </summary>
        /// <returns>0- все ок, -1 - нет подключние, -2 - ошибка при подключении </returns>
        public int Connecting()
        {
            con.Start_Connect(_ipAddress, _slave);   //Подключение к сети

            return con.IsConnect;
        }

        /// <summary>
        /// Свойства для чтения сообщения о состоянии модуля
        /// </summary>
        public string MessageConnect
        {
            get { return con.MessageConnect; }
        }

        #endregion

        #region Methodы Set measuring range
        /// <summary>
        /// Метод для включения диапозона на 500 мВ
        /// </summary>
        /// <returns></returns>
        public bool VklHighRange()
        {
            if (con.WriteSingleCoil(_slave, (ushort)DOOtput.DO01, true) &&
                con.WriteSingleRegister(_slave, (ushort)RegistrRange.Chanel_1, (ushort)Range_TableCod.mV500_500))
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Метод для включения диапозона на 150 мВ
        /// </summary>
        /// <returns></returns>
        public bool VklLowhRange()
        {
            if (con.WriteSingleCoil(_slave, (ushort)DOOtput.DO01, false) && con.WriteSingleRegister(_slave, (ushort)RegistrRange.Chanel_1, (ushort)Range_TableCod.mV150_150))
            {
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Read Discret otput

        public bool DO01
        {
            get
            {
                if (listDO != null)
                    return listDO[0];
                else
                    throw new MyExaption("Нет соединения с модулем");
            }
        }
        public bool DO02
        {
            get
            {
                if (listDO != null)
                    return listDO[1];
                else
                    throw new MyExaption("Нет соединения с модулем");
            }
        }
        public bool DO03
        {
            get
            {
                if (listDO != null)
                    return listDO[2];
                else
                    throw new MyExaption("Нет соединения с модулем");
            }
        }
        public bool DO04
        {
            get
            {
                if (listDO != null)
                    return listDO[3];
                else
                    throw new MyExaption("Нет соединения с модулем");
            }
        }
        #endregion

        #region Read Analog input
        public double AI1
        {
            get
            {
                if (listAI != null)
                {
                    // 
                    return Convert.ToDouble((double)listAI[0] * (double)RangeAI1[1] / (double)constantFormat);
                }
                else
                    throw new MyExaption("Нет соединения с модулем");
            }
        }

        #endregion

        #region Read Range AI
        /// <summary>
        /// Метод для создания списка диапазона
        /// </summary>
        /// <param name="range"></param>
        /// <returns> 3 цифра: 0 - мА, 1 - мВ, 2 - В </returns>
        private List<int> RangeValue_table(ushort range)
        {
            switch (range)
            {
                case (ushort)Range_TableCod.mA0_20:
                    return new List<int> { 0, 20, 0 };
                // break;
                case (ushort)Range_TableCod.mA20_20:
                    return new List<int> { -20, 20, 0 };
                case (ushort)Range_TableCod.mA4_20:
                    return new List<int> { 4, 20, 0 };
                case (ushort)Range_TableCod.mV150_150:
                    return new List<int> { -150, 150, 1 };
                case (ushort)Range_TableCod.mV500_500:
                    return new List<int> { -500, 500, 1 };
                case (ushort)Range_TableCod.V10_10:
                    return new List<int> { -10, 10, 2 };
                case (ushort)Range_TableCod.V1_1:
                    return new List<int> { -1, 1, 2 };
                case (ushort)Range_TableCod.V5_5:
                    return new List<int> { -5, 5, 2 };
                default:
                    throw new MyExaption("За пределами возможных диапазонов");
            }
        }


        public List<int> RangeAI1 
        {
            get
            {
                if (listRangeAI != null)
                {
                    return RangeValue_table(listRangeAI[0]);
                }
                else
                {
                    throw new MyExaption("Нет соединения с модулем");
                }
                
            }
        }

        #endregion



        private bool [] listDO { get; set; }
        private ushort [] listAI { get; set; }
        private ushort [] listRangeAI { get; set; }
        /// <summary>
        /// Опрос значений прочитанных из модуля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (con.IsConnect >= 0)
            {
                listDO = con.ReadCoils(_slave, (ushort)DOOtput.DO01, (ushort)Enum.GetNames(typeof(DOOtput)).Length);
                listAI = con.ReadInputRegisters(_slave, (ushort)AIInput.Chanel_1, (ushort)Enum.GetNames(typeof(AIInput)).Length);
                listRangeAI = con.ReadHoldingRegistr(_slave, (ushort)RegistrRange.Chanel_1, (ushort)Enum.GetNames(typeof(RegistrRange)).Length);
            }
        }
    }
}
