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

        public Validator(IQueryCollection query)
        {
            InitData();
            Validate(query);
        }

        public Validator()
        {
            InitData();
        }

        private void InitData()
        {
            _dataStr = string.Empty;
            _isDataVald = false;
        }

        public string GetData()
        {
            return _dataStr;
        }

        public void Validate(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                if (data.Length > ushort.MaxValue)
                    return;

                _isNumeric = double.TryParse(data, out double n);

                _isDataVald = true;
                _dataStr = data;
            }
        }

        public void Validate(IQueryCollection query)
        {
            if (query != null)
            {
                if (query.Count > 0)
                {
                    var isDataContains = query.ContainsKey(StringConsts.STR_DATA);
                    if (isDataContains)
                    {
                        var data = query[StringConsts.STR_DATA].ToString();
                        Validate(data);
                    }
                }
            }
        }
    }
}
