# KittyApp
The backend for a web application to fetch and transform kitten photos.

The core project is split into the following folders (normally they would be different projects, but for this one, I consider it would be overkill):

- Contracts - interfaces are here
- Controllers - endpoints
- Data - DB context
- Models - data object models
- Services - business logic

Currently, there are three controllers:

- FlippedKittyController - returns flipped image of a random kitten
- RotatedKittyController - returns rotated image of a kitten with a text specified by the caller
- UserContoller - the endpoints to manipulate app users (authenticate, add new user, delete, update user info)

FakeDBContext acts as a data source for the users. 
In a real project, it would be an Entity Framework (or another ORM) context fetching data from remote DB. 
Here I used in-memory static collection of users with the one predefined user 
(username="james007", password="CasinoRoyale").

External dependencies are three Nuget packages:

- Swashbuckle.AspNetCore - Swagger to automatically generate API documentation and facilitate debugging
- Newtonsoft.Json- to JSON serialize error messages
- System.Drawing.Common - to manipulate and transform images
