using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericDbRepository : IDbRepository<IEntity>
    {

        
        public void Close()
        {
            DbConnectionFactory.Instance.GetDbConnection().Close();
        }

        public void Commit()
        {
            DbConnectionFactory.Instance.GetDbConnection().Commit();
        }

        public void Delete(IEntity entity)
        {
           
                SqlCommand cmd = DbConnectionFactory.Instance.GetDbConnection().CreateCommand($"delete from {entity.TableName} where {entity.WhereCondition}");
           
                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Database error!");
                }
           
            
           
        }


        public List<IEntity> GetAll(IEntity entity)
        {
            List<IEntity> result;

            SqlCommand cmd = DbConnectionFactory.Instance.GetDbConnection().CreateCommand($"select {entity.SelectValues} from {entity.TableName} as {entity.TableAlias} {entity.JoinTable} {entity.JoinCondition}");
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetList(reader);
            reader.Close();
            return result;
        }



        public List<IEntity> GetAllWithCondition(IEntity entity)
        {
            List<IEntity> result;

            SqlCommand cmd = DbConnectionFactory.Instance.GetDbConnection().CreateCommand($"select {entity.SelectValues} from {entity.TableName} as {entity.TableAlias} {entity.JoinTable} {entity.JoinCondition} where {entity.GeneralCondition}");
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetList(reader);
            reader.Close();
            return result;
        }

        
        public IEntity GetSpecific(IEntity entity)
        {
            IEntity result;
            SqlCommand cmd = DbConnectionFactory.Instance.GetDbConnection().CreateCommand($"select {entity.SelectValues} from {entity.TableName} as {entity.TableAlias} {entity.JoinTable} {entity.JoinCondition} where {entity.WhereCondition};");
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetOne(reader);
            reader.Close();
            return result;
        }

        public void Rollback()
        {
            DbConnectionFactory.Instance.GetDbConnection().Rollback();
        }
        public void Save(IEntity entity)
        {
            SqlCommand cmd = DbConnectionFactory.Instance.GetDbConnection().CreateCommand($"insert into {entity.TableName} values ({entity.InsertValues})");
            if (cmd.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }

        }
        public int SaveAndGetID(IEntity entity)
        {
            SqlCommand cmd = DbConnectionFactory.Instance.GetDbConnection().CreateCommand($"insert into {entity.TableName} output inserted.{entity.IdName} values ({entity.InsertValues})");
            int newID = (int)cmd.ExecuteScalar();

            if (newID == null)
            {
                throw new Exception("Database error!");
            }
            return newID;

        }



        public void Update(IEntity entity)
        {
            SqlCommand cmd = DbConnectionFactory.Instance.GetDbConnection().CreateCommand($"update {entity.TableName} set {entity.UpdateValues} where {entity.WhereCondition}");
            if(cmd.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }

    
    }
}

