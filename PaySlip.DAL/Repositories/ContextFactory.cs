﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip.DAL.Repositories
{
    /// <summary>
    ///     Interface for factory which is in charge of creating new DbContexts
    /// </summary>
    /// <autogeneratedoc />
    public interface IDatabaseContextFactory
    {
        /// <summary>
        /// Creates new Master Database Context.
        /// </summary>
        /// <returns>newly created MasterDatabaseContext</returns>
        /// <autogeneratedoc />
        DbContext MasterDbContext();
    }
    /// It is implemented as Singleton as factory should be implemented (according to Gang of four) 
    /// </summary>
    /// <seealso cref="T:Master.Domain.DataAccessLayer.IDatabaseContextFactory" />
    /// <autogeneratedoc />
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        /// <summary>
        /// This is implementation of singleton
        /// </summary>
        /// <remarks>       
        /// </remarks>
        /// <autogeneratedoc />
        private static readonly DatabaseContextFactory instance = new DatabaseContextFactory();

        // Explicit static constructor to tell C# compiler
        static DatabaseContextFactory()
        {

        }

        //so that class cannot be initiated 
        private DatabaseContextFactory()
        {
        }


        /// <summary>
        /// Instance of DatabaseContextFactory
        /// </summary>
        public static DatabaseContextFactory Instance => instance;

        /// <inheritdoc />
        /// <summary>
        /// Creates new MasterDatabaseContext
        /// </summary>
        /// <returns></returns>
        public DbContext MasterDbContext()
        {
            return new DurgeshEPSDbEntities();
        }
    }
}
