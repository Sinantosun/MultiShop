using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MultiShop.WebUI.Enums;

namespace MultiShop.WebUI.Services
{
    public class NotificationService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly string _tempdataMessageKey = "tempdataMessage";
        private readonly string _tempdataTypeKey = "tempdataIcon";
        private ITempDataDictionary _tempdata => _tempDataDictionaryFactory.GetTempData(_contextAccessor.HttpContext);

        public NotificationService(IHttpContextAccessor contextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _contextAccessor = contextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
        }
        public void Success(string message)
        {
            SetTempdata("success", message);
        }
        public void Error(string message)
        {
            SetTempdata("danger", message);
        }
        public void Info(string message)
        {
            SetTempdata("info", message);
        }
        public void Warning(string message)
        {
            SetTempdata("warning", message);
        }

        private void SetTempdata(string icon,string message)
        {
            _tempdata[_tempdataMessageKey] = message;
            _tempdata[_tempdataTypeKey] = icon;

        }
    }
}
