// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：NullWorkDataSeesion.cs
// 创建标识：吴来伟 2017-12-19 15:38
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 15:38
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Sessions
{
    /// <summary>
    /// NullWorkDataSeesion
    /// </summary>
    public class NullWorkDataSeesion: WorkDataBaseSession
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static NullWorkDataSeesion Instance { get; } = new NullWorkDataSeesion();

        /// <summary>
        /// UserId
        /// </summary>
        public override string UserId => string.Empty;
    }
}