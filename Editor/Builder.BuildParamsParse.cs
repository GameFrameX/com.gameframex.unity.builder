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
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.LogFilePath = commandLineArgs[index + 1].Replace("/Unity/", "/");
                    }
                }
                else if (commandLineArg == "-executeMethod")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.ExecuteMethod = commandLineArgs[index + 1].Trim();
                    }
                }
                else if (commandLineArg == "-BUILD_NUMBER")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.BuildNumber = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-JOB_NAME")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.JobName = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-ObjectStorageKey")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.ObjectStorageKey = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-ObjectStorageSecret")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.ObjectStorageSecret = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-ObjectStorageBucketName")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.ObjectStorageBucketName = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-ObjectStorageEndPoint")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.ObjectStorageEndPoint = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-PackageName")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.PackageName = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-ChannelName")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.ChannelName = commandLineArgs[index + 1];
                    }
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
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.UpdateAssetPackageVersionUrl = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-UpdateAssetPackageVersionAuthorization")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.UpdateAssetPackageVersionAuthorization = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-Language")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.Language = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-WeChatBotKey")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.WeChatBotKey = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-BundleId")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.BundleId = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-AppVersion")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.AppVersion = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-BuildPipeline")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.BuildPipeline = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-PackageVersion")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.PackageVersion = commandLineArgs[index + 1];
                    }
                }
                else if (commandLineArg == "-BuildinFileCopyOption")
                {
                    if (index + 1 < commandLineArgs.Length)
                    {
                        _builderOptions.BuildinFileCopyOption = commandLineArgs[index + 1];
                    }
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

            AssetDatabase.SaveAssets();
        }
    }
}