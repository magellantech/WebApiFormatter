using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApiFormatter.Helpers;
using WebApiFormatter.Helpers.Interfaces;
using WebApiFormatter.Models;
using WebApiFormatter.Services.Interfaces;

namespace WebApiFormatter.Services
{
    public class DataFormatterService : IFormatterService
    {
        public DataFormatterService()
        {

        }

        public async Task<ResultData> FormatAsync(IQueryCollection query, ILogger logger)
        {
            var taskResult = await Task.Run(() =>
            {
                
                IValidator validator;
                IFormatter formatter;
                ResultData resultData = new ResultData();

                try
                {
                    validator = new Validator(query);

                    if (!validator.IsDataVald)
                    {
                        resultData.result = StringConsts.STR_NO_VALID_DATA;
                        return resultData;
                    }

                    if (validator.IsNumeric)
                        formatter = new NumberFormatter();
                    else
                        formatter = new StringFormatter();

                    resultData.result = formatter.Format(validator.GetData());
                }
                catch (Exception ex)
                {
                    resultData.result = StringConsts.STR_SERVER_ERROR;
                    logger.LogError(ex.Message);
                }

                return resultData;
            });

            return taskResult;
        }
    }
}
