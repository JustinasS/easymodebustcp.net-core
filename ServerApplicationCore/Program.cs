using System;

namespace ServerApplicationCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Program application = new Program();
            application.startServer();
        }

        public void startServer()
        {
            EasyModbusCore.ModbusServer modbusServer = new EasyModbusCore.ModbusServer();
            modbusServer.Listen();
            modbusServer.HoldingRegistersChanged += new EasyModbusCore.ModbusServer.HoldingRegistersChangedHandler(holdingRegistersChanged);
            Console.ReadKey();

            modbusServer.StopListening();
        }

        public void holdingRegistersChanged(int startingAddress, int quantity)
        {
            Console.WriteLine(startingAddress);
            Console.WriteLine(quantity);
        }
    }
}
