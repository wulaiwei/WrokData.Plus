// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：PageQueryEntity.cs
// 创建标识：吴来伟 2017-12-07 11:14
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 11:18
// 修改描述：
//  ------------------------------------------------------------------------------

namespace WorkData.Code.BusinessEntities
{
    /// <summary>
    ///     分页实体
    /// </summary>
    public class PageQueryEntity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PageQueryEntity" /> class.
        /// </summary>
        public PageQueryEntity()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
                Sorting = "CreationTime DESC";
        }

        /// <summary>
        ///     Sorting
        /// </summary>
        public string Sorting { get; set; }

        /// <summary>
        ///     SkipCount
        /// </summary>
        public int SkipCount { get; set; }

        /// <summary>
        ///     MaxResultCount
        /// </summary>
        public int MaxResultCount { get; set; }
    }
}