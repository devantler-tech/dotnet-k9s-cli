using System.Globalization;
using System.Runtime.InteropServices;
using CliWrap;
using Devantler.CLIRunner;

namespace Devantler.K9sCLI;

/// <summary>
/// A class to run k9s CLI commands.
/// </summary>
public static class K9s
{
  /// <summary>
  /// The K9s CLI command.
  /// </summary>
  static Command Command => GetCommand();

  internal static Command GetCommand(PlatformID? platformID = default, Architecture? architecture = default, string? runtimeIdentifier = default)
  {
    platformID ??= Environment.OSVersion.Platform;
    architecture ??= RuntimeInformation.ProcessArchitecture;
    runtimeIdentifier ??= RuntimeInformation.RuntimeIdentifier;

    string binary = (platformID, architecture, runtimeIdentifier) switch
    {
      (PlatformID.Unix, Architecture.X64, "osx-x64") => "k9s-osx-x64",
      (PlatformID.Unix, Architecture.Arm64, "osx-arm64") => "k9s-osx-arm64",
      (PlatformID.Unix, Architecture.X64, "linux-x64") => "k9s-linux-x64",
      (PlatformID.Unix, Architecture.Arm64, "linux-arm64") => "k9s-linux-arm64",
      (PlatformID.Win32NT, Architecture.X64, "win-x64") => "k9s-win-x64.exe",
      (PlatformID.Win32NT, Architecture.Arm64, "win-arm64") => "k9s-win-arm64.exe",
      _ => throw new PlatformNotSupportedException($"Unsupported platform: {Environment.OSVersion.Platform} {RuntimeInformation.ProcessArchitecture}"),
    };
    string binaryPath = Path.Combine(AppContext.BaseDirectory, binary);
    return !File.Exists(binaryPath) ?
      throw new FileNotFoundException($"{binaryPath} not found.") :
      Cli.Wrap(binaryPath);
  }

  /// <summary>
  /// Run the K9s CLI.
  /// </summary>
  /// <param name="editor"></param>
  /// <param name="kubeconfig"></param>
  /// <param name="context"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public static async Task RunAsync(Editor editor = Editor.Nano, string? kubeconfig = default, string? context = default, CancellationToken cancellationToken = default)
  {
    Environment.SetEnvironmentVariable("EDITOR", editor.ToString().ToLower(CultureInfo.CurrentCulture));
    Environment.SetEnvironmentVariable("KUBE_EDITOR", editor.ToString().ToLower(CultureInfo.CurrentCulture));
    kubeconfig ??= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".kube", "config");
    var command = string.IsNullOrEmpty(context) ?
      Command.WithArguments(
        ["--kubeconfig", kubeconfig]
      ) :
      Command.WithArguments(
        ["--kubeconfig", kubeconfig, "--context", context]
      );
    try
    {
      _ = await CLI.RunAsync(command, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
    catch (Exception ex)
    {
      throw new K9sException(ex.Message);
    }
  }
}
