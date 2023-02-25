using Quartz.Spi;

namespace IOL.GreatOffice.Api.Utilities;

public class QuartzJsonSerializer : IObjectSerializer
{
	public void Initialize() { }

	public byte[] Serialize<T>(T obj) where T : class {
		return JsonSerializer.SerializeToUtf8Bytes(obj);
	}

	public T DeSerialize<T>(byte[] data) where T : class {
		return JsonSerializer.Deserialize<T>(data);
	}
}
