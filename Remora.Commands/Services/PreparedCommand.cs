//
//  PreparedCommand.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using JetBrains.Annotations;
using Remora.Commands.Signatures;

namespace Remora.Commands.Services;

/// <summary>
/// Represents a command that has been prepared for execution.
/// </summary>
/// <remarks>
///  A prepared command is defined as having passed all its conditions, and having a set of fully materialized
/// parameters.
/// </remarks>
/// <param name="Command">The command.</param>
/// <param name="Parameters">The materialized parameters.</param>
[PublicAPI]
public record PreparedCommand(BoundCommandNode Command, object?[] Parameters);
