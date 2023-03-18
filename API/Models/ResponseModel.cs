namespace API.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel(T result)
        {
            Result = result;
        }

        public T Result { get;}
    }
}
