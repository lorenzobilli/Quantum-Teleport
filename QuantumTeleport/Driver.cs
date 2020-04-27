using Microsoft.Quantum.Simulation.Simulators;
using System.Linq;

namespace Quantum.QuantumTeleport
{
	class Driver
	{
		static void Main(string[] args)
		{
			using (var sim = new QuantumSimulator())
			{
				var rand = new System.Random();

				foreach (var execution in Enumerable.Range(0, 32))
				{
					var sent = rand.Next(2) == 0;
					var received = TeleportMessage.Run(sim, sent).Result;

					System.Console.Write($"Esecuzione numero {execution + 1}: INVIATO: {sent}, RICEVUTO: {received}");
					System.Console.Write(sent == received ? " -> Teletrasporto avvenuto con successo!\n" : "\n");
				}
			}
		}
	}
}