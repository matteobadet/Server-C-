// See https://aka.ms/new-console-template for more information

using System.Runtime.Loader;
using Server.Core;
using Server.Core.Test;

Console.WriteLine("Hello, World!");

var pers = new Personne
{
    FirstName = "Mattéo",
    LastName = "BADET",
    Age = 20
};

var sender = new Sender();
var reciever = new Reciever();

var server = new Server.Core.Server(sender, reciever);

server.Test(pers);

Console.ReadLine();