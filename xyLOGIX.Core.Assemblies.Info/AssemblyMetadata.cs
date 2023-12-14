using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Model;
using PostSharp.Patterns.Threading;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace xyLOGIX.Core.Assemblies.Info
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to obtain data from various
    /// sources.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    public static class AssemblyMetadata
    {
        /// <summary>
        /// Gets a <see cref="T:System.String" /> that contains the value of the
        /// <c>[assembly: AssemblyCompany]</c> attribute from the <c>AssemblyInfo.cs</c>
        /// file of the calling assembly.
        /// </summary>
        /// <remarks>
        /// This property returns the <see cref="F:System.String.Empty" /> value
        /// if it could not interrogate the target assembly for the requested information.
        /// </remarks>
        public static string AssemblyCompany
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var assemblyToUse = Get.AssemblyToUse();
                    if (assemblyToUse == null) return result;

                    var attributes = assemblyToUse.GetCustomAttributes(
                        typeof(AssemblyCompanyAttribute), false
                    );
                    if (attributes == null || !attributes.Any()) return result;

                    if (!(attributes.First() is AssemblyCompanyAttribute
                            companyAttribute))
                        return result;

                    if (string.IsNullOrWhiteSpace(companyAttribute.Company))
                        return result;

                    result = companyAttribute.Company;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    Console.WriteLine(ex);

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
        /// <remarks>
        /// This property returns the <see cref="F:System.String.Empty" /> value
        /// if it could not interrogate the target assembly for the requested information.
        /// </remarks>
        public static string AssemblyCopyright
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var assemblyToUse = Get.AssemblyToUse();
                    if (assemblyToUse == null) return result;

                    var attributes = assemblyToUse.GetCustomAttributes(
                        typeof(AssemblyCopyrightAttribute), false
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
                    Console.WriteLine(ex);

                    result = string.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> that contains the value of the
        /// <c>[assembly: AssemblyDescription]</c> attribute from the
        /// <c>AssemblyInfo.cs</c> file of the calling assembly.
        /// </summary>
        /// <remarks>
        /// This property returns the <see cref="F:System.String.Empty" /> value
        /// if it could not interrogate the target assembly for the requested information.
        /// </remarks>
        public static string AssemblyDescription
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var assemblyToUse = Get.AssemblyToUse();
                    if (assemblyToUse == null) return result;

                    var attributes = assemblyToUse.GetCustomAttributes(
                        typeof(AssemblyDescriptionAttribute), false
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
                    Console.WriteLine(ex);

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
        /// <remarks>
        /// This property returns the <see cref="F:System.String.Empty" /> value
        /// if it could not interrogate the target assembly for the requested information.
        /// </remarks>
        public static string AssemblyProduct
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var assemblyToUse = Get.AssemblyToUse();
                    if (assemblyToUse == null) return result;

                    var attributes = assemblyToUse.GetCustomAttributes(
                        typeof(AssemblyProductAttribute), false
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
                    Console.WriteLine(ex);

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
        /// <remarks>
        /// This property returns the <see cref="F:System.String.Empty" /> value
        /// if it could not interrogate the target assembly for the requested information.
        /// </remarks>
        public static string AssemblyTitle
        {
            get
            {
                var result = "MyAssembly"; // generic catch-all

                try
                {
                    var assemblyToUse = Get.AssemblyToUse();
                    if (assemblyToUse == null)
                        return result;

                    if (string.IsNullOrWhiteSpace(assemblyToUse.Location))
                        return result;

                    result = Path.GetFileNameWithoutExtension(
                        assemblyToUse.Location
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
                    Console.WriteLine(ex);

                    result = "MyAssembly"; // generic catch-all
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the full version <see cref="T:System.String" /> of the calling
        /// assembly.
        /// </summary>
        /// <remarks>
        /// This property returns the <see cref="F:System.String.Empty" /> value
        /// if it could not interrogate the target assembly for the requested information.
        /// </remarks>
        public static string AssemblyVersion
        {
            get
            {
                var result = string.Empty;

                try
                {
                    var assemblyToUse = Get.AssemblyToUse();
                    if (assemblyToUse == null) return result;

                    var assemblyNameToUse = assemblyToUse.GetName();
                    if (assemblyNameToUse == null) return result;

                    var assemblyVersion = assemblyNameToUse.Version;
                    if (assemblyVersion == null) return result;

                    result = assemblyVersion.ToString();
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    Console.WriteLine(ex);

                    result = string.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the shortened form of the name of the company that is associated
        /// with the target assembly.
        /// </summary>
        /// <remarks>
        /// The shortened form of a company is that which does not contain "LLC",
        /// or ", Inc." etc.
        /// <para />
        /// This property assumes that all full company names use commas to separate the
        /// brand name from the incorporation prefix.
        /// <para />
        /// This property returns the <see cref="F:System.String.Empty" /> value if it
        /// could not interrogate the target assembly for the requested information.
        /// </remarks>
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
                    Console.WriteLine(ex);
                }

                return result;
            }
        }

        /// <summary>
        /// Obtains the name of the application's product without the name of the
        /// company.
        /// </summary>
        /// <remarks>
        /// This is useful, e.g., for error messages.  Instead of, "
        /// <c>MyCompany MyApp could not locate the file</c>," you can instead say, "
        /// <c>MyApp could not locate the file</c>."
        /// <para />
        /// This property returns the value of the
        /// <see cref="P:xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyProduct" />
        /// property
        /// if the shortened form of the product name could not otherwise be determined.
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

                    result = AssemblyProduct.Replace(ShortCompanyName, "")
                                            .Trim();
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    Console.WriteLine(ex);
                }

                return result;
            }
        }

        /// <summary>
        /// Raised to attempt to find the particular
        /// <see cref="T:System.Reflection.Assembly" /> whose attributes are to be
        /// extracted by the properties of this class.
        /// </summary>
        [WeakEvent]
        public static event Func<Assembly> AssemblyReferenceRequested;

        public static bool PropertiesHaveValidValues()
        {
            var result = false;

            try
            {
                Console.WriteLine(
                    "AssemblyMetadata.PropertiesHaveValidValues: Attempting to validate the metadata..."
                );

                // Dump the value of the property, AssemblyCompany, to the log
                Console.WriteLine(
                    $"AssemblyMetadata.PropertiesHaveValidValues: AssemblyCompany = '{AssemblyCompany}'"
                );

                Console.WriteLine(
                    "*** INFO: Checking whether the value of the 'AssemblyCompany' property is blank..."
                );

                if (string.IsNullOrWhiteSpace(AssemblyCompany))
                {
                    Console.WriteLine(
                        "AssemblyMetadata.PropertiesHaveValidValues: *** ERROR *** Blank value passed for the 'AssemblyCompany' property. This property is required."
                    );

                    Console.WriteLine(
                        $"AssemblyMetadata.PropertiesHaveValidValues: Result = {result}"
                    );

                    return result;
                }

                Console.WriteLine(
                    "*** SUCCESS *** The property 'AssemblyCompany' is not blank.  Continuing..."
                );

                // Dump the value of the property, AssemblyCopyright, to the log
                Console.WriteLine(
                    $"AssemblyMetadata.PropertiesHaveValidValues: AssemblyCopyright = '{AssemblyCopyright}'"
                );

                Console.WriteLine(
                    "*** INFO: Checking whether the value of the 'AssemblyCopyright' property is blank..."
                );

                if (string.IsNullOrWhiteSpace(AssemblyCopyright))
                {
                    Console.WriteLine(
                        "AssemblyMetadata.PropertiesHaveValidValues: *** ERROR *** Blank value passed for the 'AssemblyCopyright' property. This property is required."
                    );

                    Console.WriteLine(
                        $"AssemblyMetadata.PropertiesHaveValidValues: Result = {result}"
                    );

                    return result;
                }

                Console.WriteLine(
                    "*** SUCCESS *** The property 'AssemblyCopyright' is not blank.  Continuing..."
                );

                // Dump the value of the property, AssemblyProduct, to the log
                Console.WriteLine(
                    $"AssemblyMetadata.PropertiesHaveValidValues: AssemblyProduct = '{AssemblyProduct}'"
                );

                Console.WriteLine(
                    "*** INFO: Checking whether the value of the 'AssemblyProduct' property is blank..."
                );

                if (string.IsNullOrWhiteSpace(AssemblyProduct))
                {
                    Console.WriteLine(
                        "AssemblyMetadata.PropertiesHaveValidValues: *** ERROR *** Blank value passed for the 'AssemblyProduct' property. This property is required."
                    );

                    Console.WriteLine(
                        $"AssemblyMetadata.PropertiesHaveValidValues: Result = {result}"
                    );

                    return result;
                }

                Console.WriteLine(
                    "*** SUCCESS *** The property 'AssemblyProduct' is not blank.  Continuing..."
                );

                Console.WriteLine(
                    "AssemblyMetadata.PropertiesHaveValidValues: Validating that the value of the AssemblyProduct property contains whitespace characters..."
                );

                if (!AssemblyProduct.HasWhiteSpace())
                {
                    Console.WriteLine(
                        "AssemblyMetadata.PropertiesHaveValidValues: *** ERROR *** The value of the AssemblyProduct property contains no whitespace characters.  Make this property have a value equal to a user-friendly display name for your software product.  Stopping..."
                    );

                    return result;
                }

                Console.WriteLine(
                    "AssemblyMetadata.PropertiesHaveValidValues: *** SUCCESS *** The value of the AssemblyProduct property is not blank and has whitespace characters.  Continuing..."
                );

                // Dump the value of the property, AssemblyTitle, to the log
                Console.WriteLine(
                    $"AssemblyMetadata.PropertiesHaveValidValues: AssemblyTitle = '{AssemblyTitle}'"
                );

                Console.WriteLine(
                    "*** INFO: Checking whether the value of the 'AssemblyTitle' property is blank..."
                );

                if (string.IsNullOrWhiteSpace(AssemblyTitle))
                {
                    Console.WriteLine(
                        "AssemblyMetadata.PropertiesHaveValidValues: *** ERROR *** Blank value passed for the 'AssemblyTitle' property. This property is required."
                    );

                    Console.WriteLine(
                        $"AssemblyMetadata.PropertiesHaveValidValues: Result = {result}"
                    );

                    return result;
                }

                Console.WriteLine(
                    "*** SUCCESS *** The property 'AssemblyTitle' is not blank.  Continuing..."
                );

                Console.WriteLine(
                    "AssemblyMetadata.PropertiesHaveValidValues: Validating that the 'AssemblyTitle' property contains no whitespace..."
                );

                if (AssemblyTitle.HasWhiteSpace())
                {
                    Console.WriteLine(
                        "AssemblyMetadata.PropertiesHaveValidValues: *** ERROR *** The value of the AssemblyTitle property has whitespace characters in it.  This is invalid; the title of the assembly cannot contain any whitespace characters.  Stopping..."
                    );

                    return result;
                }

                Console.WriteLine(
                    "AssemblyMetadata.PropertiesHaveValidValues: *** SUCCESS *** The value of the AssemblyTitle property is both not blank and contains no whitespace characters.  Proceeding..."
                );

                Console.WriteLine(
                    "AssemblyMetadata.PropertiesHaveValidValues: *** SUCCESS *** All assembly metadata is present."
                );

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                Console.WriteLine(ex);

                result = false;
            }

            Console.WriteLine(
                $"AssemblyMetadata.PropertiesHaveValidValues: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Determines if the specified <see cref="T:System.String" /> parameter,
        /// <paramref name="value" />, is a string that is non-blank but also contains any
        /// whitespace.
        /// </summary>
        /// <param name="value">
        /// (Required.) A <see cref="T:System.String" /> containing the value that is to be
        /// checked for whitespace.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the specified <paramref name="value" />
        /// contains any whitespace characters; <see langword="false" /> otherwise.
        /// </returns>
        private static bool HasWhiteSpace(this string value)
        {
            var result = false;

            try
            {
                if (string.IsNullOrWhiteSpace(value)) return true;

                result = Regex.Matches(value, @"\s+")
                              .Count > 0;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                Console.WriteLine(ex);

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Raises the
        /// <see
        ///     cref="E:xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyReferenceRequested" />
        /// event.
        /// </summary>
        /// <param name="e">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Core.Assemblies.Info.AssemblyReferenceRequestedEventArgs" />
        /// that contains the event data.
        /// </param>
        /// <returns>
        /// If found, the <see cref="T:System.Reflection.Assembly" /> instance
        /// whose attributes are to be extracted by the properties of this class.
        /// </returns>
        /// <remarks>
        /// If no suitable <see cref="T:System.Reflection.Assembly" /> instance
        /// is to be found, then this method returns <see langword="null" />.
        /// </remarks>
        [Yielder]
        private static Assembly OnAssemblyReferenceRequested()
        {
            Assembly result = default;

            try
            {
                result = AssemblyReferenceRequested?.Invoke();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                Console.WriteLine(ex);

                result = default;
            }

            return result;
        }

        [ExplicitlySynchronized]
        internal static class Get
        {
            /// <summary>
            /// Attempts to get the <see cref="T:System.Reflection.Assembly" />
            /// instance that is to be used to gather attributes.
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
            public static Assembly AssemblyToUse()
            {
                Assembly result = default;

                try
                {
                    result = OnAssemblyReferenceRequested();
                    if (result != null) return result;

                    var entryAssembly = Assembly.GetEntryAssembly();
                    if (entryAssembly != null &&
                        !string.IsNullOrWhiteSpace(entryAssembly.Location) &&
                        !entryAssembly.Location.Contains("JetBrains") &&
                        !entryAssembly.Location.Contains("LINQPad"))
                    {
                        result = entryAssembly;
                        return result;
                    }

                    var ancestors =
                        Find.AllAssembliesThatDependOn(
                            Assembly.GetExecutingAssembly()
                        );
                    if (ancestors == null || !ancestors.Any())
                        return result;

                    /*
                     * The call stack frames go in reverse order, from the currently-executing
                     * method, down to the initial assembly that call the
                     * calling method.  This is the entry we want.
                     */

                    var initialAssembly = ancestors.Last();
                    if (initialAssembly == null) return result;

                    var initialAssemblyPathname = initialAssembly.Location;
                    if (string.IsNullOrWhiteSpace(initialAssemblyPathname))
                        return result;
                    if (!File.Exists(initialAssemblyPathname))
                        return result;

                    result = initialAssemblyPathname.EndsWith("Tests.dll")
                        ? initialAssembly
                        : Assembly
                            .GetEntryAssembly(); // If we aren't unit-testing, the entry assembly does fine
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    Console.WriteLine(ex);

                    result = default;
                }

                return result;
            }
        }
    }
}