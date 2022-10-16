using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Agent
    {
        public int id;
        public string title;
        public string type_agent;
        public string Address;
        public string INN;
        public string KPP;
        public string DirectorName;
        public string Phone;
        public string Email;
        public string Logo;
        public int Priority;
        public int Amount_sales;

        public Agent(int id, string title, string type_agent, string Address, string INN, string KPP, string DirectorName, string Phone, string Email, string Logo, int Priority,int Amount_sales)
        {
            this.id = id;
            this.title = title;
            this.type_agent = type_agent;
            this.Address = Address;
            this.INN = INN;
            this.KPP = KPP;
            this.DirectorName = DirectorName;
            this.Phone = Phone;
            this.Email = Email;
            this.Logo = Logo;
            this.Priority = Priority;
            this.Amount_sales = Amount_sales;
        }
    }
}
