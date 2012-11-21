using System;
using System.Data;
using System.Security;
using System.Threading;

namespace app
{
  public class Calculator
  {
    IDbConnection connection;
    IDbCommand command;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
      command = this.connection.CreateCommand();
    }

    public int add(int i, int i1)
    {
      if (i < 0 || i1 < 0)
        throw new ArgumentException("Dumb calculator cannot add negative numbers. Maybe try the smart calculator?");

      connection.Open();
      command.ExecuteNonQuery();

      return i + i1;
    }

    public int subtract(int i, int i1)
    {
        return i - i1;
    }
    public void shut_down()
    {
      if (Thread.CurrentPrincipal.IsInRole("admin")) return;

      throw new SecurityException();
    }
  }
}