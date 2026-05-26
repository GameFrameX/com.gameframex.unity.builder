#if ENABLE_GAME_FRAME_X_HYBRID_CLR
using HybridCLR.Editor.Commands;
using HybridCLR.Editor.Installer;
#endif
using UnityEditor;
using UnityEngine;

namespace GameFrameX.Builder.Editor
{
    public static partial class Builder
    {
        /// <summary>
        /// 打包准备
        /// </summary>
        public static void BuildReady()
        {
            Debug.Log("BuildReady");

#if ENABLE_GAME_FRAME_X_HYBRID_CLR
            Debug.Log("BuildReady Start HybridCLR");
            var installerController = new InstallerController();
            var isInstalled = installerController.HasInstalledHybridCLR();
            Debug.Log("BuildReady Check HybridCLR Install Status:" + isInstalled + " PackageName:" + installerController.PackageVersion + " InstalledLibil2cppVersion:" + installerController.InstalledLibil2cppVersion);
            if (!isInstalled || installerController.InstalledLibil2cppVersion != installerController.PackageVersion)
            {
                Debug.Log("BuildReady Install HybridCLR");
                installerController.InstallDefaultHybridCLR();
                isInstalled = installerController.HasInstalledHybridCLR();
                Debug.Log("BuildReady Check HybridCLR Install Status After Install:" + isInstalled);
            }

            Debug.Log("BuildReady End HybridCLR");
#endif
            Debug.Log("BuildReady Start AssetDatabase Refresh");
            AssetDatabase.Refresh();
            Debug.Log("BuildReady End AssetDatabase Refresh");
#if ENABLE_GAME_FRAME_X_HYBRID_CLR
            // 构建热更新代理
            Debug.Log("BuildReady Start Generate All");
            PrebuildCommand.GenerateAll();
            Debug.Log("BuildReady End Generate All");
#endif
            AssetDatabase.Refresh();
            if (_builderOptions.IsUploadLogFile)
            {
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
                ObjectStorageUploadManager.UploadFile(_builderOptions.LogFilePath);
#endif
            }
        }
    }
}
