using System.Collections.Generic;
using System.Linq;

using DAL.Entities;

using Forms.PositionWCF;

namespace Forms.Controllers
{
    public static class CafeController
    {
        public static List<PositionModel> GetPositions(this WcfPositionServiceClient service, int dbId)
        {
            return service.GetAll(dbId).ToList();
        }

        public static void Admission(this WcfPositionServiceClient service, int dbId, PositionModel position)
        {
            var pos = service.GetAll(dbId)
                .FirstOrDefault(p => p.Name.Equals(position.Name) && p.Cost.Equals(position.Cost));

            if (pos != null)
            {
                pos.Amount += position.Amount;

                service.Update(pos, dbId);
            }
            else
                service.Create(position, dbId);
        }

        public static void SellPositions(this WcfPositionServiceClient service, int dbId, string name, int amount)
        {
            var position = service.GetAll(dbId).FirstOrDefault(p => p.Name.Equals(name));

            if (position == null)
                return;

            if (position.Amount >= amount)
            {
                position.Amount -= amount;
                if (position.Amount > 0)
                    service.Update(position, dbId);

                if (position.Amount == 0)
                    service.Delete(position.Id, dbId);
            }
        }
    }
}