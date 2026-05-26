using System;
using GameFrameX.Runtime;
using UnityEditor;
using UnityEngine;

namespace GameFrameX.Builder.Editor
{
    public static partial class Builder
    {
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
                else if (commandLineArg == "-IsUploadAsset")
                {
                    _builderOptions.IsUploadAsset = true;
                }
                else if (commandLineArg == "-IsUploadApk")
                {
                    _builderOptions.IsUploadApk = true;
                }
                else if (commandLineArg == "-IsUpdateAssetPackageVersion")
                {
                    _builderOptions.IsUpdateAssetPackageVersion = true;
                }
                else if (commandLineArg == "-UpdateAssetPackageVersionUrl")
                {
                    _builderOptions.UpdateAssetPackageVersionUrl = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-UpdateAssetPackageVersionAuthorization")
                {
                    _builderOptions.UpdateAssetPackageVersionAuthorization = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-Language")
                {
                    _builderOptions.Language = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-WeChatBotKey")
                {
                    _builderOptions.WeChatBotKey = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-BundleId")
                {
                    _builderOptions.BundleId = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-AppVersion")
                {
                    _builderOptions.AppVersion = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-BuildPipeline")
                {
                    _builderOptions.BuildPipeline = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-PackageVersion")
                {
                    _builderOptions.PackageVersion = commandLineArgs[index + 1];
                }
                else if (commandLineArg == "-BuildinFileCopyOption")
                {
                    _builderOptions.BuildinFileCopyOption = commandLineArgs[index + 1];
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
            if (!_builderOptions.BundleId.IsNullOrWhiteSpace())
            {
                PlayerSettings.applicationIdentifier = _builderOptions.BundleId.Trim();
            }

            if (!_builderOptions.AppVersion.IsNullOrWhiteSpace())
            {
                PlayerSettings.bundleVersion = _builderOptions.AppVersion.Trim();
            }
        }
    }
}
