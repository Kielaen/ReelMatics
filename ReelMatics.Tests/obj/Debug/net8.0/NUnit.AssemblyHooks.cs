// <auto-generated />
#pragma warning disable

using System.CodeDom.Compiler;
using System.Diagnostics;
using global::System.Runtime.CompilerServices;
using System.Threading.Tasks;

[GeneratedCode("Reqnroll", "2.0.2")]
[global::NUnit.Framework.SetUpFixture]
public class ReelMatics_Tests_NUnitAssemblyHooks
{
    [global::NUnit.Framework.OneTimeSetUp]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public async Task AssemblyInitializeAsync()
    {
        var currentAssembly = typeof(ReelMatics_Tests_NUnitAssemblyHooks).Assembly;
        await global::Reqnroll.TestRunnerManager.OnTestRunStartAsync(currentAssembly);
    }

    [global::NUnit.Framework.OneTimeTearDown]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public async ValueTask AssemblyCleanupAsync()
    {
        var currentAssembly = typeof(ReelMatics_Tests_NUnitAssemblyHooks).Assembly;
        await global::Reqnroll.TestRunnerManager.OnTestRunEndAsync(currentAssembly);
    }
}
#pragma warning restore
