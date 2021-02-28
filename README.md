To setup this microservice you need to do the following:

Using Docker 

1. Setup docker
2. Open the solution and build in Debug compilation (You need to change the Google API key this is located underneath the appsettings.json)
3. Run build.bat (this calls docker build with the correct settings)
4. Run instance.bat (this calls docker-compose up, NOTE: this might take a while as it needs to download MSSQL which is over 5gb  - KEEP THIS OPEN)
5. Run database.bat (This needs to happen after instance.bat has been initialized)
6. Open up Postman if you don't already have it you can install it from here https://www.postman.com/downloads/
7. Click on collections and go Import, select the file "Synlait Timezone API.postman_collection.json"
8. Run the "Fetch Timezone from Google API via Microservice" this should return the Timezone based on the Latitude
9. Run the "Fetch Timezone Request Logs via Microservice" this should return the request logs

Without Docker

1. Open up the solution and select the startup project to be Synlait.Api.TimeZone (You need to change the Google API key this is located underneath the appsettings.json)
2. Create a new instance of MSSQL and run the install script located in the project (This should create the database) on the master db
3. Run the solution
6. Open up Postman if you don't already have it you can install it from here https://www.postman.com/downloads/
7. Click on collections and go Import, select the file "Synlait Timezone API.postman_collection.json"
8. Run the "Fetch Timezone from Google API via Microservice" this should return the Timezone based on the Latitude
9. Run the "Fetch Timezone Request Logs via Microservice" this should return the request logs
