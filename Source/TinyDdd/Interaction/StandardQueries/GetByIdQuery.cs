﻿using System;
using SwissKnife;

namespace TinyDdd.Interaction.StandardQueries
{
    public sealed class GetByIdQuery<T> : IQuery<Option<T>> where T : class
    {
        public Guid Id { get; set; }
    }
}