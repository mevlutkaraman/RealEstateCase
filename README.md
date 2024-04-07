# Real estate case

Docker

For Database Migration:
  ### BackEnd:
   To start up the web API and the database
   
   ```ruby
   docker-compose build
   ```
   ```ruby
   docker-compose up
   ``` 
  
  To create tables in the database.In the terminal go to the directory.
  ```ruby
  src/RealEstate.Api
  ```   
  
  ### Second:
  Run following code in Package Manager Console
  ```ruby
  Update-Database -Context RealEstateDbContext
  ```
  Or 

  Run following code in 
  ```ruby
  dotnet ef database update --context RealEstateDbContext
  ```

