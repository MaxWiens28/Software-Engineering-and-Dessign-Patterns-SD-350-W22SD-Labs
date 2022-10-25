namespace BadgeEarner
{
    public abstract class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public int badges { get; set; }
        public override string Description { get; set; }
        public virtual string GetDescription()
        {
            return Description;
        }
        public virtual int GetBadges()
        {
            return badges;
        }
        public Client(string Name, string Email, int Age)
        {
            Name = Name;
            Email = Email;
            Age = Age;
            badges = 0;
            Description = "";
        }
    }

    public class baseUser : Client
    {
        public baseUser(string Name, string Email, int Age): base(Name, Email, Age)
        {
            string Description = "Base-level User.";
        }
    }

    public class BadgeDecorator: Client
    {
        public int GetBadges(Client client)
        {
            client.badges++;
            return badges;
        }
    }
}