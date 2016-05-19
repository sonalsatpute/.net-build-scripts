using Machine.Specifications;

namespace Store.Service.Specs
{
  [Subject("newproject")]
  public class When_I_set_the_development_enviroment
  {
    private It should_work = () => "sonal".ShouldEqual("sonal");
  }
}
