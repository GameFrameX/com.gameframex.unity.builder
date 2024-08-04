using System;
using GameFrameX.Editor;
using GameFrameX.ObjectStorage.Editor;
using GameFrameX.ObjectStorage.QiNiu.Editor;
using HybridCLR.Editor.Commands;
using HybridCLR.Editor.Installer;
using UnityEditor;
using UnityEngine;
using YooAsset.Editor;

namespace GameFrameX.Builder.Editor
{
    /// <summary>
    /// 自动化构建
    /// </summary>
    public static class Builder
    {
        private static readonly IObjectStorageUploadManager ObjectStorageUploadManager;

        private static BuilderOptions _builderOptions;

        static Builder()
        {
            BuildParamsParse();
            ObjectStorageUploadManager = ObjectStorageUploadFactory.Create<QiNiuYunObjectStorageUploadManager>(_builderOptions.ObjectStorageKey, _builderOptions.ObjectStorageSecret, _builderOptions.ObjectStorageBucketName);
            ObjectStorageUploadManager.SetSavePath($"builder/{PlayerSettings.productName}/{EditorUserBuildSettings.activeBuildTarget.ToString()}/{_builderOptions.JobName}/{Application.version}/{_builderOptions.BuildNumber}");
        }


        /// <summary>
        /// 参数构建
        /// </summary>
        private static void BuildParamsParse()
        {
            var commandLineArgs = Environment.GetCommandLineArgs();
            _builderOptions = new BuilderOptions();
            for (var index = 0; index < commandLineArgs.Length; index++)
            {
                var commandLineArg = commandLineArgs[index];
                if (commandLineArg == "-logFile")
                {
                    _builderOptions.LogFilePath = commandLineArgs[index + 1].Replace("/Unity/", "/");
                }
                else if (commandLineArg == "-BUILD_NUMBER")
                {
                    _builderOptions.BuildNumber = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-JOB_NAME")
                {
                    _builderOptions.JobName = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-ObjectStorageKey")
                {
                    _builderOptions.ObjectStorageKey = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-ObjectStorageSecret")
                {
                    _builderOptions.ObjectStorageSecret = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-ObjectStorageBucketName")
                {
                    _builderOptions.ObjectStorageBucketName = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-PackageName")
                {
                    _builderOptions.PackageName = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-IsIncrementalBuildPackage")
                {
                    _builderOptions.IsIncrementalBuildPackage = Convert.ToBoolean(commandLineArgs[index + 1]);
                }
            }

            Debug.Log(_builderOptions);
        }

        public static void BuildDouYin()
        {
            /*StarkSDKTool.StarkBuilderSettings.Instance.webGLOutputDir = "./../build/" + EditorUserBuildSettings.activeBuildTarget + "/";
            StarkSDKTool.StarkBuilderSettings.Instance.Save();
            StarkSDKTool.Builder.BuildWebGL(StarkSDKTool.StarkBuilderSettings.Instance, "./../build/" + EditorUserBuildSettings.activeBuildTarget + "/" + Application.version, out var isCancelBuild);
            Debug.Log("isCancelBuild:" + isCancelBuild);*/
        }

        /// <summary>
        /// 发布Apk
        /// </summary>
        public static void BuildApk()
        {
            var apkPath = BuildProductHelper.BuildPlayerAndroid();
            ObjectStorageUploadManager.UploadFile(apkPath);
            ObjectStorageUploadManager.UploadFile(_builderOptions.LogFilePath);
        }

        /// <summary>
        /// 打包准备
        /// </summary>
        public static void BuildReady()
        {
            var installerController = new InstallerController();
            if (!installerController.HasInstalledHybridCLR())
            {
                installerController.InstallDefaultHybridCLR();
            }

            // 复制热更新程序集
            BuildHotfixHelper.CopyHotfixCode();
            // 构建热更新代理
            PrebuildCommand.GenerateAll();
            // 复制AOT代码
            BuildHotfixHelper.CopyAOTCode();
            ObjectStorageUploadManager.UploadFile(_builderOptions.LogFilePath);
        }

        /// <summary>
        /// 打包资源
        /// </summary>
        public static void BuildAsset()
        {
            var buildInFileCopyParams = AssetBundleBuilderSetting.GetPackageBuildinFileCopyParams(_builderOptions.PackageName, EBuildPipeline.BuiltinBuildPipeline);
            BuiltinBuildPipeline pipeline = new BuiltinBuildPipeline();
            BuildParameters buildParameters = new BuiltinBuildParameters();
            buildParameters.BuildMode = _builderOptions.IsIncrementalBuildPackage ? EBuildMode.IncrementalBuild : EBuildMode.ForceRebuild;
            buildParameters.BuildTarget = EditorUserBuildSettings.activeBuildTarget;
            buildParameters.PackageVersion = DateTime.Now.ToString("yyyyMMddHHmmss");
            buildParameters.VerifyBuildingResult = true;
            buildParameters.BuildinFileCopyOption = EBuildinFileCopyOption.ClearAndCopyAll;
            buildParameters.FileNameStyle = EFileNameStyle.HashName;
            buildParameters.BuildOutputRoot = AssetBundleBuilderHelper.GetDefaultBuildOutputRoot();
            buildParameters.BuildinFileRoot = AssetBundleBuilderHelper.GetStreamingAssetsRoot();
            buildParameters.BuildPipeline = EBuildPipeline.BuiltinBuildPipeline.ToString();
            buildParameters.PackageName = _builderOptions.PackageName;
            buildParameters.EnableSharePackRule = true;
            buildParameters.BuildinFileCopyParams = buildInFileCopyParams;
            buildParameters.EncryptionServices = new EncryptionNone();
            try
            {
                pipeline.Run(buildParameters, true);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Environment.Exit(1);
            }
            finally
            {
                ObjectStorageUploadManager.UploadFile(_builderOptions.LogFilePath);
            }
        }
    }
}