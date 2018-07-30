# simple-lightweight-framework
A simple lightweight framework on asp net core, which uses dapper as ORM to execute store procedure on SQL server and simple injector for DI, ... . focused on performance!

This framework works based on executing store procedures but it's changable to do anything else on services. The reason for this approche
is reach best performance in a requset. So how does it work? each store procedure on SQL server may has some input and output arguments
that make store procedure structure. On this framework for the first step we must simulate the SP's arguments on Domain.Model.Schemas as
you see below :

public interface IBaseSchema {}

public class PagingSchema : IBaseSchema {
  [InputParameter]
  public string @OrderBy { get; set; }
  [InputParameter]
  public string @Order { get; set; }
  [InputParameter]
  public int? @Skip { get; set; }
  [InputParameter]
  public int? @Take { get; set; }
  [HelperParameter]
  public int RowsCount { get; set; }
}

[Schema("[dbo].[API_Event_GetPaging]")]
public class EventGetPagingSchema : PagingSchema
{
  [InputParameter]
  public string @Token { get; set; }
  [InputParameter]
  public string @DeviceId { get; set; }
  [InputParameter]
  public string @Title { get; set; }
  [InputParameter]
  public DateTime? @FromDate { get; set; }
  [InputParameter]
  public DateTime? @ToDate { get; set; }
  [OutputParameter]
  public short @StatusCode { get; set; }
}

  This type of properties declaration made project to had ability for generating SP's parameters automaticaly, So we don't need to
  declare parameters manualy on the code. We just call the SPs ...
