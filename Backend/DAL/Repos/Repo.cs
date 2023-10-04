namespace DAL.Repos
{
    internal class Repo
    {
        protected MFCContext db;
        internal Repo() { 
            db = new MFCContext();
        }
    }
}