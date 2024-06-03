It is MicroServices Project Which is having two services(2webapi) projects and 1 Ocelot gate way project.
We are configuring the Serives in The Ocelot Gateway api indiidually each end point will be independent.
Technologies Used: Asp.net core Webapi, Mysql, Entity framework and Ocelot gateway

After cloning my project you need to check the connection string in each service Appsettings.json then you need to run Migrations according to your db then tables will be creates and you can work. 

Commands for generating migrations:
add-migation <migration name>
update-database
after executing these two commands in Package manager console It will create schema in db and tables in that schema.
