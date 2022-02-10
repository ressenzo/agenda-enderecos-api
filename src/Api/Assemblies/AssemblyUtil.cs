using System.Collections.Generic;
using System.Reflection;

namespace Api.Assemblies
{
    public static class AssemblyUtil
    {
        public static IEnumerable<Assembly> Assemblies()
        {
            return new Assembly[]
            {
                Assembly.Load(nameof(Api)),
                Assembly.Load(nameof(Infra))
            };
        }
    }
}
