// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.EntityFramework
// 文件名：WorkDataContext.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//  
// 修改标识：吴来伟2018-01-19 13:49
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Domain.Core.Contents;
using Domain.EntityFramework.AuditRules;
using Domain.EntityFramework.Mappings.Contents;
using WorkData.Code.Entities.BaseInterfaces;
using WorkData.EntityFramework;

#endregion

namespace Domain.EntityFramework.EntityFramework
{
    /// <summary>
    ///     WorkDataContext
    /// </summary>
    public class WorkDataContext : WorkDataBaseDbContext
    {
        /// <summary>
        ///     AuditRuleConfigs
        /// </summary>
        public static List<AuditRuleConfig> AuditRuleConfigs;

        public WorkDataContext()
            : base("WorkDataContext")
        {
        }

        #region Cms

        /// <summary>
        ///     There are no comments for Category in the schema.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        ///     There are no comments for Content in the schema.
        /// </summary>
        public DbSet<Content> Contents { get; set; }

        /// <summary>
        ///     There are no comments for ContentDescriptionField in the schema.
        /// </summary>
        public DbSet<ContentDescriptionField> ContentDescriptionFields { get; set; }

        /// <summary>
        ///     There are no comments for ContentDoubleField in the schema.
        /// </summary>
        public DbSet<ContentDoubleField> ContentDoubleFields { get; set; }

        /// <summary>
        ///     There are no comments for ContentIntField in the schema.
        /// </summary>
        public DbSet<ContentIntField> ContentIntFields { get; set; }

        /// <summary>
        ///     There are no comments for ContentStringField in the schema.
        /// </summary>
        public DbSet<ContentStringField> ContentStringFields { get; set; }

        /// <summary>
        ///     There are no comments for ContentTextField in the schema.
        /// </summary>
        public DbSet<ContentTextField> ContentTextFields { get; set; }

        /// <summary>
        ///     There are no comments for ContentTimeField in the schema.
        /// </summary>
        public DbSet<ContentTimeField> ContentTimeFields { get; set; }

        /// <summary>
        ///     There are no comments for Model in the schema.
        /// </summary>
        public DbSet<Model> Models { get; set; }

        /// <summary>
        ///     There are no comments for ModelField in the schema.
        /// </summary>
        public DbSet<ModelField> ModelFields { get; set; }

        public int AuditRuleEvent { get; private set; }

        #endregion

        /// <summary>
        ///     WorkDataContext
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public WorkDataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Configuration.AutoDetectChangesEnabled = true; //对多对多，一对多进行curd操作时需要为true
            Configuration.LazyLoadingEnabled = false;

            //this.Configuration.AutoDetectChangesEnabled = false;//禁止状态追踪
            //this.Configuration.ProxyCreationEnabled = false;//禁止动态拦截System.Data.Entity.DynamicProxies.
            //自动创建表，如果Entity有改到就更新到表结构
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbEntity, Configuration>());
            Database.SetInitializer<WorkDataContext>(null);
        }

        /// <summary>
        ///     重写模型创建函数
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //默认移除级联删除
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //移除复数表名的契约

            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ContentConfiguration());
            modelBuilder.Configurations.Add(new ContentDescriptionFieldConfiguration());
            modelBuilder.Configurations.Add(new ContentDoubleFieldConfiguration());
            modelBuilder.Configurations.Add(new ContentIntFieldConfiguration());
            modelBuilder.Configurations.Add(new ContentStringFieldConfiguration());
            modelBuilder.Configurations.Add(new ContentTextFieldConfiguration());
            modelBuilder.Configurations.Add(new ContentTimeFieldConfiguration());
            modelBuilder.Configurations.Add(new ModelConfiguration());
            modelBuilder.Configurations.Add(new ModelFieldConfiguration());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            //add auditrule
            AuditRuleConfigs = new List<AuditRuleConfig>();
            InitAuditRuleConfigs();
            //审计
            AttachAuditRule();

            return base.SaveChanges();
        }

        /// <summary>
        ///     GetAuditUserId
        /// </summary>
        /// <returns></returns>
        protected virtual string GetAuditUserId()
        {
            return !string.IsNullOrEmpty(WorkDataSession?.UserId)
                ? WorkDataSession.UserId
                : null;
        }


        /// <summary>
        ///     AttachAuditRule
        /// </summary>
        protected virtual void AttachAuditRule()
        {
            var ctx = ((IObjectContextAdapter) this).ObjectContext;

            var objectStateEntryList = ctx.ObjectStateManager
                .GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted)
                .ToList();

            foreach (var entry in objectStateEntryList)
            {
                if (entry.IsRelationship) continue;
                switch (entry.State)
                {
                    case EntityState.Added:
                        ExecuteAuditRule(entry.Entity, EntityState.Added);
                        break;
                    case EntityState.Deleted:
                        ExecuteAuditRule(entry.Entity, EntityState.Deleted);
                        break;
                    case EntityState.Modified:
                        ExecuteAuditRule(entry.Entity, EntityState.Modified);
                        break;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityState"></param>
        public void ExecuteAuditRule(object entity, EntityState entityState)
        {
            var addAuditRules = LoadAuditRuleConfigs(entityState);
            foreach (var addAuditRule in addAuditRules)
            {
                addAuditRule.AuditRuleAction(entity);
            }
        }

        /// <summary>
        ///     LoadAuditRuleConfigs
        /// </summary>
        /// <param name="entityState"></param>
        /// <returns></returns>
        public List<AuditRuleConfig> LoadAuditRuleConfigs(EntityState entityState)
        {
            return AuditRuleConfigs
                .Where(x => x.EntityState == entityState).ToList();
        }

        #region 审计业务方法

        /// <summary>
        ///     InitAuditRuleConfigs
        /// </summary>
        public void InitAuditRuleConfigs()
        {
            var createAction = new AuditRuleConfig
            {
                AuditRuleAction = JudgeAndSetCreate,
                EntityState = EntityState.Added
            };
            AuditRuleConfigs.Add(createAction);

            var updateAction = new AuditRuleConfig
            {
                AuditRuleAction = JudgeAndSetUpdate,
                EntityState = EntityState.Modified
            };

            AuditRuleConfigs.Add(updateAction);
        }

        /// <summary>
        ///     JudgeAndSetUpdate
        /// </summary>
        /// <param name="entityAsObj"></param>
        public virtual void JudgeAndSetUpdate(object entityAsObj)
        {
            var addedEntity = entityAsObj as IModifier;
            if (addedEntity == null) return;

            var userId = GetAuditUserId();
            addedEntity.ModifierTime = DateTime.Now;
            addedEntity.ModifierUserId = userId;
        }

        /// <summary>
        ///     JudgeAndSetCreate
        /// </summary>
        /// <param name="entityAsObj"></param>
        public virtual void JudgeAndSetCreate(object entityAsObj)
        {
            var addedEntity = entityAsObj as ICreate;
            if (addedEntity == null) return;

            var userId = GetAuditUserId();
            addedEntity.CreateTime = DateTime.Now;
            addedEntity.CreateUserId = userId;
        }

        #endregion
    }
}