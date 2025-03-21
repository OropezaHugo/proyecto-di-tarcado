namespace Api.idHelper;

public interface IIdHelper<T>
{
  int ObtenerUltimoId(IEnumerable<T> entities);   
}