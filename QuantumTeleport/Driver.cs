/*
 *	Quantum Teleport
 *	
 *  The MIT License (MIT)
 *
 *  Copyright (c) 2020 Lorenzo Billi
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
 *  documentation files (the "Software"), to deal in the Software without restriction, including without limitation the
 *  right to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
 *  permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all copies or substantial portions of
 *  the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 *  WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS
 *  OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 *  OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. *	
 */

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