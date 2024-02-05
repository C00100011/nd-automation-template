# nd-automation-template
Baseline template to use with NetDaemon .NET automation in Home Assistant

## How to set it up
If you want to set this up as you own and develop in codespaces you need to do the following
### Prerequisites
- Home Assistant installation
- Working installation of Visual Studio or any other C# .NET IDE.
- NetDaemon extension installed in Home Assistant


### Configuration
1. Make sure you've got a GitHub runner on your Home Assistant installation, or even better a seperate machine with file access
2. Set the following secrets and variables in actions
   - (SECRET) HASS_API_TOKEN (on environment "Production") = This should contain a long life access token from HASS
   - (VARIABLE) HASS_ADDON_NAME = This should contain the name of the NetDaemon add-on in HASS (this is needed to trigger a restart of the add-on)
   - (VARIABLE) HASS_HOSTNAME = This is the external accesible hostname without the https:// prefix
   - (VARIABLE) HASS_PORT = Port on which HASS is accesible
   - (VARIABLE) HASS_SSL = if SSL enabled
   - (VARIABLE) SOLUTION = the solution name if renamed after own specific name (default is NetDaemonAutomations)
3. Set the following secrets and variables in codespaces
   - (SECRET) HASS_HOST = Hostname of you HASS installation
   - (SECRET) HASS_TOKEN = This should contain a long life access token from HASS
4. Now you can use codespaces to develop > everytime you start a codespace it with retrieve the entities from the codegen command

## Lets collaborate and make this stable
