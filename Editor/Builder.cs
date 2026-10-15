using System;
using GameFrameX.Editor;
using GameFrameX.Runtime;
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
using GameFrameX.ObjectStorage.Runtime;
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_TENCENT
using GameFrameX.ObjectStorage.Tencent.Runtime;
#endif
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_QI_NIU
using GameFrameX.ObjectStorage.QiNiu.Runtime;
#endif
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_A_LI_YUN
using GameFrameX.ObjectStorage.ALiYun.Runtime;
#endif
#endif
using UnityEditor;
using UnityEngine;
using YooAsset;

namespace GameFrameX.Builder.Editor
{
    /// <summary>
    /// 自动化构建
    /// </summary>
    public static partial class Builder
    {
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
        private static readonly IObjectStorageManager ObjectStorageManager;
#endif
        private static BuilderOptions _builderOptions;

        static Builder()
        {
            BuildParamsParse();
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
            ObjectStorageOptions objectStorageOptions = new ObjectStorageOptions
            {
                AccessKey = _builderOptions.ObjectStorageKey,
                SecretKey = _builderOptions.ObjectStorageSecret,
                BucketName = _builderOptions.ObjectStorageBucketName,
                Endpoint = _builderOptions.ObjectStorageEndPoint,
                SavePath = $"builder/{PlayerSettings.productName}/{EditorUserBuildSettings.activeBuildTarget.ToString()}/{_builderOptions.JobName}/{Application.version}/{_builderOptions.BuildNumber}"
            };

#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_QI_NIU
            ObjectStorageManager = ObjectStorageManagerFactory.Create<QiNiuYunObjectStorageManager>(objectStorageOptions);
#endif

#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_TENCENT
            ObjectStorageManager = ObjectStorageManagerFactory.Create<TencentCloudObjectStorageManager>(objectStorageOptions);
#endif

#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_A_LI_YUN
            ObjectStorageManager = ObjectStorageManagerFactory.Create<ALiYunObjectStorageManager>(objectStorageOptions);
#endif
#endif
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
                ObjectStorageManager.UploadFile(new ObjectStorageUploadOptions { LocalPath = apkPath });
#endif
            }

            if (_builderOptions.IsUploadLogFile)
            {
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
                ObjectStorageManager.UploadFile(new ObjectStorageUploadOptions { LocalPath = _builderOptions.LogFilePath });
#endif
            }
        }
    }
}
