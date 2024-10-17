using Devantler.K9sCLI;
using Devantler.KindCLI;

namespace Devantler.K9sCLITests.K9sTests;

/// <summary>
/// Tests
/// </summary>
[Collection("Flux")]
public class RunAsyncTests
{
  /// <summary>
  /// Test RunAsync executes K9s CLI on the default context in the kubeconfig file when no properties are set.
  /// </summary>
  [Fact]
  public async Task RunAsync_WithNoPropertiesSet_StartsK9sAsync()
  {
    // Arrange
    string clusterName = "test-cluster";
    string configPath = Path.Combine(AppContext.BaseDirectory, "assets/kind-config.yaml");
    using var source = new CancellationTokenSource();
    var cancellationToken1 = source.Token;
    var cancellationToken2 = new CancellationToken();

    // Act
    await Kind.DeleteClusterAsync(clusterName, cancellationToken1);
    await Kind.CreateClusterAsync(clusterName, configPath, cancellationToken1);

    var task = K9s.RunAsync(cancellationToken: cancellationToken1);
    await Task.Delay(5000);
    await source.CancelAsync();
    await task.ConfigureAwait(true);

    // Cleanup
    await Kind.DeleteClusterAsync(clusterName, cancellationToken2);
  }

  /// <summary>
  /// Test that RunAsync executes K9s CLI on the specified context in the specified kubeconfig file when all properties are set.
  /// </summary>
  /// <returns></returns>
  [Fact]
  public async Task RunAsync_WithAllPropertiesSet_StartsK9sAsync()
  {
    // Arrange
    string clusterName = "test-cluster";
    string configPath = Path.Combine(AppContext.BaseDirectory, "assets/kind-config.yaml");
    using var source = new CancellationTokenSource();
    var cancellationToken1 = source.Token;
    var cancellationToken2 = new CancellationToken();

    // Act
    await Kind.DeleteClusterAsync(clusterName, cancellationToken1);
    await Kind.CreateClusterAsync(clusterName, configPath, cancellationToken1);
    var task = K9s.RunAsync(
      Editor.Nano,
      $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/.kube/config",
      $"kind-{clusterName}", cancellationToken1
    );
    await Task.Delay(5000);
    await source.CancelAsync();
    await task.ConfigureAwait(true);

    // Cleanup
    await Kind.DeleteClusterAsync(clusterName, cancellationToken2);
  }
}
