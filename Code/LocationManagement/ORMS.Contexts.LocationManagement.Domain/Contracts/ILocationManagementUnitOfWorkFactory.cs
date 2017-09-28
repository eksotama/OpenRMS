﻿//-----------------------------------------------------------------------
// <copyright file="ILocationManagementUnitOfWorkFactory.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.LocationManagement.Domain.Contracts
{
    using Shared.SharedKernel.Interfaces;

    /// <summary>
    /// An interface that provides access to a location management unit of work factory.
    /// </summary>
    public interface ILocationManagementUnitOfWorkFactory : IUnitOfWorkFactory<ILocationManagementUnitOfWork>
    {
    }
}