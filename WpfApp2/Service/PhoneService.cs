using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Entity;

namespace WpfApp2.Service
{
    public class PhoneService
    {
        private readonly Praktika923MVEntities context;
        public PhoneService(Praktika923MVEntities context)
        {
            this.context = context;
        }
        public List<Kontakt> GetAllKontakt()
        {
            return  context.Kontakt.OrderByDescending(p=>p.favorite).ToList();
        }

        public List<Group> GetAllGroup()
        {
            return context.Group.ToList();
        }

        public void AddContact(Kontakt kontakt)
        {
            context.Kontakt.Add(kontakt);
            context.SaveChanges();
        }
        public void AddGroup(Group group)
        {
            context.Group.Add(group);
            context.SaveChanges();
        }
        public void RemoveGroup(Group group)
        {
            var group1 = context.Group.FirstOrDefault(p => p.name == group.name);
            context.Group.Remove(group1);
            context.SaveChanges();
        }
        public void RemoveContact(Kontakt kontakt)
        {
            var kontakt1 = context.Kontakt.FirstOrDefault(p => p.name == kontakt.name);
            context.Kontakt.Remove(kontakt1);
            context.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public List<Kontakt> Filtered(int query)
        {
            return context.Kontakt
                .Where(p=> p.Group.id == query)
            .ToList();
        }
    }
}
