using Alphaleonis.Win32.Filesystem;
using System;
using System.Linq;
using System.Reflection;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Assemblies.Info
{
    /// <summary>
    /// Exposes static methods to obtain data from various sources.
    /// </summary>
    public static class Get
    {
        /// <summary>
        /// Gets a <see cref="T:System.String" /> that contains the value of the
        /// <c>[assembly: AssemblyProduct]</c> attribute from the <c>AssemblyInfo.cs</c>
        /// file
        /// of  the calling assembly.
        /// </summary>
        private static string AssemblyProduct
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var attributes = Assembly.GetCallingAssembly()
                                             .GetCustomAttributes(
                                                 typeof(
                                                     AssemblyProductAttribute),
                                                 false
                                             );
                    if (attributes == null || !attributes.Any())
                        return result;

                    if (!(attributes.First() is AssemblyProductAttribute
                            productAttribute)) return result;
                    if (string.IsNullOrWhiteSpace(productAttribute.Product))
                        return result;

                    result = productAttribute.Product;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = string.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> that contains the value of the
        /// <c>[assembly: AssemblyTitle]</c> attribute from the <c>AssemblyInfo.cs</c> file
        /// of  the calling assembly.
        /// </summary>
        private static string AssemblyTitle
        {
            get
            {
                var result = Path.GetFileNameWithoutExtension(
                    Assembly.GetCallingAssembly()
                            .CodeBase
                );

                try
                {
                    var attributes = Assembly.GetCallingAssembly()
                                             .GetCustomAttributes(
                                                 typeof(AssemblyTitleAttribute),
                                                 false
                                             );
                    if (attributes == null || !attributes.Any())
                        return result;

                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute == null ||
                        string.IsNullOrWhiteSpace(titleAttribute.Title))
                        return result;

                    result = titleAttribute.Title;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = Path.GetFileNameWithoutExtension(
                        Assembly.GetCallingAssembly()
                                .CodeBase
                    );
                }

                return result;
            }
        }
    }
}