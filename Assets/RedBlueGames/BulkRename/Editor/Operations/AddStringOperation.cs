﻿/* MIT License

Copyright (c) 2016 Edward Rowe, RedBlueGames

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace RedBlueGames.BulkRename
{
    using UnityEditor;

    /// <summary>
    /// RenameOperation that adds a string to the rename string.
    /// </summary>
    public class AddStringOperation : BaseRenameOperation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RedBlueGames.BulkRename.AddStringOperation"/> class.
        /// </summary>
        public AddStringOperation()
        {
            this.Prefix = string.Empty;
            this.Suffix = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RedBlueGames.BulkRename.AddStringOperation"/> class.
        /// This is a clone constructor, copying the values from one to another.
        /// </summary>
        /// <param name="operationToCopy">Operation to copy.</param>
        public AddStringOperation(AddStringOperation operationToCopy)
        {
            this.Prefix = operationToCopy.Prefix;
            this.Suffix = operationToCopy.Suffix;
        }

        /// <summary>
        /// Gets the path that's displayed when this rename op is used in the Add Op menu.
        /// </summary>
        /// <value>The display path.</value>
        public override string MenuDisplayPath
        {
            get
            {
                return "Add/Add Prefix or Suffix";
            }
        }

        /// <summary>
        /// Gets the order in which this rename op is displayed in the Add Op menu (lower is higher in the list.)
        /// </summary>
        /// <value>The menu order.</value>
        public override int MenuOrder
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets or sets the prefix to add.
        /// </summary>
        /// <value>The prefix to add..</value>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the suffix to add.
        /// </summary>
        /// <value>The suffix to add.</value>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets the heading label for the Rename Operation.
        /// </summary>
        /// <value>The heading label.</value>
        protected override string HeadingLabel
        {
            get
            {
                return "Add Prefix or Suffix";
            }
        }

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <returns>A clone of this instance</returns>
        public override BaseRenameOperation Clone()
        {
            var clone = new AddStringOperation(this);
            return clone;
        }

        /// <summary>
        /// Rename the specified input, using the relativeCount.
        /// </summary>
        /// <param name="input">Input String to rename.</param>
        /// <param name="relativeCount">Relative count. This can be used for enumeration.</param>
        /// <returns>A new string renamed according to the rename operation's rules.</returns>
        public override string Rename(string input, int relativeCount)
        {
            var modifiedName = input;
            if (!string.IsNullOrEmpty(this.Prefix))
            {
                modifiedName = string.Concat(this.Prefix, modifiedName);
            }

            if (!string.IsNullOrEmpty(this.Suffix))
            {
                modifiedName = string.Concat(modifiedName, this.Suffix);
            }

            return modifiedName;
        }

        /// <summary>
        /// Draws the contents of the Rename Op using EditorGUILayout.
        /// </summary>
        protected override void DrawContents()
        {   
            this.Prefix = EditorGUILayout.TextField("Prefix", this.Prefix);
            this.Suffix = EditorGUILayout.TextField("Suffix", this.Suffix);
        }
    }
}