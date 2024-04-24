using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class CustomersDto 
    {
        public long customer_id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string patronymic { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public CustomersDto(Customers customers)
        {
            customer_id = customers.customer_id;
            first_name = customers.first_name;
            second_name = customers.second_name;
            patronymic = customers.patronymic;
            email = customers.patronymic;
            login = customers.login;
            password = customers.password;
        }
    }   
}