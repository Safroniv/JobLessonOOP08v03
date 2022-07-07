using Incapsulation.Data.Entities;
using Incapsulation.Data.Specifications;

namespace Incapsulation.Data.Storages
{
    public class DataStorage<TEntity> where TEntity : BaseEntity
    {
        public Dictionary<int, TEntity> _data = new();

        //crud - сreate read update delete

        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public void AddEntity(TEntity entity)
        {
            _data.Add(entity.Id, entity);
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity? GetById(int id)
        {
            var result = _data.TryGetValue(id, out var entity);
            return result == false ? null : entity;
        }

        //было
        //public Customer[] GetBySpecification (CustomerByAgeSpecification spec)

        public TEntity[] GetBySpecification(SpecificationBase<TEntity> spec)
        {
            var allEntitities = _data.Values.ToArray();
            var result = new List<TEntity>();
            //когда применяется конструкция с массивом,
            //мы говорим что для каждого элемента данного массива
            //мы производим перебор элементов
            foreach (var entity in allEntitities)
            {
                if (spec.Ensure(entity))
                {
                    result.Add(entity);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <returns></returns>
        public bool UpdateCustomer(int id, TEntity updatedEntity)
        {
            if (_data.TryGetValue(id, out var _))
            {
                _data[id] = updatedEntity;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int id)
        { return _data.Remove(id); }
    }
}
