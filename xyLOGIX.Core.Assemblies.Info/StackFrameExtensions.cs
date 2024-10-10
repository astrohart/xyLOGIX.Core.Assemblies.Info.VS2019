using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.Reflection;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Core.Assemblies.Info
{
    /// <summary>
    /// Exposes extension methods for the
    /// <see cref="T:System.Diagnostics.StackFrame" /> class.
    /// </summary>
    [Log(AttributeExclude = true)]
    public static class StackFrameExtensions
    {
        /// <summary>
        /// Attempts to obtain a reference to the
        /// <see cref="T:System.Reflection.Assembly" /> instance that represents the
        /// assembly that contains the method that is at the current stack
        /// <paramref name="frame" />.
        /// </summary>
        /// <param name="frame">
        /// (Required.) Reference to an instance of the
        /// <see cref="T:System.Diagnostics.StackFrame" /> that represents the top of the
        /// call stack.
        /// </param>
        /// <returns>
        /// If successful, a reference to the
        /// <see cref="T:System.Reflection.Assembly" /> instance that represents the
        /// assembly that contains the method that is at the current stack
        /// <paramref name="frame" />; <see langword="null" /> otherwise.
        /// </returns>
        public static Assembly GetDeclaringAssembly(this StackFrame frame)
        {
            Assembly result = default;

            try
            {
                if (frame == null) return result;

                var currentlyRunningMethod = frame.GetMethod();
                if (currentlyRunningMethod == null) return result;

                var containingType = currentlyRunningMethod.ReflectedType;
                if (containingType == null) return result;

                result = containingType.Assembly;
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