using System.Diagnostics;
using System.Runtime.InteropServices;
using CliWrap;

namespace DevantlerTech.K9sCLI;

/// <summary>
/// A class to run k9s CLI commands.
/// </summary>
public static class K9s
{
  /// <summary>
  /// The K9s CLI command.
  /// </summary>
  static Command Command
  {
    get
    {
      string binaryName = "k9s";
      string? pathEnv = Environment.GetEnvironmentVariable("PATH");

      if (!string.IsNullOrEmpty(pathEnv))
      {
        string[] paths = pathEnv.Split(Path.PathSeparator);
        foreach (string dir in paths)
        {
          string fullPath = Path.Combine(dir, binaryName);
          if (File.Exists(fullPath))
          {
            return Cli.Wrap(fullPath);
          }
        }
      }

      throw new FileNotFoundException($"The '{binaryName}' CLI was not found in PATH.");
    }
  }

  /// <summary>
  /// Runs the k9s CLI command with the given arguments.
  /// </summary>
  /// <param name="arguments"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public static async Task<int> RunAsync(
    string[] arguments,
    CancellationToken cancellationToken = default)
  {
    // call k9s binary with the given arguments without cliwrap
    var process = new ProcessStartInfo
    {
      FileName = Command.TargetFilePath,
      Arguments = string.Join(' ', arguments),
      UseShellExecute = true,
      CreateNoWindow = true,
    };
    using var proc = Process.Start(process) ?? throw new InvalidOperationException("Failed to start k9s process.");
    await proc.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
    return proc.ExitCode;
  }
}
