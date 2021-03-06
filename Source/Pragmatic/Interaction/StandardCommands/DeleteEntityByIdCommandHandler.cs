﻿using Pragmatic.Interaction.EntityDeletion;
using SwissKnife.Diagnostics.Contracts;

namespace Pragmatic.Interaction.StandardCommands
{
    public sealed class DeleteEntityByIdCommandHandler : ICommandHandler<DeleteEntityByIdCommand, Response>
    {
        private readonly EntityDeleterProvider _entityDeleterProvider;

        public DeleteEntityByIdCommandHandler(EntityDeleterProvider entityDeleterProvider)
        {
            Argument.IsNotNull(entityDeleterProvider, "entityDeleterProvider");

            _entityDeleterProvider = entityDeleterProvider;
        }

        public Response Execute(DeleteEntityByIdCommand command)
        {
            Response response = new Response();

            var entityDeleter = _entityDeleterProvider.GetEntityDeleterFor(command.EntityType);

            if (entityDeleter.IsNone)
            {
                response.AddError(() => EntityResources.DeletingEntitiesOfTypeIsNotForseen); // TODO-IG: Replace the generic word entity with the localized entity description.
                return response;
            }

            return entityDeleter.Value.DeleteEntity(command.EntityId);
        }
    }
}
