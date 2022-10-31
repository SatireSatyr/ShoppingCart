using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI
{
    public interface IGetProductQueryHandler
    {
        public Product Handle(long productId);
    }
}
