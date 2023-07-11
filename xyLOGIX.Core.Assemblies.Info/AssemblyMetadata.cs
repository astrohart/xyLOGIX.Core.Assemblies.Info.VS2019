using Alphaleonis.Win32.Filesystem;
using System;
using System.Linq;
using System.Reflection;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Core.Assemblies.Info
{
    /// <summary>
    /// Exposes static methods to obtain data from various sources.
    /// </summary>
    public static class AssemblyMetadata
    {
        /// <summary>
        /// Gets a <see cref="T:System.String" /> that contains the value of the
        /// <c>[assembly: AssemblyCompany]</c> attribute from the <c>AssemblyInfo.cs</c>
        /// file of the calling assembly.
        /// </summary>
        public static string AssemblyCompany
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var attributes = Get.AssemblyToUse()
                                        .GetCustomAttributes(
                                            typeof(AssemblyCompanyAttribute),
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
        /// file of the calling assembly.
        /// </summary>
        public static string AssemblyProduct
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var attributes = Get.AssemblyToUse()
                                        .GetCustomAttributes(
                                            typeof(AssemblyProductAttribute),
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
        /// of the calling assembly.
        /// </summary>
        public static string AssemblyTitle
        {
            get
            {
                var result = "MyAssembly"; // generic catch-all

                var assemblyToUse = Get.AssemblyToUse();
                if (assemblyToUse == null)
                    return result;

                try
                {
                    result = Path.GetFileNameWithoutExtension(
                        assemblyToUse.CodeBase
                    );

                    var attributes = assemblyToUse.GetCustomAttributes(
                        typeof(AssemblyTitleAttribute), false
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

                    result = "MyAssembly"; // generic catch-all
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the full version of the application.
        /// </summary>
        public static string AssemblyVersion
            => Assembly.GetEntryAssembly()
                       .GetName()
                       .Version.ToString();

        /// <summary>
        /// Exposes static methods to get values.
        /// </summary>
        internal static class Get
        {
            /// <summary>
            /// Attempts to get the <see cref="T:System.Reflection.Assembly" /> instance that
            /// is to be used to gather attributes.
            /// </summary>
            /// <returns>
            /// If successful, the <see cref="T:System.Reflection.Assembly" />
            /// instance that is to be used to gather attributes, or <see langword="null" /> if
            /// not possible.
            /// </returns>
            /// <remarks>
            /// This library can be called either from a unit test, or from a EXE.
            /// <para />
            /// We basically ask the calling assembly whether its pathname ends with
            /// <c>Tests.dll</c>.  If affirmative, then the return value of the
            /// <see cref="M:System.Reflection.Assembly.GetCallingAssembly" /> method is
            /// fetched.
            /// <para />
            /// Otherwise, we assume that we have been called from a WinForms or Console or WPF
            /// EXE application; therefore, the return value of this method is that of the
            /// <see cref="M:System.Reflection.Assembly.GetEntryAssembly" /> method.
            /// </remarks>
            internal static Assembly AssemblyToUse()
            {
                Assembly result = default;

                try
                {
                    if (Assembly.GetCallingAssembly() == null) return result;

                    var callingAssemblyPathname = Assembly.GetCallingAssembly()
                        .Location;
                    if (string.IsNullOrWhiteSpace(callingAssemblyPathname))
                        return result;
                    if (!File.Exists(callingAssemblyPathname))
                        return result;

                    result = callingAssemblyPathname.EndsWith("Tests.dll")
                        ? Assembly.GetCallingAssembly()
                        : Assembly.GetEntryAssembly();
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = default;
                }

                return result;
            }
        }
    }
}