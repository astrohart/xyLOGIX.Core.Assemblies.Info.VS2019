using PostSharp.Patterns.Diagnostics;
using System;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Core.Assemblies.Info
{
    /// <summary>
    /// Provides method(s) and property(ies) to assist with manipulating
    /// <see cref="T:System.String" />(s) of text.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class InternalStringExtensions
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Assemblies.Info.InternalStringExtensions" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static InternalStringExtensions() { }

        /// <summary>
        /// Removes the <paramref name="trimString" />, if present, from the end
        /// of the specified <paramref name="target" />.
        /// </summary>
        /// <param name="target">
        /// (Required.) A <see cref="T:System.String" /> that is to be
        /// trimmed.
        /// </param>
        /// <param name="trimString">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the character(s) that are to be trimmed.
        /// </param>
        /// <remarks>
        /// If either of the required parameters, <paramref name="target" />, or
        /// <paramref name="trimString" />, are <see langword="null" />, blank, or the
        /// <see cref="F:System.String.Empty" /> value, then this method is idempotent.
        /// </remarks>
        /// <returns>
        /// If successful, a <see cref="T:System.String" /> containing the trimmed
        /// version of <paramref name="target" /> with the specified
        /// <paramref name="trimString" /> removed from the end of it; otherwise, the
        /// method is idempotent.
        /// </returns>
        [return: NotLogged]
        public static string TrimEnd(
            [NotLogged] this string target,
            [NotLogged] string trimString
        )
        {
            var result = target;

            try
            {
                if (string.IsNullOrEmpty(trimString)) return result;
                if (!target.EndsWith(trimString)) return result;

                while (result.EndsWith(trimString))
                {
                    result = result.Substring(
                        0, result.Length - trimString.Length
                    );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = target;
            }

            return result;
        }

        /// <summary>
        /// Removes the <paramref name="trimString" />, if present, from the start of the
        /// specified <paramref name="target" />.
        /// </summary>
        /// <param name="target">
        /// (Required.) A <see cref="T:System.String" /> that is to be
        /// trimmed.
        /// </param>
        /// <param name="trimString">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the character(s) that are to be trimmed.
        /// </param>
        /// <remarks>
        /// If either of the required parameters, <paramref name="target" />, or
        /// <paramref name="trimString" />, are <see langword="null" />, blank, or the
        /// <see cref="F:System.String.Empty" /> value, then this method is idempotent.
        /// </remarks>
        /// <returns>
        /// If successful, a <see cref="T:System.String" /> containing the trimmed
        /// version of <paramref name="target" /> with the specified
        /// <paramref name="trimString" /> removed from the start of it; otherwise, the
        /// method is idempotent.
        /// </returns>
        [return: NotLogged]
        public static string TrimStart(
            [NotLogged] this string target,
            [NotLogged] string trimString
        )
        {
            var result = target;

            try
            {
                if (string.IsNullOrEmpty(trimString)) return result;
                if (!target.StartsWith(trimString)) return result;

                while (result.StartsWith(trimString))
                {
                    result = result.Substring(trimString.Length);
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = target;
            }

            return result;
        }
    }
}