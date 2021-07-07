﻿using System.Collections.Generic;
using System.Linq;

namespace Pacioli.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public IList<Entry> Entries { get; set; } = new List<Entry>();

        private IList<Entry> _entries = new List<Entry>();

        public bool Balance()
        {
            var amounts = from e in _entries select e.Amount;
            return amounts.Sum() == 0;
        }

        public decimal Debit
        {
            get
            {
                var amounts = from e in _entries where e.Amount > 0 select e.Amount;
                return amounts.Sum();
            }
        }

        public decimal Credit
        {
            get
            {
                var amounts = from e in _entries where e.Amount < 0 select e.Amount;
                return -amounts.Sum();
            }
        }
        
        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public void AddEntries(params Entry[] entries)
        {
            foreach (var entry in entries)
            {
                _entries.Add(entry);
            }
        }
    }
}
