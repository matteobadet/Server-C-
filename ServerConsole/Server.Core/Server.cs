using System.Net;
using System.Net.Sockets;

namespace Server.Core;

public class Server
{
    private ServerStateEnum _state;
    
    private int _port;
    private IPAddress _ipAdress;
    private IPEndPoint _ipEndPoint;

    private ISender _sender;
    private IReciever _reciever;

    private Socket _listener;

    public Server(ISender sender, IReciever reciever, string ipAdress = "0.0.0.0", int port = 25250)
    {
        _state = ServerStateEnum.Created;
        
        _sender = sender;
        _reciever = reciever;
        _port = port;
        _ipAdress = IPAddress.Parse(ipAdress);
        _ipEndPoint = new IPEndPoint(_ipAdress, _port);
    }

    public void Test<T>(T entity)
    {
        _sender.Send<T>(entity);
    }
    
    public void Start()
    {
        if (CheckIfServerCanBeStarted())
        {
            _listener = new Socket(_ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(_ipEndPoint);
            _listener.Listen(_port);
            
            _state = ServerStateEnum.Open;
        }
    }

    public void Stop()
    {
        if (CheckIfServerCanBeStopped())
        {
            _listener.Close();
            _state = ServerStateEnum.Close;
        }
    }

    private bool CheckIfServerCanBeStarted()
    {
        return _state == ServerStateEnum.Created || _state == ServerStateEnum.Close || _state == ServerStateEnum.Error;
    }

    private bool CheckIfServerCanBeStopped()
    {
        return _state == ServerStateEnum.Open;
    }

    private void ProcessMessages()
    {
        var handler = _listener.AcceptAsync();
        while (true)
        {
            var buffer = new byte[1_024];
            
        }
    }
}