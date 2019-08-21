using System;
using System.Collections.Generic;
using System.Data;
using buergershack.Models;
using Dapper;

namespace buergershack.Data
{
  public class BurgersRepository
  {
    private readonly IDbConnection _db;

    public BurgersRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Burger> GetBurgers()
    {
      return _db.Query<Burger>("SELECT * FROM burger");
    }

    internal Burger CreateBurger(Burger burgerData)
    {
      try
      {
        //execute scalar let's you do multiple commands
        int id = _db.ExecuteScalar<int>(@"
          INSERT INTO burger (name, description)
          VALUES (@Name, @Description);
          SELECT LAST_INSERT_ID();
          ", burgerData);
        burgerData.Id = id;
        return burgerData;
      }
      catch (Exception e)
      {

        throw e;
      }
    }
  }
}