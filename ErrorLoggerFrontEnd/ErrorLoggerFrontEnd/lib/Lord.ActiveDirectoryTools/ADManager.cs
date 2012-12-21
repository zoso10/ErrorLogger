using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Collections;
using System.Reflection;
using System.Security.Cryptography;

namespace Lord.ActiveDirectoryTools
{
    public class ADManager
    {
        #region "Variables and Properties"

        /// <summary>
        /// The node in the Active Directory heirarchy where the search will start.
        /// </summary>
        private DirectoryEntry searchRoot;

        /// <summary>
        /// Uses the search root to perform queries against Active Directory.
        /// </summary>
        private DirectorySearcher ldapSearch;

        /// <summary>
        /// The cache that will store ADUsers.
        /// </summary>
        public ADCache Cache { get; private set; }

        private LordDomains _Domain;

        private static byte[] key = { };
        private static byte[] IV = { 12, 115, 20, 97, 56, 117, 100, 13  };
        private static string stringKey = "#nl(@)r^";


        /// <summary>
        /// The domain to query against.
        /// </summary>
        public LordDomains Domain
        {
            get{ return _Domain; }
            set
            {
                _Domain = value;
                string ldapPath = "";
                string userName = "";
                string pw = "";
                switch (value)
                {
                    case LordDomains.LORD:
                        ldapPath = "LDAP://DC=LORD,DC=LOCAL";
                        userName = @"LORD\AuthService";
                        pw = Decrypt(ActiveDirectoryTools.Properties.Settings.Default.AuthService);
                        searchRoot = new DirectoryEntry(ldapPath, userName, pw);
                        break;
                    case LordDomains.MAIN:
                        ldapPath = "LDAP://DC=MAIN,DC=LORD,DC=COM";
                        userName = @"MAIN\srvpdmadmin";
                        pw = Decrypt(ActiveDirectoryTools.Properties.Settings.Default.srvPDMAdmin);
                        searchRoot = new DirectoryEntry(ldapPath, userName, pw);
                        break;                   
                    case LordDomains.FRITTSHANNA:
                        ldapPath = "LDAP://DC=local,DC=frittshanna,DC=com";
                        userName = @"local.frittshanna.com\lordadmin";
                        pw = Decrypt(ActiveDirectoryTools.Properties.Settings.Default.lordAdmin);
                        searchRoot = new DirectoryEntry(ldapPath, userName, pw);
                        break;
                    case LordDomains.DMZ:
                        ldapPath = "LDAP://DC=LORD,DC=DMZ";
                        userName = @"LORDDMZ\srvldap";
                        pw = Decrypt(ActiveDirectoryTools.Properties.Settings.Default.srvldap);
                        searchRoot = new DirectoryEntry(ldapPath, userName, pw);
                        break;
                }

                ldapSearch = new DirectorySearcher(searchRoot);
            }
        }

        #endregion

        #region "Constructors"

        /// <summary>
        /// Initializes an object that can be used to perform lookups on user information.
        /// </summary>
        /// <param name="cache">ADCacheContainer is an abstract class, so you will need to use an implementation of it.</param>
        /// <param name="domain">The domain that you want to perform the query against.</param>
        public ADManager(ADCache cache, LordDomains domain)
        {
            Cache = cache;
            Domain = domain;
            ldapSearch.PageSize = int.MaxValue / 2;
        }
        /// <summary></summary>
        public ADManager(LordDomains domain)
        {
            Cache = new ADCache();
            Cache.ADUserExpiration = TimeSpan.MinValue;
            Domain = domain;
            ldapSearch.PageSize = int.MaxValue / 2;
        }

        #endregion

        #region "Functions"

        #region "Create"

        /// <summary>
        /// Creates a new user in Active Directory.
        /// </summary>
        /// <param name="distinguishedName">Determines how the user will appear in Active Directory.
        /// Do not specify domain-related information. Remember to give the user an account name, email, etc.
        /// using the EditProperty function.
        /// e.g. "CN=Jones\, James,OU=Users,OU=Grandview,OU=Domestic"</param>
        /// <returns></returns>
        public ADUser CreateUser(string distinguishedName)
        {
            var users = searchRoot.Children;
            var newUser = users.Add(distinguishedName, "user");
            newUser.CommitChanges();
            var returnVar = new ADUser(newUser);

            Cache.AddToCache(returnVar);

            return returnVar;
        }

