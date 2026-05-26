using System;
using GameFrameX.Editor;
using GameFrameX.Runtime;
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE
using GameFrameX.ObjectStorage.Editor;
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_TENCENT
using GameFrameX.ObjectStorage.Tencent.Editor;
#endif
#if ENABLE_GAME_FRAME_X_OBJECT_STORAGE_QI_NIU
using GameFrameX.ObjectStorage.QiNiu.Editor;
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
    }
}
