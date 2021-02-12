# AuthSystemAutomationTests
Authomation tests for AuthSystem application.
AuthSystem available in my repositorium.

## The following technologies have been used in the project:

### C# with .Net
- code of tests steps.
### Specflow
- scenarios
### NUnit
- test framework
### Selenium
- for using Chrome web browser in tests.

### Configuration:

- For correct configure of this application your need to download the source code, unzip it and open via Visual Studio.
- Please make sure that specflow, and NUnit test adapter extension is installed in VS.
If not please go to Extension manager and install above.

- Open the test solution in Visual Studio.
Go to Tools => NuGet Package Manager => Manage NuGet Packages for Solution.
Please Insstall the latest stable version of the following packages:
- NUnit;
- Specflow;
- Specflow.NUnit;
- Selenium.WebDriver;
- Selenium.WebDriver.ChromeDriver;
- DotNetSeleniumExtras.WaitHelper;

### Run automation tests:
## IMPORTANT 
### BEFORE RUNNING THE TESTS PLEASE REMEMBER THAT AuthSystem app needs to be run in other VS window
Please build the application via Visual Studio using combination of keys (Ctrl+Shift+B) or using VS menubar:
- Build => Bulid.

After that please go tu VS Test Explorer window and run All tests.


### If you have any questions or suggestions please contact me via e-mail:
contact@maciejwolejszo.pl
