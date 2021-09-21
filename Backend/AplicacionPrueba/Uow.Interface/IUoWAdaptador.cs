using System;

namespace UoW.Interface
{
    public interface IUoWAdaptador : IDisposable
    {
        IUoWRepositorio Repositorios { get; }

        void SaveChange();
    }
}