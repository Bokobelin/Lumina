using Lumina.Networking;

//Vector3 packet example
static byte[] GeneratePacket()
{

	PacketBuilder builder = new();
	builder.AddFloat(100.0f);  // X position
	builder.AddFloat(200.0f);  // Y position
	builder.AddFloat(300.0f);  // Z position

	GamePacket positionPacket = new(packetType: 1, payload: builder.GetPayload());
	byte[] dataToSend = positionPacket.ToBytes();
	return dataToSend;
}

static void ReceivePacket(byte[] dataReceived)
{
	GamePacket receivedPacket = GamePacket.FromBytes(dataReceived);
	if (receivedPacket.PacketType == 1)  // Position packet
	{
		float x = BitConverter.ToSingle(receivedPacket.Payload, 0);
		float y = BitConverter.ToSingle(receivedPacket.Payload, 4);
		float z = BitConverter.ToSingle(receivedPacket.Payload, 8);
		Console.WriteLine($"Received Position: X={x}, Y={y}, Z={z}");
	}
}

//Example usage
byte[] packet = GeneratePacket();
ReceivePacket(packet);
