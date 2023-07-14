using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
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
        /// <c>[assembly: AssemblyCopyright]</c> attribute from the <c>AssemblyInfo.cs</c>
        /// file of the calling assembly.
        /// </summary>
        public static string AssemblyCopyright
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var attributes = Get.AssemblyToUse()
                                        .GetCustomAttributes(
                                            typeof(AssemblyCopyrightAttribute),
                                            false
                                        );
                    if (attributes == null || !attributes.Any())
                        return result;
                    if (!(attributes.First() is AssemblyCopyrightAttribute
                            copyrightAttribute)) return result;
                    if (string.IsNullOrWhiteSpace(copyrightAttribute.Copyright))
                        return result;

                    result = copyrightAttribute.Copyright;
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
        /// <c>[assembly: AssemblyDescription]</c> attribute from the
        /// <c>AssemblyInfo.cs</c>
        /// file of the calling assembly.
        /// </summary>
        public static string AssemblyDescription
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var attributes = Get.AssemblyToUse()
                                        .GetCustomAttributes(
                                            typeof(
                                                AssemblyDescriptionAttribute),
                                            false
                                        );
                    if (attributes == null || !attributes.Any())
                        return result;
                    if (!(attributes.First() is AssemblyDescriptionAttribute
                            descriptionAttribute)) return result;
                    if (string.IsNullOrWhiteSpace(
                            descriptionAttribute.Description
                        ))
                        return result;

                    result = descriptionAttribute.Description;
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

        public static string ShortCompanyName
        {
            get
            {
                var result = AssemblyCompany;

                try
                {
                    if (string.IsNullOrWhiteSpace(AssemblyCompany))
                        return result;

                    var commaIndex = AssemblyCompany.IndexOf(',');
                    if (commaIndex < 0) return result; // comma not found

                    result =
                        AssemblyCompany.Remove(
                            commaIndex
                        ); // remove ', LLC' for example, from company name
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);
                }

                return result;
            }
        }

        /// <summary>
        /// Obtains the name of the application's product without the name of the company.
        /// </summary>
        /// <remarks>
        /// This is useful, e.g., for error messages.  Instead of, "
        /// <c>MyCompany MyApp could not locate the file</c>," you can instead say, "
        /// <c>MyApp could not locate the file</c>."
        /// </remarks>
        public static string ShortProductName
        {
            get
            {
                var result = AssemblyProduct;

                try
                {
                    if (string.IsNullOrWhiteSpace(AssemblyCompany))
                        return result;
                    if (string.IsNullOrWhiteSpace(ShortCompanyName))
                        return result;

                    result = AssemblyProduct.Replace(ShortCompanyName, "");
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);
                }

                return result;
            }
        }

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
            [Log(AttributeExclude = true)]
            internal static Assembly AssemblyToUse()
            {
                Assembly result = default;

                try
                {
                    var executingAssembly = Assembly.GetExecutingAssembly();
                    var callerAssemblies = new StackTrace().GetFrames()
                        .Select(
                            x => x.GetMethod()
                                  .ReflectedType.Assembly
                        )
                        .Distinct()
                        .Where(
                            x => x.GetReferencedAssemblies()
                                  .Any(
                                      y => y.FullName ==
                                           executingAssembly.FullName
                                  )
                        );
                    var initialAssembly = callerAssemblies.Last();

                    if (initialAssembly == null) return result;

                    var initialAssemblyPathname = initialAssembly.Location;
                    if (string.IsNullOrWhiteSpace(initialAssemblyPathname))
                        return result;
                    if (!File.Exists(initialAssemblyPathname))
                        return result;

                    result = initialAssemblyPathname.EndsWith("Tests.dll")
                        ? initialAssembly
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