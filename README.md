# 🐶 .NET K9s CLI

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![Test](https://github.com/devantler/dotnet-k9s-cli/actions/workflows/test.yaml/badge.svg)](https://github.com/devantler/dotnet-k9s-cli/actions/workflows/test.yaml)
[![codecov](https://codecov.io/gh/devantler/dotnet-k9s-cli/graph/badge.svg?token=RhQPb4fE7z)](https://codecov.io/gh/devantler/dotnet-k9s-cli)

<details>
  <summary>Show/hide folder structure</summary>

<!-- readme-tree start -->
```
.
├── .github
│   ├── scripts
│   └── workflows
├── Devantler.K9sCLI
│   └── runtimes
│       ├── linux-arm64
│       │   └── native
│       ├── linux-x64
│       │   └── native
│       ├── osx-arm64
│       │   └── native
│       ├── osx-x64
│       │   └── native
│       ├── win-arm64
│       │   └── native
│       └── win-x64
│           └── native
└── Devantler.K9sCLI.Tests
    └── K9sTests

20 directories
```
<!-- readme-tree end -->

</details>

A simple .NET library that embeds the K9s CLI.

## 🚀 Getting Started

To get started, you can install the package from NuGet.

```bash
dotnet add package Devantler.K9sCLI
```

## 📝 Usage

You can execute the K9s CLI commands using the `K9s` class.

```csharp
using Devantler.K9sCLI;

var (exitCode, output) = await K9s.RunAsync(["arg1", "arg2"]);
```
