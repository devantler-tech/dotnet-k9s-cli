#!/bin/bash
set -e

get() {
  local url=$1
  local binary=$2
  local target_dir=$3
  local target_name=$4
  local archiveType=$5

  echo "Downloading $target_name from $url"
  if [ "$archiveType" = "tar" ]; then
    curl -LJ "$url" | tar xvz -C "$target_dir" "$binary"
    mv "$target_dir/$binary" "${target_dir}/$target_name"
  elif [ "$archiveType" = "zip" ]; then
    curl -LJ "$url" -o "$target_dir/$target_name.zip"
    unzip -o "$target_dir/$target_name.zip" -d "$target_dir"
    mv "$target_dir/$binary" "${target_dir}/$target_name"
    rm "$target_dir/$target_name.zip"
  elif [ "$archiveType" = false ]; then
    curl -LJ "$url" -o "$target_dir/$target_name"
  fi
  chmod +x "$target_dir/$target_name"
}

get "https://getbin.io/derailed/k9s?os=darwin&arch=amd64" "k9s" "src/Devantler.K9sCLI/runtimes/osx-x64/native" "k9s-osx-x64" "tar"
get "https://getbin.io/derailed/k9s?os=darwin&arch=arm64" "k9s" "src/Devantler.K9sCLI/runtimes/osx-arm64/native" "k9s-osx-arm64" "tar"
get "https://getbin.io/derailed/k9s?os=linux&arch=amd64" "usr/bin/k9s" "src/Devantler.K9sCLI/runtimes/linux-x64/native" "k9s-linux-x64" "tar"
get "https://getbin.io/derailed/k9s?os=linux&arch=arm64" "usr/bin/k9s" "src/Devantler.K9sCLI/runtimes/linux-arm64/native" "k9s-linux-arm64" "tar"
get "https://getbin.io/derailed/k9s?os=windows&arch=amd64" "k9s.exe" "src/Devantler.K9sCLI/runtimes/win-x64/native" "k9s-win-x64.exe" "zip"
get "https://getbin.io/derailed/k9s?os=windows&arch=arm64" "k9s.exe" "src/Devantler.K9sCLI/runtimes/win-arm64/native" "k9s-win-arm64.exe" "zip"
rm -rf src/Devantler.K9sCLI/runtimes/*/native/usr
rm -rf src/Devantler.K9sCLI/runtimes/*/native/LICENSE
rm -rf src/Devantler.K9sCLI/runtimes/*/native/README.md
