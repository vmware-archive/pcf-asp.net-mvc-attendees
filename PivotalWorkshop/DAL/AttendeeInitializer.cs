using PivotalWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PivotalWorkshop.DAL
{
    public class AttendeeInitializer : System.Data.Entity.DropCreateDatabaseAlways<AttendeeContext>
    {
        protected override void Seed(AttendeeContext context)
        {
            List<Attendee> attendees = new List<Attendee>
            {
            new Attendee{id=1,address="123 Main Street",city="San Diego",email="attendee1@gmail.com",firstName="John",lastName="Doe",phoneNumber="(800) 555-1212",state="CA",zipCode="92113"},
            new Attendee{id=2,address="456 Main Street",city="San Diego",email="attendee2@gmail.com",firstName="Jane",lastName="Smith",phoneNumber="(800) 555-1214",state="CA",zipCode="92113"},
            new Attendee{id=3,address="789 Main Street",city="San Diego",email="attendee3@gmail.com",firstName="Fred",lastName="Flintstone",phoneNumber="(800) 555-1215",state="CA",zipCode="92113"},
            new Attendee{id=4,address="203 Main Street",city="San Diego",email="attendee4@gmail.com",firstName="Betty",lastName="Rubble",phoneNumber="(800) 555-1216",state="CA",zipCode="92113"},
            };

            attendees.ForEach(a => context.Attendees.Add(a));
            context.SaveChanges();
       }
    }
}