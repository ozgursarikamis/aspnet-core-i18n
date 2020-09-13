using Microsoft.Extensions.Localization;

namespace i18n.StringLocalizers.Services
{
    public interface IDepartmentService
    {
        string GetInfo(string name);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IStringLocalizer<DepartmentService> _localizer;

        public DepartmentService(IStringLocalizer<DepartmentService> localizer)
        {
            _localizer = localizer;
        }

        public string GetInfo(string name)
        {
            LocalizedString value = _localizer[name];
            if (value.ResourceNotFound)
            {
                return _localizer["help"];
            }

            return value;
        }
    }
}
