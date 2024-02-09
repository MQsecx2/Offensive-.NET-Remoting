## Description
A simple POC demonstrating the utilization of .NET Remoting for lateral movement (it requires admin access on the target server).
<br>
<br>
It is merely intended to demonstrate lateral movement and does not utilize a covert method to execute commands on the server. The execution is achieved by invoking cmd.exe which is not deemed OPSEC friendly in certain scenarios, a better approach might involve using **BinaryFormatter** to execute assemblies.
<br>
<br>
For more details, refer to the [blog post](https://www.mqsec.me/2024/02/07/net-remoting-for-lateral-movement-and-backdooring/).

## Compile
**Note:** I encountered difficulty generating a single solution for the project when Costura.Fody is used. So, I created 3 seperate projects.
Costura.Fody is used to embed SharedInterfaces.dll in RemotingServer.exe & RemotingClient.exe.
1. Change the port number in RemotingServer
2. Change the ip and port in RemotingClient
3. Compile SharedInterfaces first
4. Compile both RemotingServer & RemotingClient

## Usage & Example:
```
C:\Remoting> RemotingClient.exe "whoami && hostname"
C:\Remoting> RemotingClient.exe ipconfig
```

## Disclaimer
The shared POC is for **educational purposes ONLY**, use it within your own networks and/or with the permission of the network owner.
<br>
<br>
.NET Remoting is a deprecated technology with limited security features. Therefore, its use in a client environment during red team engagements should be approached cautiously, especially since the shared POC lacks authentication measures and may leave systems susceptible to backdoors.
