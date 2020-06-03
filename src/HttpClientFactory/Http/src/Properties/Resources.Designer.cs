// <auto-generated />

using System.Globalization;
using System.Reflection;
using System.Resources;

namespace HttpClientFactoryLite.Properties
{
    internal static class Resources
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Microsoft.Extensions.Http.Resources", typeof(Resources).GetTypeInfo().Assembly);

        /// <summary>
        /// The '{0}' must not contain a null entry.
        /// </summary>
        internal static string HttpMessageHandlerBuilder_AdditionalHandlerIsNull
        {
            get => GetString("HttpMessageHandlerBuilder_AdditionalHandlerIsNull");
        }

        /// <summary>
        /// The '{0}' must not contain a null entry.
        /// </summary>
        internal static string FormatHttpMessageHandlerBuilder_AdditionalHandlerIsNull(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("HttpMessageHandlerBuilder_AdditionalHandlerIsNull"), p0);

        /// <summary>
        /// The '{0}' property must be null. '{1}' instances provided to '{2}' must not be reused or cached.{3}Handler: '{4}'
        /// </summary>
        internal static string HttpMessageHandlerBuilder_AdditionHandlerIsInvalid
        {
            get => GetString("HttpMessageHandlerBuilder_AdditionHandlerIsInvalid");
        }

        /// <summary>
        /// The '{0}' property must be null. '{1}' instances provided to '{2}' must not be reused or cached.{3}Handler: '{4}'
        /// </summary>
        internal static string FormatHttpMessageHandlerBuilder_AdditionHandlerIsInvalid(object p0, object p1, object p2, object p3, object p4)
            => string.Format(CultureInfo.CurrentCulture, GetString("HttpMessageHandlerBuilder_AdditionHandlerIsInvalid"), p0, p1, p2, p3, p4);

        /// <summary>
        /// The '{0}' must not be null.
        /// </summary>
        internal static string HttpMessageHandlerBuilder_PrimaryHandlerIsNull
        {
            get => GetString("HttpMessageHandlerBuilder_PrimaryHandlerIsNull");
        }

        /// <summary>
        /// The '{0}' must not be null.
        /// </summary>
        internal static string FormatHttpMessageHandlerBuilder_PrimaryHandlerIsNull(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("HttpMessageHandlerBuilder_PrimaryHandlerIsNull"), p0);

        /// <summary>
        /// The handler lifetime must be at least 1 second.
        /// </summary>
        internal static string HandlerLifetime_InvalidValue
        {
            get => GetString("HandlerLifetime_InvalidValue");
        }

        /// <summary>
        /// The handler lifetime must be at least 1 second.
        /// </summary>
        internal static string FormatHandlerLifetime_InvalidValue()
            => GetString("HandlerLifetime_InvalidValue");

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name);

            System.Diagnostics.Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}
