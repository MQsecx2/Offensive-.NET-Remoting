using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using SharedInterfaces;


namespace RemotingServer
{
    class RemoteCommandExec : MarshalByRefObject, IRemoteCommandExec
    {
        public string ExecuteCommands(string command)
        {
            try
            {
                // Execute commands and get the result
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/c {command}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                string result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return result;
            }
            catch (Exception ex)
            {
                return $"Error executing command: {ex.Message}";
            }
        }

        static void Main(string[] args)
        {
            // Create and register the TCP channel
            TcpChannel channel = new TcpChannel(1234);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;

            // Reemote object
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(RemoteCommandExec), "RemoteCommandExec",
                WellKnownObjectMode.Singleton);

            Console.WriteLine("Server is running...");
            Console.ReadLine();

        }
    }
}