        /// <summary>
        /// Tries to create an AD user and if it already exists then it appends an integer to the last name
        /// </summary>
        /// <param name="distinguishedName">Determines how the user will appear in Active Directory.
        /// Do not specify domain-related information. Remember to give the user an account name, email, etc.
        /// using the EditProperty function.
        /// e.g. "CN=Jones\, James,OU=Users,OU=Grandview,OU=Domestic"</param>
        /// <returns>The created user</returns>
        public ADUser CreateDMZUser(string distinguishedName)
        {
            //"CN=Hitchcock\\, Alfred,OU=Users,OU=Grandview,OU=North_America"

            if (Domain == LordDomains.DMZ)
            {
                int count = 0;
                bool created = false;
                string currentName = distinguishedName;
                ADUser returnUser = null;

                while (!created)
                {
                    var users = searchRoot.Children;
                    var newUser = users.Add(currentName, "user");

                    try
                    {
                        newUser.CommitChanges();

                        created = true;

                        returnUser = new ADUser(newUser);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("The object already exists."))
                        {
                            count++;

                            if(distinguishedName.Split(',')[0].Contains('\\'))
                            {
                                string namePart1 = string.Format("{0}{1}", distinguishedName.Split("\\".ToCharArray(), 2)[0], count.ToString());
                                string namePart2 = distinguishedName.Split("\\".ToCharArray(), 2)[1];

                                currentName = string.Format("{0}\\{1}", namePart1, namePart2);
                            }
                            else
                            {
                                string namePart1 = string.Format("{0}{1}", distinguishedName.Split(",".ToCharArray(), 2)[0], count.ToString());
                                string namePart2 = distinguishedName.Split("\\".ToCharArray(), 2)[1];

                                currentName = string.Format("{0}\\{1}", namePart1, namePart2);
                            }                            
                        }
                    }

                }

                if (returnUser != null)
                {
                    Cache.AddToCache(returnUser);
                }

                return returnUser;
            }
            else
            {
                throw new Exception("ERROR: You are not connected to the DMZ domain!");
            }
        }

        public ADGroup CreateGroup(string distinguishedName)
        {
            var users = searchRoot.Children;
            var newUser = users.Add(distinguishedName, "group");
            
            newUser.CommitChanges();
            var returnVar = new ADGroup(newUser);

            Cache.AddToCache(returnVar);

            return returnVar;
        }

        #endregion

        #region "Read"

        /// <summary>
        /// Retrieves all users from Active Directory.
        /// </summary>
        /// <returns>An array of users.</returns>
        public ADUser[] GetAllUsers()
        {
            ldapSearch.Filter = "(objectCategory=person)";

            SearchResultCollection results = ldapSearch.FindAll();
            if (results == null) return null;

            IList<ADUser> userList = new List<ADUser>();
            foreach (SearchResult result in results)
            {
                ADUser user = new ADUser(result);
                userList.Add(user);
                Cache.AddToCache(user);
            }

            return userList.ToArray<ADUser>();
        }

        /// <summary>
        /// Retrives entity info based on guid. Tries fetching from cache first. Case-insensitive. Throws FormatException. Returns null if no results found. Caches result.
        /// </summary>
        /// <param name="objectGuid">e.g. "15152bfd-2efe-4e04-baaa-6b2a975f6695"</param>
        /// <returns></returns>
        protected T GetEntityByGuid<T>(string objectGuid) where T : ADEntity
        {
            T ade = (T)Cache.FetchByGuid(objectGuid);
            if (ade != null) return ade;

            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(objectGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) return null;

            ade = SharedMethods.New<T>(result);

            Cache.AddToCache(ade);

            return ade;
        }
        public ADUser GetUserByGuid(string objectGuid)
        {
            return GetEntityByGuid<ADUser>(objectGuid);
        }
        public ADUser GetUserByGuid(Guid objectGuid)
        {
            return GetEntityByGuid<ADUser>(objectGuid.ToString());
        }

