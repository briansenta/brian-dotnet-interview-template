# .NET Interview Template

## Context
This sample application is supposed to check if a given application name is installed by looking into the Windows registry.
It then should report the installation status to a mock web API.

## Directions
Steps through the 5 TODOs to complete the functionality and get the tests to pass.

## Solution
I started by looking at the test, to see what was required of the functionality (a la "Test Driven Development").
I then did a ctrl-shift-f in Visual Studio for the string "todo", and started implemented my best interpretations of the requirements.
I was not 100% sure if the services registered in Program.cs should be registered as Singleton, Transient, Scoped, or what. Singleton seemed to make the most sense. I'd be happy to discuss.
I then attempted an actual implementation of querying for installed applications on the current machine. It seems to generally work, although it's definitely not production-ready.
Lastly, I noticed the repo uses spaces, not tabs. I am dieing to know if Syncro as a whole follows this approach.
