using Newtonsoft.Json;

namespace Core.Extensions.LoanTemplateJsons
{
    public static class GenericFieldGetter
    {
        public static T GetDeserializeObject<T>(this string property)
        {
            return JsonConvert.DeserializeObject<T>(property);
        }
    }
}
