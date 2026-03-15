namespace app_manager_device_domain.Models
{
    public class ResponseModel<T>
    {
        public string message { get; set; }
        public T data { get; set; }
        public bool status { get; set; } = false;

        public ResponseModel(T data, bool status)
        {
            this.data = data;
            this.status = status;
        }

        public ResponseModel(bool status, string message)
        {
            this.message = message;
            this.status = status;
        }

        public ResponseModel(bool status)
        {
            this.message = "";
            this.status = status;
        }
        public ResponseModel(T data)
        {
            this.data = data;
            if (this.data != null) this.status = true;
            else this.status = false;
        }

        public ResponseModel<T> AddMessage(string message)
        {
            this.message = message;
            return this;
        }

        public ResponseModel<T> SetStatus(bool status)
        {
            this.status = status;
            return this;
        }
    }
}
