using System;
using GameFrameX.Editor;
using UnityEditor;
using UnityEngine;
using YooAsset;
using YooAsset.Editor;

namespace GameFrameX.Builder.Editor
{
    public static partial class Builder
    {
        /// <summary>
        /// 打包资源
        /// </summary>
        public static void BuildAsset()
        {
            // 复制热更新程序集
            Debug.Log("BuildReady Start Copy Hotfix Code");
            BuildHotfixHelper.CopyHotfixCode();
            AssetDatabase.Refresh();
            Debug.Log("BuildReady End Copy Hotfix Code");

            // 复制AOT代码
            Debug.Log("BuildReady Start Copy AOT Code");
            BuildHotfixHelper.CopyAOTCode();
            AssetDatabase.Refresh();
            Debug.Log("BuildReady End Copy AOT Code");

            Debug.Log("BuildAsset");
            {
                // 修改资源包文件名的大小写不敏感为true
                foreach (var assetBundleCollectorPackage in AssetBundleCollectorSettingData.Setting.Packages)
                {
                    assetBundleCollectorPackage.LocationToLower = true;
                }

                AssetBundleCollectorSettingData.SaveFile();
            }

            var buildPipeline = (EBuildPipeline)Enum.Parse(typeof(EBuildPipeline), _builderOptions.BuildPipeline, true);
            var buildInFileCopyParams = AssetBundleBuilderSetting.GetPackageBuildinFileCopyParams(_builderOptions.PackageName, buildPipeline);
            IBuildPipeline pipeline;
            BuildParameters buildParameters;
            switch (buildPipeline)
            {
                case EBuildPipeline.ScriptableBuildPipeline:
                    pipeline = new ScriptableBuildPipeline();
                    buildParameters = new ScriptableBuildParameters();
                    break;
                case EBuildPipeline.RawFileBuildPipeline:
                    pipeline = new RawFileBuildPipeline();
                    buildParameters = new RawFileBuildParameters();
                    break;
                default:
                    pipeline = new BuiltinBuildPipeline();
                    buildParameters = new BuiltinBuildParameters();
                    break;
            }
            buildParameters.BuildMode = _builderOptions.IsIncrementalBuildPackage ? EBuildMode.IncrementalBuild : EBuildMode.ForceRebuild;
            buildParameters.BuildTarget = EditorUserBuildSettings.activeBuildTarget;
            buildParameters.PackageVersion = DateTime.Now.ToString("yyyyMMddHHmmss");
            buildParameters.VerifyBuildingResult = true;
            buildParameters.BuildinFileCopyOption = EBuildinFileCopyOption.ClearAndCopyAll;
            buildParameters.FileNameStyle = EFileNameStyle.HashName;
            buildParameters.BuildOutputRoot = AssetBundleBuilderHelper.GetDefaultBuildOutputRoot();
            buildParameters.BuildinFileRoot = AssetBundleBuilderHelper.GetStreamingAssetsRoot();
            buildParameters.BuildPipeline = buildPipeline.ToString();
            buildParameters.PackageName = _builderOptions.PackageName;
            buildParameters.EnableSharePackRule = true;
            buildParameters.BuildinFileCopyParams = buildInFileCopyParams;
            buildParameters.EncryptionServices = new EncryptionNone();
            bool isSuccess = false;

            try
            {
                pipeline.Run(buildParameters, true);
                Debug.Log("BuildAsset End");
                isSuccess = true;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Environment.Exit(1);
            }
            finally
            {
                Debug.Log($"BuildAsset Finally IsSuccess={isSuccess}");
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
                        Debug.Log($"开始上传资源包=>{buildParameters.PackageName}--{buildParameters.PackageVersion}");
                        string savePath = $"Bundles/{PlayerSettings.applicationIdentifier}/{EditorUserBuildSettings.activeBuildTarget.ToString()}/{Application.version}/{_builderOptions.ChannelName}/{_builderOptions.PackageName}/{buildParameters.PackageVersion}";
                        string uploadPath = $"{buildParameters.BuildOutputRoot}/{buildParameters.BuildTarget.ToString()}/{Application.version}/{buildParameters.PackageName}/{buildParameters.PackageVersion}";
                        Debug.Log($"资源包存储路径=>{savePath}");
                        Debug.Log($"资源包上传路径=>{uploadPath}");
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
                        ObjectStorageUploadManager.SetSavePath(savePath);
                        ObjectStorageUploadManager.UploadDirectory(uploadPath);
#endif
                        Debug.Log($"结束上传资源包=>{buildParameters.PackageName}--{buildParameters.PackageVersion}");
                    }

                    if (_builderOptions.IsUpdateAssetPackageVersion)
                    {
                        var result = BuilderUpdateAssetPackageVersionHelper.Run(buildParameters, _builderOptions);
                        if (result)
                        {
                            WeChatNotifyWorkHelper.Run(buildParameters, _builderOptions);
                        }
                    }
                }
            }
        }
    }
}
