using System.Diagnostics;
using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Linq;
using System.Reflection;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Core.Assemblies.Info
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to obtain data from various
    /// sources.
    /// </summary>
    public static class Get
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Assemblies.Info.Get" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Get() { }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> that contains the value of the
        /// <c>[assembly: AssemblyCompany]</c> attribute from the <c>AssemblyInfo.cs</c>
        /// file of  the calling assembly.
        /// </summary>
        public static string AssemblyCompany
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var attributes = Assembly.GetCallingAssembly()
                                             .GetCustomAttributes(
                                                 typeof(
                                                     AssemblyCompanyAttribute),
                                                 false
                                             );
                    if (attributes == null || !attributes.Any())
                        return result;

                    if (!(attributes.First() is AssemblyCompanyAttribute
                            companyAttribute)) return result;
                    if (string.IsNullOrWhiteSpace(companyAttribute.Company))
                        return result;

                    result = companyAttribute.Company;
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
        /// <c>[assembly: AssemblyProduct]</c> attribute from the <c>AssemblyInfo.cs</c>
        /// file of  the calling assembly.
        /// </summary>
        public static string AssemblyProduct
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
        public static string AssemblyTitle
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