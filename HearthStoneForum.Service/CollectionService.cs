﻿using HearthStoneForum.IRepository;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Service
{
    public class CollectionService : BaseService<Collection>, ICollectionService
    {
        private readonly ICollectionRepository _iCollectionRepository;
        public CollectionService(ICollectionRepository iCollectionRepository)
        {
            base._iBaseRepository = iCollectionRepository;
            _iCollectionRepository = iCollectionRepository;
        }
    }
}
