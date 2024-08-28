
using ReadITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReadITAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public MyDbContext _Context;
        public IcategoryRepository Category { get; private set;}
        public IbookRepository book { get; private set;}
        public IpublisherRepository publisher { get; private set; }
        public IorderRepository order { get; private set; }
        public IApplication_UserRepository ApplicationUser { get; private set; }
        public IRequstionRepository request { get; private set; }
        public IsalesRepository sales { get; private set; }

        public UnitOfWork(MyDbContext myContext)
        {
            _Context = myContext;
            Category = new categoryRepository(_Context);
            book = new bookRepository(_Context);
            publisher = new publisherRepository(_Context);
            order = new orderRepository(_Context);
            ApplicationUser = new Application_UserRepository(_Context);
            request = new RequstionRepository(_Context);
            sales = new salesRepository(_Context);
        }

        public void Save()
        {
            _Context.SaveChanges();
        }
    }
}
