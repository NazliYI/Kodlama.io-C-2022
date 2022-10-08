using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeEgitim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IoC Container
            CustomerManager customerManager = new CustomerManager(new Customer(), new MilitaryCreditManager());
            customerManager.GiveCredit();
        }     
    }

    class CreditManager
    {
        public void Calculate(int creditType)
        {
           if (creditType == 1)
            {

            }

           if (creditType == 2)
            {

            }

            Console.WriteLine("Hesapla");
        }

        public void Save()
        {
            Console.WriteLine("Kredi Verildi");
        }
    }


    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate();

        public virtual void Save()
        {
           Console.WriteLine("Kaydedildi");
        }
    }

    class TeacherCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            //hesaplamalar
            Console.WriteLine("Öğretmen kredisi hesaplandı");
        }

        public override void Save()
        {
            base.Save();
        }


    }

    class MilitaryCreditManager :BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Asker kredisi hesaplandı");
        }

       
    }


    class Customer
    {
       
        public Customer()
        {
            Console.WriteLine("Müşteri nesnesi başlatıldı");
        }
        public int Id { get; set; }//get set, hem yazılabilir hem okunabilir.
        

        public string City { get; set; }    


    }

    class Company : Customer
    {
        
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }


    class Person : Customer

    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalityIdenity { get; set; }
    }




    class CustomerManager
    {
        private Customer _customer;
        private ICreditManager _creditManager;
        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;
            _creditManager = creditManager; 
        }
        public void Save ()
        {
            Console.WriteLine("Müşteri Kaydedildi:");

        }

        public void Delete()
        {
            Console.WriteLine("Müşteri Silindi:" );

        }

        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi verildi");
        }
    }
    
}
