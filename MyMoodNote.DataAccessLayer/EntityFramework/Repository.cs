﻿using MyMoodNote.DataAccessLayer;
using MyMoodNote.DataAccessLayer.Abstract;
using MyMoodNote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyMoodNote.DataAccessLayer.EntityFramework
{
    public class Repository<T>:RepositoryBase, IRepository<T> where T : class 
    {
        private DatabaseContext db;
        private DbSet<T> _objectSet;

        public Repository()
        {
            db = RepositoryBase.CreateContext();
            _objectSet = db.Set<T>();

        }

        public List<T> List()
        {
           return _objectSet.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }
        
        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            if(obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
                DateTime now = DateTime.Now;
                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = "system"; // işlem yapan kullanıcı adı yazılmalı 
            }
            return Save();

        }

        public int Update(T obj)
        {
            if (obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;

                o.ModifiedOn = DateTime.Now;
                o.ModifiedUsername = "system"; // işlem yapan kullanıcı adı yazılmalı 
            }
            return Save();

        }

        public int Delete(T obj)
       {
        //    if (obj is MyEntityBase)
        //    {
        //        MyEntityBase o = obj as MyEntityBase;

        //        o.ModifiedOn = DateTime.Now;
        //        o.ModifiedUsername = "system"; // işlem yapan kullanıcı adı yazılmalı 
        //    }

            _objectSet.Remove(obj);
            return Save();

        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return _objectSet.FirstOrDefault(where);

        }



    }
}
