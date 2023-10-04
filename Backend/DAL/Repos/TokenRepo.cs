using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Insert(Token token)
        {
            db.Tokens.Add(token);
            if (db.SaveChanges() > 0)
            {
                return token;
            }
            return null;
        }


        //public List<Token> GetAll()
        //{
        //    throw new NotImplementedException();
        //}
        //public Token Get(int tkey)
        //{
        //    var data =db.Tokens.FirstOrDefault(t => t.Tkey.Equals(tkey));
        //    if(data != null) { return data; }
        //    return null;
        //}
        //public Token Update(Token obj)
        //{
        //    var exst = db.Tokens.FirstOrDefault(t=> t.Tkey.Equals(obj.Tkey));
        //    if (exst != null)
        //    {
        //        db.Entry(exst).CurrentValues.SetValues(obj);

        //        if (db.SaveChanges() > 0) { return exst; }
        //    }
        //    return null;
        //}
        //public Token Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetData(string tkey)
        //{
        //    var data = db.Tokens.FirstOrDefault(t => t.Tkey.Equals(tkey));
        //    return data?.Tkey;
        //}


        public Token Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> GetAll()
        {
            throw new NotImplementedException();
        }

        public Token Get(string tkey)
        {
            return db.Tokens.FirstOrDefault(t => t.Tkey.Equals(tkey));
        }

        public Token Update(Token obj)
        {
            var token = Get(obj.Tkey);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return token;
            return null;
        }

        public List<Token> GetByCategorys(string id)
        {
            throw new NotImplementedException();
        }
    }
}
