using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace Core.Context.Log
{
    public class CustomDbInterceptor : IDbCommandInterceptor
    {
        public event EventHandler<LogEntry> EventLogged;

        private void OneventLogged(LogEntry logEntry)
        {
            EventLogged?.Invoke(this, logEntry);
        }


        private LogEntry PrepareEntry<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            return new LogEntry()
            {
                CommandName = command.CommandText
            };
        }

        private void HandleCommand<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            LogEntry entry = PrepareEntry<T>(command, interceptionContext);
            OneventLogged(entry);
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            HandleCommand(command, interceptionContext);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            HandleCommand(command, interceptionContext);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            HandleCommand(command, interceptionContext);
        }
    }
}
