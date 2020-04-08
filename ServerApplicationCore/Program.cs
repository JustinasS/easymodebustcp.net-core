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
            Console.WriteLine("[Modbus Server][INFO] - press any key to exit application");
            Console.WriteLine("[Modbus Server][INFO] - started");

            Console.ReadKey();
            Console.WriteLine("[Modbus Server][INFO] - terminated");
            modbusServer.StopListening();
        }

        public void holdingRegistersChanged(int startingAddress, int quantity)
        {
            Console.WriteLine($"Adress: \t {startingAddress} \t Value: \t {quantity}");
        }
    }
}
