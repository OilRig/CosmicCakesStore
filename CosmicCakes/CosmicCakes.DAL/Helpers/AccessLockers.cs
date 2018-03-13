using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Helpers
{
    public struct ReadLock : IDisposable
    {
        private readonly ReaderWriterLockSlim _syncronizer;
        public void Dispose()
        {
            _syncronizer.ExitReadLock();
        }
        public ReadLock(ReaderWriterLockSlim syncronizer)
        {
            _syncronizer = syncronizer;
            _syncronizer.EnterReadLock();
        }
    }
    public struct WriteLock : IDisposable
    {
        private readonly ReaderWriterLockSlim _syncronizer;

        public void Dispose()
        {
            _syncronizer.ExitWriteLock();
        }
        public WriteLock(ReaderWriterLockSlim syncronizer)
        {
            _syncronizer = syncronizer;
            _syncronizer.EnterWriteLock();
        }
    }
}
