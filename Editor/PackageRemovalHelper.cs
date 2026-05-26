using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace GameFrameX.Builder.Editor
{
    public static class PackageRemovalHelper
    {
        private const string RemovePackagesArg = "-RemovePackages";

        public static void Run()
        {
            var packagesToRemove = ParseRemovePackages();
            if (packagesToRemove.Count == 0)
            {
                throw new Exception($"未检测到 {RemovePackagesArg} 参数。用法: -RemovePackages 包名1,包名2,包名3");
            }

            Debug.Log($"[PackageRemoval] 计划移除 {packagesToRemove.Count} 个包: {string.Join(", ", packagesToRemove)}");

            RemoveFromManifest(packagesToRemove);
            RemovePackageDirectories(packagesToRemove);

            AssetDatabase.Refresh();
            Debug.Log("[PackageRemoval] 完成");
        }

        private static List<string> ParseRemovePackages()
        {
            var args = Environment.GetCommandLineArgs();
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == RemovePackagesArg && i + 1 < args.Length)
                {
                    var packages = args[i + 1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    return new List<string>(packages);
                }
            }

            return new List<string>();
        }

        private static void RemoveFromManifest(List<string> packagesToRemove)
        {
            var manifestPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Packages", "manifest.json"));
            if (!File.Exists(manifestPath))
            {
                Debug.LogWarning("[PackageRemoval] manifest.json 不存在: " + manifestPath);
                return;
            }

            var json = File.ReadAllText(manifestPath);
            var manifest = JObject.Parse(json);
            var dependencies = manifest["dependencies"] as JObject;
            if (dependencies == null)
            {
                Debug.LogWarning("[PackageRemoval] manifest.json 中未找到 dependencies 节点");
                return;
            }

            var removedCount = 0;
            foreach (var packageName in packagesToRemove)
            {
                if (dependencies[packageName] != null)
                {
                    dependencies.Remove(packageName);
                    removedCount++;
                    Debug.Log($"[PackageRemoval] 从 manifest.json 移除依赖: {packageName}");
                }
                else
                {
                    Debug.Log($"[PackageRemoval] manifest.json 中未找到依赖，跳过: {packageName}");
                }
            }

            if (removedCount > 0)
            {
                File.WriteAllText(manifestPath, manifest.ToString());
                Debug.Log($"[PackageRemoval] manifest.json 已更新，共移除 {removedCount} 个依赖");
            }
        }

        private static void RemovePackageDirectories(List<string> packagesToRemove)
        {
            var packagesRoot = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Packages"));

            foreach (var packageName in packagesToRemove)
            {
                var packageDir = Path.Combine(packagesRoot, packageName);
                if (Directory.Exists(packageDir))
                {
                    Directory.Delete(packageDir, true);
                    Debug.Log($"[PackageRemoval] 删除本地包目录: {packageName}");
                }
                else
                {
                    Debug.Log($"[PackageRemoval] 本地包目录不存在，跳过: {packageName}");
                }
            }
        }
    }
}
