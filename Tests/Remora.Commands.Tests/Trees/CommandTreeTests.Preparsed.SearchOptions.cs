//
//  CommandTreeTests.Preparsed.SearchOptions.cs
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

using System;
using System.Collections.Generic;
using Remora.Commands.Tests.Data.DummyModules;
using Remora.Commands.Trees;
using Xunit;

namespace Remora.Commands.Tests.Trees;

public static partial class CommandTreeTests
{
    public static partial class Preparsed
    {
        /// <summary>
        /// Tests various search options.
        /// </summary>
        public class SearchOptions
        {
            /// <summary>
            /// Tests the key comparison option.
            /// </summary>
            public class KeyComparison
            {
                /// <summary>
                /// Tests whether a command can be found by performing a search with a different key comparison.
                /// </summary>
                [Fact]
                public void CanFindCommandWithDifferentCasing()
                {
                    var builder = new CommandTreeBuilder();
                    builder.RegisterModule<GroupWithCasingDifferences>();

                    var tree = builder.Build();

                    var options = new TreeSearchOptions(StringComparison.OrdinalIgnoreCase);

                    var result = tree.Search
                    (
                        "test somecommand",
                        new Dictionary<string, IReadOnlyList<string>>(),
                        searchOptions: options
                    );

                    Assert.NotEmpty(result);
                }
            }
        }
    }
}
