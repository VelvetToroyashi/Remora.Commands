//
//  ParameterCondition.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
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

using System.Threading;
using System.Threading.Tasks;
using Remora.Commands.Conditions;
using Remora.Commands.Tests.Data.Attributes;
using Remora.Results;

namespace Remora.Commands.Tests.Data.Conditions
{
    /// <inheritdoc />
    public class ParameterCondition : ICondition<ParameterConditionAttribute, string>
    {
        /// <inheritdoc />
        public ValueTask<Result> CheckAsync
        (
            ParameterConditionAttribute attribute,
            string value,
            CancellationToken ct = default
        )
        {
            return attribute.Data == value
                ? new ValueTask<Result>(Result.FromSuccess())
                : new ValueTask<Result>(new InvalidOperationError("No match :("));
        }
    }
}
