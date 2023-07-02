using System.Linq.Expressions;

namespace IDSoft.CrmWelcome.Infrastructure.Helpers
{
    public static class LinqExtensions
    {
        public static string GetReflectedPropertyValue(this object subject, string field)
        {
            object reflectedValue = subject.GetType().GetProperty(field).GetValue(subject, null);
            return reflectedValue != null ? reflectedValue.ToString() : "";
        }
    }
}