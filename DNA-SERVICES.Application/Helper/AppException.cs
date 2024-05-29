using System;
using System.Runtime.Serialization;

namespace DNA_SERVICES.Application.Helper
{
	[Serializable]
	public class AppException : Exception
	{
		List<string> Messages { get; }
		public AppException()
		{
			Messages = new List<string>();
		}
		protected AppException(List<string> messages) : base(string.Join(",", messages))
		{
			Messages = messages;
		}
		protected AppException(string message) : base(message)
		{
			Messages = new List<string>() { message };
		}
		protected AppException(string message, Exception innerException): base(message, innerException)
		{
			Messages = new List<string>() { message };
		}
		protected AppException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
		{

		}
	}
}

