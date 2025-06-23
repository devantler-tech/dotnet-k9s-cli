# 🐶 .NET K9s CLI

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![Test](https://github.com/devantler-tech/dotnet-k9s-cli/actions/workflows/test.yaml/badge.svg)](https://github.com/devantler-tech/dotnet-k9s-cli/actions/workflows/test.yaml)
[![codecov](https://codecov.io/gh/devantler-tech/dotnet-k9s-cli/graph/badge.svg?token=RhQPb4fE7z)](https://codecov.io/gh/devantler-tech/dotnet-k9s-cli)

A simple .NET library that embeds the K9s CLI.

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 or later
- [K9s CLI](https://k9scli.io/topics/install/) installed and available in your system's PATH

### Installation

To get started, you can install the package from NuGet.

```bash
dotnet add package DevantlerTech.K9sCLI
```

## 📝 Usage

You can execute the K9s CLI commands using the `K9s` class.

```csharp
using DevantlerTech.K9sCLI;

var exitCode = await K9s.RunAsync(["arg1", "arg2"]);
```
