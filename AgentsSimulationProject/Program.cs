using System;

namespace AgentsSimulationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartRobot smartRobot = new SmartRobot();
            GreedyRobot greedyRobot = new GreedyRobot();
            var SimulationSystemG = new SimulationSystem(5, 5, 3, 10, 10, 30, greedyRobot);
            var SimulationSystemS = new SimulationSystem(5, 5, 3, 10, 10, 30, smartRobot);
            Console.WriteLine("                         Escenario 1");
            var resultGreedy = SimulationSystemG.SimulateTimes(30);
            var resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            SimulationSystemG = new SimulationSystem(7, 7, 4, 12, 12, 30, greedyRobot);
            SimulationSystemS = new SimulationSystem(7, 7, 4, 12, 12, 30, smartRobot);
            Console.WriteLine("                         Escenario 2");
            resultGreedy = SimulationSystemG.SimulateTimes(30);
            resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            Console.WriteLine("\n                         Escenario 3");
            SimulationSystemG = new SimulationSystem(10, 10, 6, 20, 15, 30, greedyRobot);
            SimulationSystemS = new SimulationSystem(10, 10, 6, 20, 15, 30, smartRobot);
            resultGreedy = SimulationSystemG.SimulateTimes(30);
            resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            Console.WriteLine("\n                         Escenario 4");
            SimulationSystemG = new SimulationSystem(13, 13, 7, 20, 10, 30, greedyRobot);
            SimulationSystemS = new SimulationSystem(13, 13, 7, 20, 10, 30, smartRobot);
            resultGreedy = SimulationSystemG.SimulateTimes(30);
            resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            Console.WriteLine("\n                         Escenario 5");
            SimulationSystemG = new SimulationSystem(16, 16, 9, 15, 30, 30, greedyRobot);
            SimulationSystemS = new SimulationSystem(16, 16, 9, 15, 30, 30, smartRobot);
            resultGreedy = SimulationSystemG.SimulateTimes(30);
            resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            Console.WriteLine("\n                         Escenario 6");
            SimulationSystemG = new SimulationSystem(20, 20, 10, 20, 40, 30, greedyRobot);
            SimulationSystemS = new SimulationSystem(20, 20, 10, 20, 40, 30, smartRobot);
            resultGreedy = SimulationSystemG.SimulateTimes(30);
            resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            Console.WriteLine("\n                         Escenario 7");
            SimulationSystemG = new SimulationSystem(25, 25, 23, 10, 10, 30, greedyRobot);
            SimulationSystemS = new SimulationSystem(25, 25, 23, 10, 10, 30, smartRobot);
            resultGreedy = SimulationSystemG.SimulateTimes(30);
            resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            Console.WriteLine("\n                         Escenario 8");
            SimulationSystemG = new SimulationSystem(25, 25, 10, 10, 10, 30, greedyRobot);
            SimulationSystemS = new SimulationSystem(25, 25, 10, 10, 10, 30, smartRobot);
            resultGreedy = SimulationSystemG.SimulateTimes(30);
            resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            Console.WriteLine("\n                         Escenario 9");
            SimulationSystemG = new SimulationSystem(25, 25, 23, 20, 10, 30, greedyRobot);
            SimulationSystemS = new SimulationSystem(25, 25, 23, 20, 10, 30, smartRobot);
            resultGreedy = SimulationSystemG.SimulateTimes(30);
            resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            Console.WriteLine("\n                         Escenario 10");
            SimulationSystemG = new SimulationSystem(25, 25, 13, 30, 10, 30, greedyRobot);
            SimulationSystemS = new SimulationSystem(25, 25, 13, 30, 10, 30, smartRobot);
            resultGreedy = SimulationSystemG.SimulateTimes(30);
            resultSmart = SimulationSystemS.SimulateTimes(30);
            Console.WriteLine("Resultados:                 Robot Greedy                 SmartBot\n Veces Ganadas:                  {0}                         {3}\n Veces Despedido:                 {1}                          {4}\n % de Basura:                 {2}                {5}", resultGreedy.Item1, resultGreedy.Item2, resultGreedy.Item3, resultSmart.Item1, resultSmart.Item2, resultSmart.Item3);

            Console.ReadLine();

        }
    }
}
