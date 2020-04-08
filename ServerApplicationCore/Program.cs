using System;

namespace ServerApplicationCore
{
    class Program
    {
        private EasyModbusCore.ModbusServer modbusServer;

        static void Main(string[] args)
        {
            Program application = new Program();
            application.startServer();
        }

        public void startServer()
        {
            modbusServer = new EasyModbusCore.ModbusServer();
            modbusServer.Listen();
            modbusServer.NumberOfConnectedClientsChanged += ModbusServer_NumberOfConnectedClientsChanged;
            modbusServer.HoldingRegistersChanged += new EasyModbusCore.ModbusServer.HoldingRegistersChangedHandler(holdingRegistersChanged);
            Console.WriteLine("[Modbus Server][INFO] - press any key to exit application");
            Console.WriteLine("[Modbus Server][INFO] - started");

            Console.ReadKey();
            Console.WriteLine("[Modbus Server][INFO] - terminated");
            modbusServer.StopListening();
        }

        private void ModbusServer_NumberOfConnectedClientsChanged()
        {
            Console.WriteLine($"Connected clients: \t {modbusServer.NumberOfConnections}");
        }

        public void holdingRegistersChanged(int startingAddress, int quantity)
        {
            Console.WriteLine($"Adress: \t {startingAddress} \t Value: \t {quantity}");
        }
    }
}
