﻿// 
// MoveSet.cs
//  
// Author:
//       Jon Thysell <thysell@gmail.com>
// 
// Copyright (c) 2015, 2016 Jon Thysell <http://jonthysell.com>
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzinga.Core
{
    public class MoveSet : IEnumerable<Move>
    {
        public int Count
        {
            get
            {
                return _moves.Count;
            }
        }

        private HashSet<Move> _moves;

        public MoveSet()
        {
            _moves = new HashSet<Move>();
        }

        public MoveSet(string moveSetString) : this()
        {
            if (String.IsNullOrWhiteSpace(moveSetString))
            {
                throw new ArgumentNullException("moveSetString");
            }

            string[] split = moveSetString.Split(MoveSet.MoveStringSeparator);

            for (int i = 0; i < split.Length; i++)
            {
                Move parseMove = new Move(split[i]);
                Add(parseMove);
            }
        }

        public void Add(IEnumerable<Move> moves)
        {
            if (null == moves)
            {
                throw new ArgumentNullException("moves");
            }

            foreach (Move move in moves)
            {
                Add(move);
            }
        }

        public bool Add(Move move)
        {
            if (null == move)
            {
                throw new ArgumentNullException("move");
            }

            return _moves.Add(move);
        }

        public void Remove(IEnumerable<Move> moves)
        {
            if (null == moves)
            {
                throw new ArgumentNullException("moves");
            }

            foreach (Move move in moves)
            {
                Remove(move);
            }
        }

        public bool Remove(Move move)
        {
            if (null == move)
            {
                throw new ArgumentNullException("move");
            }

            return _moves.Remove(move);
        }

        public bool Contains(Move move)
        {
            if (null == move)
            {
                throw new ArgumentNullException("move");
            }

            return _moves.Contains(move);
        }

        public IEnumerator<Move> GetEnumerator()
        {
            foreach (Move move in _moves)
            {
                yield return move;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Move move in _moves)
            {
                sb.AppendFormat("{0}{1}", move.ToString(), MoveStringSeparator);
            }

            return sb.ToString().TrimEnd(MoveStringSeparator);
        }

        public const char MoveStringSeparator = ';';
    }
}
