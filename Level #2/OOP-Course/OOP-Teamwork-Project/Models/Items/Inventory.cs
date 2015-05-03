namespace TeamworkProject.Models.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [Serializable]
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public List<Item> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            this.Items.Add(itemToAdd);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this.items)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}