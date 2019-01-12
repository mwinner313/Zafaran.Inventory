namespace Zafaran.WareHouse.Core.Dtos
{
    public class Response
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }

        public static Response Success()
        {
          return new Response(){Succeed = true};
        }

        public static Response Failed(string message)
        {
            return new Response
            {
                Message = message,
                Succeed = false
            };
        }
    }
}