USE recipedb;
GO

CREATE VIEW FavoriteRecipe
AS
SELECT R.id,
       R.Name,
	   R.Description,
	   R.Yields,
	   R.NumServings,
	   R.ThumbnailUrl,
	   R.ThumbnailAltText,
	   R.OriginalVideoUrl,
	   R.CookTimeMinutes,
	   R.PrepTimeMinutes,
	   R.TotalTimeMinutes,
	   R.SeoPath,
	   R.SeoTitle,
	   R.TotalTimeTier,
	   F.favoriteId,
	   F.userID,
	   F.RecipeId,
	   F.IsFavorite,
	   F.favoriteDescription
	   		 	        
FROM Recipes AS R
INNER JOIN Favorites AS F
    ON R.RecipeId = F.RecipeId;
GO

SELECT *
FROM FavoriteRecipe;