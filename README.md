# Plexxis Interview Test
## Requirements
Create a simple but impressive (looks good, works well, has intuitive design, etc.) CRUD application that can do the following:
(iOS was not tested since I didn not have access to a apple device)
 
1) Retrieve employees from a REST API -->    
2) Display the employees in a Xamarin application -->  (I've added padding for each employee row, and background color uses the color each employee is assigned with)
3) Has UI mechanisms for creating and deleting employees  -->( Add button in the navigation bar, long hold the employee row on android or swipe on iPhone to delete)
4) Has API endpoints for creating and deleting employees  -->( Unfotunately I was not able to get the app to POST properly, so all my api endpoints uses GET, which I know is not very secure)  
5) Edit your version of the README.md file to explain to us what things you did, where you focussed your effort, etc.  
 
## Read over the Bonus objectives and consider tackling those items as well
 
_Bonus (Encouraged)_   
1) Use a relational database to store the data (SQLite, MariaDB, Postgres) (SQLITE DB was used to store employee data on both phone and server)   
2) UI mechanisms to edit/update employee data   (double tap on employee row to edit that employee, double tap back on android to exit, tap outside the popup on iOS to exit)
3) Add API endpoint to update employee data   ( Unfotunately I was not able to get the app to POST properly, so all my api endpoints uses GET, which I know is not very secure)  
**Extra Bonus (Will put you at the top of our list!)**    
4) Use an on device DB to keep an up to date copy of the data in case the user goes offline. (sqlite db available on device, keep in mind I did not allow any data modification if the device goes offline)

last note, I've only setup mechanism to check if the device is online, but it does not check if the server is actually online.

## Getting Started
 
You are given a basic app. The back-end server is located in the /server folder and it hosted at <localhost:8000/api/employee>.  The data is being served from a JSON file located in the /server/data folder.  
 
To begin make sure you download the `Xamarin Desktop app` for `Visual Studio` or for your IDE of choice. 
 
Startup the Xamarin frontend server through the `Xamarin desktop app` .
Then startup the ASPNet server, from the terminal navigate to the project folder and run `dotnet run --project server`.

On your `Xamarin desktop app`, you should see this once you run build on it. 

![Alt text]( /phone.png "This is what it should look like.")
 
## Getting it Done
- You are free to use whatever libraries that you want. Be prepared to defend your decisions.
- There is no time limit. Use as little or as much time as is necessary to showcase your abilities.
- You should fork or clone our repository into your own repository.
- Send us the link when you are done the exercise (pglinker at plexxis dot com).

If you do well on the test, we will bring you in for an interview. Your test results will be used as talking points.

This is your chance to amaze us with your talent!
