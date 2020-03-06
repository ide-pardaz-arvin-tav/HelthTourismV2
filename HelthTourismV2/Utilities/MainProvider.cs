using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Utilities
{
    public class MainProvider
    {
        private static readonly string ConnectionString =
        ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _commandText = "";

        public MainProvider()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        private void _disconnect()
        {
            _connection.Close();
        }

        public enum Tables
        {
            TblHospital,
            TblPatientSicknessRel,
            TblDoctor,
            TblImage,
            TblCity,
            TblCountry,
            TblSickness,
            TblOperation,
            TblUserPass,
            TblNews,
            TblSection,
            TblPatient,
            TblPatientImageRel,
            TblConfig,
            TblSectionOperationRel,
            TblOperationImageRel,
            TblHospitalImageRel,
            TblHospitalSectionRel,
            TblNewsImageRel,
            TblTicket,
            TblTicketImageRel
        }

        public enum PatientSicknessRel
        {
            PatientId,
            SicknessId,
            DoctorId,
            HospitalId,
            BeforeCureDesc,
            AfterCureDesc
        }

        public enum PatientImageRel
        {
            PatientId,
            ImageId
        }

        public enum SectionOperationRel
        {
            SectionId,
            OperationId
        }

        public enum OperationImageRel
        {
            OperationId,
            ImageId
        }

        public enum HospitalImageRel
        {
            HospitalId,
            ImageId
        }

        public enum HospitalSectionRel
        {
            HospitalId,
            SectionId,
            DoctorId
        }

        public enum NewsImageRel
        {
            NewsId,
            ImageId
        }

        public enum TicketImageRel
        {
            TicketId,
            ImageId
        }

        public object Add<T>(T table)
        {
            try
            {
                object tableObj = table;
                SqlCommand command;
                if (table.GetType() == typeof(TblHospital))
                {
                    TblHospital hospital = (TblHospital)tableObj;
                    if (!MethodRepo.ExistInDb("TblHospital", "Name", hospital.Name))
                    {
                        _commandText =
                            $"insert into TblHospital (Name , UserPassId , Percentage , Description , Longitude , Latitude) values ('{hospital.Name}' , '{hospital.UserPassId}' , '{hospital.Percentage}' , '{hospital.Description}' , '{hospital.Longitude}' , '{hospital.Latitude}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblHospital where Name = '{hospital.Name}' ORDER BY id DESC",
                            _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblHospital(Convert.ToInt32(reader["id"]), reader["Name"].ToString(),
                            Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Percentage"]),
                            reader["Description"].ToString(), reader["Longitude"].ToString(),
                            reader["Latitude"].ToString());
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblPatientSicknessRel))
                {
                    TblPatientSicknessRel patientSicknessRel = (TblPatientSicknessRel)tableObj;
                    _commandText = $"insert into TblPatientSicknessRel (PatientId , SicknessId , DoctorId , HospitalId , BeforeCureDesc , AfterCureDesc) values ('{patientSicknessRel.PatientId}' , '{patientSicknessRel.SicknessId}' , '{patientSicknessRel.DoctorId}' , '{patientSicknessRel.HospitalId}' , '{patientSicknessRel.BeforeCureDesc}' , '{patientSicknessRel.AfterCureDesc}' )";
                    command = new SqlCommand($"select TOP (1) * from TblPatientSicknessRel where PatientId = '{patientSicknessRel.PatientId}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblPatientSicknessRel(Convert.ToInt32(reader["id"]),
                        Convert.ToInt32(reader["PatientId"]), Convert.ToInt32(reader["SicknessId"]),
                        Convert.ToInt32(reader["DoctorId"]), Convert.ToInt32(reader["HospitalId"]),
                        reader["BeforeCureDesc"].ToString(), reader["AfterCureDesc"].ToString());
                }
                else if (table.GetType() == typeof(TblDoctor))
                {
                    TblDoctor doctor = (TblDoctor)tableObj;
                    if (!MethodRepo.ExistInDb("TblDoctor", "Name", doctor.Name))
                    {
                        _commandText =
                            $"insert into TblDoctor (Name , SectionId , NowActive) values ('{doctor.Name}' , '{doctor.SectionId}' , '{doctor.NowActive}' )";
                        command = new SqlCommand($"select TOP (1) * from TblDoctor where Name = '{doctor.Name}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblDoctor(Convert.ToInt32(reader["id"]), reader["Name"].ToString(),
                            Convert.ToInt32(reader["SectionId"]), Convert.ToBoolean(reader["NowActive"]));
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblImage))
                {
                    TblImage image = (TblImage)tableObj;
                    _commandText = $"insert into TblImage (Image , Status) values ('{image.Image}' , '{image.Status}' )";
                    command = new SqlCommand($"select TOP (1) * from TblImage where Image = '{image.Image}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblImage(Convert.ToInt32(reader["id"]), reader["Image"].ToString(),
                        Convert.ToInt32(reader["Status"]));
                }
                else if (table.GetType() == typeof(TblCity))
                {
                    TblCity city = (TblCity)tableObj;
                    if (!MethodRepo.ExistInDb("TblCity", "Name", city.Name))
                    {
                        _commandText =
                            $"insert into TblCity (Name , CountryId) values ('{city.Name}' , '{city.CountryId}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblCity where Name = '{city.Name}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblCity(Convert.ToInt32(reader["id"]), reader["Name"].ToString(),
                            Convert.ToInt32(reader["CountryId"]));
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblCountry))
                {
                    TblCountry country = (TblCountry)tableObj;
                    if (!MethodRepo.ExistInDb("TblCountry", "Name", country.Name))
                    {
                        _commandText = $"insert into TblCountry (Name) values ('{country.Name}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblCountry where Name = '{country.Name}' ORDER BY id DESC",
                            _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblCountry(Convert.ToInt32(reader["id"]), reader["Name"].ToString());
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblSickness))
                {
                    TblSickness sickness = (TblSickness)tableObj;
                    if (!MethodRepo.ExistInDb("TblSickness", "Name", sickness.Name))
                    {
                        _commandText =
                            $"insert into TblSickness (Name , SectionId) values ('{sickness.Name}' , '{sickness.SectionId}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblSickness where Name = '{sickness.Name}' ORDER BY id DESC",
                            _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblSickness(Convert.ToInt32(reader["id"]), reader["Name"].ToString(),
                            Convert.ToInt32(reader["SectionId"]));
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblOperation))
                {
                    TblOperation operation = (TblOperation)tableObj;
                    _commandText = $"insert into TblOperation (OperationName , OperationPrice) values ('{operation.OperationName}' , '{operation.OperationPrice}' )";
                    command = new SqlCommand($"select TOP (1) * from TblOperation where OperationName = '{operation.OperationName}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblOperation(Convert.ToInt32(reader["id"]), reader["OperationName"].ToString(),
                        long.Parse(reader["OperationPrice"].ToString()));
                }
                else if (table.GetType() == typeof(TblUserPass))
                {
                    TblUserPass userPass = (TblUserPass)tableObj;
                    if (!MethodRepo.ExistInDb("TblUserPass", "Username", userPass.Username))
                    {
                        _commandText =
                            $"insert into TblUserPass (Username , Password , IsHelthApple) values ('{userPass.Username}' , '{userPass.Password}' , '{userPass.IsHelthApple}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblUserPass where Username = '{userPass.Username}' ORDER BY id DESC",
                            _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblUserPass(Convert.ToInt32(reader["id"]), reader["Username"].ToString(),
                            reader["Password"].ToString(), Convert.ToBoolean(reader["IsHelthApple"]));
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblNews))
                {
                    TblNews news = (TblNews)tableObj;
                    if (!MethodRepo.ExistInDb("TblNews", "Title", news.Title))
                    {
                        _commandText =
                            $"insert into TblNews (Title , MainData , MainDataRtf) values ('{news.Title}' , '{news.MainData}' , '{news.MainDataRtf}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblNews where Title = '{news.Title}' ORDER BY id DESC",
                            _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblNews(Convert.ToInt32(reader["id"]), reader["Title"].ToString(),
                            reader["MainData"].ToString(), reader["MainDataRtf"].ToString());
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblSection))
                {
                    TblSection section = (TblSection)tableObj;
                    if (!MethodRepo.ExistInDb("TblSection", "SectionName", section.SectionName))
                    {
                        _commandText = $"insert into TblSection (SectionName) values ('{section.SectionName}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblSection where SectionName = '{section.SectionName}' ORDER BY id DESC",
                            _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblSection(Convert.ToInt32(reader["id"]), reader["SectionName"].ToString());
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblPatient))
                {
                    TblPatient patient = (TblPatient)tableObj;
                    if (!MethodRepo.ExistInDb("TblPatient", "Name", patient.Name))
                    {
                        _commandText =
                            $"insert into TblPatient (Name , IsMan , BirthDate , CountryId , CityId , PassNoOrIdentification , HelthCode , Email , TellNo , Address , Payed , CoShare , DateReleased , UserPassId , Status , TimeRegistered , ParentalName , Job , Insurance , HelpName , HelpJob , HelpPassNo , HelpTelNo) values ('{patient.Name}' , '{patient.IsMan}' , '{patient.BirthDate}' , '{patient.CountryId}' , '{patient.CityId}' , '{patient.PassNoOrIdentification}' , '{patient.HelthCode}' , '{patient.Email}' , '{patient.TellNo}' , '{patient.Address}' , '{patient.Payed}' , '{patient.CoShare}' , '{patient.DateReleased}' , '{patient.UserPassId}' , '{patient.Status}' , '{patient.TimeRegistered}' , '{patient.ParentalName}' , '{patient.Job}' , '{patient.Insurance}' , '{patient.HelpName}' , '{patient.HelpJob}' , '{patient.HelpPassNo}' , '{patient.HelpTelNo}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblPatient where Name = '{patient.Name}' ORDER BY id DESC",
                            _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(),
                            Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(),
                            Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]),
                            reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(),
                            reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(),
                            long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()),
                            reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]),
                            Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(),
                            reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(),
                            reader["HelpName"].ToString(), reader["HelpJob"].ToString(),
                            reader["HelpPassNo"].ToString(),
                            reader["HelpTelNo"].ToString());
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblPatientImageRel))
                {
                    TblPatientImageRel patientImageRel = (TblPatientImageRel)tableObj;
                    _commandText = $"insert into TblPatientImageRel (PatientId , ImageId) values ('{patientImageRel.PatientId}' , '{patientImageRel.ImageId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblPatientImageRel where PatientId = '{patientImageRel.PatientId}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblPatientImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["PatientId"]),
                        Convert.ToInt32(reader["ImageId"]));
                }
                else if (table.GetType() == typeof(TblConfig))
                {
                    TblConfig config = (TblConfig)tableObj;
                    if (!MethodRepo.ExistInDb("TblConfig", "JwtKey", config.JwtKey))
                    {
                        _commandText = $"insert into TblConfig (JwtKey) values ('{config.JwtKey}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblConfig where JwtKey = '{config.JwtKey}' ORDER BY id DESC",
                            _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblConfig(Convert.ToInt32(reader["id"]), reader["JwtKey"].ToString());
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblSectionOperationRel))
                {
                    TblSectionOperationRel sectionOperationRel = (TblSectionOperationRel)tableObj;
                    _commandText = $"insert into TblSectionOperationRel (SectionId , OperationId) values ('{sectionOperationRel.SectionId}' , '{sectionOperationRel.OperationId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblSectionOperationRel where SectionId = '{sectionOperationRel.SectionId}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblSectionOperationRel(Convert.ToInt32(reader["id"]),
                        Convert.ToInt32(reader["SectionId"]), Convert.ToInt32(reader["OperationId"]));
                }
                else if (table.GetType() == typeof(TblOperationImageRel))
                {
                    TblOperationImageRel operationImageRel = (TblOperationImageRel)tableObj;
                    _commandText = $"insert into TblOperationImageRel (OperationId , ImageId) values ('{operationImageRel.OperationId}' , '{operationImageRel.ImageId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblOperationImageRel where OperationId = '{operationImageRel.OperationId}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblOperationImageRel(Convert.ToInt32(reader["id"]),
                        Convert.ToInt32(reader["OperationId"]), Convert.ToInt32(reader["ImageId"]));
                }
                else if (table.GetType() == typeof(TblHospitalImageRel))
                {
                    TblHospitalImageRel hospitalImageRel = (TblHospitalImageRel)tableObj;
                    _commandText = $"insert into TblHospitalImageRel (HospitalId , ImageId) values ('{hospitalImageRel.HospitalId}' , '{hospitalImageRel.ImageId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblHospitalImageRel where HospitalId = '{hospitalImageRel.HospitalId}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblHospitalImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["HospitalId"]),
                        Convert.ToInt32(reader["ImageId"]));
                }
                else if (table.GetType() == typeof(TblHospitalSectionRel))
                {
                    TblHospitalSectionRel hospitalSectionRel = (TblHospitalSectionRel)tableObj;
                    _commandText = $"insert into TblHospitalSectionRel (HospitalId , SectionId , DoctorId) values ('{hospitalSectionRel.HospitalId}' , '{hospitalSectionRel.SectionId}' , '{hospitalSectionRel.DoctorId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblHospitalSectionRel where HospitalId = '{hospitalSectionRel.HospitalId}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblHospitalSectionRel(Convert.ToInt32(reader["id"]),
                        Convert.ToInt32(reader["HospitalId"]), Convert.ToInt32(reader["SectionId"]),
                        Convert.ToInt32(reader["DoctorId"]));
                }
                else if (table.GetType() == typeof(TblNewsImageRel))
                {
                    TblNewsImageRel newsImageRel = (TblNewsImageRel)tableObj;
                    _commandText = $"insert into TblNewsImageRel (NewsId , ImageId) values ('{newsImageRel.NewsId}' , '{newsImageRel.ImageId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblNewsImageRel where NewsId = '{newsImageRel.NewsId}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblNewsImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["NewsId"]),
                        Convert.ToInt32(reader["ImageId"]));
                }
                else if (table.GetType() == typeof(TblTicket))
                {
                    TblTicket ticket = (TblTicket)tableObj;
                    if (!MethodRepo.ExistInDb("TblTicket", "Email", ticket.Email))
                    {
                        _commandText =
                            $"insert into TblTicket (IsRegistered , UserPassId , Email , TellNo , Data) values ('{ticket.IsRegistered}' , '{ticket.UserPassId}' , '{ticket.Email}' , '{ticket.TellNo}' , '{ticket.Data}' )";
                        command = new SqlCommand(
                            $"select TOP (1) * from TblTicket where Email = '{ticket.Email}' ORDER BY id DESC",
                            _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblTicket(Convert.ToInt32(reader["id"]), Convert.ToBoolean(reader["IsRegistered"]),
                            Convert.ToInt32(reader["UserPassId"]), reader["Email"].ToString(),
                            reader["TellNo"].ToString(), reader["Data"].ToString());
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblTicketImageRel))
                {
                    TblTicketImageRel ticketImageRel = (TblTicketImageRel)tableObj;
                    _commandText = $"insert into TblTicketImageRel (TicketId , ImageId) values ('{ticketImageRel.TicketId}' , '{ticketImageRel.ImageId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblTicketImageRel where TicketId = '{ticketImageRel.TicketId}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblTicketImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["TicketId"]),
                        Convert.ToInt32(reader["ImageId"]));
                }
                else return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public bool Update<T>(T table, int logId)
        {
            try
            {
                object tableObj = table;
                if (table.GetType() == typeof(TblHospital))
                {
                    TblHospital hospital = (TblHospital)tableObj;
                    if (!MethodRepo.ExistInDb("TblHospital", "Name", hospital.Name))
                        _commandText =
                            $"update TblHospital set Name = '{hospital.Name}' , UserPassId = '{hospital.UserPassId}' , Percentage = '{hospital.Percentage}' , Description = '{hospital.Description}' , Longitude = '{hospital.Longitude}' , Latitude = '{hospital.Latitude}  where id = '{logId}'";
                    else return false;
                }
                else if (table.GetType() == typeof(TblPatientSicknessRel))
                {
                    TblPatientSicknessRel patientSicknessRel = (TblPatientSicknessRel)tableObj;
                    _commandText = $"update TblPatientSicknessRel set PatientId = '{patientSicknessRel.PatientId}' , SicknessId = '{patientSicknessRel.SicknessId}' , DoctorId = '{patientSicknessRel.DoctorId}' , HospitalId = '{patientSicknessRel.HospitalId}' , BeforeCureDesc = '{patientSicknessRel.BeforeCureDesc}' , AfterCureDesc = '{patientSicknessRel.AfterCureDesc}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblDoctor))
                {
                    TblDoctor doctor = (TblDoctor)tableObj;
                    if (!MethodRepo.ExistInDb("TblDoctor", "Name", doctor.Name))
                        _commandText =
                            $"update TblDoctor set Name = '{doctor.Name}' , SectionId = '{doctor.SectionId}' , NowActive = '{doctor.NowActive}  where id = '{logId}'";
                    else return false;
                }
                else if (table.GetType() == typeof(TblImage))
                {
                    TblImage image = (TblImage)tableObj;
                    _commandText = $"update TblImage set Image = '{image.Image}' , Status = '{image.Status}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblCity))
                {
                    TblCity city = (TblCity)tableObj;
                    if (!MethodRepo.ExistInDb("TblCity", "Name", city.Name))
                        _commandText =
                            $"update TblCity set Name = '{city.Name}' , CountryId = '{city.CountryId}  where id = '{logId}'";
                    else return false;
                }
                else if (table.GetType() == typeof(TblCountry))
                {
                    TblCountry country = (TblCountry)tableObj;
                    if (!MethodRepo.ExistInDb("TblCountry", "Name", country.Name))
                        _commandText =
                            $"update TblCountry set Name = '{country.Name}  where id = '{logId}'";
                    else return false;
                }
                else if (table.GetType() == typeof(TblSickness))
                {
                    TblSickness sickness = (TblSickness)tableObj;
                    if (!MethodRepo.ExistInDb("TblSickness", "Name", sickness.Name))
                        _commandText =
                            $"update TblSickness set Name = '{sickness.Name}' , SectionId = '{sickness.SectionId}  where id = '{logId}'";
                    else return false;
                }
                else if (table.GetType() == typeof(TblOperation))
                {
                    TblOperation operation = (TblOperation)tableObj;
                    _commandText = $"update TblOperation set OperationName = '{operation.OperationName}' , OperationPrice = '{operation.OperationPrice}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblUserPass))
                {
                    TblUserPass userPass = (TblUserPass)tableObj;
                    if (!MethodRepo.ExistInDb("TblUserPass", "Username", userPass.Username))
                        _commandText =
                            $"update TblUserPass set Username = '{userPass.Username}' , Password = '{userPass.Password}' , IsHelthApple = '{userPass.IsHelthApple}  where id = '{logId}'";
                    else return false;
                }
                else if (table.GetType() == typeof(TblNews))
                {
                    TblNews news = (TblNews)tableObj;
                    if (!MethodRepo.ExistInDb("TblNews", "Title", news.Title))
                        _commandText =
                            $"update TblNews set Title = '{news.Title}' , MainData = '{news.MainData}' , MainDataRtf = '{news.MainDataRtf}  where id = '{logId}'";
                    else return false;
                }
                else if (table.GetType() == typeof(TblSection))
                {
                    TblSection section = (TblSection)tableObj;
                    if (!MethodRepo.ExistInDb("TblSection", "SectionName", section.SectionName))
                        _commandText =
                            $"update TblSection set SectionName = '{section.SectionName}  where id = '{logId}'";
                    else return false;
                }
                else if (table.GetType() == typeof(TblPatient))
                {
                    TblPatient patient = (TblPatient)tableObj;
                    if (!MethodRepo.ExistInDb("TblPatient", "Name", patient.Name))
                        _commandText =
                            $"update TblPatient set Name = '{patient.Name}' , IsMan = '{patient.IsMan}' , BirthDate = '{patient.BirthDate}' , CountryId = '{patient.CountryId}' , CityId = '{patient.CityId}' , PassNoOrIdentification = '{patient.PassNoOrIdentification}' , HelthCode = '{patient.HelthCode}' , Email = '{patient.Email}' , TellNo = '{patient.TellNo}' , Address = '{patient.Address}' , Payed = '{patient.Payed}' , CoShare = '{patient.CoShare}' , DateReleased = '{patient.DateReleased}' , UserPassId = '{patient.UserPassId}' , Status = '{patient.Status}' , TimeRegistered = '{patient.TimeRegistered}' , ParentalName = '{patient.ParentalName}' , Job = '{patient.Job}' , Insurance = '{patient.Insurance}' , HelpName = '{patient.HelpName}' , HelpJob = '{patient.HelpJob}' , HelpPassNo = '{patient.HelpPassNo}' , HelpTelNo = '{patient.HelpTelNo}  where id = '{logId}'";
                    else return false;
                }
                else if (table.GetType() == typeof(TblPatientImageRel))
                {
                    TblPatientImageRel patientImageRel = (TblPatientImageRel)tableObj;
                    _commandText = $"update TblPatientImageRel set PatientId = '{patientImageRel.PatientId}' , ImageId = '{patientImageRel.ImageId}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblConfig))
                {
                    TblConfig config = (TblConfig)tableObj;
                    _commandText = $"update TblConfig set JwtKey = '{config.JwtKey}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblSectionOperationRel))
                {
                    TblSectionOperationRel sectionOperationRel = (TblSectionOperationRel)tableObj;
                    _commandText = $"update TblSectionOperationRel set SectionId = '{sectionOperationRel.SectionId}' , OperationId = '{sectionOperationRel.OperationId}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblOperationImageRel))
                {
                    TblOperationImageRel operationImageRel = (TblOperationImageRel)tableObj;
                    _commandText = $"update TblOperationImageRel set OperationId = '{operationImageRel.OperationId}' , ImageId = '{operationImageRel.ImageId}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblHospitalImageRel))
                {
                    TblHospitalImageRel hospitalImageRel = (TblHospitalImageRel)tableObj;
                    _commandText = $"update TblHospitalImageRel set HospitalId = '{hospitalImageRel.HospitalId}' , ImageId = '{hospitalImageRel.ImageId}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblHospitalSectionRel))
                {
                    TblHospitalSectionRel hospitalSectionRel = (TblHospitalSectionRel)tableObj;
                    _commandText = $"update TblHospitalSectionRel set HospitalId = '{hospitalSectionRel.HospitalId}' , SectionId = '{hospitalSectionRel.SectionId}' , DoctorId = '{hospitalSectionRel.DoctorId}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblNewsImageRel))
                {
                    TblNewsImageRel newsImageRel = (TblNewsImageRel)tableObj;
                    _commandText = $"update TblNewsImageRel set NewsId = '{newsImageRel.NewsId}' , ImageId = '{newsImageRel.ImageId}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblTicket))
                {
                    TblTicket ticket = (TblTicket)tableObj;
                    if (!MethodRepo.ExistInDb("TblTicket", "Email", ticket.Email))
                        _commandText = $"update TblTicket set IsRegistered = '{ticket.IsRegistered}' , UserPassId = '{ticket.UserPassId}' , Email = '{ticket.Email}' , TellNo = '{ticket.TellNo}' , Data = '{ticket.Data}  where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblTicketImageRel))
                {
                    TblTicketImageRel ticketImageRel = (TblTicketImageRel)tableObj;
                    _commandText = $"update TblTicketImageRel set TicketId = '{ticketImageRel.TicketId}' , ImageId = '{ticketImageRel.ImageId}  where id = '{logId}'";
                }
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public bool Delete(Tables tableType, int id)
        {
            try
            {
                _commandText = $"delete from {tableType.ToString()} where id = N'{id}'";
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public IEnumerable SelectAll(Tables tableType)
        {
            try
            {
                _commandText = $"select * from {tableType.ToString()}";
                _command = new SqlCommand(_commandText, _connection);
                SqlDataReader reader = _command.ExecuteReader();
                switch (tableType)
                {
                    case Tables.TblHospital:
                        List<TblHospital> hospitals = new List<TblHospital>();
                        while (reader.Read())
                            hospitals.Add(new TblHospital(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Percentage"]), reader["Description"].ToString(), reader["Longitude"].ToString(), reader["Latitude"].ToString()));
                        return hospitals;

                    case Tables.TblPatientSicknessRel:
                        List<TblPatientSicknessRel> patientSicknessRels = new List<TblPatientSicknessRel>();
                        while (reader.Read())
                            patientSicknessRels.Add(new TblPatientSicknessRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["PatientId"]), Convert.ToInt32(reader["SicknessId"]), Convert.ToInt32(reader["DoctorId"]), Convert.ToInt32(reader["HospitalId"]), reader["BeforeCureDesc"].ToString(), reader["AfterCureDesc"].ToString()));
                        return patientSicknessRels;

                    case Tables.TblDoctor:
                        List<TblDoctor> doctors = new List<TblDoctor>();
                        while (reader.Read())
                            doctors.Add(new TblDoctor(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["SectionId"]), Convert.ToBoolean(reader["NowActive"])));
                        return doctors;

                    case Tables.TblImage:
                        List<TblImage> images = new List<TblImage>();
                        while (reader.Read())
                            images.Add(new TblImage(Convert.ToInt32(reader["id"]), reader["Image"].ToString(), Convert.ToInt32(reader["Status"])));
                        return images;

                    case Tables.TblCity:
                        List<TblCity> cities = new List<TblCity>();
                        while (reader.Read())
                            cities.Add(new TblCity(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["CountryId"])));
                        return cities;

                    case Tables.TblCountry:
                        List<TblCountry> countries = new List<TblCountry>();
                        while (reader.Read())
                            countries.Add(new TblCountry(Convert.ToInt32(reader["id"]), reader["Name"].ToString()));
                        return countries;

                    case Tables.TblSickness:
                        List<TblSickness> sicknesses = new List<TblSickness>();
                        while (reader.Read())
                            sicknesses.Add(new TblSickness(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["SectionId"])));
                        return sicknesses;

                    case Tables.TblOperation:
                        List<TblOperation> operations = new List<TblOperation>();
                        while (reader.Read())
                            operations.Add(new TblOperation(Convert.ToInt32(reader["id"]), reader["OperationName"].ToString(), long.Parse(reader["OperationPrice"].ToString())));
                        return operations;

                    case Tables.TblUserPass:
                        List<TblUserPass> userPasses = new List<TblUserPass>();
                        while (reader.Read())
                            userPasses.Add(new TblUserPass(Convert.ToInt32(reader["id"]), reader["Username"].ToString(), reader["Password"].ToString(), Convert.ToBoolean(reader["IsHelthApple"])));
                        return userPasses;

                    case Tables.TblNews:
                        List<TblNews> newses = new List<TblNews>();
                        while (reader.Read())
                            newses.Add(new TblNews(Convert.ToInt32(reader["id"]), reader["Title"].ToString(), reader["MainData"].ToString(), reader["MainDataRtf"].ToString()));
                        return newses;

                    case Tables.TblSection:
                        List<TblSection> sections = new List<TblSection>();
                        while (reader.Read())
                            sections.Add(new TblSection(Convert.ToInt32(reader["id"]), reader["SectionName"].ToString()));
                        return sections;

                    case Tables.TblPatient:
                        List<TblPatient> patients = new List<TblPatient>();
                        while (reader.Read())
                            patients.Add(new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString()));
                        return patients;

                    case Tables.TblPatientImageRel:
                        List<TblPatientImageRel> patientImageRels = new List<TblPatientImageRel>();
                        while (reader.Read())
                            patientImageRels.Add(new TblPatientImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["PatientId"]), Convert.ToInt32(reader["ImageId"])));
                        return patientImageRels;

                    case Tables.TblConfig:
                        List<TblConfig> configs = new List<TblConfig>();
                        while (reader.Read())
                            configs.Add(new TblConfig(Convert.ToInt32(reader["id"]), reader["JwtKey"].ToString()));
                        return configs;

                    case Tables.TblSectionOperationRel:
                        List<TblSectionOperationRel> sectionOperationRels = new List<TblSectionOperationRel>();
                        while (reader.Read())
                            sectionOperationRels.Add(new TblSectionOperationRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["SectionId"]), Convert.ToInt32(reader["OperationId"])));
                        return sectionOperationRels;

                    case Tables.TblOperationImageRel:
                        List<TblOperationImageRel> operationImageRels = new List<TblOperationImageRel>();
                        while (reader.Read())
                            operationImageRels.Add(new TblOperationImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["OperationId"]), Convert.ToInt32(reader["ImageId"])));
                        return operationImageRels;

                    case Tables.TblHospitalImageRel:
                        List<TblHospitalImageRel> hospitalImageRels = new List<TblHospitalImageRel>();
                        while (reader.Read())
                            hospitalImageRels.Add(new TblHospitalImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["HospitalId"]), Convert.ToInt32(reader["ImageId"])));
                        return hospitalImageRels;

                    case Tables.TblHospitalSectionRel:
                        List<TblHospitalSectionRel> hospitalSectionRels = new List<TblHospitalSectionRel>();
                        while (reader.Read())
                            hospitalSectionRels.Add(new TblHospitalSectionRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["HospitalId"]), Convert.ToInt32(reader["SectionId"]), Convert.ToInt32(reader["DoctorId"])));
                        return hospitalSectionRels;

                    case Tables.TblNewsImageRel:
                        List<TblNewsImageRel> newsImageRels = new List<TblNewsImageRel>();
                        while (reader.Read())
                            newsImageRels.Add(new TblNewsImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["NewsId"]), Convert.ToInt32(reader["ImageId"])));
                        return newsImageRels;

                    case Tables.TblTicket:
                        List<TblTicket> tickets = new List<TblTicket>();
                        while (reader.Read())
                            tickets.Add(new TblTicket(Convert.ToInt32(reader["id"]), Convert.ToBoolean(reader["IsRegistered"]), Convert.ToInt32(reader["UserPassId"]), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Data"].ToString()));
                        return tickets;

                    case Tables.TblTicketImageRel:
                        List<TblTicketImageRel> ticketImageRels = new List<TblTicketImageRel>();
                        while (reader.Read())
                            ticketImageRels.Add(new TblTicketImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["TicketId"]), Convert.ToInt32(reader["ImageId"])));
                        return ticketImageRels;

                    default:
                        return new List<bool>();
                }
            }
            catch
            {
                return new List<bool>();
            }
            finally
            {
                _disconnect();
            }
        }

        public object SelectById(Tables table, int id)
        {
            try
            {
                _command = new SqlCommand($"select * from {table.ToString()} where id = '{id}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                if (table == Tables.TblHospital)
                    return new TblHospital(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Percentage"]), reader["Description"].ToString(), reader["Longitude"].ToString(), reader["Latitude"].ToString());
                else if (table == Tables.TblPatientSicknessRel)
                    return new TblPatientSicknessRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["PatientId"]), Convert.ToInt32(reader["SicknessId"]), Convert.ToInt32(reader["DoctorId"]), Convert.ToInt32(reader["HospitalId"]), reader["BeforeCureDesc"].ToString(), reader["AfterCureDesc"].ToString());
                else if (table == Tables.TblDoctor)
                    return new TblDoctor(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["SectionId"]), Convert.ToBoolean(reader["NowActive"]));
                else if (table == Tables.TblImage)
                    return new TblImage(Convert.ToInt32(reader["id"]), reader["Image"].ToString(), Convert.ToInt32(reader["Status"]));
                else if (table == Tables.TblCity)
                    return new TblCity(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["CountryId"]));
                else if (table == Tables.TblCountry)
                    return new TblCountry(Convert.ToInt32(reader["id"]), reader["Name"].ToString());
                else if (table == Tables.TblSickness)
                    return new TblSickness(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["SectionId"]));
                else if (table == Tables.TblOperation)
                    return new TblOperation(Convert.ToInt32(reader["id"]), reader["OperationName"].ToString(), long.Parse(reader["OperationPrice"].ToString()));
                else if (table == Tables.TblUserPass)
                    return new TblUserPass(Convert.ToInt32(reader["id"]), reader["Username"].ToString(), reader["Password"].ToString(), Convert.ToBoolean(reader["IsHelthApple"]));
                else if (table == Tables.TblNews)
                    return new TblNews(Convert.ToInt32(reader["id"]), reader["Title"].ToString(), reader["MainData"].ToString(), reader["MainDataRtf"].ToString());
                else if (table == Tables.TblSection)
                    return new TblSection(Convert.ToInt32(reader["id"]), reader["SectionName"].ToString());
                else if (table == Tables.TblPatient)
                    return new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString());
                else if (table == Tables.TblPatientImageRel)
                    return new TblPatientImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["PatientId"]), Convert.ToInt32(reader["ImageId"]));
                else if (table == Tables.TblConfig)
                    return new TblConfig(Convert.ToInt32(reader["id"]), reader["JwtKey"].ToString());
                else if (table == Tables.TblSectionOperationRel)
                    return new TblSectionOperationRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["SectionId"]), Convert.ToInt32(reader["OperationId"]));
                else if (table == Tables.TblOperationImageRel)
                    return new TblOperationImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["OperationId"]), Convert.ToInt32(reader["ImageId"]));
                else if (table == Tables.TblHospitalImageRel)
                    return new TblHospitalImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["HospitalId"]), Convert.ToInt32(reader["ImageId"]));
                else if (table == Tables.TblHospitalSectionRel)
                    return new TblHospitalSectionRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["HospitalId"]), Convert.ToInt32(reader["SectionId"]), Convert.ToInt32(reader["DoctorId"]));
                else if (table == Tables.TblNewsImageRel)
                    return new TblNewsImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["NewsId"]), Convert.ToInt32(reader["ImageId"]));
                else if (table == Tables.TblTicket)
                    return new TblTicket(Convert.ToInt32(reader["id"]), Convert.ToBoolean(reader["IsRegistered"]), Convert.ToInt32(reader["UserPassId"]), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Data"].ToString());
                else if (table == Tables.TblTicketImageRel)
                    return new TblTicketImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["TicketId"]), Convert.ToInt32(reader["ImageId"]));

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                _disconnect();
            }
        }

        #region TblHospital

        public TblHospital SelectHospitalByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblHospital where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblHospital(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Percentage"]), reader["Description"].ToString(), reader["Longitude"].ToString(), reader["Latitude"].ToString());
            }
            catch
            {
                return new TblHospital(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblHospital> SelectHospitalByUserPassId(int userPassId)
        {
            try
            {
                List<TblHospital> ret = new List<TblHospital>();
                _command = new SqlCommand($"select* from TblHospital where UserPassId = N'{userPassId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblHospital(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Percentage"]), reader["Description"].ToString(), reader["Longitude"].ToString(), reader["Latitude"].ToString()));
                }
                return ret;
            }
            catch
            {
                return new List<TblHospital>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblPatientSicknessRel

        public List<TblPatientSicknessRel> SelectPatientSicknessRel(int entry, PatientSicknessRel entryType)
        {
            try
            {
                List<TblPatientSicknessRel> ret = new List<TblPatientSicknessRel>();
                if (entryType == PatientSicknessRel.PatientId)
                    _command = new SqlCommand($"select* from TblPatientSicknessRel where PatientId = N'{entry}'", _connection);
                else if (entryType == PatientSicknessRel.SicknessId)
                    _command = new SqlCommand($"select* from TblPatientSicknessRel where SicknessId = N'{entry}'", _connection);
                else if (entryType == PatientSicknessRel.DoctorId)
                    _command = new SqlCommand($"select* from TblPatientSicknessRel where DoctorId = N'{entry}'", _connection);
                else if (entryType == PatientSicknessRel.HospitalId)
                    _command = new SqlCommand($"select* from TblPatientSicknessRel where HospitalId = N'{entry}'", _connection);
                else if (entryType == PatientSicknessRel.BeforeCureDesc)
                    _command = new SqlCommand($"select* from TblPatientSicknessRel where BeforeCureDesc = N'{entry}'", _connection);
                else if (entryType == PatientSicknessRel.AfterCureDesc)
                    _command = new SqlCommand($"select* from TblPatientSicknessRel where AfterCureDesc = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblPatientSicknessRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["PatientId"]), Convert.ToInt32(reader["SicknessId"]), Convert.ToInt32(reader["DoctorId"]), Convert.ToInt32(reader["HospitalId"]), reader["BeforeCureDesc"].ToString(), reader["AfterCureDesc"].ToString()));
                return ret;
            }
            catch
            {
                return new List<TblPatientSicknessRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblDoctor

        public TblDoctor SelectDoctorByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblDoctor(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["SectionId"]), Convert.ToBoolean(reader["NowActive"]));
            }
            catch
            {
                return new TblDoctor(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblDoctor> SelectDoctorBySectionId(int sectionId)
        {
            try
            {
                List<TblDoctor> ret = new List<TblDoctor>();
                _command = new SqlCommand($"select* from TblDoctor where SectionId = N'{sectionId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblDoctor(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["SectionId"]), Convert.ToBoolean(reader["NowActive"])));
                }
                return ret;
            }
            catch
            {
                return new List<TblDoctor>();
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblDoctor> SelectDoctorByNowActive(bool nowActive)
        {
            try
            {
                List<TblDoctor> ret = new List<TblDoctor>();
                _command = new SqlCommand($"select* from TblDoctor where NowActive = N'{nowActive}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblDoctor(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["SectionId"]), Convert.ToBoolean(reader["NowActive"])));
                }
                return ret;
            }
            catch
            {
                return new List<TblDoctor>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblImage

        public TblImage SelectImageByImage(string image)
        {
            try
            {
                _command = new SqlCommand($"select* from TblImage where Image = N'{image}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblImage(Convert.ToInt32(reader["id"]), reader["Image"].ToString(), Convert.ToInt32(reader["Status"]));
            }
            catch
            {
                return new TblImage(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblCity

        public TblCity SelectCityByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblCity where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblCity(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["CountryId"]));
            }
            catch
            {
                return new TblCity(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblCity> SelectCityByCountryId(int countryId)
        {
            try
            {
                List<TblCity> ret = new List<TblCity>();
                _command = new SqlCommand($"select* from TblCity where CountryId = N'{countryId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblCity(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["CountryId"])));
                }
                return ret;
            }
            catch
            {
                return new List<TblCity>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblCountry

        public TblCountry SelectCountryByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblCountry where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblCountry(Convert.ToInt32(reader["id"]), reader["Name"].ToString());
            }
            catch
            {
                return new TblCountry(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblSickness

        public TblSickness SelectSicknessByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblSickness where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblSickness(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["SectionId"]));
            }
            catch
            {
                return new TblSickness(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblSickness> SelectSicknessBySectionId(int sectionId)
        {
            try
            {
                List<TblSickness> ret = new List<TblSickness>();
                _command = new SqlCommand($"select* from TblSickness where SectionId = N'{sectionId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblSickness(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToInt32(reader["SectionId"])));
                }
                return ret;
            }
            catch
            {
                return new List<TblSickness>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblOperation

        public TblOperation SelectOperationByOperationName(string operationName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblOperation where OperationName = N'{operationName}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblOperation(Convert.ToInt32(reader["id"]), reader["OperationName"].ToString(), long.Parse(reader["OperationPrice"].ToString()));
            }
            catch
            {
                return new TblOperation(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblUserPass

        public TblUserPass SelectUserPassByUsername(string username)
        {
            try
            {
                _command = new SqlCommand($"select* from TblUserPass where Username = N'{username}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblUserPass(Convert.ToInt32(reader["id"]), reader["Username"].ToString(), reader["Password"].ToString(), Convert.ToBoolean(reader["IsHelthApple"]));
            }
            catch
            {
                return new TblUserPass(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public TblUserPass SelectUserPassByUsernameAndPassword(string username, string password)
        {
            try
            {
                _command = new SqlCommand($"select* from TblUserPass where Username = N'{username}' and Password = N'{password}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblUserPass(Convert.ToInt32(reader["id"]), reader["Username"].ToString(), reader["Password"].ToString(), Convert.ToBoolean(reader["IsHelthApple"]));
            }
            catch
            {
                return new TblUserPass(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public TblUserPass SelectUserPassByPassword(string password)
        {
            try
            {
                _command = new SqlCommand($"select* from TblUserPass where Password = N'{password}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblUserPass(Convert.ToInt32(reader["id"]), reader["Username"].ToString(), reader["Password"].ToString(), Convert.ToBoolean(reader["IsHelthApple"]));
            }
            catch
            {
                return new TblUserPass(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblUserPass> SelectUserPassByIsHelthApple(bool isHelthApple)
        {
            try
            {
                List<TblUserPass> ret = new List<TblUserPass>();
                _command = new SqlCommand($"select* from TblUserPass where IsHelthApple = N'{isHelthApple}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblUserPass(Convert.ToInt32(reader["id"]), reader["Username"].ToString(), reader["Password"].ToString(), Convert.ToBoolean(reader["IsHelthApple"])));
                }
                return ret;
            }
            catch
            {
                return new List<TblUserPass>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblNews

        public TblNews SelectNewsByTitle(string title)
        {
            try
            {
                _command = new SqlCommand($"select* from TblNews where Title = N'{title}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblNews(Convert.ToInt32(reader["id"]), reader["Title"].ToString(), reader["MainData"].ToString(), reader["MainDataRtf"].ToString());
            }
            catch
            {
                return new TblNews(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblSection

        public TblSection SelectSectionBySectionName(string sectionName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblSection where SectionName = N'{sectionName}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblSection(Convert.ToInt32(reader["id"]), reader["SectionName"].ToString());
            }
            catch
            {
                return new TblSection(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblPatient

        public TblPatient SelectPatientByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblPatient> SelectPatientByIsMan(bool isMan)
        {
            try
            {
                List<TblPatient> ret = new List<TblPatient>();
                _command = new SqlCommand($"select* from TblPatient where IsMan = N'{isMan}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString()));
                }
                return ret;
            }
            catch
            {
                return new List<TblPatient>();
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblPatient> SelectPatientByCountryId(int countryId)
        {
            try
            {
                List<TblPatient> ret = new List<TblPatient>();
                _command = new SqlCommand($"select* from TblPatient where CountryId = N'{countryId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                while (reader.Read())
                {
                    ret.Add(new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString()));
                }
                return ret;
            }
            catch
            {
                return new List<TblPatient>();
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblPatient> SelectPatientByCityId(int cityId)
        {
            try
            {
                List<TblPatient> ret = new List<TblPatient>();
                _command = new SqlCommand($"select* from TblPatient where CityId = N'{cityId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString()));
                }
                return ret;
            }
            catch
            {
                return new List<TblPatient>();
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblPatient> SelectPatientByPassNoOrIdentification(int passNoOrIdentification)
        {
            try
            {
                List<TblPatient> ret = new List<TblPatient>();
                _command = new SqlCommand($"select* from TblPatient where PassNoOrIdentification = N'{passNoOrIdentification}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString()));
                }
                return ret;
            }
            catch
            {
                return new List<TblPatient>();
            }
            finally
            {
                _disconnect();
            }
        }

        public TblPatient SelectPatientByEmail(string email)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where Email = N'{email}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public TblPatient SelectPatientByTellNo(string tellNo)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where TellNo = N'{tellNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblPatient> SelectPatientByUserPassId(int userPassId)
        {
            try
            {
                List<TblPatient> ret = new List<TblPatient>();
                _command = new SqlCommand($"select* from TblPatient where UserPassId = N'{userPassId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString()));
                }
                return ret;
            }
            catch
            {
                return new List<TblPatient>();
            }
            finally
            {
                _disconnect();
            }
        }

        public TblPatient SelectPatientByParentalName(string parentalName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where ParentalName = N'{parentalName}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public TblPatient SelectPatientByHelpName(string helpName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where HelpName = N'{helpName}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblPatient(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), Convert.ToBoolean(reader["IsMan"]), reader["BirthDate"].ToString(), Convert.ToInt32(reader["CountryId"]), Convert.ToInt32(reader["CityId"]), reader["PassNoOrIdentification"].ToString(), reader["HelthCode"].ToString(), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Address"].ToString(), long.Parse(reader["Payed"].ToString()), long.Parse(reader["CoShare"].ToString()), reader["DateReleased"].ToString(), Convert.ToInt32(reader["UserPassId"]), Convert.ToInt32(reader["Status"]), reader["TimeRegistered"].ToString(), reader["ParentalName"].ToString(), reader["Job"].ToString(), reader["Insurance"].ToString(), reader["HelpName"].ToString(), reader["HelpJob"].ToString(), reader["HelpPassNo"].ToString(), reader["HelpTelNo"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblPatientImageRel

        public List<TblPatientImageRel> SelectPatientImageRel(int entry, PatientImageRel entryType)
        {
            try
            {
                List<TblPatientImageRel> ret = new List<TblPatientImageRel>();
                if (entryType == PatientImageRel.PatientId)
                    _command = new SqlCommand($"select* from TblPatientImageRel where PatientId = N'{entry}'", _connection);
                else if (entryType == PatientImageRel.ImageId)
                    _command = new SqlCommand($"select* from TblPatientImageRel where ImageId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblPatientImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["PatientId"]), Convert.ToInt32(reader["ImageId"])));
                return ret;
            }
            catch
            {
                return new List<TblPatientImageRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblConfig

        #endregion

        #region TblSectionOperationRel

        public List<TblSectionOperationRel> SelectSectionOperationRel(int entry, SectionOperationRel entryType)
        {
            try
            {
                List<TblSectionOperationRel> ret = new List<TblSectionOperationRel>();
                if (entryType == SectionOperationRel.SectionId)
                    _command = new SqlCommand($"select* from TblSectionOperationRel where SectionId = N'{entry}'", _connection);
                else if (entryType == SectionOperationRel.OperationId)
                    _command = new SqlCommand($"select* from TblSectionOperationRel where OperationId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblSectionOperationRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["SectionId"]), Convert.ToInt32(reader["OperationId"])));
                return ret;
            }
            catch
            {
                return new List<TblSectionOperationRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblOperationImageRel

        public List<TblOperationImageRel> SelectOperationImageRel(int entry, OperationImageRel entryType)
        {
            try
            {
                List<TblOperationImageRel> ret = new List<TblOperationImageRel>();
                if (entryType == OperationImageRel.OperationId)
                    _command = new SqlCommand($"select* from TblOperationImageRel where OperationId = N'{entry}'", _connection);
                else if (entryType == OperationImageRel.ImageId)
                    _command = new SqlCommand($"select* from TblOperationImageRel where ImageId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblOperationImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["OperationId"]), Convert.ToInt32(reader["ImageId"])));
                return ret;
            }
            catch
            {
                return new List<TblOperationImageRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblHospitalImageRel

        public List<TblHospitalImageRel> SelectHospitalImageRel(int entry, HospitalImageRel entryType)
        {
            try
            {
                List<TblHospitalImageRel> ret = new List<TblHospitalImageRel>();
                if (entryType == HospitalImageRel.HospitalId)
                    _command = new SqlCommand($"select* from TblHospitalImageRel where HospitalId = N'{entry}'", _connection);
                else if (entryType == HospitalImageRel.ImageId)
                    _command = new SqlCommand($"select* from TblHospitalImageRel where ImageId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblHospitalImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["HospitalId"]), Convert.ToInt32(reader["ImageId"])));
                return ret;
            }
            catch
            {
                return new List<TblHospitalImageRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblHospitalSectionRel

        public List<TblHospitalSectionRel> SelectHospitalSectionRel(int entry, HospitalSectionRel entryType)
        {
            try
            {
                List<TblHospitalSectionRel> ret = new List<TblHospitalSectionRel>();
                if (entryType == HospitalSectionRel.HospitalId)
                    _command = new SqlCommand($"select* from TblHospitalSectionRel where HospitalId = N'{entry}'", _connection);
                else if (entryType == HospitalSectionRel.SectionId)
                    _command = new SqlCommand($"select* from TblHospitalSectionRel where SectionId = N'{entry}'", _connection);
                else if (entryType == HospitalSectionRel.DoctorId)
                    _command = new SqlCommand($"select* from TblHospitalSectionRel where DoctorId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblHospitalSectionRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["HospitalId"]), Convert.ToInt32(reader["SectionId"]), Convert.ToInt32(reader["DoctorId"])));
                return ret;
            }
            catch
            {
                return new List<TblHospitalSectionRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblNewsImageRel

        public List<TblNewsImageRel> SelectNewsImageRel(int entry, NewsImageRel entryType)
        {
            try
            {
                List<TblNewsImageRel> ret = new List<TblNewsImageRel>();
                if (entryType == NewsImageRel.NewsId)
                    _command = new SqlCommand($"select* from TblNewsImageRel where NewsId = N'{entry}'", _connection);
                else if (entryType == NewsImageRel.ImageId)
                    _command = new SqlCommand($"select* from TblNewsImageRel where ImageId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblNewsImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["NewsId"]), Convert.ToInt32(reader["ImageId"])));
                return ret;
            }
            catch
            {
                return new List<TblNewsImageRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblTicket

        public List<TblTicket> SelectTicketByIsRegistered(bool isRegistered)
        {
            try
            {
                List<TblTicket> ret = new List<TblTicket>();
                _command = new SqlCommand($"select* from TblTicket where IsRegistered = N'{isRegistered}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblTicket(Convert.ToInt32(reader["id"]), Convert.ToBoolean(reader["IsRegistered"]), Convert.ToInt32(reader["UserPassId"]), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Data"].ToString()));
                }
                return ret;
            }
            catch
            {
                return new List<TblTicket>();
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblTicket> SelectTicketByUserPassId(int userPassId)
        {
            try
            {
                List<TblTicket> ret = new List<TblTicket>();
                _command = new SqlCommand($"select* from TblTicket where UserPassId = N'{userPassId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new TblTicket(Convert.ToInt32(reader["id"]), Convert.ToBoolean(reader["IsRegistered"]), Convert.ToInt32(reader["UserPassId"]), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Data"].ToString()));
                }
                return ret;
            }
            catch
            {
                return new List<TblTicket>();
            }
            finally
            {
                _disconnect();
            }
        }

        public TblTicket SelectTicketByEmail(string email)
        {
            try
            {
                _command = new SqlCommand($"select* from TblTicket where Email = N'{email}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblTicket(Convert.ToInt32(reader["id"]), Convert.ToBoolean(reader["IsRegistered"]), Convert.ToInt32(reader["UserPassId"]), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Data"].ToString());
            }
            catch
            {
                return new TblTicket(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        public TblTicket SelectTicketByTellNo(string tellNo)
        {
            try
            {
                _command = new SqlCommand($"select* from TblTicket where TellNo = N'{tellNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblTicket(Convert.ToInt32(reader["id"]), Convert.ToBoolean(reader["IsRegistered"]), Convert.ToInt32(reader["UserPassId"]), reader["Email"].ToString(), reader["TellNo"].ToString(), reader["Data"].ToString());
            }
            catch
            {
                return new TblTicket(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblTicketImageRel

        public List<TblTicketImageRel> SelectTicketImageRel(int entry, TicketImageRel entryType)
        {
            try
            {
                List<TblTicketImageRel> ret = new List<TblTicketImageRel>();
                if (entryType == TicketImageRel.TicketId)
                    _command = new SqlCommand($"select* from TblTicketImageRel where TicketId = N'{entry}'", _connection);
                else if (entryType == TicketImageRel.ImageId)
                    _command = new SqlCommand($"select* from TblTicketImageRel where ImageId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblTicketImageRel(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["TicketId"]), Convert.ToInt32(reader["ImageId"])));
                return ret;
            }
            catch
            {
                return new List<TblTicketImageRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

    }
}
