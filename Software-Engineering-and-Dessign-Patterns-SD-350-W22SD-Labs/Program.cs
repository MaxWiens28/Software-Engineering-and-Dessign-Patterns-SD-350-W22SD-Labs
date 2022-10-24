namespace ConsoleStack
{
    public abstract class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public bool accessDisabled { get; set; }
        public IAccessHandler AccessHandler { get; set; }
        public override virtual void PerformAccessHandler()
        {
            AccessHandler.getAccess();
        }

        public Client(string Name, string Email, int Age)
        {
            Name = Name;
            Email = Email;
            Age = Age;
            accessDisabled = false;
        }
    }

    public class User : Client
    {
        public int Reputation { get; set; }
        public User(string Name, string Email, int Age, int Reputation) : base(Name, Email, Age)
        {
            Reputation = Reputation;
            AccessHandler = new HasReputation(Reputation);
        }
    }
    public class Manager : Client
    {
        public Manager(string Name, string Email, int Age) : base(Name, Email, Age)
        {
            AccessHandler = new HasAccessAutomatic();
        }
    }
    public class Admin : Client
    {
        public Admin(string Name, string Email, int Age) : base(Name, Email, Age)
        {
            AccessHandler = new HasAccessAutomatic();
        }
    }

    public interface IAccessHandler
    {
        public bool getAccess(int? Reputation, bool accessDisabled);
    }

    public class HasReputation : IAccessHandler
    {
        public bool getAccess(int? Reputation, bool accessDisabled)
        {
            if (Reputation < 20)
            {
                return accessDisabled = true;
            }
            else
            {
                return accessDisabled = false;
            }
        }
    }

    public class HasAccessAutomatic : IAccessHandler
    {
        public bool getAccess(int? Reputation, bool accessDisabled)
        {
            if (accessDisabled = false)
            {
                return accessDisabled = true;
            }
            else
            {
                return accessDisabled = false;
            }
        }
    }

}