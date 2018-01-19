﻿// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.EntityFramework
// 文件名：CreateAuditable.cs
// 创建标识：吴来伟 2017-12-21 15:52
// 创建描述：
//  
// 修改标识：吴来伟2017-12-21 15:52
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using WorkData.Code.Entities.BaseInterfaces;
using WorkData.Code.Extensions;
using WorkData.Code.Sessions;

namespace WorkData.EntityFramework.Auditables
{
    /// <summary>
    /// CreateAuditable
    /// </summary>
    public class CreateAuditable : IAuditable
    {
        public void AttemptSetEntityProperty(object entityAsObj, IWorkDataSession workDataSession)
        {
            var entity = entityAsObj.As<ICreate>();

            //Don't set if it's already set
            if (string.IsNullOrEmpty(entity.CreateUserId))
            {
                entity.CreateUserId = workDataSession.UserId;
            }

            entity.CreateTime = DateTime.Now;

        }
    }
}