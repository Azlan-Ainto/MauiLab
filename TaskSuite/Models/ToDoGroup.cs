using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TaskSuite.Models
{
    public class ToDoGroup : ObservableCollection<ToDoItem>
    {
        public string Name { get; private set; }
        public ToDoGroup(string name, List<ToDoItem> items) : base(items)
        {
            Name = name;
        }
    }
}
