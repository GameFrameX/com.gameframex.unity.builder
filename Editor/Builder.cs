using System;
using GameFrameX.Editor;
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
using GameFrameX.ObjectStorage.Editor;
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_TENCENT
using GameFrameX.ObjectStorage.Tencent.Editor;
#endif
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_QI_NIU
using GameFrameX.ObjectStorage.QiNiu.Editor;
#endif
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_A_LI_YUN
using GameFrameX.ObjectStorage.ALiYun.Editor;
#endif
#endif
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
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
        private static readonly IObjectStorageUploadManager ObjectStorageUploadManager;
#endif
        private static BuilderOptions _builderOptions;

        static Builder()
        {
            BuildParamsParse();
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_QI_NIU
            ObjectStorageUploadManager = ObjectStorageUploadFactory.Create<QiNiuYunObjectStorageUploadManager>(_builderOptions.ObjectStorageKey, _builderOptions.ObjectStorageSecret, _builderOptions.ObjectStorageBucketName, _builderOptions.ObjectStorageEndPoint);
#endif

#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_TENCENT
            ObjectStorageUploadManager = ObjectStorageUploadFactory.Create<TencentCloudObjectStorageUploadManager>(_builderOptions.ObjectStorageKey, _builderOptions.ObjectStorageSecret, _builderOptions.ObjectStorageBucketName, _builderOptions.ObjectStorageEndPoint);
#endif

#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_A_LI_YUN
            ObjectStorageUploadManager = ObjectStorageUploadFactory.Create<ALiYunObjectStorageUploadManager>(_builderOptions.ObjectStorageKey, _builderOptions.ObjectStorageSecret, _builderOptions.ObjectStorageBucketName, _builderOptions.ObjectStorageEndPoint);
#endif
            ObjectStorageUploadManager.SetSavePath($"builder/{PlayerSettings.productName}/{EditorUserBuildSettings.activeBuildTarget.ToString()}/{_builderOptions.JobName}/{Application.version}/{_builderOptions.BuildNumber}");
#endif
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
                else if (commandLineArg == "-executeMethod")
                {
                    _builderOptions.ExecuteMethod = commandLineArgs[index + 1].Trim();
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
                else if (commandLineArg == "-ObjectStorageEndPoint")
                {
                    _builderOptions.ObjectStorageEndPoint = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-PackageName")
                {
                    _builderOptions.PackageName = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-ChannelName")
                {
                    _builderOptions.ChannelName = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-IsIncrementalBuildPackage")
                {
                    _builderOptions.IsIncrementalBuildPackage = true;
                }
                else if (commandLineArg == "-IsUploadLogFile")
                {
                    _builderOptions.IsUploadLogFile = true;
                }
                else if (commandLineArg == "-IsUploadApk")
                {
                    _builderOptions.IsUploadApk = true;
                }
            }

            if (_builderOptions.ExecuteMethod.IsNullOrWhiteSpace())
            {
                throw new Exception("executeMethod is null");
            }

            if (_builderOptions.BuildNumber.IsNullOrWhiteSpace())
            {
                throw new Exception("build number is null");
            }

            if (_builderOptions.LogFilePath.IsNullOrWhiteSpace())
            {
                var split = _builderOptions.ExecuteMethod.Split(new[] { ".", }, StringSplitOptions.RemoveEmptyEntries);
                _builderOptions.LogFilePath = $"../Logs/{split[split.Length - 1]}_{_builderOptions.BuildNumber}.log";
            }

            Debug.Log("-----------构建参数开始-----------");
            Debug.Log(_builderOptions);
            Debug.Log("-----------构建参数结束-----------");
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
            if (_builderOptions.IsUploadApk)
            {
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
                ObjectStorageUploadManager.UploadFile(apkPath);
#endif
            }

            if (_builderOptions.IsUploadLogFile)
            {
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
                ObjectStorageUploadManager.UploadFile(_builderOptions.LogFilePath);
#endif
            }
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
            if (_builderOptions.IsUploadLogFile)
            {
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
                ObjectStorageUploadManager.UploadFile(_builderOptions.LogFilePath);
#endif
            }
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
            bool isSuccess = false;

            try
            {
                pipeline.Run(buildParameters, true);
                isSuccess = true;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Environment.Exit(1);
            }
            finally
            {
                if (_builderOptions.IsUploadLogFile)
                {
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
                    ObjectStorageUploadManager.UploadFile(_builderOptions.LogFilePath);
#endif
                }

                if (isSuccess)
                {
                    if (_builderOptions.IsUploadAsset)
                    {
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
                        ObjectStorageUploadManager.SetSavePath($"Bundles/{PlayerSettings.applicationIdentifier}/{EditorUserBuildSettings.activeBuildTarget.ToString()}/{Application.version}/{_builderOptions.ChannelName}/{_builderOptions.PackageName}/{buildParameters.PackageVersion}");
                        ObjectStorageUploadManager.UploadDirectory($"{buildParameters.BuildOutputRoot}/{buildParameters.PackageVersion}");
#endif
                    }
                }
            }
        }
    }
}