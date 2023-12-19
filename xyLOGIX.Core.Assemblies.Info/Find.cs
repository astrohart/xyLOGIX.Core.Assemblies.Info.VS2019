using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Core.Assemblies.Info
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to find information on assemblies through
    /// Reflection.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class Find
    {
        /// <summary>
        /// Attempts to obtain a collection of references to instances of
        /// <paramref name="executingAssembly" /> in the call stack that refer to the
        /// specified <paramref name="executingAssembly" />.
        /// </summary>
        /// <param name="executingAssembly">
        /// (Required.) Reference to an instance of the
        /// currently-executing <see cref="T:System.Reflection.Assembly" />.
        /// </param>
        /// <returns>
        /// If successful, a read-only collection of references to instances of
        /// <paramref name="executingAssembly" /> in the call stack that refer to the
        /// specified <paramref name="executingAssembly" /> is returned.
        /// </returns>
        /// <remarks>If there is an issue that is experienced </remarks>
        internal static IReadOnlyList<Assembly> AllAssembliesThatDependOn(
            Assembly executingAssembly
        )
        {
            var result = Enumerable.Empty<Assembly>()
                                   .ToAdvisableCollection();

            try
            {
                if (executingAssembly == null) return result;
                var stackTraceFrames = new StackTrace().GetFrames();
                if (stackTraceFrames == null || !stackTraceFrames.Any())
                    return result;

                result = stackTraceFrames.Select(x => x.GetDeclaringAssembly())
                                         .Distinct()
                                         .Where(
                                             assembly
                                                 => assembly.DependsOn(
                                                     executingAssembly
                                                 )
                                         )
                                         .ToAdvisableCollection();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = Enumerable.Empty<Assembly>()
                                   .ToAdvisableCollection();
            }

            return result;
        }

        /// <summary>
        /// Determines if the specified <paramref name="executingAssembly" /> is
        /// referred to by other assemblies in the current stack trace frame.
        /// </summary>
        /// <param name="currentAssembly">
        /// (Required.) A
        /// <see cref="T:System.Reflection.Assembly" /> that is to be checked.
        /// </param>
        /// <param name="executingAssembly">
        /// (Required.) Reference to the
        /// currently-executing <see cref="T:System.Reflection.Assembly" />.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the specified
        /// <paramref name="currentAssembly" /> depends upon the
        /// <paramref name="executingAssembly" />; <see langword="false" /> otherwise, or
        /// if the relationship between the specified assemblies could not be determined.
        /// </returns>
        /// <remarks>
        /// This method also returns <see langword="false" /> if information is
        /// missing or a system error occurs during the operation.
        /// </remarks>
        private static bool DependsOn(
            this Assembly currentAssembly,
            Assembly executingAssembly
        )
        {
            var result = false;

            try
            {
                if (currentAssembly == null) return result;

                var referringAssemblyNames =
                    currentAssembly.GetReferencedAssemblies();
                if (referringAssemblyNames == null ||
                    !referringAssemblyNames.Any())
                    return result;

                result = referringAssemblyNames.Any(
                    name => name.FullName.Equals(executingAssembly.FullName)
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            return result;
        }
    }
}