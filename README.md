# AnotherTechTest

This is my solution to an interview tech test, please ignore this project unless I sent it to you.

## Project Structure

This project is broken down into 3 parts. In order to run it for yourself in the browser, you'll need to have both the API and frontend running (more on this below).

### .NET API, located under `./SearchPlatform`
The API was built in Visual Studio and is configured to run in IISExpress on port `5293`. The simplest way to run the API is to open it in Visual Studio and run the debugger.

There are a couple of things to note:
- If you use a different port for the API, you'll need to update the `proxy` setting in the `package.json` file in the frontend to correspond with the new port.
- I'm using C# 10 [file scoped namespace declarations](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration) so you'll need to have C# 10 enabled.
- The application is configured to generate an OpenAPI specification when running, this will open when you debug the app.

### React frontend located under `./SearchFrontend`
I created the frontend using a [Create React App](https://create-react-app.dev/) template. You'll need to follow these steps to run it:
1. install nodejs and npm if you haven't already
1. navigate to the `./SearchFrontend` folder and run `npm install` to install the npm dependencies.
1. run `npm run start` which will run the app in your default browser under `localhost/3000`
1. to run all tests, run `npm run test`

For more information, I've left the default generated readme from create react app in the project.

### Playwright end-to-end tests under `./EndToEndTests`
This is a basic playwright test suite to end-to-end test the entire application. If I had more time, I would have implemented all of the test scenarios described in the specification.

To run this, use the following steps:
- run `npx playwright install` to install playwright and the browser engines
- run `npx playwright test` to run all playwright tests.

