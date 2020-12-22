//
//  CommandTreeTests.Raw.cs
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

using Remora.Commands.Tests.Data.DummyModules;
using Remora.Commands.Trees;
using Xunit;

namespace Remora.Commands.Tests.Trees
{
    public partial class CommandTreeTests
    {
        /// <summary>
        /// Tests functionality of raw parsing-based operations.
        /// </summary>
        public class Raw
        {
            /// <summary>
            /// Tests basic requirements.
            /// </summary>
            public class Basic
            {
                /// <summary>
                /// Tests whether the tree can be successfully searched.
                /// </summary>
                [Fact]
                public void SearchIsSuccessfulIfAMatchingCommandExists()
                {
                    var builder = new CommandTreeBuilder();
                    builder.RegisterModule<NamedGroupWithCommandsWithNestedNamedGroupWithCommands>();

                    var tree = builder.Build();

                    var result = tree.Search("a c d");
                    Assert.NotEmpty(result);
                }

                /// <summary>
                /// Tests whether the tree can be successfully searched.
                /// </summary>
                [Fact]
                public void SearchIsUnsuccessfulIfNoMatchingCommandExists()
                {
                    var builder = new CommandTreeBuilder();
                    builder.RegisterModule<NamedGroupWithCommandsWithNestedNamedGroupWithCommands>();

                    var tree = builder.Build();

                    var result = tree.Search("a d c");
                    Assert.Empty(result);
                }
            }

            /// <summary>
            /// Tests aliasing behaviour.
            /// </summary>
            public class Aliasing
            {
                /// <summary>
                /// Tests whether a command can be found by searching for its primary key and one of the aliases of the
                /// group it is contained within.
                /// </summary>
                [Fact]
                public void CanFindCommandByCommandPrimaryKeyAndGroupAlias()
                {
                    var builder = new CommandTreeBuilder();
                    builder.RegisterModule<AliasedGroupWithAliasedCommand>();

                    var tree = builder.Build();

                    var result = tree.Search("t command");
                    Assert.NotEmpty(result);
                }

                /// <summary>
                /// Tests whether a command can be found by searching for one of its aliases and the primary key of the
                /// group it is contained within.
                /// </summary>
                [Fact]
                public void CanFindCommandByCommandAliasAndGroupPrimaryKey()
                {
                    var builder = new CommandTreeBuilder();
                    builder.RegisterModule<AliasedGroupWithAliasedCommand>();

                    var tree = builder.Build();

                    var result = tree.Search("test c");
                    Assert.NotEmpty(result);
                }

                /// <summary>
                /// Tests whether a command can be found by searching for one of its aliases and one of the aliases of the
                /// group it is contained within.
                /// </summary>
                [Fact]
                public void CanFindCommandByCommandAliasAndGroupAlias()
                {
                    var builder = new CommandTreeBuilder();
                    builder.RegisterModule<AliasedGroupWithAliasedCommand>();

                    var tree = builder.Build();

                    var result = tree.Search("t c");
                    Assert.NotEmpty(result);
                }
            }
        }
    }
}