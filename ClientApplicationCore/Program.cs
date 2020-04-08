using System;

namespace ClientApplicationCore
{
    class Program
    {
        static void Main(string[] args)
        {

            EasyModbusCore.ModbusClient modbusClient = new EasyModbusCore.ModbusClient("127.0.0.1", 502);
            modbusClient.Connect();
            while (true)
            {
                DateTime datetimeStart = DateTime.Now;
                for (int i = 25000; i < 26000; i++)
                {
                    modbusClient.WriteSingleRegister(i, i);
                }
                DateTime datetimeEnd = DateTime.Now;

                Console.WriteLine("Time elapsed: " + (datetimeEnd - datetimeStart));
            }
        }
    }
}