        /// <summary>
        /// Retrieves entity info based on account name. Do not prefix with domain. Tries fetching from cache first. Case-insensitive. Returns null if no results found. Caches result.
        /// </summary>
        /// <param name="accountName">Account name, without domain. e.g. "james_jones"</param>
        /// <returns></returns>
        protected T GetEntityByAccountName<T>(string accountName) where T : ADEntity
        {
            if (accountName == null) return null;

            T ade = (T)Cache.FetchByNTName(accountName);
            if (ade != null) return ade;

            ldapSearch.Filter = String.Format("(sAMAccountName={0})", accountName);

            SearchResult result = ldapSearch.FindOne();
            if (result == null) return null;

            ade = SharedMethods.New<T>(result);

            Cache.AddToCache(ade);

            return ade;
        }
        public ADUser GetUserByAccountName(string accountName)
        {
            return GetEntityByAccountName<ADUser>(accountName);
        }
        public ADGroup GetGroupByAccountName(string accountName)
        {
            return GetEntityByAccountName<ADGroup>(accountName);
        }

        /// <summary>
        /// Retrieves entity info based on account name. Do not prefix with domain. Does NOT try fetching from cache first. Case-insensitive. Caches results.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        protected IList<T> GetEntitiesByEmail<T>(string email) where T : ADEntity
        {
            if (email == null) return null;

            IList<T> returnVar = new List<T>();

            ldapSearch.Filter = string.Format("(mail={0})", email);

            SearchResultCollection results = ldapSearch.FindAll();
            foreach (SearchResult result in results)
            {
                T entity = SharedMethods.New<T>(result);
                returnVar.Add(entity);
                Cache.AddToCache(entity);
            }

            return returnVar;
        }

        public IList<ADUser> GetUsersByEmail(string email)
        {
            return GetEntitiesByEmail<ADUser>(email);
        }
        public IList<ADGroup> GetGroupsByEmail(string email)
        {
            return GetEntitiesByEmail<ADGroup>(email);
        }
   

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Attribute"></param>
        /// <param name="SearchValue"></param>
        /// <returns></returns>
        protected IList<T> GetEntitiesByAttribute<T>(string Attribute, string SearchValue) where T : ADEntity
        {
            if (string.IsNullOrEmpty(Attribute) || string.IsNullOrEmpty(SearchValue))
            {
                return null;
            }

            IList<T> returnVar = new List<T>();

            ldapSearch.Filter = string.Format("({0}={1})", Attribute, SearchValue);
            
            SearchResultCollection results = ldapSearch.FindAll();
            foreach (SearchResult result in results)
            {
                T entity = SharedMethods.New<T>(result);
                returnVar.Add(entity);
                Cache.AddToCache(entity);
            }

            return returnVar;
        }

