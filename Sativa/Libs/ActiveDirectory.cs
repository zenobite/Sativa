using System.DirectoryServices.AccountManagement;

namespace Sativa.Libs
{
    public class ActiveDirectory
    {
        public ActiveDirectory()
        {

        }

        public static bool DoesUserExist(string Username, string adDomainName, string adContainer = "", string adUsername = "", string adPassword = "")
        {
            bool Exist = false;
            PrincipalContext pc = null;

            if (adContainer == "")
            {
                if (adUsername == "" || adPassword == "")
                {
                    pc = new PrincipalContext(ContextType.Domain, adDomainName);
                }
                else
                {
                    pc = new PrincipalContext(ContextType.Domain, adDomainName, adUsername, adPassword);
                }
            }
            else
            {
                if (adUsername == "" || adPassword == "")
                {
                    pc = new PrincipalContext(ContextType.Domain, adDomainName, adContainer);
                }
                else
                {
                    pc = new PrincipalContext(ContextType.Domain, adDomainName, adContainer, adUsername, adPassword);
                }
            }

            using (UserPrincipal foundUser = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, Username))
            {
                Exist = (foundUser != null);
            }

            pc.Dispose();
            pc = null;
            return Exist;
        }

        public static bool ValidateCredentials(string Username, string Password, string adDomainName. string adContainer = "", string adUsername = "", string adUsername = "", string adPassword = "")
        {
            bool isValid = false;

            try
            {
                PrincipalContext pc = null;
                if (adContainer == "")
                {
                    if (adUsername == "" || adPassword == "")
                    {
                        pc = new PrincipalContext(ContextType.Domain, adDomainName);
                    }
                    else
                    {
                        pc = new PrincipalContext(ContextType.Domain, adDomainName, adUsername, adPassword);
                    }
                }
                else
                {
                    if (adUsername == "" || adPassword == "")
                    {
                        pc = new PrincipalContext(ContextType.Domain, adDomainName, adContainer);
                    }
                    else
                    {
                        pc = new PrincipalContext(ContextType.Domain, adDomainName, adContainer, adUsername, adPassword);
                    }
                }

                isValid = pc.ValidateCredentials(Username, Password);
                pc.Dispose();
                pc = null;
            }
            catch (System.DirectoryServicesCOMException ex)
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool AddUserToGroup(string Username, string GroupName, string adDomainName, string adContainer = "", string adUsername = "", string adPassword = "")
        {
            bool success = false;
            
            try
            {
                PrincipalContext pc = null;
                if (adContainer == "")
                {
                    if (adUsername == "" || adPassword == "")
                    {
                        pc = new PrincipalContext(ContextType.Domain, adDomainName);
                    }
                    else
                    {
                        pc = new PrincipalContext(ContextType.Domain, adDomainName, adUsername, adPassword);
                    }
                }
                else
                {
                    if (adUsername == "" || adPassword == "")
                    {
                        pc = new PrincipalContext(ContextType.Domain, adDomainName, adContainer);
                    }
                    else
                    {
                        pc = new PrincipalContext(ContextType.Domain, adDomainName, adContainer, adUsername, adPassword);
                    }

                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, GroupName);
                    group.Members.Add(pc, IdentityType.UserPrincipalName, Username);
                    group.Save();
                    pc.Dispose();
                    pc = null;
                    success = true;
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException ex)
            {
                success = false;
            }

            return success;
        }

        public static bool RemoveUserFromGroup(string Username, string GroupName, string adDomainName, string adContainer = "", string adUsername = "", string adPassword = "") 
		{   
			bool success = false;
			try 
			{
                PrincipalContext pc = null;
                if (adContainer == "")
                {
                    if (adUsername == "" || adPassword == "")
                        pc = new PrincipalContext(ContextType.Domain, adDomainName);
                    else
                        pc = new PrincipalContext(ContextType.Domain, adDomainName, adUsername, adPassword);
                }
                else
                {
                    if (adUsername == "" || adPassword == "")
                        pc = new PrincipalContext(ContextType.Domain, adDomainName, adContainer);
                    else
                        pc = new PrincipalContext(ContextType.Domain, adDomainName, adContainer, adUsername, adPassword);
                }
                GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, GroupName);
				group.Members.Remove(pc, IdentityType.UserPrincipalName, Username);
				group.Save();

                pc.Dispose();
                pc = null;
                success = true;				
			} 
			catch (System.DirectoryServices.DirectoryServicesCOMException ex) 
			{ 
				success = false;
			}
			
			return success;
		}
    }
}