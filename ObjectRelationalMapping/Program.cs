using System;

namespace ObjectRelationalMapping
{
    public class Orm : IDisposable
    {
        private readonly Database database;

        public Orm(Database database)
        {
            this.database = database;
        }

        public void Begin()
        {
            database.BeginTransaction();
        }

        public void Write(string data)
        {
            try
            {
                database.Write(data);
            }
            catch (InvalidOperationException)
            {
                database.Dispose();
            }
        }

        public void Commit()
        {
            try
            {
                database.EndTransaction();
            }
            catch (InvalidOperationException)
            {
                database.Dispose();
            }
        }

        public void Dispose()
        {
            database.Dispose();
        }

       
    }

    public class Database : IDisposable
    {
        public enum State { Closed, TransactionStarted, DataWritten, Invalid };

        public Enum BeginTransaction()
        {
            return State.TransactionStarted;
        }

        public void Write(string data)
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

//var db = new Database();
//var orm = new Orm(db);
//orm.Begin();
//orm.Write("good write");
//object[] actual = { db.DbState, db.lastData };
//Assert.Equal(new object[] { Database.State.DataWritten, "good write" }, actual);