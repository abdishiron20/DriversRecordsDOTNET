using Dispatch_app.Models;
using Microsoft.EntityFrameworkCore;

namespace Dispatch_app.Repositories
{
    public class DriverRepo : IDriverRepo
    {
        public  AppDbContext _dbContext;

        public DriverRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DriverResponse GetDriver(int id)
        {


            Drivers driverResult = _dbContext.Drivers.Where(x => x.ID == id).FirstOrDefault();

            List<Contacts> contacts = _dbContext.Contacts.Where(x => x.DriverId == driverResult.ID).ToList();



            DriverResponse response = new DriverResponse();


            response.ID = driverResult.ID;
            response.FirstName = driverResult.FirstName;
            response.LastName = driverResult.LastName;
            response.Phone = driverResult.Phone;
            response.Email = driverResult.Email;
            response.Address = driverResult.Address;

            response.Contacts = new List<Contacts>();

            foreach (var contact in contacts)
            {
                var contactResponse = new Contacts();

                contactResponse.ID = contact.ID;
                contactResponse.FirstName = contact.FirstName;
                contactResponse.LastName = contact.LastName;
                contactResponse.Phone = contact.Phone;

                response.Contacts.Add(contactResponse);
            }

            return response;
        }

        public List<DriverResponse> GetDrivers()
        {

            List<DriverResponse> driverResponses = new List<DriverResponse>();



            List<Drivers> driverResult = _dbContext.Drivers.ToList();

            foreach (Drivers driver in driverResult)
            {
                var contacts = _dbContext.Contacts.Where(x => x.DriverId == driver.ID).ToList();
                DriverResponse driverResponse = new DriverResponse();


                driverResponse.ID = driver.ID;
                driverResponse.FirstName = driver.FirstName;
                driverResponse.LastName = driver.LastName;
                driverResponse.Phone = driver.Phone;
                driverResponse.Email = driver.Email;
                driverResponse.Address = driver.Address;

                driverResponse.Contacts = new List<Contacts>();

                foreach (var contact in contacts)
                {
                    var contactResponse = new Contacts();

                    contactResponse.ID = contact.ID;
                    contactResponse.FirstName = contact.FirstName;
                    contactResponse.LastName = contact.LastName;
                    contactResponse.Phone = contact.Phone;

                    driverResponse.Contacts.Add(contactResponse);
                }
                driverResponses.Add(driverResponse);

            }
            return driverResponses;
        }

        public string Create(DriverRequest request)
        {

            string error = string.Empty;
            if (string.IsNullOrEmpty(request.FirstName))
            {
                return "Sorry FirstName can not be null";
            }
            Drivers driverObj = new Drivers();

            driverObj.FirstName = request.FirstName;
            driverObj.LastName = request.LastName;
            driverObj.Email = request.Email;
            driverObj.Phone = request.Phone;
            driverObj.Address = request.Address;
            driverObj.CarrierId = 4;

            _dbContext.Drivers.Add(driverObj);
            _dbContext.SaveChanges();

            AddContact(driverObj.ID, request.Contacts);

            error = "your data has been saved successfully!";

            return error;
        }


       public string Update(DriverRequest request)
        {
            var driver = _dbContext.Drivers.Where(x=>x.ID == request.ID).FirstOrDefault(); //

            if (driver == null)
            {
                return "Sorry, the ID you provided does not exist!";
            }
            driver.FirstName = request.FirstName;
            driver.LastName = request.LastName;
            driver.Address = request.Address;
            driver.Phone = request.Phone;
            driver.Email = request.Email;

            _dbContext.Drivers.Update(driver);
            _dbContext.SaveChanges();


            foreach (var contact in request.Contacts) 
            {

                var updatedContact = _dbContext.Contacts.Where(x => x.ID == contact.ID).FirstOrDefault();
                if (updatedContact != null)
                {
                    updatedContact.FirstName = contact.FirstName;
                    updatedContact.LastName = contact.LastName;
                    updatedContact.Phone = contact.Phone;

                    _dbContext.Contacts.Update(updatedContact);
                    _dbContext.SaveChanges();
                }

            }
            // Update existing contacts
            //why is there an error Contacts ? It already exists (-come back to this later_)
//            foreach (var updatedContact in request.Contacts)    
//            {
//                var existingContact = _dbContext.Contacts.Where(x=>x.ID == updatedContact.ID).FirstOrDefault();

//                if (existingContact != null) { 
               
//                    //existingContact.ID = updatedContact
//                    //existingContact.FirstName = updatedContact.FirstName;    
//.                   existingContact.LastName = updatedContact.LastName;
//                    existingContact.Phone = updatedContact.Phone;
     
//                    //existingContact.Email = updatedContact.Email;   // we'll ignore these for now per Adeer. 
//                    //existingContact.Address = updatedContact.Address;

//                    // check the database
//                }

//            }

            // Add new contacts
            //foreach (var newContact in request.Contacts)
            //{
            //   Contacts.ReferenceEquals(newContact.ID, request.ID); //testing this
            //}

            
            return "your data has been updated successfully!";
        }

        public string Delete(int id)
        {
            var data = _dbContext.Drivers.Where(x => x.ID == id).FirstOrDefault();

            if (data == null)
            {
                return "sorry, the Id you provided does not exist!";
            }

            _dbContext.Drivers.Remove(data);
            _dbContext.SaveChanges();

            return "your data has been deleted successfully!";
        }


        private string AddContact(int driverId, List<Contacts> contacts)
        {
            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    contact.DriverId = driverId;

                    _dbContext.Contacts.Add(contact);
                    _dbContext.SaveChanges();
                }
            }
            return "contact(s) has been added successfully!";
        }
    }
}
