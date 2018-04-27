using System.Collections.Generic;
using TesteDotNet.Domain;
using TesteDotNet.Domain.Const;
using TesteDotNet.Infrastructure.Repository.Implementations.Bases;
using TesteDotNet.Infrastructure.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Linq;
using System;

namespace TesteDotNet.Infrastructure.Repository.Implementations
{
    public class ItemRepository : IItemRepository
    {

        public ItemRepository()
        {

        }

        public void Add(ItemDomain t)
        {
            using (var unitOfWork = new UnitOfWork(NameDatabase.DatabaseDefault))
            {

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@NOME", dbType: DbType.String, value: t.Name);
                parameters.Add("@CATEGORIA_ID", dbType: DbType.Int32, value: t.Category.Id);

                unitOfWork.GetConnection().Execute("SP_I_ITEM", parameters, commandType: CommandType.StoredProcedure);

                unitOfWork.Commit();
            }
        }

        public void Update(ItemDomain t)
        {
            using (var unitOfWork = new UnitOfWork(NameDatabase.DatabaseDefault))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@ID", dbType: DbType.Int32, value: t.Id);
                parameters.Add("@NOME", dbType: DbType.String, value: t.Name);
                parameters.Add("@CATEGORIA_ID", dbType: DbType.Int32, value: t.Category.Id);

                unitOfWork.GetConnection().Execute("SP_U_ITEM", parameters, commandType: CommandType.StoredProcedure);

                unitOfWork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitOfWork = new UnitOfWork(NameDatabase.DatabaseDefault))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@ID", dbType: DbType.Int32, value: id);

                unitOfWork.GetConnection().Execute("SP_D_ITEM", parameters, commandType: CommandType.StoredProcedure);

                unitOfWork.Commit();
            }
        }

        public IEnumerable<ItemDomain> Find(ItemDomain item)
        {
            using (var unitOfWork = new UnitOfWork(NameDatabase.DatabaseDefault))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@NOME_ITEM",            dbType: DbType.String,      value: item.Name);
                parameters.Add("@CATEGORIA_ID",         dbType: DbType.Int32,       value: item.Category.Id);
                parameters.Add("@CATEGORIA_NOME",       dbType: DbType.String,      value: item.Category.Name);
                parameters.Add("@DATA_CADASTRO_ITEM",   dbType: DbType.DateTime,    value: item.DateCreate);

                Func<ItemDomain, CategoryDomain, ItemDomain> mapper = (ite, category) =>
                {
                    ite.Category = category;

                    return item;
                };

                return unitOfWork.GetConnection().Query("SP_S_BUSCAR_ITEM_POR_TODOS_CAMPOS", param: parameters, map: mapper, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<ItemDomain> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(NameDatabase.DatabaseDefault))
            {
                Func<ItemDomain, CategoryDomain, ItemDomain> mapper = (item, category) =>
                {
                    item.Category = category;

                    return item;
                };

                return unitOfWork.GetConnection().Query("SP_S_ITEM_BUSCAR_TODOS", map: mapper, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public ItemDomain GetById(int id)
        {
            using (var unitOfWork = new UnitOfWork(NameDatabase.DatabaseDefault))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@ID", dbType: DbType.Int32, value: id);

                return unitOfWork.GetConnection().Query<ItemDomain>("SP_S_ITEM_POR_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public bool HasNameEqual(string name)
        {
            using (var unitOfWork = new UnitOfWork(NameDatabase.DatabaseDefault))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@NOME", dbType: DbType.String, value: name);

                var result = unitOfWork.GetConnection().Query<int>("SP_S_BUSCAR_ITEM_POR_NOME", parameters, commandType: CommandType.StoredProcedure).Count();

                return result > 0;
            }
        }
    }
}
