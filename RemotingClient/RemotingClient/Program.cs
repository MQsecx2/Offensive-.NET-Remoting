using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using SharedInterfaces;

namespace RemotingClient
{
    class RemotingClient
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: RemotingClient.exe <commad>");
                Environment.Exit(1);
            }
            try
            {
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                IRemoteCommandExec remoteExec = (IRemoteCommandExec)Activator.GetObject(
                    typeof(IRemoteCommandExec), "tcp://192.168.29.131:1234/RemoteCommandExec"); // Replace the IP and PORT

                // Execute command on the server
                string commandResult = remoteExec.ExecuteCommands(args[0]);

                Console.WriteLine(commandResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in the server side: {ex}");
            }

        }
    }
}
