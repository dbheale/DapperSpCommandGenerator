/*
 *         _   _   _ _____ ___     ____ _____ _   _ _____ ____    _  _____ _____ ____  
 *        / \ | | | |_   _/ _ \   / ___| ____| \ | | ____|  _ \  / \|_   _| ____|  _ \ 
 *       / _ \| | | | | || | | | | |  _|  _| |  \| |  _| | |_) |/ _ \ | | |  _| | | | |
 *      / ___ \ |_| | | || |_| | | |_| | |___| |\  | |___|  _ </ ___ \| | | |___| |_| |
 *     /_/   \_\___/  |_| \___/   \____|_____|_| \_|_____|_| \_\/   \_\_| |_____|____/ 
 *    This file has been automatically generated. Any modification will get overwritten.
 *       If you want to create custom commands, they must be in a different folder.
 */
using Dapper;
using System.Data;

namespace SampleOutput.Commands.StoredProcedures.Dbo
{

    public record struct Update_Contacts_Command(int Id, string? Title, string? FirstName, string? MiddleName, string? LastName, string? Suffix, string? Company, string? Department, string? JobTitle, string? BusinessStreet, string? BusinessStreet2, string? BusinessStreet3, string? BusinessCity, string? BusinessState, string? BusinessPostalCode, string? BusinessCountryRegion, string? HomeStreet, string? HomeStreet2, string? HomeStreet3, string? HomeCity, string? HomeState, string? HomePostalCode, string? HomeCountryRegion, string? OtherStreet, string? OtherStreet2, string? OtherStreet3, string? OtherCity, string? OtherState, string? OtherPostalCode, string? OtherCountryRegion, string? AssistantsPhone, string? BusinessFax, string? BusinessPhone, string? BusinessPhone2, string? Callback, string? CarPhone, string? CompanyMainPhone, string? HomeFax, string? HomePhone, string? HomePhone2, string? ISDN, string? MobilePhone, string? OtherFax, string? OtherPhone, string? Pager, string? PrimaryPhone, string? RadioPhone, string? TTY_TDDPhone, string? Telex, string? Account, string? Anniversary, string? AssistantsName, string? BillingInformation, string? Birthday, string? BusinessAddressPOBox, string? Categories, string? Children, string? DirectoryServer, string? E_mailAddress, string? E_mailType, string? E_mailDisplayName, string? E_mail2Address, string? E_mail2Type, string? E_mail2DisplayName, string? E_mail3Address, string? E_mail3Type, string? E_mail3DisplayName, string? Gender, string? GovernmentIDNumber, string? Hobby, string? HomeAddressPOBox, string? Initials, string? InternetFreeBusy, string? Keywords, string? Language, string? Location, string? ManagersName, string? Mileage, string? Notes, string? OfficeLocation, string? OrganizationalIDNumber, string? OtherAddressPOBox, string? Priority, string? Private, string? Profession, string? ReferredBy, string? Sensitivity, string? Spouse, string? User1, string? User2, string? User3, string? User4, string? WebPage) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Id", Id);
			p.Add("Title", Title);
			p.Add("FirstName", FirstName);
			p.Add("MiddleName", MiddleName);
			p.Add("LastName", LastName);
			p.Add("Suffix", Suffix);
			p.Add("Company", Company);
			p.Add("Department", Department);
			p.Add("JobTitle", JobTitle);
			p.Add("BusinessStreet", BusinessStreet);
			p.Add("BusinessStreet2", BusinessStreet2);
			p.Add("BusinessStreet3", BusinessStreet3);
			p.Add("BusinessCity", BusinessCity);
			p.Add("BusinessState", BusinessState);
			p.Add("BusinessPostalCode", BusinessPostalCode);
			p.Add("BusinessCountryRegion", BusinessCountryRegion);
			p.Add("HomeStreet", HomeStreet);
			p.Add("HomeStreet2", HomeStreet2);
			p.Add("HomeStreet3", HomeStreet3);
			p.Add("HomeCity", HomeCity);
			p.Add("HomeState", HomeState);
			p.Add("HomePostalCode", HomePostalCode);
			p.Add("HomeCountryRegion", HomeCountryRegion);
			p.Add("OtherStreet", OtherStreet);
			p.Add("OtherStreet2", OtherStreet2);
			p.Add("OtherStreet3", OtherStreet3);
			p.Add("OtherCity", OtherCity);
			p.Add("OtherState", OtherState);
			p.Add("OtherPostalCode", OtherPostalCode);
			p.Add("OtherCountryRegion", OtherCountryRegion);
			p.Add("AssistantsPhone", AssistantsPhone);
			p.Add("BusinessFax", BusinessFax);
			p.Add("BusinessPhone", BusinessPhone);
			p.Add("BusinessPhone2", BusinessPhone2);
			p.Add("Callback", Callback);
			p.Add("CarPhone", CarPhone);
			p.Add("CompanyMainPhone", CompanyMainPhone);
			p.Add("HomeFax", HomeFax);
			p.Add("HomePhone", HomePhone);
			p.Add("HomePhone2", HomePhone2);
			p.Add("ISDN", ISDN);
			p.Add("MobilePhone", MobilePhone);
			p.Add("OtherFax", OtherFax);
			p.Add("OtherPhone", OtherPhone);
			p.Add("Pager", Pager);
			p.Add("PrimaryPhone", PrimaryPhone);
			p.Add("RadioPhone", RadioPhone);
			p.Add("TTY_TDDPhone", TTY_TDDPhone);
			p.Add("Telex", Telex);
			p.Add("Account", Account);
			p.Add("Anniversary", Anniversary);
			p.Add("AssistantsName", AssistantsName);
			p.Add("BillingInformation", BillingInformation);
			p.Add("Birthday", Birthday);
			p.Add("BusinessAddressPOBox", BusinessAddressPOBox);
			p.Add("Categories", Categories);
			p.Add("Children", Children);
			p.Add("DirectoryServer", DirectoryServer);
			p.Add("E_mailAddress", E_mailAddress);
			p.Add("E_mailType", E_mailType);
			p.Add("E_mailDisplayName", E_mailDisplayName);
			p.Add("E_mail2Address", E_mail2Address);
			p.Add("E_mail2Type", E_mail2Type);
			p.Add("E_mail2DisplayName", E_mail2DisplayName);
			p.Add("E_mail3Address", E_mail3Address);
			p.Add("E_mail3Type", E_mail3Type);
			p.Add("E_mail3DisplayName", E_mail3DisplayName);
			p.Add("Gender", Gender);
			p.Add("GovernmentIDNumber", GovernmentIDNumber);
			p.Add("Hobby", Hobby);
			p.Add("HomeAddressPOBox", HomeAddressPOBox);
			p.Add("Initials", Initials);
			p.Add("InternetFreeBusy", InternetFreeBusy);
			p.Add("Keywords", Keywords);
			p.Add("Language", Language);
			p.Add("Location", Location);
			p.Add("ManagersName", ManagersName);
			p.Add("Mileage", Mileage);
			p.Add("Notes", Notes);
			p.Add("OfficeLocation", OfficeLocation);
			p.Add("OrganizationalIDNumber", OrganizationalIDNumber);
			p.Add("OtherAddressPOBox", OtherAddressPOBox);
			p.Add("Priority", Priority);
			p.Add("Private", Private);
			p.Add("Profession", Profession);
			p.Add("ReferredBy", ReferredBy);
			p.Add("Sensitivity", Sensitivity);
			p.Add("Spouse", Spouse);
			p.Add("User1", User1);
			p.Add("User2", User2);
			p.Add("User3", User3);
			p.Add("User4", User4);
			p.Add("WebPage", WebPage);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Update_Contacts]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"Id:{Id}, Title:{Title}, FirstName:{FirstName}, MiddleName:{MiddleName}, LastName:{LastName}, Suffix:{Suffix}, Company:{Company}, Department:{Department}, JobTitle:{JobTitle}, BusinessStreet:{BusinessStreet}, BusinessStreet2:{BusinessStreet2}, BusinessStreet3:{BusinessStreet3}, BusinessCity:{BusinessCity}, BusinessState:{BusinessState}, BusinessPostalCode:{BusinessPostalCode}, BusinessCountryRegion:{BusinessCountryRegion}, HomeStreet:{HomeStreet}, HomeStreet2:{HomeStreet2}, HomeStreet3:{HomeStreet3}, HomeCity:{HomeCity}, HomeState:{HomeState}, HomePostalCode:{HomePostalCode}, HomeCountryRegion:{HomeCountryRegion}, OtherStreet:{OtherStreet}, OtherStreet2:{OtherStreet2}, OtherStreet3:{OtherStreet3}, OtherCity:{OtherCity}, OtherState:{OtherState}, OtherPostalCode:{OtherPostalCode}, OtherCountryRegion:{OtherCountryRegion}, AssistantsPhone:{AssistantsPhone}, BusinessFax:{BusinessFax}, BusinessPhone:{BusinessPhone}, BusinessPhone2:{BusinessPhone2}, Callback:{Callback}, CarPhone:{CarPhone}, CompanyMainPhone:{CompanyMainPhone}, HomeFax:{HomeFax}, HomePhone:{HomePhone}, HomePhone2:{HomePhone2}, ISDN:{ISDN}, MobilePhone:{MobilePhone}, OtherFax:{OtherFax}, OtherPhone:{OtherPhone}, Pager:{Pager}, PrimaryPhone:{PrimaryPhone}, RadioPhone:{RadioPhone}, TTY_TDDPhone:{TTY_TDDPhone}, Telex:{Telex}, Account:{Account}, Anniversary:{Anniversary}, AssistantsName:{AssistantsName}, BillingInformation:{BillingInformation}, Birthday:{Birthday}, BusinessAddressPOBox:{BusinessAddressPOBox}, Categories:{Categories}, Children:{Children}, DirectoryServer:{DirectoryServer}, E_mailAddress:{E_mailAddress}, E_mailType:{E_mailType}, E_mailDisplayName:{E_mailDisplayName}, E_mail2Address:{E_mail2Address}, E_mail2Type:{E_mail2Type}, E_mail2DisplayName:{E_mail2DisplayName}, E_mail3Address:{E_mail3Address}, E_mail3Type:{E_mail3Type}, E_mail3DisplayName:{E_mail3DisplayName}, Gender:{Gender}, GovernmentIDNumber:{GovernmentIDNumber}, Hobby:{Hobby}, HomeAddressPOBox:{HomeAddressPOBox}, Initials:{Initials}, InternetFreeBusy:{InternetFreeBusy}, Keywords:{Keywords}, Language:{Language}, Location:{Location}, ManagersName:{ManagersName}, Mileage:{Mileage}, Notes:{Notes}, OfficeLocation:{OfficeLocation}, OrganizationalIDNumber:{OrganizationalIDNumber}, OtherAddressPOBox:{OtherAddressPOBox}, Priority:{Priority}, Private:{Private}, Profession:{Profession}, ReferredBy:{ReferredBy}, Sensitivity:{Sensitivity}, Spouse:{Spouse}, User1:{User1}, User2:{User2}, User3:{User3}, User4:{User4}, WebPage:{WebPage}";
        }
    }
}