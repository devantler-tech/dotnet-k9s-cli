namespace Devantler.K9sCLI.Tests.K9sTests;

/// <summary>
/// Tests for the <see cref="K9s.RunAsync(string[], CancellationToken)" /> method.
/// </summary>
public class RunAsyncTests
{
  /// <summary>
  /// Tests that the binary can return the version of the k9s CLI command.
  /// </summary>
  [Fact]
  public async Task RunAsync_Version_ReturnsVersion()
  {
    // Arrange
    var exitCode = await K9s.RunAsync(["version", "-s"]);

    // Assert
    Assert.Equal(0, exitCode);
  }
}
