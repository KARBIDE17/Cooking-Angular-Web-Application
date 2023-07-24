-- Table: Recipes
CREATE DATABASE RecipeDB;
 USE RecipeDB;
CREATE TABLE Recipes (
    RecipeId int PRIMARY KEY,
	id int,
    Name nvarchar(255),
    Description nvarchar(max),
    Yields nvarchar(100),
    NumServings int,
    ThumbnailUrl nvarchar(max),
    ThumbnailAltText nvarchar(max),
    OriginalVideoUrl nvarchar(max),
    CookTimeMinutes int NULL,
    PrepTimeMinutes int NULL,
    TotalTimeMinutes int NULL,
    SeoPath nvarchar(max) NULL,
    SeoTitle nvarchar(max) NULL,
    TotalTimeTier nvarchar(max) NULL
);

-- Table: Nutrition
CREATE TABLE Nutrition (
    NutritionId int PRIMARY KEY,
	RecipeId int FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId),
    Carbohydrates int,
    Fiber int,
    UpdatedAt datetime,
    Protein int,
    Fat int,
    Calories int,
    Sugar int
    
);

-- Table: Instructions
CREATE TABLE Instructions (
    InstructionId int PRIMARY KEY,
    RecipeId int FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId),
    Position int,
    DisplayText nvarchar(max),
    StartTime int,
    EndTime int,
    Appliance nvarchar(max) NULL
    
);

-- Table: Ingredients
CREATE TABLE Ingredients (
    IngredientId int PRIMARY KEY,
	id int,
	RecipeId int FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId),
    Name nvarchar(255)
);

-- Table: Sections
CREATE TABLE Sections (
    SectionId int PRIMARY KEY,
    RecipeId int FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId),
    Name nvarchar(255),
    Position int
    
);

-- Table: Components
CREATE TABLE Components (
    ComponentId int PRIMARY KEY,
    SectionId int FOREIGN KEY (SectionId) REFERENCES Sections(SectionId),
	IngredientId int FOREIGN KEY (IngredientId) REFERENCES Ingredients(IngredientId),
    Position int,
    RawText nvarchar(max),
    ExtraComment nvarchar(max)
    
);

CREATE TABLE Users (
	userID int NOT NULL IDENTITY(1,1)  PRIMARY KEY,
    userName nvarchar(40),
	userPassword nvarchar(20),
	userEmail nvarchar(50),
	userPhone nvarchar(50)
   
);

CREATE TABLE Favorites (
	
	favoriteId int NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	userID int FOREIGN KEY (userID) REFERENCES Users(userID),    
    RecipeId int FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId),   
	IsFavorite bit,
	favoriteDescription nvarchar(max)
    
   
); 

