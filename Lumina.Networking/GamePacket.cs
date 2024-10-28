namespace Lumina.Networking;

public class GamePacket
{
	public byte PacketType { get; set; }
	public byte[] Payload { get; set; }

	public GamePacket(byte packetType, byte[] payload)
	{
		PacketType = packetType;
		Payload = payload;
	}

	public byte[] ToBytes()
	{
		byte[] lengthBytes = BitConverter.GetBytes(Payload.Length);
		byte[] packetBytes = new byte[1 + lengthBytes.Length + Payload.Length];

		packetBytes[0] = PacketType;
		Buffer.BlockCopy(lengthBytes, 0, packetBytes, 1, lengthBytes.Length);
		Buffer.BlockCopy(Payload, 0, packetBytes, 1 + lengthBytes.Length, Payload.Length);

		return packetBytes;
	}

	public static GamePacket FromBytes(byte[] data)
	{
		byte packetType = data[0];
		int payloadLength = BitConverter.ToInt32(data, 1);
		byte[] payload = new byte[payloadLength];
		Buffer.BlockCopy(data, 5, payload, 0, payloadLength);

		return new GamePacket(packetType, payload);
	}
}