using Dev_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_BLL
{
    public class clsDeveloper
    {

        enum enMode { AddNew, Update }
        enMode _Mode;

        public int DeveloperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public clsDeveloper()
        {
            DeveloperID = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            HireDate = DateTime.MinValue;

            _Mode = enMode.AddNew;
        }

        clsDeveloper(int DeveloperID, string FirstName, string LastName, string Email, DateTime HireDate)
        {
            this.DeveloperID = DeveloperID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.HireDate = HireDate;

            _Mode = enMode.Update;
        }

        static public clsDeveloper GetDeveloperByID(int developerID)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            string email = string.Empty;
            DateTime hireDate = DateTime.MinValue;
            bool found = clsDeveloperData.GetDeveloperByID(developerID, ref firstName, ref lastName, ref email, ref hireDate);
            if (found)
            {
                return new clsDeveloper(developerID, firstName, lastName, email, hireDate);
            }
            else
            {
                return null; // Not found
            }

        }

        bool _AddNew()
        {
            this.DeveloperID = clsDeveloperData.AddDeveloper(this.FirstName, this.LastName, this.Email);
            return this.DeveloperID != -1;
        }

        bool _Update()
        {
            return clsDeveloperData.UpdateDeveloper(this.DeveloperID, this.FirstName, this.LastName, this.Email);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _Update();
                    }
            }
            return false;
        }

        public static bool DeleteByID(int DeveloperID)
        {
            return clsDeveloperData.DeleteDeveloper(DeveloperID);
        }

        public static DataTable GetAll()
        {
            return clsDeveloperData.GetAllDevelopers();
        }

    }
}
