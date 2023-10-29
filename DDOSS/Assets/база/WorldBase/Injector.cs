using VContainer;

namespace база.WorldBase
{
    public static class Injector
    {
        private static IObjectResolver _resolver;

        public static void SetResolver(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public static void Inject(object o)
        {
            _resolver.Inject(o);
        }
    }
}