namespace Server.Core;

public interface ISender
{
    public void Send<T>(T entity);
}