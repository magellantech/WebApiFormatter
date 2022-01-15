using Microsoft.AspNetCore.Http;
using WebApiFormatter.Helpers.Interfaces;

namespace WebApiFormatter.Helpers
{
    public class Validator: IValidator
    {
        private bool _isNumeric;
        private bool _isDataVald;
        private string _dataStr;

        public bool IsDataVald
        {
            get
            {
                return _isDataVald;
            }
        }

        public bool IsNumeric
        {
            get
            {
                return _isNumeric;
            }
        }

        public Validator(HttpRequest httpRequest)
        {
            _dataStr = string.Empty;
            _isDataVald = false;
            Validate(httpRequest);
        }

        public string GetData()
        {
            return _dataStr;
        }

        void Validate(HttpRequest httpRequest)
        {
            if (httpRequest.Query != null)
            {
                if (httpRequest.Query.Count > 0)
                {
                    var isDataContains = httpRequest.Query.ContainsKey(StringConsts.STR_DATA);
                    if (isDataContains)
                    {
                        var data = httpRequest.Query[StringConsts.STR_DATA].ToString();

                        if (!string.IsNullOrEmpty(data))
                        {
                            if (data.Length > ushort.MaxValue)
                                return;

                            _isNumeric = double.TryParse(data, out double n);

                            if (_isNumeric)
                                if ((n == 0)||(n>double.MaxValue)||(n<double.MinValue))
                                    return;

                            _isDataVald = true;
                            _dataStr = data;
                        }
                    }
                }
            }
        }
    }
}
