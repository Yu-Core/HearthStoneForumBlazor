using HearthStoneForum.IRepository;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Service
{
    public class CarouselService : BaseService<Carousel>, ICarouselService
    {
        private readonly ICarouselRepository _iCarouselRepository;
        public CarouselService(ICarouselRepository iCarouselRepository)
        {
            base._iBaseRepository = iCarouselRepository;
            this._iCarouselRepository = iCarouselRepository;
        }
    }
}
