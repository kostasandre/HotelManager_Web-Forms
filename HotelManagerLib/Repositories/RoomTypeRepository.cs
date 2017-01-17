using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLib.Repositories
{
    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories.Interfaces;
    public class RoomTypeRepository : IEntityRepository<RoomType>
    {
        public RoomType Create(RoomType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<RoomType> ReadAllList()
        {
            throw new NotImplementedException();
        }

        public IQueryable<RoomType> ReadAllQuery(DataBaseContext context)
        {
            throw new NotImplementedException();
        }

        public RoomType ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RoomType entity)
        {
            throw new NotImplementedException();
        }
    }
}
