﻿using System;

namespace OrmInOneGo
{
    public class Orm
    {
        private Database database;

        public Orm(Database database)
        {
            this.database = database;
        }

        public void Write(string data)
        {

            try
            {
                database.BeginTransaction();
                database.Write(data);
                database.EndTransaction();

            }

            catch (InvalidOperationException)
            {
                database.Dispose();
                throw new InvalidOperationException();
                
            }




        }

        public bool WriteSafely(string data)
        {
            try
            {
                database.BeginTransaction();
                database.Write(data);
                database.EndTransaction();
                return true;

            }

            catch (InvalidOperationException)
            {
                database.Dispose();
                return false;

            }
        }


    }

    public class Database
    {
        public void BeginTransaction()
        {

        }

        public void Write(string data)
        {

        }

        public void BeginTransction()
        {

        }

        public void EndTransaction()
        {

        }

        public void Dispose()
        {

        }
    }
}
