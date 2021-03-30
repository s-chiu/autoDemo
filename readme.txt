How to Run:
Clone the repository and open the solution in Visual Studio
Restore packages via Tools > Nuget Package Manager > Manage Nuget Packages for Solution
Build the solution via Build > Build autoDemo
Select the testEnv config
Select the Chrome.runsettings via via Test > Configure runsettings
Open the test explorer window via Test > Test Explorer
Run the tests

add a new configuration for different environments (i.e. dev, test, prod)
if using .net core, then the end of the csproj file needs to be updated with the new config
add a new runsettings file for different browsers (i.e. chrome, firefox)
tags can be modified to filter out specific tests (i.e. regression, smoke)
test fail screenhots are saved in the FailureScreenshots folder
