// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using YooAsset.Editor;

namespace GameFrameX.Builder.Editor
{
    /// <summary>
    /// 资源包版本更新
    /// </summary>
    internal sealed class BuilderUpdateAssetPackageVersionHelper
    {
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="buildParameters"></param>
        /// <param name="builderOptions"></param>
        public static bool Run(BuildParameters buildParameters, BuilderOptions builderOptions)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", builderOptions.UpdateAssetPackageVersionAuthorization);
                var url = builderOptions.UpdateAssetPackageVersionUrl;

                AssetPackageVersionRequest content = new AssetPackageVersionRequest
                {
                    AppVersion = Application.version,
                    PackageName = Application.identifier,
                    AssetPackageVersion = buildParameters.PackageVersion,
                    AssetPackageName = buildParameters.PackageName,
                    Platform = buildParameters.BuildTarget.ToString(),
                    Language = builderOptions.Language,
                    Channel = builderOptions.ChannelName,
                };

                var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                try
                {
                    // 使用同步方式发送HTTP请求
                    var httpResponseMessage = httpClient.PostAsync(url, stringContent).GetAwaiter().GetResult();
                    var response = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Debug.Log(response);
                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }

            return false;
        }

        /// <summary>
        /// 请求参数
        /// </summary>
        private sealed class AssetPackageVersionRequest
        {
            /// <summary>
            /// 语言
            /// </summary>
            public string Language { get; set; }

            /// <summary>
            /// 资源包名称
            /// </summary>
            public string AssetPackageName { get; set; }

            /// <summary>
            /// 平台
            /// </summary>
            public string Platform { get; set; }

            /// <summary>
            /// 包名
            /// </summary>
            public string PackageName { get; set; }

            /// <summary>
            /// 程序版本
            /// </summary>
            public string AppVersion { get; set; }

            /// <summary>
            /// 渠道
            /// </summary>
            public string Channel { get; set; }

            /// <summary>
            /// 资源包版本
            /// </summary>
            public string AssetPackageVersion { get; set; }
        }
    }
}