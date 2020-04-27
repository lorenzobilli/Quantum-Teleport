namespace Quantum.QuantumTeleport {

	open Microsoft.Quantum.Canon;
	open Microsoft.Quantum.Intrinsic;
	open Microsoft.Quantum.Measurement;

	operation Teleport(message : Qubit, target : Qubit) : Unit
	{
		using (register = Qubit())
		{
			// Creo l'entanglement necessario per teletrasportare il messaggio
			H(register);
			CNOT(register, target);

			// Codifico il messaggio nell'entanglement appena creato...
			CNOT(message, register);
			H(message);

			// ...e misuro i qubit per estrapolare i dati
			let data1 = M(message);
			let data2 = M(register);

			// Decodifico il messaggio applicando le correzioni sui qubit di destinazione
			if (MResetZ(message) == One)
			{
				Z(target);
			}
			if (IsResultOne(MResetZ(register)))
			{
				X(target);
			}
		}
	}

	operation TeleportMessage(message : Bool) : Bool
	{
		using ((msg, target) = (Qubit(), Qubit()))
		{
			// Codifico il messaggio che voglio inviare...
			if (message)
			{
				X(msg);
			}

			// ...ed utilizzo la funzione Teleport() per inviarlo
			Teleport(msg, target);

			// Infine restituisco il risultato
			return MResetZ(target) == One;
		}
	}
}
