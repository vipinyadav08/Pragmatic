﻿using TinyDdd.Interaction;

namespace TinyDdd.Example.Model.HowToUseQueriesAndCommands.Commands
{
    public sealed class CreateUserCommand : ICommand<Response<User>>
    {
        public string FirstName { get; set; }
    }
}
