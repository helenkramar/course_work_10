using System;
using System.Collections.Generic;
using System.Linq;

using DAL.Entities;

using BLL.Services;

namespace Forms.Controllers
{
    public static class ManufactureController
    {
        public static List<Position> GetPositions(this PositionService service, int dbId)
        {
            return service.GetAll(dbId).ToList();
        }

        public static List<string> GetDesserts()
        {
            return Enum.GetNames(typeof(Desserts)).ToList();
        }

        public static void AddPositions(this PositionService service, int dbId, string name, int amount, double cost)
        {
            var position = ManufactureController.GetPositions(service, dbId).FirstOrDefault(p => p.Name.Equals(name) && p.Cost.Equals(cost));

            if (position != null)
            {
                position.Amount += amount; 

               service.Update(position, dbId);
            }
            else
            {
                position = new Position
                {
                    Name = name,
                    Amount = amount,
                    Cost = cost
                };

                service.Create(position, dbId);
            }
        }

        public static void SendPositions(this PositionService service, int dbIdFrom, int dbIdTo, string name, int amount, double cost)
        {
            WriteOff(service, dbIdFrom, name, amount, cost);
            
            service.Admission(dbIdTo, new Position
            {
                Name = name,
                Amount = amount,
                Cost = cost
            });
        }

        private static void WriteOff(PositionService service, int dbId, string name, int amount, double cost)
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