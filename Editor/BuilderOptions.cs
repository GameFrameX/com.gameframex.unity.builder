using Newtonsoft.Json;

namespace GameFrameX.Builder.Editor
{
    internal sealed class BuilderOptions
    {
        /// <summary>
        /// 日志文件路径
        /// </summary>
        public string LogFilePath { get; set; } = string.Empty;

        /// <summary>
        /// 构建号
        /// </summary>
        public string BuildNumber { get; set; } = string.Empty;

        /// <summary>
        /// 对象存储的Key
        /// </summary>
        public string ObjectStorageKey { get; set; } = string.Empty;

        /// <summary>
        /// 对象存储的秘钥
        /// </summary>
        public string ObjectStorageSecret { get; set; } = string.Empty;

        /// <summary>
        /// 对象存储桶的名称
        /// </summary>
        public string ObjectStorageBucketName { get; set; } = string.Empty;

        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName { get; set; } = string.Empty;

        /// <summary>
        /// 资源包名称
        /// </summary>
        public string PackageName { get; set; } = string.Empty;

        /// <summary>
        /// 是否使用增量构建的方式构建
        /// </summary>
        public bool IsIncrementalBuildPackage { get; set; } = false;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}