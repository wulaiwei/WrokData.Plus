// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Test
// 文件名：ElasticsearchTest.cs
// 创建标识：吴来伟 2018-01-04 9:29
// 创建描述：
//  
// 修改标识：吴来伟2018-01-09 16:51
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;
using WorkData.Code.Elasticsearchs;
using WorkData.Test.TestEntity;

#endregion

namespace WorkData.Test
{
    [TestClass]
    public class ElasticsearchTest
    {
        private readonly ElasticsearchProvider _provider = new ElasticsearchProvider();

        /// <summary>
        ///     Index
        /// </summary>
        [TestMethod]
        public void Index()
        {
            var child = new Person
            {
                Id=109,
                Content = "child",
                CreateTime = DateTime.Now,
                Description = "的撒发射点发撒打发是child",
                IsManager = true,
                Name = "初六child"
            };
            var preson = new Person
            {
                Id = 2,
                Content = "asdfakjs.hdfasdf啊实打实地方",
                CreateTime = DateTime.Now,
                Description = "的撒发射点发撒打发是",
                IsManager = true,
                Name = "初六",
                Childs=new List<Person>()
                {
                    child
                }
            };
            _provider.Index(preson, "preson");
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void Search()
        {
            var searchRequest = new SearchRequest<Person>("preson", "person")
            {
                Query = new TermQuery {Field = "name", Value = "六"}
            };

            var list = _provider.SearchPage(searchRequest);
        }

        /// <summary>
        ///     高亮
        /// </summary>
        [TestMethod]
        public void HighLigter()
        {
            var searchRequest = new SearchRequest<Person>("preson", "person")
            {
                Query = new TermQuery {Field = "name", Value = "六"},
                Highlight = new Highlight
                {
                    PreTags = new[] {"<p class=\"c_color\">"},
                    PostTags = new[] {"</p>"},
                    Encoder = "html",
                    Fields = new Dictionary<Field, IHighlightField>
                    {
                        {
                            "name", new HighlightField()
                        }
                    }
                }
            };
            var list = _provider.SearchPage(searchRequest);

            var data = list.Hits.Select(c => new Person
            {
                Id = c.Source.Id,
                Name = string.Join("", c.Highlights["name"].Highlights.FirstOrDefault()) //高亮显示的内容，一条记录中出现了几次
            }).ToList();
        }

        /// <summary>
        /// PostFilter
        /// </summary>
        [TestMethod]
        public void PostFilter()
        {
            var searchRequest = new SearchRequest<Person>("preson", "person")
            {
                PostFilter = new TermQuery { Field = "name", Value = "六" }
            };

            var list = _provider.SearchPage(searchRequest);

        }

        /// <summary>
        /// Sort
        /// </summary>
        [TestMethod]
        public void Sort()
        {
            var searchRequest = new SearchRequest<Person>("preson", "person")
            {
                Sort = new List<ISort>
                {
                    new SortField{ Field="id",Order=SortOrder.Descending}
                }
            };

            var list = _provider.SearchPage(searchRequest);
        }

        [TestMethod]
        public void SizeFrom()
        {
            var searchRequest = new SearchRequest<Person>("preson", "person")
            {
                Size=1,
                From=0
            };

            var list = _provider.SearchPage(searchRequest);
        }

        [TestMethod]
        public void AllIndexType()
        {
            var searchRequest = new SearchRequest<Person>(Indices.AllIndices,Types.AllTypes)
            {
                Size = 1,
                From = 0
            };
            var list = _provider.SearchPage(searchRequest);
        }

        [TestMethod]
        public void TestKey()
        {
            var role = new TestEntity.Role()
            {
                Code="Administrator",
                Name="超级管理员",
                Key="0001-0001-0001"
            };
            _provider.Index(role,"role");
        }

        [TestMethod]
        public void AliasAdd()
        {
            var request = new BulkAliasRequest
            {
                Actions = new IAliasAction[]
                {
                    new AliasAddAction
                    {
                        Add = new AliasAddOperation { Index = "role", Alias = "role_alias" ,Filter=new TermQuery()
                        {
                            Field="name",
                            Value="超级管理员"
                        }}
                    }
                }
            };
            _provider.Alias(request);
        }

        [TestMethod]
        public void AliasRemove()
        {
            var request = new BulkAliasRequest
            {
                Actions = new IAliasAction[]
                {
                    new AliasRemoveAction
                    {
                        Remove=new AliasRemoveOperation
                        {
                            Index="role",
                            Alias = "role_alias"
                        }
                    }
                }
            };
            _provider.Alias(request);
        }
    }
}