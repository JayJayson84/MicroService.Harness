## Example .Net Core MicroService Architecture
- RabbitMQ
- MassTransit
- Docker / Docker Compose
- Logging - A custom Logger implementation can be found in `./common/logging` which provides additional extension methods for the `Microsoft.Extensions.Logging.ILogger` and utilizes the compile time [Caller Information Attributes](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information) to add the member name, file path and line number to every log. You can configure your own logging provider e.g. Log4Net or Serilog (an example for NLog has been included in `./common/logging/MicroService.Logging.NLog`).
- Encryption Service - To demonstrate an end-to-end example, an encryption service is included and builds upon an idea discussed on [StackOverflow](https://stackoverflow.com/questions/18835169/add-salt-to-data-to-be-encrypted) to create a random SALT (if ommitted) and append it to the encrypted string. You can of course include a SALT value, or implement your own SALT'ing strategy. An encryption key is always required.
> [!IMPORTANT]
> The Encryption service serves as an example and is something I have been experimenting with. Make sure to follow recommended guidance when selecting and using services in your own Micro Service infrastructure.

## Useful VS Code extensions
- Install the 'Docker' extension for VSCode.
- Install the 'C#' extension for VSCode.
- Install the 'C# Dev Kit' extension for VSCode.

## Getting started
1. Clone the repository and open with Visual Studio Code.
1. If you don't already have a Docker environment set up on your local machine, follow the guide below starting from the `Install Ubuntu on WSL2` section through to the end of the ReadMe.
1. Create a RabbitMQ login following the steps provided below.
1. Update the RabbitMQ hostname following the steps provided below.
1. Debug and Test using the steps provided in the sections below.

## Generate RabbitMQ password hashes
1. Open the repository in VSCode.
1. Build and run the RabbitMQ container image from a VSCode terminal:
   
   ```
   docker-compose up -d --build rabbitmq
   ```
1. Open the Docker pane in the VSCode sidebar.
1. Right click the `microservice.rabbitmq:debug` container and click 'Attach Shell'.
1. In the terminal window that opens, generate a password hash for the `admin` and `broker` user accounts:
   
   ```
   rabbitmqctl hash_password <your_unencrypted_password>
   ```
1. Update the **password_hash** for the `admin` and `broker` user accounts in `./containers/rabbitmq/config/definitions.json`.
1. Update the **RABBITMQ__PASSWORD** value with the unencrypted `broker` password in the `.env` file in the root of the repository.
> [!IMPORTANT]
> These passwords are intended for local development only. Take care to avoid committing passwords into public and/or shared repositories and follow recommended guidance when deploying containers to other environments.

## Update the RabbitMQ Hostname
1. Login to the Ubuntu on Windows application from the start menu e.g. `Ubuntu 22.04.3 LTS`.
1. Get the IPv4 address for the eth0 adapter by running the `ifconfig` command.
1. Update the **RABBITMQ__HOSTNAME** value with the IPv4 address inside the `.env` file in the root of the respository.

## Debug from VSCode
1. Load the solution in VSCode.
1. Switch to the `Run and Debug` window.
1. Choose a Launch configuration in the dropdown list.
1. Click the play icon to run the project.
1. You can add breakpoints in the source code and step through the code.
1. Logs are written to the debug console using the included logging library in `common/logging`.
> [!NOTE]
> If you haven't already, run the installer for the VSDebugger image in the VSCode terminal:  
> `docker-compose up install.vsdbg`.

## Testing
<ins>RabbitMQ</ins>
1. Open the RabbitMQ URL via:  
   http://localhost:15672  
   [http://\<ubuntu-eth0-ip>:15672](http://localhost:15672)
1. Login using either the **admin** or **broker** account username and password.

<ins>Swagger</ins>
1. Open the Swagger URL for the Producer via:  
   http://localhost:5000/swagger  
   [http://\<ubuntu-eth0-ip>:5000/swagger](http://localhost:5000/swagger)

<ins>Postman</ins>
1. Example GET:  
   http://localhost:5000/api/Encryption/CheckEndpoint  
   [http://\<ubuntu-eth0-ip>:5000/api/Encryption/CheckEndpoint](http://localhost:5000/api/Encryption/CheckEndpoint)
1. Example POST:  
   http://localhost:5000/api/Encryption/EncryptString?encryptionMethod=1&value=test&key=abc123  
   [http://\<ubuntu-eth0-ip>:5000/api/Encryption/EncryptString?encryptionMethod=1&value=test&key=abc123](http://localhost:5000/api/Encryption/EncryptString?encryptionMethod=1&value=test&key=abc123)

<ins>Unit Tests</ins>
- There are unit tests included in some areas (look for the Test projects in the folder tree), though you are welcome to expand on them.
- The Consumer project contains an integration test using the MassTransit Test Harness.
- DSL is a test pattern and stands for Domain Specific Language. There are builders to construct tests and they have been expanded to separate the SUTs (subject under test) into a separate class, as well as the assertions in some cases. Feel free to experiment with your own pattern(s).
> [!WARNING]
> The [Moq](https://www.nuget.org/packages/Moq) nuget package has been used for the unit tests and uses a version prior to `V4.20`. It's recommend not to go beyond that version due to a decision by the author to include a closed source library which harvests email addresses. It's recommended to stick with older versions or to migrate to another mocking framework such as [NSubstitute](https://www.nuget.org/packages/NSubstitute).

<ins>End-To-End Tests</ins>
- There is a webpage and WPF Desktop application in the accompanying [repository](https://github.com/JayJayson84/MicroService.Harness.Demo).

## Testing with Self-Signed SSL
The Producer API can be tested using a self-signed SSL certificate. An example of how the certificate is installed can be found in the **SSL** stage inside `dockerfile.microservice-security-producer` in the root of the repository.
1. Edit the `.env` file in the root of the repository.
1. Set the **ASPNETCORE_ENVIRONMENT** value to either `Development` or `Staging`.
1. Set the **ASPNETCORE_URLS** value to `https://+:5001` or `http://+:5000;https://+:5001` (to enable both protocols).
1. Set the **SSL_CERT_KEY** value to a password of your choice.
1. Open the Swagger URL for the Producer via:  
   https://localhost:5001/swagger  
   [https://\<ubuntu-eth0-ip>:5001/swagger](https://localhost:5001/swagger)
1. Use the https URL equivalents of those shown in the section above when using Postman (you may need to disbale **SSL Certificate Validation** in settings.)

## Install Ubuntu on WSL2
<ins>Run in Powershell (Admin)</ins>
1. Install the VirtualMachinePlatform optional Windows feature.
   
   i. Check Status:
	```
   Get-WindowsOptionalFeature -Online -FeatureName VirtualMachinePlatform
   ```
	ii. Install:
   ```
   Enable-WindowsOptionalFeature -Online -FeatureName VirtualMachinePlatform -NoRestart
   ```
1. Install the WSL optional Windows feature.

   i. Check Status:
   ```
   Get-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux
   ```
	ii. Install:
   ```
   Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux -NoRestart
   ```
1. Reboot.
1. Update the WSL Kernel.
   
	i. Check the Kernel version pre-update:
   ```
   wsl --status
   ```
	ii. Update WSL:
   ```
   wsl --update
   ```
	iii. Check the Kernel version post-update:
   ```
   wsl --version
   ```
1. Set the default version for new Linux installations to use WSL2.

   ```
   wsl --set-default-version 2
   ```
1. Confirm the default version for new Linux installations.

   ```
   wsl --status
   ```
1. Show a list of any Linux distributions that are already installed.

   ```
   wsl --list --verbose
   ```
1. If you already have a distribution installed on WSL1 you can convert it to WSL2 e.g.

   ```
   wsl --set-version Ubuntu-22.04 2
   ```
1. Show a list of the available distributions that can be installed.

   ```
   wsl --list --online
   ```
1. Install a distribution (recommended version Ubuntu-22.04).

   ```
   wsl --install --distribution Ubuntu-22.04
   ```
1. During the installation:
	- Enter a Unix username when prompted
	- Enter a Unix password when prompted
6. Close PowerShell.

## Install Docker & Docker Compose on Ubuntu

1. Login to the Ubuntu on Windows application from the start menu e.g. `Ubuntu 22.04.3 LTS`.
1. Install Docker by running each of the following commands in turn:

   ```
	sudo apt-get update
   ```
   ```
	sudo apt-get upgrade -y
   ```
   ```
	sudo apt install --no-install-recommends apt-transport-https ca-certificates curl gnupg2 -y
   ```
   ```
	cd ~
   ```
   ```
	curl -fsSL https://get.docker.com -o get-docker.sh
   ```
   ```
	sudo sh get-docker.sh
   ```
   ```
	sudo usermod -aG docker $USER
   ```
   ```
	echo "export DOCKER_HOST=tcp://localhost:2375" >> ~/.bash_profile
   ```
   ```
	sudo rm get-docker.sh
   ```
1. Install Docker Compose.
   
	i. Check to see if it is already installed:
   ```
   docker compose version
   ```
	ii. Install using the package handler:
   ```
   sudo apt-get install docker-compose-plugin -y
   ```
1. Disable Docker from running on system startup.

   i. Get the task names for the Docker service:
   ```
   systemctl list-unit-files | grep -i docker
   ```
	ii. Disable the tasks found by the command above e.g:
   ```
   sudo systemctl disable docker.service
   ```
   ```
   sudo systemctl disable docker.socket
   ```
	iii. Confirm that the task STATE has been set to disabled:
   ```
   systemctl list-unit-files | head -1; systemctl list-unit-files | grep -i docker
   ```
	iv. Restart Docker:
   ```
   sudo systemctl restart docker
   ```
1. Close Ubuntu on Windows.

## Manually Install Docker.exe on Windows

1. Download the latest `Docker` binaries from https://download.docker.com/win/static/stable/x86_64/.
2. Create the directory `C:\Docker` and extract the files from the archive above into this folder.
3. Limit the memory usage for WSL Linux distributions.
   
	i. Check the current memory/swap usage in Ubuntu:
   ```
   free -m
   ```
	ii. Create file `C:\Users\<UserName>\.wslconfig` with the following content:
   ```
   # Settings apply across all Linux distros running on WSL 2
   [wsl2]
   memory=12GB
   processors=4
   swap=4GB
   ```
4. Disable Windows `PATH` on WSL.

   i. Either, from the Ubuntu terminal:
   ```
	echo -e "[interop]\nappendWindowsPath = false" | sudo tee -a /etc/wsl.conf
   ```
   ii. Or, by manually editing the wsl config file in Ubuntu:
   ```
   sudo nano /etc/wsl.conf
   ```
   Insert the following section:
   ```
   [interop]
   enabled=false
   appendWindowsPath=false
   ```
5. Download the `Docker Compose` binary.
   
   i. Either, using PowerShell as Admin (update the source url below with the latest version number):
   ```
   Start-BitsTransfer -Source "https://github.com/docker/compose/releases/download/v2.23.3/docker-compose-windows-x86_64.exe" -Destination C:\Docker\docker-compose.exe
   ```
   ii. Or, by manually downloading:
      - Find the latest version via https://github.com/docker/compose/releases.  
      - Click the download link for the `docker-compose-windows-x86_64.exe` binary under the `Assets` heading.  
      - Move the downloaded file to folder `C:\Docker` and rename the file to `docker-compose.exe`.

## Windows Environment Variables
1. Open the `System Environment Variables` dialog in Windows and add the following entries:

   | Action | System Variable | Value | Description |
   | ------ | --------------- | ----- | ----------- |
   | Edit | PATH | C:\Docker | Register location of Docker.exe for Windows. |
   | Add | DOCKER_HOST | tcp://localhost:2375 | Exposes the url that Docker is listening to in Ubuntu. |
1. Verify that `Docker` is accessible through the terminal by running the following command in PowerShell:
   ```
   dockerd --version
   ```
1. Verify that `Docker Compose` is accessible through the terminal by running the following command in PowerShell:
   ```
   docker-compose --version
   ```

## Run Docker

This process is the same every time you want to start docker on your environment:

1. Login to the Ubuntu on Windows application from the start menu e.g. `Ubuntu 22.04.3 LTS`.
1. Enter the following command in the Ubuntu terminal:
   ```
   sudo dockerd -H localhost
   ```

The -H flag will start the Docker daemon and attach to the process to show it's output. If the daemon is already running you cannot attach to the ouput of the process directly. Either, stop and then start the daemon with the -H flag or inspect the log files to view the processes output.

1. Check if the Docker daemon is already running.
   ```
   sudo systemctl status docker
   ```
1. Stop the Docker service.
   ```
   sudo systemctl stop docker
   ```
1. Kill a hung Docker service.
   
	i. Get the process ID (PID):
   ```
   ps -ef | grep docker
   ```
	ii. Kill the process:
   ```
   kill <process_id>
   ```
1. Start Docker with the -H flag.
   ```
   sudo dockerd -H localhost
   ```
1. Inspect logs using any of these approaches.
   
	i. Using Journalctl (systemd):
   ```
   journalctl -u docker.service
   ```
	ii. View the Docker daemon's logs in real-time:
   ```
   docker logs <container_name_or_id>
   ```
	iii. Using Tail:
   ```
   tail -f /var/log/docker.log
   ```