        /// <summary>
        /// Gathers a list of users that have an attribute set to the search value
        /// </summary>
        /// <param name="Attribute">Attribute to compare</param>
        /// <param name="SearchValue">Search criteria</param>
        /// <returns>List of ADUsers that have the attribute that contains the search value</returns>
        public IList<ADUser> GetUsersByAttribute(string Attribute, string SearchValue)
        {
            return GetEntitiesByAttribute<ADUser>(Attribute, SearchValue);
        }
        public IList<ADGroup> GetGroupsByAttribute(string Attribute, string SearchValue)
        {
            return GetEntitiesByAttribute<ADGroup>(Attribute, SearchValue);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="LDAPQuery"></param>
        /// <returns></returns>
        protected IList<T> GetEntitiesByQuery<T>(string LDAPQuery) where T : ADEntity
        {
            if (string.IsNullOrEmpty(LDAPQuery))
            {
                return null;
            }

            IList<T> returnVar = new List<T>();

            ldapSearch.Filter = LDAPQuery;

            SearchResultCollection results = ldapSearch.FindAll();
            foreach (SearchResult result in results)
            {
                T entity = SharedMethods.New<T>(result);
                returnVar.Add(entity);
                Cache.AddToCache(entity);
            }

            return returnVar;
        }

        /// <summary>
        /// Gathers a list of users that fall within the LDAP Query
        /// </summary>
        /// <param name="LDAPQuery">The query to filter by. e.g. "(&(givenname=James)(sn=Jones))"</param>
        /// <returns>List of ADUsers that have the attributes contained in the query</returns>
        public IList<ADUser> GetUsersByQuery(string LDAPQuery)
        {
            return GetEntitiesByQuery<ADUser>(LDAPQuery);
        }
        public IList<ADGroup> GetGroupsByQuery(string LDAPQuery)
        {
            return GetEntitiesByQuery<ADGroup>(LDAPQuery);
        }


        /// <summary>
        /// Authenticates a user. If authentication is successful, nothing will happen. If authentication fails, an exception will be thrown.
        /// </summary>
        /// <param name="userGuid">A user GUID</param>
        /// <param name="password">User's password</param>
        /// <returns>Error message if unable to authenticate otherwise an empty string</returns>
        public void AuthenticateUser(string userGuid, string password)
        {
            ADUser user = GetUserByGuid(userGuid);

            var de = new DirectoryEntry(searchRoot.Path, user.AccountName, password);
            object nativeObject = de.NativeObject;
        }
        public void AuthenticateUser(ADUser user, string password)
        {
            AuthenticateUser(user.ObjectGuid.ToString(), password);
        }

        /// <summary>
        /// Retrieves the list of entities that belong to a particular group. Result is not cached.
        /// </summary>
        /// <param name="groupName">The group in question.</param>
        /// <returns>A list of entities.</returns>
        protected T[] GetEntitiesInGroupByName<T>(string groupName) where T : ADEntity
        {
            //Get the group DirectoryEntry
            ldapSearch.Filter = String.Format("(&(name={0})(objectCategory=group))", groupName);

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Cannot find group.");

            DirectoryEntry DEGroup = result.GetDirectoryEntry();

            object members = DEGroup.Invoke("members", null);

            var userList = new ArrayList();
            foreach (object groupMember in (IEnumerable)members)
            {
                userList.Add(SharedMethods.New<T>(new DirectoryEntry(groupMember)));
            }

            return (T[])userList.ToArray(typeof(T));
        }
        public ADUser[] GetUsersInGroupByName(string groupName)
        {
            return GetEntitiesInGroupByName<ADUser>(groupName).Where<ADUser>(x => ((object[])x.Properties["objectclass"]).Contains("user")).ToArray<ADUser>();
        }
        public ADGroup[] GetGroupsInGroupByName(string groupName)
        {
            return GetEntitiesInGroupByName<ADGroup>(groupName).Where<ADGroup>(x => ((object[])x.Properties["objectclass"]).Contains("group")).ToArray<ADGroup>();
        }

        protected T[] GetEntitiesInGroup<T>(string groupGuid) where T : ADEntity
        {
            //Get the group DirectoryEntry
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(groupGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Cannot find group.");

            DirectoryEntry DEGroup = result.GetDirectoryEntry();

            object members = DEGroup.Invoke("members", null);

            var userList = new ArrayList();
            foreach (object groupMember in (IEnumerable)members)
            {
                userList.Add(SharedMethods.New<T>(new DirectoryEntry(groupMember)));
            }

            return (T[])userList.ToArray(typeof(T));
        }
        public ADUser[] GetUsersInGroup(string groupGuid)
        {
            return GetEntitiesInGroup<ADUser>(groupGuid).Where<ADUser>(x => ((object[])x.Properties["objectclass"]).Contains("user")).ToArray<ADUser>();
        }
        public ADUser[] GetUsersInGroup(ADGroup group)
        {
            return GetEntitiesInGroup<ADUser>(group.ObjectGuid.ToString()).Where<ADUser>(x => ((object[])x.Properties["objectclass"]).Contains("user")).ToArray<ADUser>();
        }
        public ADGroup[] GetGroupsInGroup(string groupGuid)
        {
            return GetEntitiesInGroup<ADGroup>(groupGuid).Where<ADGroup>(x => ((object[])x.Properties["objectclass"]).Contains("group")).ToArray<ADGroup>();
        }
        public ADGroup[] GetGroupsInGroup(ADGroup group)
        {
            return GetEntitiesInGroup<ADGroup>(group.ObjectGuid.ToString()).Where<ADGroup>(x => ((object[])x.Properties["objectclass"]).Contains("group")).ToArray<ADGroup>();
        }

        protected ADGroup[] GetGroupsEntityIsIn<T>(string objectGuid) where T : ADEntity
        {
            T ade = GetEntityByGuid<T>(objectGuid);

            var groupList = new ArrayList();
            foreach (object group in (object[])ade.Properties["memberof"])
            {
                string ldapStr = "LDAP://" + group.ToString();
                var de = new DirectoryEntry(ldapStr);
                groupList.Add(SharedMethods.New<ADGroup>(de));
            }

            return (ADGroup[])groupList.ToArray(typeof(ADGroup));
        }
        public ADGroup[] GetGroupsUserIsIn(string userGuid)
        {
            return GetGroupsEntityIsIn<ADUser>(userGuid);
        }
        public ADGroup[] GetGroupsUserIsIn(ADUser user)
        {
            return GetGroupsEntityIsIn<ADUser>(user.ObjectGuid.ToString());
        }
        public ADGroup[] GetGroupsGroupIsIn(string groupGuid)
        {
            return GetGroupsEntityIsIn<ADGroup>(groupGuid);
        }
        public ADGroup[] GetGroupsGroupIsIn(ADGroup group)
        {
            return GetGroupsEntityIsIn<ADGroup>(group.ObjectGuid.ToString());
        }

        public ADUser GetUserManager(string userGuid)
        {
            ADUser user = GetUserByGuid(userGuid);
            object userManagerAdObject = user.Properties["manager"];

            if (userManagerAdObject == null) return null;

            DirectoryEntry de = new DirectoryEntry("LDAP://" + userManagerAdObject.ToString());
            if (de == null) return null;

            ADUser userManager = new ADUser(de);
            Cache.AddToCache(userManager);

            return userManager;
        }
        public ADUser GetUserManager(ADUser user)
        {
            return GetUserManager(user.ObjectGuid.ToString());
        }

        public bool IsAccountLocked(string userGuid)
        {
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(userGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to unlock an account for a nonexistent user.");

            DirectoryEntry DEUser = result.GetDirectoryEntry();

            return Convert.ToBoolean(DEUser.InvokeGet("IsAccountLocked"));
        }
        public bool IsAccountLocked(ADUser user)
        {
            return IsAccountLocked(user.ObjectGuid.ToString());
        }

        #endregion

        #region "Update"

        /// <summary>
        /// Adds an entity to a group in Active Directory.
        /// </summary>
        /// <param name="entityGuid">The GUID of the entity in question.</param>
        /// <param name="groupGuid">The GUID of the group to assign the user to.</param>
        protected void AddEntityToGroup(string entityGuid, string groupGuid)
        {
            // TODO: Fix error when adding user to group they are already in.

            //Get the entity DirectoryEntry
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(entityGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to add a nonexistent entity to a group.");

            DirectoryEntry DEEntity = result.GetDirectoryEntry();

            //Get the group DirectoryEntry
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(groupGuid));

            result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to add an entity to a nonexistent group.");

            DirectoryEntry DEGroup = result.GetDirectoryEntry();

            //Add the entity to the group
            try
            {
                DEGroup.Properties["member"].Add(DEEntity.Path.Substring(7));
                DEGroup.CommitChanges();

                Cache.RemoveByGuid(entityGuid);
                Cache.RemoveByGuid(groupGuid);
            }
            catch (DirectoryServicesCOMException) { }

            DEGroup.Close();
            DEEntity.Close();
        }

        public void AddUserToGroup(string userGuid, string groupGuid)
        {
            AddEntityToGroup(userGuid, groupGuid);
        }
        public void AddUserToGroup(string userGuid, ADGroup group)
        {
            AddEntityToGroup(userGuid, group.ObjectGuid.ToString());
        }
        public void AddUserToGroup(ADUser user, string groupGuid)
        {
            AddEntityToGroup(user.ObjectGuid.ToString(), groupGuid);
        }
        public void AddUserToGroup(ADUser user, ADGroup group)
        {
            AddEntityToGroup(user.ObjectGuid.ToString(), group.ObjectGuid.ToString());
        }

        public void AddGroupToGroup(string groupGuidFrom, string groupGuidTo)
        {
            AddEntityToGroup(groupGuidFrom, groupGuidTo);
        }
        public void AddGroupToGroup(string groupGuidFrom, ADGroup groupTo)
        {
            AddEntityToGroup(groupGuidFrom, groupTo.ObjectGuid.ToString());
        }
        public void AddGroupToGroup(ADGroup groupFrom, string groupGuidTo)
        {
            AddEntityToGroup(groupFrom.ObjectGuid.ToString(), groupGuidTo);
        }
        public void AddGroupToGroup(ADGroup groupFrom, ADGroup groupTo)
        {
            AddEntityToGroup(groupFrom.ObjectGuid.ToString(), groupTo.ObjectGuid.ToString());
        }

        /// <summary>
        /// Removes an entity from a group in Active Directory.
        /// </summary>
        /// <param name="entityGuid">The GUID of the entity in question.</param>
        /// <param name="groupGuid">The GUID of the group that the entity is being removed from.</param>
        protected void RemoveEntityFromGroup(string entityGuid, string groupGuid)
        {
            //Get the entity DirectoryEntry
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(entityGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to remove a nonexistent entity from a group.");

            DirectoryEntry DEEntity = result.GetDirectoryEntry();

            //Get the group DirectoryEntry
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(groupGuid));

            result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to remove an entity from a nonexistent group.");

            DirectoryEntry DEGroup = result.GetDirectoryEntry();

            try
            {
                //Remove the user from the group.
                DEGroup.Properties["member"].Remove(DEEntity.Path.Substring(7));
                DEGroup.CommitChanges();

                Cache.RemoveByGuid(entityGuid);
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException) { }

            DEGroup.Close();
            DEEntity.Close();
        }
        
        public void RemoveUserFromGroup(string userGuid, string groupGuid)
        {
            RemoveEntityFromGroup(userGuid, groupGuid);
        }
        public void RemoveUserFromGroup(string userGuid, ADGroup group)
        {
            RemoveEntityFromGroup(userGuid, group.ObjectGuid.ToString());
        }
        public void RemoveUserFromGroup(ADUser user, string groupGuid)
        {
            RemoveEntityFromGroup(user.ObjectGuid.ToString(), groupGuid);
        }
        public void RemoveUserFromGroup(ADUser user, ADGroup group)
        {
            RemoveEntityFromGroup(user.ObjectGuid.ToString(), group.ObjectGuid.ToString());
        }

        public void RemoveGroupFromGroup(string groupGuidFrom, string groupGuidTo)
        {
            RemoveEntityFromGroup(groupGuidFrom, groupGuidTo);
        }
        public void RemoveGroupFromGroup(string groupGuidFrom, ADGroup groupTo)
        {
            RemoveEntityFromGroup(groupGuidFrom, groupTo.ObjectGuid.ToString());
        }
        public void RemoveGroupFromGroup(ADGroup groupFrom, string groupGuidTo)
        {
            RemoveEntityFromGroup(groupFrom.ObjectGuid.ToString(), groupGuidTo);
        }
        public void RemoveGroupFromGroup(ADGroup groupFrom, ADGroup groupTo)
        {
            RemoveEntityFromGroup(groupFrom.ObjectGuid.ToString(), groupTo.ObjectGuid.ToString());
        }

        /// <summary>
        /// Edits a user property.
        /// </summary>
        /// <param name="userGuid">The GUID of the user or group in question.</param>
        /// <param name="propertyName">The user property to change.</param>
        /// <param name="newValue">The new value to assign the property.</param>
        public void SetProperty(string guid, string propertyName, object newValue)
        {
            //Get the user DirectoryEntry
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(guid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to edit a property for a nonexistent user.");

            DirectoryEntry DEUser = result.GetDirectoryEntry();

            DEUser.Properties[propertyName].Value = newValue;

            DEUser.CommitChanges();

            Cache.RemoveByGuid(guid);

            DEUser.Close();
        }
        public void SetProperty(ADUser user, string propertyName, object newValue)
        {
            SetProperty(user.ObjectGuid.ToString(), propertyName, newValue);
        }
        public void SetProperty(ADGroup group, string propertyName, object newValue)
        {
            SetProperty(group.ObjectGuid.ToString(), propertyName, newValue);
        }

        /// <summary>
        /// Toggles a flag in the user account control property.
        /// </summary>
        /// <param name="userGuid">The GUID of the user in question.</param>
        /// <param name="uac">The user account control property to toggle.</param>
        public void ToggleUserAccountControl(string userGuid, UserAccountControl uac)
        {
            //Get the user DirectoryEntry
            ldapSearch.Filter = String.Format("(&(objectGUID={0})(objectCategory=person))", SharedMethods.Guid2OctetString(userGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to edit a property for a nonexistent user.");

            DirectoryEntry DEUser = result.GetDirectoryEntry();

            UserAccountControl curVal = (UserAccountControl)DEUser.Properties["userAccountControl"].Value;
            DEUser.Properties["userAccountControl"].Value = curVal ^ uac;

            DEUser.CommitChanges();

            Cache.RemoveByGuid(userGuid);

            DEUser.Close();
        }
        /// <summary></summary>
        public void ToggleUserAccountControl(ADUser user, UserAccountControl uac)
        {
            ToggleUserAccountControl(user.ObjectGuid.ToString(), uac);
        }

        /// <summary>
        /// Sets a flag in the user account control property.
        /// </summary>
        /// <param name="userGuid">The GUID of the user in question.</param>
        /// <param name="uac">The user account control property to toggle.</param>
        public void SetUserAccountControl(string userGuid, UserAccountControl uac)
        {
            //Get the user DirectoryEntry
            ldapSearch.Filter = String.Format("(&(objectGUID={0})(objectCategory=person))", SharedMethods.Guid2OctetString(userGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to edit a property for a nonexistent user.");

            DirectoryEntry DEUser = result.GetDirectoryEntry();

            UserAccountControl curVal = (UserAccountControl)DEUser.Properties["userAccountControl"].Value;
            DEUser.Properties["userAccountControl"].Value = curVal | uac;

            DEUser.CommitChanges();

            Cache.RemoveByGuid(userGuid);

            DEUser.Close();
        }
        /// <summary></summary>
        public void SetUserAccountControl(ADUser user, UserAccountControl uac)
        {
            SetUserAccountControl(user.ObjectGuid.ToString(), uac);
        }

        /// <summary>
        /// Clears a flag in the user account control property.
        /// </summary>
        /// <param name="userGuid">The GUID of the user in question.</param>
        /// <param name="uac">The user account control property to toggle.</param>
        public void ClearUserAccountControl(string userGuid, UserAccountControl uac)
        {
            //Get the user DirectoryEntry
            ldapSearch.Filter = String.Format("(&(objectGUID={0})(objectCategory=person))", SharedMethods.Guid2OctetString(userGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to edit a property for a nonexistent user.");

            DirectoryEntry DEUser = result.GetDirectoryEntry();

            UserAccountControl curVal = (UserAccountControl)DEUser.Properties["userAccountControl"].Value;
            DEUser.Properties["userAccountControl"].Value = (int)curVal & ((int)uac ^ int.MaxValue);

            DEUser.CommitChanges();

            Cache.RemoveByGuid(userGuid);

            DEUser.Close();
        }
        /// <summary></summary>
        public void ClearUserAccountControl(ADUser user, UserAccountControl uac)
        {
            ClearUserAccountControl(user.ObjectGuid.ToString(), uac);
        }

        /// <summary></summary>
        public void SetPassword(string userGuid, string password)
        {
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(userGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to set a password for a nonexistent user.");

            DirectoryEntry DEUser = result.GetDirectoryEntry();
            
            DEUser.Invoke("SetPassword", new object[] { password });

            DEUser.CommitChanges();

            Cache.RemoveByGuid(userGuid);

            DEUser.Close();
        }
        /// <summary></summary>
        public void SetPassword(ADUser user, string password)
        {
            SetPassword(user.ObjectGuid.ToString(), password);
        }

        public void UnlockAccount(string userGuid)
        {
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(userGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) throw new NullReferenceException("Attempted to unlock an account for a nonexistent user.");

            DirectoryEntry DEUser = result.GetDirectoryEntry();

            DEUser.Properties["LockOutTime"].Value = 0;
            DEUser.CommitChanges();
        }
        public void UnlockAccount(ADUser user)
        {
            UnlockAccount(user.ObjectGuid.ToString());
        }

        #endregion

        #region "Delete"

        /// <summary>
        /// Deletes an entity permanently from Active Directory.
        /// </summary>
        /// <param name="userGuid"></param>
        protected void DeleteEntity(string userGuid)
        {
            if (userGuid == null) return;
            ldapSearch.Filter = String.Format("(objectGUID={0})", SharedMethods.Guid2OctetString(userGuid));

            SearchResult result = ldapSearch.FindOne();
            if (result == null) return; //User doesn't exist.

            DirectoryEntry DEUser = result.GetDirectoryEntry();

            DEUser.DeleteTree();

            DEUser.CommitChanges();
        }
        public void DeleteUser(string userGuid)
        {
            if (userGuid == null) return;
            DeleteEntity(userGuid);
        }
        public void DeleteUser(ADUser user)
        {
            if (user == null) return;
            DeleteEntity(user.ObjectGuid.ToString());
        }
        public void DeleteGroup(string groupGuid)
        {
            if (groupGuid == null) return;
            DeleteEntity(groupGuid);
        }
        public void DeleteGroup(ADGroup group)
        {
            if (group == null) return;
            DeleteEntity(group.ObjectGuid.ToString());
        }

        #endregion

        #region "EncryptDecrypt"

        private static string Encrypt(string text)
        {
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(text);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }

            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private static string Decrypt(string text)
        {
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] byteArray = Convert.FromBase64String(text);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();
                return System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        #endregion

        #endregion


    }
}
