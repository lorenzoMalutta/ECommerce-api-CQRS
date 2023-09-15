﻿namespace agrolugue_api.Domain.Data.Repository
{
    public interface ICommands<T>
    {
        void Create(T command);
        void Update(T command);
        void Delete(T command);
    }
}
