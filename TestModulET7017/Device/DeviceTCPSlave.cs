using System;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using NModbus;
using NModbus.Utility;


namespace TestModulET7017
{
    using System.Linq;
    using System.Runtime.CompilerServices;
    using NModbus.Logging;

    class DeviceTCPSlave
    {

        TcpClient tcpClient;

        IModbusMaster master;
        string _ipAddress = "10.0.0.69"; // ip aдресс
        int tcpPort = 502;

        DateTime dtDisconnect = new DateTime(); // Время разрыва связи
        DateTime dtNow = new DateTime();        // Новый отсчет времени для подключения
        bool NetworkIsOk = false;               // флаг на определение подключения
        Timer timer1 = null;

        byte _slave = 0;
        ushort _startAddress = 0;
        ushort _numOfPoints = 0;

        ushort _registerAddressSr = 0;
        ushort _valueSr = 0;

        ushort[] readInputRegisters; // чтение регистров
        bool[] reedDiscreteInputs; // чтение дискретных значений

        byte _whatReed = 100; // передаваемое значение для чтение регистров


        string messageConnect = "Состояние подключения к приборам";

        sbyte isconnect = -10;

        #region Свойства для общения с внешним миром

        /// <summary>
        /// tcpPort - 502 /TCP,UDP	используется в Modbus
        /// </summary>
        public int TCP_Port
        {
            set
            {
                tcpPort = value;
            }
        }

        /// <summary>
        /// Сообщение о состоянии подключения
        /// </summary>
       public string MessageConnect
        {
            get
            {
                return messageConnect;
            }
        }

        /// <summary>
        /// Свойство определяющеее есть липодключение
        /// </summary>
        public sbyte IsConnect
        {
            get
            {
                return isconnect;
            }
            private set
            {
                isconnect = value;
            }
        }
        #endregion


        /// <summary>
        /// Метод вызова для подключения к сети по TCP
        /// </summary>
        /// <param name="WhatReeder"> 0 - Coils (0xxxx); 1 - Discrete Inputs (1xxxx); 3 -  Input Register (3xxxx); 4 - Holding Register (4xxxx)</param>
        /// <param name="Slave"> Адресс устройства в TCP MODBUS</param>
        /// <param name="IpAddress"> ip адресс устройства</param>
        /// <param name="NumOfPoints"> количество читаемых параметров </param>
        public void Start_Connect(string IpAddress, byte Slave, ushort StartAddress, ushort NumOfPoints, byte WhatReeder)
        {
            _ipAddress = IpAddress;          // ipAddress устройства для подключения

            _startAddress = StartAddress;   // Стартовый регистр с которого надо начинанать читать значение
            _numOfPoints = NumOfPoints;     // Количество регистров читаемых со стартового
            _slave = Slave;                 // Адресс устройства
            _whatReed = WhatReeder;

            NetworkIsOk = Connect();

            TimerCallback tm = new TimerCallback(timer1_Tick);
            timer1 = new Timer(tm, 0, 0, 1000);
            
        }

        /// <summary>
        /// Метод для чтения значений регистров в модуле
        /// </summary>
        /// <param name="StartAddress">"Стартовый регистр с которого надо начинанать читать значение"</param>
        /// <param name="NumOfPoints">Количество регистров читаемых со стартового</param>
        /// <returns></returns>
        public ushort[] ReadInputRegister
        {
            get
            {
                return readInputRegisters;
            }
            private set
            {
                readInputRegisters = value;
            }
            
        }

        public bool[] ReedDiscreteInputs
        {
            get
            {
                return reedDiscreteInputs;
            }
            set
            {
                if(value != null)
                    reedDiscreteInputs = value;
                else
                {
                    reedDiscreteInputs = null;
                }
            }
        }
        /// <summary>
        /// Запись значения регистра удержания
        /// </summary>
        /// <param name="RegisterAddress"> Адрес регистра для записи значения Value.</param>
        /// <param name="Value">VЗначение для записи</param>
        public void WriteSingleRegister(ushort RegisterAddress, ushort Value)
        {
            _registerAddressSr = RegisterAddress;
            _valueSr = Value;
        }




        private void timer1_Tick(object state)
        {
            //Включение таймера timer1, опрос с периодичностью в 1000 мс
            try
            {
                if (NetworkIsOk)
                {
                    switch (_whatReed)
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                //Чтениие дискретных выходов
                                ReedDiscreteInputs = master.ReadInputs(_slave, _startAddress, _numOfPoints); // Discrete Inputs (1xxxx)
                                break;
                            }
                        case 3:
                            {
                                // чтение входов и выходов
                                ReadInputRegister = master.ReadInputRegisters(_slave, _startAddress, _numOfPoints); // Input Register (3xxxx)
                                break;
                            }
                        default:
                            break;
                    }
                    

                    

                    // Запись значения регистра в модуль
                   // master.WriteSingleRegister(_registerAddressSr, _valueSr); // Holding Register (4xxxx)

                    IsConnect = 0;
                }

                else
                {
                    // повторное подключение
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        messageConnect = String.Format(DateTime.Now.ToString() + ": Start connectings...");
                        NetworkIsOk = Connect();
                        if (!NetworkIsOk)
                        {
                            messageConnect = String.Format(DateTime.Now.ToString() + ": Сбой подключения. Дождитесь повторной попытки");
                            dtDisconnect = DateTime.Now;
                            IsConnect = -1;
                        }
                    }
                    else
                    {
                        messageConnect = String.Format(DateTime.Now.ToString() + ": Дождитесь повторной попытки подключения");
                        IsConnect = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("System"))
                {
                    //установите NetworkIsOk в false и повторите попытку подключения
                    NetworkIsOk = false;
                    messageConnect = ex.Message;
                    dtDisconnect = DateTime.Now;
                    IsConnect = -2;
                }
            }
        }

        /// <summary>
        /// Метод соединения
        /// </summary>
        /// <returns> true - есть подключение; false - подключение отсутсвуете </returns>
        private bool Connect()
        {
            if (master != null)
                master.Dispose();
            if (tcpClient != null)
                tcpClient.Close();
            try
            {
                tcpClient = new TcpClient();
                IAsyncResult asyncResult = tcpClient.BeginConnect(_ipAddress, tcpPort, null, null);
                asyncResult.AsyncWaitHandle.WaitOne(3000, true); // ожидание 3 секунды
                if (!asyncResult.IsCompleted)
                {
                    tcpClient.Close();
                    messageConnect = String.Format(DateTime.Now.ToString() + ": Не удается подключиться к приборам");
                    return false;
                }
                // создание мастера Modbus TCP с помощью tcpclient
                //  master = IModbusIpMaster.CreateIp(tcpClient);
                var factory = new ModbusFactory();
                master = factory.CreateMaster(tcpClient);
                master.Transport.Retries = 0; // не нужно делать повторные попытки
                master.Transport.ReadTimeout = 1500;
                messageConnect = String.Format(DateTime.Now.ToString() + ": Подключение к приборам...");
                return true;


            }
            catch (Exception ex)
            {
                messageConnect = String.Format(DateTime.Now.ToString() + ": Идет подключение..." + ex.StackTrace + "==>" + ex.Message);
                return false;
                
            }
        }

        #region Чтение и запись регистров
        

        #endregion
    }
}
