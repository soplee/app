using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }

    public class when_attempting_to_shut_down_the_calculator : concern
    {
      Establish c = () =>
      {
        principal = fake.an<IPrincipal>();
        spec.change(() => Thread.CurrentPrincipal).to(principal);
      };

      public class and_they_are_not_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);
        };

        Because b = () =>
          spec.catch_exception(() => sut.shut_down());

        It should_throw_a_security_exception = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();
      }
      public class and_they_are_in_the_correct_security_group
      {
        Establish c = () =>
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

        Because b = () =>
          sut.shut_down();

        It should_not_fail = () =>
        {
        };

      }

      static IPrincipal principal;
    }

    public class when_adding_two_positive_numbers : concern
    {
      //arrange
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
        command = fake.an<IDbCommand>();

        connection.setup(x => x.CreateCommand()).Return(command);
      };

      //act
      Because b = () =>
        result = sut.add(2, 3);

      //assert
      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      It should_open_a_connection_to_the_database = () =>
        connection.received(x => x.Open());

      It should_run_a_query = () =>
        command.received(x => x.ExecuteNonQuery());
     
     
      static int result;
      static IDbConnection connection;
      static IDbCommand command;
    }

    public class when_attempting_to_add_a_negative_to_a_positive : concern
    {
      Because b = () =>
        spec.catch_exception(() => sut.add(2, -3));

      It should_throw_an_argument_exception = () =>
        spec.exception_thrown.ShouldBeAn<ArgumentException>();
    }

      
      public class when_subtracting_two_numbers : concern 
      {  
        //act
        Because b = () =>
        result = sut.subtract(3,2);

          private It should_be_equal_number = () =>
                                              result.ShouldEqual(1);


        static int result;
      }

  }
}