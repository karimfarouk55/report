
using DAL.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        SmartERPStandardContext SmartERPStandardContext { get; }
        IDbContextTransaction dbContextTransaction { get; set; }
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        void Commit();
    }
}
