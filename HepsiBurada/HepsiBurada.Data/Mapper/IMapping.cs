﻿namespace HepsiBurada.Data.Mapper
{
    public interface IMapping
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}