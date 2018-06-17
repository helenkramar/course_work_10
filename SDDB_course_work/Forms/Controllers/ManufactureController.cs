using System;
using System.Collections.Generic;
using System.Linq;

using DAL.Entities;

using Forms.PositionWCF;

namespace Forms.Controllers
{
    public static class ManufactureController
    {
        public static List<PositionModel> GetPositions(this WcfPositionServiceClient service, int dbId)
        {
            return service.GetAll(dbId).ToList();
        }

        public static List<string> GetDesserts()
        {
            return Enum.GetNames(typeof(Desserts)).ToList();
        }

        public static void AddPositions(this WcfPositionServiceClient service, int dbId, string name, int amount, double cost)
        {
            var position = ManufactureController.GetPositions(service, dbId).FirstOrDefault(p => p.Name.Equals(name) && p.Cost.Equals(cost));

            if (position != null)
            {
                position.Amount += amount; 

               service.Update(position, dbId);
            }
            else
            {
                position = new PositionModel
                {
                    Name = name,
                    Amount = amount,
                    Cost = cost
                };

                service.Create(position, dbId);
            }
        }

        public static void SendPositions(this WcfPositionServiceClient service, int dbIdFrom, int dbIdTo, string name, int amount, double cost)
        {
            WriteOff(service, dbIdFrom, name, amount, cost);
            
            service.Admission(dbIdTo, new PositionModel
            {
                Name = name,
                Amount = amount,
                Cost = cost
            });
        }

        private static void WriteOff(WcfPositionServiceClient service, int dbId, string name, int amount, double cost)
        {
            var position = service.GetAll(dbId).FirstOrDefault(p => p.Name.Equals(name) && p.Cost.Equals(cost));

            if(position == null)
                return;

            if (position.Amount >= amount)
            {
                position.Amount -= amount;
                service.Update(position, dbId);
            }
            else
                service.Delete(position.Id, dbId);
        }
    }
}