// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Net.Http;
using System.Text;
using YooAsset.Editor;

namespace GameFrameX.Builder.Editor
{
    /// <summary>
    /// 企业微信通知
    /// </summary>
    internal static class WeChatNotifyWorkHelper
    {
        public static void Run(BuildParameters buildParameters, BuilderOptions builderOptions)
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={builderOptions.WeChatBotKey}";

                // 构建Markdown消息内容
                var content = $@"{{
         ""msgtype"": ""markdown"",
         ""markdown"": {{
             ""content"": ""### 游戏资源版本更新\n> 时间：{DateTime.Now:yyyy-MM-dd HH:mm:ss}\n> 资源版本:{buildParameters.PackageVersion}\n> 游戏版本:{UnityEngine.Application.version} \n>游戏包名:{UnityEngine.Application.identifier}  \n> 资源包名:{buildParameters.PackageName} \n> 资源平台:{buildParameters.BuildTarget.ToString()} \n> 渠道:{builderOptions.ChannelName} \n> 资源语言:{builderOptions.Language}\n""
         }}
     }}";
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                try
                {
                    // 使用同步方式发送HTTP请求
                    var httpResponseMessage = httpClient.PostAsync(url, stringContent).GetAwaiter().GetResult();
                    Console.WriteLine(httpResponseMessage.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}