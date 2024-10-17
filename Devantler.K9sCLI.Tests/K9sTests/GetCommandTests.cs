using System.Runtime.InteropServices;
using Devantler.K9sCLI;

namespace Devantler.K9sCLI.Tests.K9sTests;

/// <summary>
/// Tests for the <see cref="K9s.GetCommand(PlatformID?, Architecture?, string?)"/> method.
/// </summary>
public class GetCommandTests
{
  /// <summary>
  /// Test to verify that the command returns the correct binary for MacOS on x64 architecture.
  /// </summary>
  [Fact]
  public void GetCommand_ShouldReturnOSXx64Binary()
  {
    {
      // Arrange
      string expectedBinary = "flux-osx-x64";

      // Act
      string actualBinary = Path.GetFileName(K9s.GetCommand(PlatformID.Unix, Architecture.X64, "osx-x64").TargetFilePath);

      // Assert
      Assert.Equal(expectedBinary, actualBinary);
    }
  }

  /// <summary>
  /// Test to verify that the command returns the correct binary for Linux on x64 architecture.
  /// </summary>
  [Fact]
  public void GetCommand_ShouldReturnOSXArm64Binary()
  {
    // Arrange
    string expectedBinary = "flux-osx-arm64";

    // Act
    string actualBinary = Path.GetFileName(K9s.GetCommand(PlatformID.Unix, Architecture.Arm64, "osx-arm64").TargetFilePath);

    // Assert
    Assert.Equal(expectedBinary, actualBinary);
  }

  /// <summary>
  /// Test to verify that the command returns the correct binary for Linux on ARM64 architecture.
  /// </summary>
  [Fact]
  public void GetCommand_ShouldReturnLinuxArm64Binary()
  {
    // Arrange
    string expectedBinary = "flux-linux-arm64";

    // Act
    string actualBinary = Path.GetFileName(K9s.GetCommand(PlatformID.Unix, Architecture.Arm64, "linux-arm64").TargetFilePath);

    // Assert
    Assert.Equal(expectedBinary, actualBinary);
  }

  /// <summary>
  /// Test to verify that the command returns the correct binary for Windows on x64 architecture.
  /// </summary>
  [Fact]
  public void GetCommand_ShouldReturnWindowsX64Binary()
  {
    // Arrange
    string expectedBinary = "flux-win-x64.exe";

    // Act
    string actualBinary = Path.GetFileName(K9s.GetCommand(PlatformID.Win32NT, Architecture.X64, "win-x64").TargetFilePath);

    // Assert
    Assert.Equal(expectedBinary, actualBinary);
  }

  /// <summary>
  /// Test to verify that the command returns the correct binary for Windows on ARM64 architecture.
  /// </summary>
  [Fact]
  public void GetCommand_ShouldReturnWindowsArm64Binary()
  {
    // Arrange
    string expectedBinary = "flux-win-arm64.exe";

    // Act
    string actualBinary = Path.GetFileName(K9s.GetCommand(PlatformID.Win32NT, Architecture.Arm64, "win-arm64").TargetFilePath);

    // Assert
    Assert.Equal(expectedBinary, actualBinary);
  }

  /// <summary>
  /// Test to verify that the command returns a <see cref="PlatformNotSupportedException"/> when the platform is not supported.
  /// </summary>
  [Fact]
  public void GetCommand_GivenInvaldiPlatform_ShouldThrowPlatformNotSupportedException()
  {
    // Arrange
    var platformID = PlatformID.Other;
    var architecture = Architecture.Wasm;
    string runtimeIdentifier = "wasm";

    // Act
    void Act() => K9s.GetCommand(platformID, architecture, runtimeIdentifier);

    // Assert
    _ = Assert.Throws<PlatformNotSupportedException>(Act);
  }
}
