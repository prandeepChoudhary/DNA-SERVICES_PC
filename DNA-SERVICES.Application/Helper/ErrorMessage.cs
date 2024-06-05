using System;
namespace DNA_SERVICES.Application.Helper
{
	public class ErrorMessage
	{
		public string? Code { get; set; }
		public List<string> Messages { get; set; }
		public ErrorMessage? InnerError { get; set; }

		public ErrorMessage()
		{
			Messages = new List<string>();
		}
        public ErrorMessage(string code, string message )
        {
            this.Code = code;
            this.Messages = new List<string> { message };
        }
        public ErrorMessage(string code, List<string> messages)
        {
            this.Code = code;
            this.Messages = messages;
        }

    }
}

