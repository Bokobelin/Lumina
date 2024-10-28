using System.Text;

namespace Lumina.Networking;

public class PacketBuilder
{
	private MemoryStream stream = new();

	public void AddFloat(float value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		stream.Write(bytes, 0, bytes.Length);
	}

	public void AddString(string value)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(value);
		AddInt(bytes.Length);
		stream.Write(bytes, 0, bytes.Length);
	}

	public void AddInt(int value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		stream.Write(bytes, 0, bytes.Length);
	}

	public byte[] GetPayload()
	{
		return stream.ToArray();
	}
}
