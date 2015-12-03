﻿using System;
using System.Collections.Generic;

namespace CharacterGen.Mappers.Domain.Collections
{
    public class CollectionsMapperCachingProxy : ICollectionsMapper
    {
        private ICollectionsMapper innerMapper;
        private Dictionary<String, Dictionary<String, IEnumerable<String>>> cachedTables;

        public CollectionsMapperCachingProxy(ICollectionsMapper innerMapper)
        {
            this.innerMapper = innerMapper;
            cachedTables = new Dictionary<String, Dictionary<String, IEnumerable<String>>>();
        }

        public Dictionary<String, IEnumerable<String>> Map(String tableName)
        {
            if (cachedTables.ContainsKey(tableName) == false)
                cachedTables[tableName] = innerMapper.Map(tableName);

            return cachedTables[tableName];
        }
    }
}