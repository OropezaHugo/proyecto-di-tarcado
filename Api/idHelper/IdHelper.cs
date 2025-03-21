namespace Api.idHelper;

public class IdHelper<T> : IIdHelper<T>
{
  public int ObtenerUltimoId(IEnumerable<T> entities)
  {
    var propertyInfo = typeof(T).GetProperty("Id");
    if (propertyInfo == null)
      throw new InvalidOperationException("La entidad no tiene una propiedad 'Id'.");

    return entities.Any() ? entities.Max(e => (int)propertyInfo.GetValue(e)!) : 0;
  }
}