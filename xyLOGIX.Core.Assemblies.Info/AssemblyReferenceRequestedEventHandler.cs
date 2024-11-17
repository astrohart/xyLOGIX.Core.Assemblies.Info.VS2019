using System;
using System.Reflection;

namespace xyLOGIX.Core.Assemblies.Info
{
    /// <summary>
    /// Delegate that expresses the method signature for a handler of an
    /// <c>AssemblyReferenceRequested</c> event.
    /// </summary>
    /// <param name="e">
    /// (Required.) A <see cref="T:System.EventArgs" /> that contains the event data.
    /// </param>
    /// <returns>
    /// If successful, a reference to an instance of
    /// <see cref="T:System.Reflection.Assembly" /> that indicates which .NET assembly
    /// is to be used for extracting metadata.
    /// </returns>
    public delegate Assembly AssemblyReferenceRequestedEventHandler(
        EventArgs e
    );
}