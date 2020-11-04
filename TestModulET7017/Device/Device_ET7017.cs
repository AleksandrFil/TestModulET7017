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
    class Device_ET7017
    {
        static string _ipAddress = "192.168.12.3";     // ip aдресс
        static byte _slave = 3;                         // Адресс устройства

        static ushort _startAddress = 0;                // Стартовый регистр с которого надо начинанать читать значение
        static ushort _numOfPoints = 10;                // Количество регистров читаемых со стартового

        ushort _registerAddress = 0;    // регистр для записи
        ushort _value = 0;              // значение дляч записи

        static ushort potentialP1 = 55000;      // напряжение на ПОСТ1
        static ushort potentialP2 = 55000;      // напряжение на ПОСТ2
        static ushort tokP1 = 55000;            // ток на ПОСТ1
        static ushort tokP2 = 55000;            // ток на ПОСТ2

        static double _koefTokP1 = 1;           // коеффициент для амперметра на посту 1
        static double _koefTokP2 = 1;           // коеффициент для амперметра на посту 2
        static double _koefPotP1 = 1;           // коеффициент для вольтметра на посту 1
        static double _koefPotP2 = 1;           // коеффициент для вольтметра на посту 2 

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
            this.timer.Interval = 1500;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Enabled = true;
        }


        #endregion

        #region Чтение значений из модуля

        /// <summary>
        /// Опрос значений прочитанных из модуля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (con.IsConnect >= 0)
            {
               try
               {
                   //ushort[] readReg = Input_Register(_numOfPoints);
                   ushort[] readReg = con.ReadInputRegister;
                   if (readReg != null)
                   {
                       PotentialP1 = readReg[0];
                       PotentialP2 = readReg[1];
                       TokP1 = readReg[2];
                       TokP2 = readReg[3];
                   }
                   else
                   {
                       PotentialP1 = 65535;
                       PotentialP2 = 65535;
                       TokP1 = 65535;
                       TokP2 = 65535;
                   }
               
               }
               catch (Exception ex)
               {
                   throw new MyExaption("нет соединения с аналоговым модулем", ex);
               }
            }



        }
        public string MessageConnect
        {
            get { return con.MessageConnect; }
        }

        /// <summary>
        /// Значение напряжения ПОСТ1
        /// </summary>
        static public ushort PotentialP1
        {
            get
            {
                if (potentialP1 != 65535 && potentialP2 != 55000)
                {
                    return Convert.ToUInt16(potentialP1 * _koefPotP1);
                }
                else
                {
                    return potentialP1;
                }
                
            }
            private set
            {
                potentialP1 = value;
            }
        }


        /// <summary>
        /// Значение напряжения ПОСТ2
        /// </summary>
        static public ushort PotentialP2
        {
            get
            {
                if (potentialP2 != 65535 && potentialP2 != 55000)
                {
                    return Convert.ToUInt16(potentialP2 * _koefPotP2);
                }
                else
                {
                    return potentialP2 ;
                }
                
            }
            private set
            {
                potentialP2 = value;
            }
        }

        /// <summary>
        /// Значение тока ПОСТ1
        /// </summary>
        static public ushort TokP1
        {
            get
            {
                if (tokP1 != 65535 && tokP1 != 55000)
                {
                    return Convert.ToUInt16(tokP1 * _koefTokP1);
                }
                return tokP1;
            }
            private set
            {
                tokP1 = value;
            }
        }

        /// <summary>
        /// Значение тока ПОСТ2
        /// </summary>
        static public ushort TokP2
        {
            get
            {
                if (tokP2 != 65535 && tokP2 != 55000)
                {
                    return Convert.ToUInt16(tokP2 * _koefTokP2);
                }
                return tokP2;
            }
            private set
            {
                tokP2 = value;
            }
        }

        #endregion



        /// <summary>
        /// Метод подключения к сети
        /// </summary>
        /// <returns>0- все ок, -1 - нет подключние, -2 - ошибка при подключении </returns>
       public int Connecting()
        {
            con.Start_Connect(_ipAddress, _slave, _startAddress, _numOfPoints, 3);                      //Подключение к сети
          
                return con.IsConnect; 
        }

        /*
        /// <summary>
        /// Метод чтения регистров
        /// </summary>
        /// <param name="StartAddress"></param>
        /// <param name="NumOfPoints"></param>
        /// <returns></returns>
        static private ushort[] Input_Register(ushort numOfPoints)
        {
            return con.ReadInputRegister;
        }

        /// <summary>
        /// Метод чтения и записи регистров управления
        /// </summary>
        /// <param name="RegisterAddress"></param>
        /// <param name="Value"></param>
        public void Holding_Register(ushort RegisterAddress, ushort Value)
        {
            _registerAddress = RegisterAddress;
            _value = Value;

            con.WriteSingleRegister(_registerAddress, _value);
        }
        */
    }
}
