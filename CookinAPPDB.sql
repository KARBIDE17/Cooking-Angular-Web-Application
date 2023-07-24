
CREATE DATABASE CookingAppDB;
 USE CookingAppDB; 

CREATE TABLE Recipe (
     recipeId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	 recipeName nvarchar(50),
     videoUrl nvarchar(Max),     
     description nvarchar(Max)
	 );

	 CREATE TABLE Ingredient (
     ingredientId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	 recipeId int FOREIGN KEY (recipeId) REFERENCES Recipe(recipeId),
     ingredientname nvarchar(50),     
     quantity decimal,
	 measurement nvarchar(30),
	 instruction nvarchar(Max)
	 
	 );

	CREATE TABLE Users (
	userID int NOT NULL IDENTITY(1,1)  PRIMARY KEY,
    userName nvarchar(40),
	userPassword nvarchar(20),
	userEmail nvarchar(50),
	userPhone nvarchar(50)
   
);

DROP TABLE dbo.Favorites;

 CREATE TABLE Favorites (
	
	favoriteId int NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	userID int FOREIGN KEY (userID) REFERENCES Users(userID),    
    recipeId int FOREIGN KEY (recipeId) REFERENCES Recipe(recipeId),   
	IsFavorite bit,
	favoriteDescription nvarchar(max)
    
   
); 


CREATE TABLE Nutrition (
     nutritionId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	 recipeId int FOREIGN KEY (recipeId) REFERENCES Recipe(recipeId),
     calories nvarchar(50),     
     protein nvarchar(50),
	 fat nvarchar(50),
	 sugar nvarchar(50),
	 carbs nvarchar(50),
	 fiber nvarchar(50)
	 
	 );

	 CREATE TABLE Instruction (
     instructionId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	 recipeId int FOREIGN KEY (recipeId) REFERENCES Recipe(recipeId),
	 postion int, 
	 starttime int,
	 endtime int,
     step nvarchar(max),   
	 
	 );

	  CREATE TABLE Credits (
       creditId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	   recipeId int FOREIGN KEY (recipeId) REFERENCES Recipe(recipeId),
	   userID int FOREIGN KEY (userID) REFERENCES Users(userID)  
	  
	 
	 );


	/* INSERT INTO Favorites (userID, recipeId, IsFavorite, favoriteDescription)
VALUES
    (1, 1, 1, 'Spaghetti Bolognese')
    ;

	INSERT INTO Users (userName, userPassword, userEmail, userPhone)
VALUES
    ('John Doe', 'password123', 'john.doe@example.com', '1234567890'),
    ('Jane Smith', 'abc456', 'jane.smith@example.com', '9876543210'),
    ('Mike Johnson', 'mikepass', 'mike.johnson@example.com', '5551234567'),
    ('Emily Davis', 'emily123', 'emily.davis@example.com', '7778889999'),
    ('David Brown', 'pass123', 'david.brown@example.com', '4445556666');


	INSERT INTO Recipe (recipeName, videoUrl, description)
VALUES
    ('Spaghetti Bolognese', 'https://www.youtube.com/watch?v=xyz123', 'Classic Italian pasta dish with a meaty sauce.'),
    ('Chicken Curry', 'https://www.youtube.com/watch?v=abc456', 'Flavorful curry made with tender chicken and aromatic spices.'),
    ('Chocolate Chip Cookies', 'https://www.youtube.com/watch?v=pqr789', 'Homemade cookies loaded with chocolate chips.'),
    ('Vegetable Stir-Fry', 'https://www.youtube.com/watch?v=def789', 'Healthy and colorful mix of fresh vegetables cooked quickly.'),
    ('Grilled Salmon', 'https://www.youtube.com/watch?v=ghi456', 'Delicious and nutritious salmon fillets grilled to perfection.');

*/




