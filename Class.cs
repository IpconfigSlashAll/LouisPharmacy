using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web;

namespace Project
{

    internal class Class
    {
        static String connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        static SqlConnection myConn = new SqlConnection(connString);

        static System.Data.SqlClient.SqlCommand cmdString = new System.Data.SqlClient.SqlCommand();


        public void AddPatient(string Fname, string M_I, string LName, string DOB, string Gender, string Phone, string STREET, string CITY, string STATE_ADD, string ZIP, string Insurance, string COUNTRY)
        {


            try

            {
                // open connection 

                myConn.Open();

                //clear any parameters 

                cmdString.Parameters.Clear();

                // command 

                cmdString.Connection = myConn;

                cmdString.CommandType = CommandType.StoredProcedure;

                cmdString.CommandTimeout = 1500;

                cmdString.CommandText = "AddPatient";

                //        Define input parameter 

                bool IsAllLetters(string input)
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetter(c))
                        {
                            return false;
                        }
                    }
                    return true;
                }

                bool IsLettersDigitsOrSpaces(string input)
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                        {
                            return false;
                        }
                    }
                    return true;
                }


                // Check and add parameters
                if (IsAllLetters(Fname))
                {
                    cmdString.Parameters.Add("@Fname", SqlDbType.VarChar, 25).Value = Fname;
                }
                else
                {
                    throw new ArgumentException("Invalid format for First Name (Use only Letters)");
                }

                //if (IsAllLetters(LName)) && (IsWhite)
                //{
                    cmdString.Parameters.Add("@Lname", SqlDbType.VarChar, 25).Value = LName;
                //}
                //else
                //{
                //    throw new ArgumentException("Invalid format for Last Name (Use only Letters)");
                //}

                if (IsAllLetters(M_I))
                {
                    cmdString.Parameters.Add("@M_I", SqlDbType.VarChar, 1).Value = M_I;
                }
                else
                {
                    throw new ArgumentException("Invalid format for Middle Initial (Use only Letters)");
                }

                if (DateTime.TryParse(DOB, out DateTime parsedDOB))
                {
                    cmdString.Parameters.Add("@DOB", SqlDbType.Date).Value = parsedDOB;
                }
                else
                {
                    throw new ArgumentException("Invalid date format for DOB.");
                }

                if (IsAllLetters(Gender))
                {
                    cmdString.Parameters.Add("@Gender", SqlDbType.VarChar, 60).Value = Gender;
                }
                else
                {
                    throw new ArgumentException("Invalid format for Gender (Use only Letters)");
                }

                cmdString.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = Phone;

                if (IsLettersDigitsOrSpaces(STREET))
                {
                    cmdString.Parameters.Add("@STREET", SqlDbType.VarChar, 60).Value = STREET;
                }
                else
                {
                    throw new ArgumentException("Invalid format for Street (Use only Letters, Numbers, and Spaces)");
                }

                if (IsAllLetters(CITY))
                {
                    cmdString.Parameters.Add("@CITY", SqlDbType.VarChar, 60).Value = CITY;
                }
                else
                {
                    throw new ArgumentException("Invalid format for City (Use only Letters)");
                }

                if (IsAllLetters(STATE_ADD))
                {
                    cmdString.Parameters.Add("@STATE_ADD", SqlDbType.VarChar, 2).Value = STATE_ADD;
                }
                else
                {
                    throw new ArgumentException("Invalid format for State (Use only Letters)");
                }

                cmdString.Parameters.Add("@ZIP", SqlDbType.VarChar, 5).Value = ZIP;

                if (IsAllLetters(Insurance) && (Insurance == "Yes" || Insurance == "No" || Insurance == "Y" || Insurance == "N"))
                {
                    cmdString.Parameters.Add("@Insurance", SqlDbType.VarChar, 3).Value = Insurance;
                }
                else
                {
                    throw new ArgumentException("Please Enter Yes, No, Y, N for insurance");
                }

                if (IsAllLetters(COUNTRY))
                {
                    cmdString.Parameters.Add("@COUNTRY", SqlDbType.VarChar, 3).Value = COUNTRY;
                }
                else
                {
                    throw new ArgumentException("Invalid format for Country (Use only Letters)");
                }

                cmdString.ExecuteNonQuery();
            }

            catch (Exception ex)

            {
                //throw new ArgumentException(ex.Message);
            }

            finally
            {
                myConn.Close();
            }
        }

        public void AddPhysician(string Fname, string LName, string Email, string Phone)
        {

            bool IsAllLetters(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            bool IsValidEmailFormat(string input)
            {
                foreach (char c in input)
                {
                    if (!(char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '-' || c == '_'))
                    {
                        return false;
                    }
                }
                return input.Contains('@');
            }

            try
            {
                // Open connection
                myConn.Open();

                // Clear any parameters
                cmdString.Parameters.Clear();

                // Command setup
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "AddPhysician";

                // Validate and add parameters
                if (IsAllLetters(Fname))
                {
                    cmdString.Parameters.Add("@Fname", SqlDbType.VarChar, 50).Value = Fname;
                }
                else
                {
                    throw new ArgumentException("Invalid format for First Name (Use only Letters)");
                }

                if (IsAllLetters(LName))
                {
                    cmdString.Parameters.Add("@Lname", SqlDbType.VarChar, 50).Value = LName;
                }
                else
                {
                    throw new ArgumentException("Invalid format for Last Name (Use only Letters)");
                }

                if (IsValidEmailFormat(Email))
                {
                    cmdString.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email;
                }
                else if (!string.IsNullOrEmpty(Email))
                {
                    throw new ArgumentException("Invalid format for Email (Use only Letters, Numbers, '@', '.', '-', and '_')");
                }
                else
                {
                    cmdString.Parameters.Add("@EMAIL", SqlDbType.VarChar, 100).Value = DBNull.Value;
                }

                cmdString.Parameters.Add("@Phone", SqlDbType.VarChar, 50).Value = Phone;

                cmdString.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void AddPrescription(string patientID, string physicianID, string medName, string dosage, string intMethod, int refillsLeft)
        {
            bool IsAllLetters(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            bool IsLettersDigitsOrSpaces(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                    {
                        return false;
                    }
                }
                return true;
            }
            try
            {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "AddPrescription";

                if (!string.IsNullOrEmpty(patientID))
                {
                    cmdString.Parameters.Add("@patientID", SqlDbType.VarChar, 50).Value = patientID;
                }
                else
                {
                    throw new ArgumentException("Patient ID cannot be empty.");
                }

                if (!string.IsNullOrEmpty(physicianID))
                {
                    cmdString.Parameters.Add("@PhysicianID", SqlDbType.VarChar, 50).Value = physicianID;
                }
                else
                {
                    throw new ArgumentException("Physician ID cannot be empty.");
                }

                if (IsAllLetters(medName))
                {
                    cmdString.Parameters.Add("@MedName", SqlDbType.VarChar, 50).Value = medName;
                }
                else
                {
                    throw new ArgumentException("Medication name must contain only letters.");
                }

                if (IsLettersDigitsOrSpaces(dosage))
                {
                    cmdString.Parameters.Add("@dosage", SqlDbType.VarChar, 50).Value = dosage;
                }
                else
                {
                    throw new ArgumentException("Invalid dosage format.");
                }

                if (IsLettersDigitsOrSpaces(intMethod))
                {
                    cmdString.Parameters.Add("@intMethod", SqlDbType.VarChar, 50).Value = intMethod;
                }
                else
                {
                    throw new ArgumentException("Invalid format for intake method (use only letters).");
                }

                if (refillsLeft >= 0)
                {
                    cmdString.Parameters.Add("@refillsleft", SqlDbType.Int).Value = refillsLeft;
                }
                else
                {
                    throw new ArgumentException("Refills left cannot be negative.");
                }

                cmdString.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                //throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public bool CheckPatID(string patid)
        {
            try
            {

               //myConn.Open();

                // Clear parameters and set up command
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.Text;
                
                cmdString.CommandText = @"SELECT COUNT(1) FROM PATIENTS WHERE PATIENTID = @patientId";
                cmdString.Parameters.Add("@patientId", SqlDbType.VarChar, 25).Value = patid;

                int exists = (int)cmdString.ExecuteScalar();
                if (exists > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //finally
            //{ 
            //    myConn.Close(); 
            //}
        }


        public void UpdatePatient(string patientId, string Fname, string M_I, string LName, string DOB, string Gender, string Phone, string STREET, string CITY, string STATE_ADD, string ZIP, string COUNTRY, string Insurance)
        {
            bool IsAllLetters(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            bool IsLettersDigitsOrSpaces(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            try
            {
                // Open connection
                myConn.Open();

                // Clear any parameters
                cmdString.Parameters.Clear();

                // Command configuration
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "UpdatePatient";

                // Validate and add parameters
                if (!string.IsNullOrEmpty(patientId) && CheckPatID(patientId))
                {
                    // Clear any parameters
                    cmdString.Parameters.Clear();

                    // Command configuration
                    cmdString.Connection = myConn;
                    cmdString.CommandType = CommandType.StoredProcedure;
                    cmdString.CommandTimeout = 1500;
                    cmdString.CommandText = "UpdatePatient";
                    cmdString.Parameters.Add("@patientId", SqlDbType.VarChar, 25).Value = patientId;
                }
                else if (string.IsNullOrEmpty(patientId))
                {
                    throw new ArgumentException("Patient ID cannot be empty or must exist");
                }

                if (!string.IsNullOrEmpty(Fname) && IsAllLetters(Fname))
                {
                    cmdString.Parameters.Add("@Fname", SqlDbType.VarChar, 25).Value = Fname;
                }
                else if (!string.IsNullOrEmpty(Fname))
                {
                    throw new ArgumentException("First name must contain only letters.");
                }

                if (!string.IsNullOrEmpty(LName) && IsAllLetters(LName))
                {
                    cmdString.Parameters.Add("@Lname", SqlDbType.VarChar, 25).Value = LName;
                }
                else if (!string.IsNullOrEmpty(LName))
                {
                    throw new ArgumentException("Last name must contain only letters.");
                }

                if (!string.IsNullOrEmpty(M_I) && M_I.Length == 1 && char.IsLetter(M_I[0]))
                {
                    cmdString.Parameters.Add("@M_I", SqlDbType.VarChar, 1).Value = M_I;
                }
                else if (!string.IsNullOrEmpty(M_I))
                {
                    throw new ArgumentException("Middle initial must be a single letter.");
                }

                if (DateTime.TryParse(DOB, out DateTime parsedDOB))
                {
                    cmdString.Parameters.Add("@DOB", SqlDbType.Date).Value = parsedDOB;
                }
                else if (!string.IsNullOrEmpty(DOB))
                {
                    throw new ArgumentException("Invalid date format for DOB.");
                }

                if (!string.IsNullOrEmpty(Gender) && (Gender == "MALE" || Gender == "FEMALE" || Gender == "Male" || Gender == "Female"))
                {
                    cmdString.Parameters.Add("@Gender", SqlDbType.VarChar, 6).Value = Gender;
                }
                else if (!string.IsNullOrEmpty(Gender))
                {
                    throw new ArgumentException("Gender must be 'Male' or 'Female'.");
                }

                if (!string.IsNullOrEmpty(Phone) && IsLettersDigitsOrSpaces(Phone))
                {
                    cmdString.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = Phone;
                }

                if (!string.IsNullOrEmpty(STREET))
                {
                    cmdString.Parameters.Add("@STREET", SqlDbType.VarChar, 60).Value = STREET;
                }

                if (!string.IsNullOrEmpty(CITY) && IsAllLetters(CITY))
                {
                    cmdString.Parameters.Add("@CITY", SqlDbType.VarChar, 60).Value = CITY;
                }
                else if (!string.IsNullOrEmpty(CITY))
                {
                    throw new ArgumentException("City name must contain only letters.");
                }

                if (!string.IsNullOrEmpty(STATE_ADD) && STATE_ADD.Length == 2 && IsAllLetters(STATE_ADD))
                {
                    cmdString.Parameters.Add("@STATE_ADD", SqlDbType.VarChar, 2).Value = STATE_ADD;
                }
                else if (!string.IsNullOrEmpty(STATE_ADD))
                {
                    throw new ArgumentException("State abbreviation must be two letters.");
                }

                if (!string.IsNullOrEmpty(ZIP) && ZIP.All(char.IsDigit) && ZIP.Length == 5)
                {
                    cmdString.Parameters.Add("@ZIP", SqlDbType.VarChar, 5).Value = ZIP;
                }
                else if (!string.IsNullOrEmpty(ZIP))
                {
                    throw new ArgumentException("ZIP code must contain only 5 digits.");
                }

                if (!string.IsNullOrEmpty(COUNTRY) && IsAllLetters(COUNTRY) && COUNTRY.Length == 3)
                {
                    cmdString.Parameters.Add("@COUNTRY", SqlDbType.VarChar, 3).Value = COUNTRY;
                }
                else if (!string.IsNullOrEmpty(COUNTRY))
                {
                    throw new ArgumentException("Country must contain only 3 letters.");
                }

                if (!string.IsNullOrEmpty(Insurance) && IsAllLetters(Insurance) && (Insurance == "Yes" || Insurance == "No" || Insurance == "Y" || Insurance == "N"))
                {
                    cmdString.Parameters.Add("@Insurance", SqlDbType.VarChar, 3).Value = Insurance;
                }
                else if (!string.IsNullOrEmpty(Insurance))
                {
                    throw new ArgumentException("Insurance must contain no more than 3 letters (Yes or No).");
                }

                cmdString.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void UpdatePrescription(string prescriptionID, string patientID, string physicianID, string medName, string dosage, string intMethod, int refillsLeft)
        {
            bool IsAllLetters(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            bool IsLettersDigitsOrSpaces(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            try
            {
                // Open connection
                myConn.Open();

                // Clear any parameters
                cmdString.Parameters.Clear();

                // Command configuration
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "UpdatePrescription";

                // Define input parameters if not null or empty
                if (!string.IsNullOrEmpty(prescriptionID))
                {
                    cmdString.Parameters.Add("@PrescriptionID", SqlDbType.VarChar, 50).Value = prescriptionID;
                }
                else
                {
                    throw new ArgumentException("Prescription ID cannot be empty.");
                }

                if (!string.IsNullOrEmpty(patientID))
                {
                    cmdString.Parameters.Add("@PatientID", SqlDbType.VarChar, 50).Value = patientID;
                }

                if (!string.IsNullOrEmpty(physicianID))
                {
                    cmdString.Parameters.Add("@PhysicianID", SqlDbType.VarChar, 20).Value = physicianID;
                }

                if (IsAllLetters(medName) && !string.IsNullOrEmpty(medName))
                {
                    cmdString.Parameters.Add("@MedName", SqlDbType.VarChar, 50).Value = medName;
                }
                else if (!string.IsNullOrEmpty(medName))
                {
                    throw new ArgumentException("Medication name must contain only letters.");
                }

                if (IsLettersDigitsOrSpaces(dosage) && !string.IsNullOrEmpty(dosage))
                {
                    cmdString.Parameters.Add("@Dosage", SqlDbType.VarChar, 50).Value = dosage;
                }
                else if (!string.IsNullOrEmpty(dosage))
                {
                    throw new ArgumentException("Invalid dosage format.");
                }

                if (IsLettersDigitsOrSpaces(intMethod) && !string.IsNullOrEmpty(intMethod))
                {
                    cmdString.Parameters.Add("@IntMethod", SqlDbType.VarChar, 50).Value = intMethod;
                }
                else if (!string.IsNullOrEmpty(intMethod))
                {
                    throw new ArgumentException("Invalid format for intake method (use only letters).");
                }

                if (refillsLeft >= 0)
                {
                    cmdString.Parameters.Add("@RefillsLeft", SqlDbType.Int).Value = refillsLeft;
                }

                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet SearchPatient(string searchTerm)
        {
            try
            {
                // Open connection
                myConn.Open();

                // Clear any parameters
                cmdString.Parameters.Clear();

                // Set up command for stored procedure
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "SearchPatient";

                // Parse search term
                string[] terms = searchTerm.Trim().Split(' ');

                // Add parameters for first and last name
                if (terms.Length > 0)
                {
                    cmdString.Parameters.AddWithValue("@FName", terms[0]);
                }
                else
                {
                    cmdString.Parameters.AddWithValue("@FName", DBNull.Value);
                }

                if (terms.Length > 1)
                {
                    cmdString.Parameters.AddWithValue("@LName", terms[1]);
                }
                else
                {
                    cmdString.Parameters.AddWithValue("@LName", DBNull.Value);
                }

                // Set up adapter and dataset
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdString;

                DataSet dataSet = new DataSet();

                // Fill adapter
                adapter.Fill(dataSet);

                // Return dataset
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet GetPatientByID(string PATIENTID)

        {
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetPatientByID";
                // Define input parameter
                cmdString.Parameters.Add("@PATIENTID", SqlDbType.VarChar, 20).Value = PATIENTID;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();

                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();

                // fill adapater
                aAdapter.Fill(aDataSet);

                // return dataSet
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet GetDoctorByID(string DOCTORID)

        {
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetDoctorByID";
                // Define input parameter
                cmdString.Parameters.Add("@DOCTORID", SqlDbType.VarChar, 20).Value = DOCTORID;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();

                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();

                // fill adapater
                aAdapter.Fill(aDataSet);

                // return dataSet
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet GetPrescByID(string PRESCID)

        {
            try

            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetPrescByID";
                // Define input parameter
                cmdString.Parameters.Add("@PRESCID", SqlDbType.Int).Value = PRESCID;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();

                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();

                // fill adapater
                aAdapter.Fill(aDataSet);

                // return dataSet
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet GetRefillByID(string RX_NO)

        {
            try

            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetRefillByID";
                // Define input parameter
                cmdString.Parameters.Add("@RX_NO", SqlDbType.Int).Value = RX_NO;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();

                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();

                // fill adapater
                aAdapter.Fill(aDataSet);

                // return dataSet
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet SearchPhysician(string searchTerm)
        {
            try
            {
                // Open connection
                myConn.Open();

                // Clear any parameters
                cmdString.Parameters.Clear();

                // Set up command for stored procedure
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "SearchPhysician";

                // Parse search term
                string[] terms = searchTerm.Trim().Split(' ');

                // Add parameters for first and last name
                if (terms.Length > 0)
                {
                    cmdString.Parameters.AddWithValue("@FName", terms[0]);
                }
                else
                {
                    cmdString.Parameters.AddWithValue("@FName", DBNull.Value);
                }

                if (terms.Length > 1)
                {
                    cmdString.Parameters.AddWithValue("@LName", terms[1]);
                }
                else
                {
                    cmdString.Parameters.AddWithValue("@LName", DBNull.Value);
                }

                // Set up adapter and dataset
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdString;

                DataSet dataSet = new DataSet();

                // Fill adapter
                adapter.Fill(dataSet);

                // Return dataset
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }


        public DataSet LoadRefills(string prescriptionId)
        {
            try
            {

                myConn.Open();

                // Clear parameters and set up command
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.Text;
                cmdString.CommandText = @"
                SELECT R.*, P.RefillsLeft
                FROM Refills AS R
                INNER JOIN Prescriptions AS P ON R.PrescriptionID = P.PrescriptionID
                WHERE R.PrescriptionID = @PrescriptionID";

                // Add prescription ID parameter
                cmdString.Parameters.AddWithValue("@PrescriptionID", prescriptionId);

                // Set up adapter and dataset
                SqlDataAdapter adapter = new SqlDataAdapter(cmdString);
                DataSet dataSet = new DataSet();

                // Fill the dataset
                adapter.Fill(dataSet);

                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void TriggerRefillProcedure(int prescriptionId, string status)
        {
            try
            {
                myConn.Open();
                // Clear parameters and set up for stored procedure
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "dbo.GETREFILLS";

                // Add parameters for the stored procedure
                cmdString.Parameters.AddWithValue("@PrescriptionID", prescriptionId > 0 ? (object)prescriptionId : DBNull.Value);
                cmdString.Parameters.AddWithValue("@status", !string.IsNullOrEmpty(status) ? (object)status : DBNull.Value);

                // Execute the stored procedure
                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            { 
                myConn.Close(); 
            }
        }


        public DataSet LoadPatientInfo(string patientID)
        {       
            try
            {
                // Open the connection
                myConn.Open();
                // Clear parameters and set up command for stored procedure
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "GetPatientInfoAndPrescriptions";
                cmdString.Parameters.AddWithValue("@PatientID", patientID);
                // Set up adapter and dataset
                SqlDataAdapter adapter = new SqlDataAdapter(cmdString);
                DataSet dataSet = new DataSet();
                // Fill the dataset
                adapter.Fill(dataSet);

                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                // Close the connection
                myConn.Close();
            }
        }

        public void DeletePatient(string PatID)
        {
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "DeletePatient";
                // Define input parameter
                cmdString.Parameters.Add("@PATIENTID", SqlDbType.VarChar, 25).Value = PatID;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();
                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void DeleteDoctor(string docID)
        {
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "DeleteDoctor";
                // Define input parameter
                cmdString.Parameters.Add("@DOCTORID", SqlDbType.VarChar, 20).Value = docID;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();
                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
               // throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void DeletePresc(string PrescID)
        {
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "DeletePresc";
                // Define input parameter
                cmdString.Parameters.Add("@PrescID", SqlDbType.VarChar, 7).Value = PrescID;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();
                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void DeletRefill(string RXNO, string PrescID)
        {
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "DeletRefill";
                // Define input parameter
                cmdString.Parameters.Add("@RXNO", SqlDbType.VarChar, 20).Value = RXNO;
                cmdString.Parameters.Add("@PrescID", SqlDbType.VarChar, 20).Value = PrescID;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();
                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
               // throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void DeleteRefill(int RXNO)
        {
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "DeleteRefill";
                // Define input parameter
                cmdString.Parameters.Add("@RX_NO", SqlDbType.Int).Value = RXNO;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();
                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
               // throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void UpdateRefill(string RXNO, DateTime Date, string Status)
        {
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "UpdateRefill";
                // Define input parameter
                cmdString.Parameters.Add("@RXNO", SqlDbType.VarChar, 20).Value = RXNO;
                cmdString.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                if (!string.IsNullOrEmpty(Status) && (Status == "COMPLETED" || Status == "PENDING"))
                {
                    cmdString.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = Status;
                }
                else if (!string.IsNullOrEmpty(Status))
                {
                    throw new ArgumentException("Please select 'COMPLETED' OR 'PENDING'.");
                }
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();
                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet RXByID(string rxno)

        {
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "RXByID";
                // Define input parameter
                cmdString.Parameters.Add("@rxid", SqlDbType.VarChar, 6).Value = rxno;
                // adapter and dataset
                SqlDataAdapter aAdapter = new SqlDataAdapter();
                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();
                // fill adapater
                aAdapter.Fill(aDataSet);

                // return dataSet
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void UpdateDoctor(string DoctorID, string Fname, string LName, string Email, string Phone)
        {
            bool IsAllLetters(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            bool IsLettersDigitsOrSpaces(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            try
            {
                // Open connection
                myConn.Open();

                // Clear any parameters
                cmdString.Parameters.Clear();

                // Command configuration
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "UpdateDoctor";

                cmdString.Parameters.Add("@DoctorID", SqlDbType.VarChar, 20).Value = DoctorID;

                if (!string.IsNullOrEmpty(Fname) && IsAllLetters(Fname))
                {
                    cmdString.Parameters.Add("@Fname", SqlDbType.VarChar, 25).Value = Fname;
                }
                else if (!string.IsNullOrEmpty(Fname))
                {
                    throw new ArgumentException("First name must contain only letters.");
                }

                if (!string.IsNullOrEmpty(LName) && IsAllLetters(LName))
                {
                    cmdString.Parameters.Add("@Lname", SqlDbType.VarChar, 25).Value = LName;
                }
                else if (!string.IsNullOrEmpty(LName))
                {
                    throw new ArgumentException("Last name must contain only letters.");
                }
                cmdString.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email;

                if (!string.IsNullOrEmpty(Phone) && IsLettersDigitsOrSpaces(Phone))
                {
                    cmdString.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = Phone;
                }

                cmdString.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // throw new Exception(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void AddRefill(string PrescriptionID, string Refill)
        {
            try
            {
                // open connection 
                myConn.Open();
                //clear any parameters 
                cmdString.Parameters.Clear();
                // command 
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "ADDREFILL";
                //  Define input parameter 
                cmdString.Parameters.Add("@PrescriptionID", SqlDbType.VarChar, 25).Value = PrescriptionID;
                cmdString.Parameters.Add("@REFILLSLEFT", SqlDbType.Int).Value = Refill;
                cmdString.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public bool VerifyUser(string Username, string Password)
        {
            bool acessG = false;
            try
            {
                // open connection
                myConn.Open();
                //clear any parameters
                cmdString.Parameters.Clear();
                // command
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "VerfiyUser";
                // Define input parameter
                cmdString.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = Username;
                cmdString.Parameters.Add("@UPassword", SqlDbType.VarChar, 100).Value = Password;

                SqlParameter Result = new SqlParameter("@Result", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                cmdString.Parameters.Add(Result);
                cmdString.ExecuteNonQuery();

                acessG = Convert.ToInt32(Result.Value) == 1;
                return acessG;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

    }
}
