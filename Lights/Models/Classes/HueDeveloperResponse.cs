namespace PhilipsHueAPI.Models.Classes
{
    public class HueDeveloperResponse
    {
        private HueDeveloperResponseSuccess _success;
        public HueDeveloperResponseSuccess success { get { return _success; } set { _success = value; } }

        private HueDeveloperResponseError _error;
        public HueDeveloperResponseError error { get { return _error; } set { _error = value; } }

        public HueDeveloperResponse()
        {
            _success = new HueDeveloperResponseSuccess();
            _error = new HueDeveloperResponseError();
        }

        public HueDeveloperResponse(HueDeveloperResponseSuccess success, HueDeveloperResponseError error)
        {
            _success = success;
            _error = error;
        }

        public string GetErrorMessage()
        {
            if (error != null)
            {
                return error.description;
            }

            return "";
        }

        public bool HasSuccess()
        {
            if (!string.IsNullOrEmpty(success.username))
                return true;
            else
                return false;
        }
    }

    public class HueDeveloperResponseSuccess
    {
        private string _username;
        public string username { get { return _username; } set { _username = value; } }

        public HueDeveloperResponseSuccess()
        {
            _username = "";
        }

        public HueDeveloperResponseSuccess(string username)
        {
            _username = username;
        }
    }

    public class HueDeveloperResponseError
    {
        private string _type;
        public string type { get { return _type; } set { _type = value; } }

        private string _address;
        public string address { get { return _address; } set { _address = value; } }

        private string _description;
        public string description { get { return _description; } set { _description = value; } }

        public HueDeveloperResponseError()
        {
            _type = "";
            _address = "";
            _description = "";
        }

        public HueDeveloperResponseError(string type, string address, string description)
        {
            _type = type;
            _address = address;
            _description = description;
        }
    }
}
