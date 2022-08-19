using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WPF.ViewModels;

namespace WPF.Extensions
{
    public static class CloneExtensions
    {
        public static T Clone<T>(this T cloneable) where T : new()
        {
            var toJson = JsonSerializer.Serialize<T>(cloneable);
            return JsonSerializer.Deserialize<T>(toJson);
        }
    }
}
