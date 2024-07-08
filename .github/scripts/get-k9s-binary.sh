#!/bin/bash
set -e

get() {
  local url=$1
  local binary=$2
  local target_dir=$3
  local target_name=$4
  local isTar=$5

  # check if tar
  if [ "$isTar" = true ]; then
    curl -LJ "$url" | tar xvz -C "$target_dir" "$binary"
    mv "$target_dir/$binary" "${target_dir}/$target_name"
  elif [ "$isTar" = false ]; then
    curl -LJ "$url" -o "$target_dir/$target_name"
  fi
  chmod +x "$target_dir/$target_name"
}

get "https://getbin.io/derailed/k9s?os=darwin&arch=amd64" "k9s" "src/Devantler.K9sCLI/assets/binaries" "k9s-darwin-amd64" true
get "https://getbin.io/derailed/k9s?os=darwin&arch=arm64" "k9s" "src/Devantler.K9sCLI/assets/binaries" "k9s-darwin-arm64" true
get "https://getbin.io/derailed/k9s?os=linux&arch=amd64" "usr/bin/k9s" "src/Devantler.K9sCLI/assets/binaries" "k9s-linux-amd64" true
get "https://getbin.io/derailed/k9s?os=linux&arch=arm64" "usr/bin/k9s" "src/Devantler.K9sCLI/assets/binaries" "k9s-linux-arm64" true
