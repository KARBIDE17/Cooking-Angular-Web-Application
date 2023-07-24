import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Recipe, Result } from './recipe';
import { Observable } from 'rxjs';
import { Favorite } from './favorite';
import { UserRecipe } from './user-recipe';
import { Favoriterecipe } from './favoriterecipe';
import { Users } from './users';

@Injectable({
  providedIn: 'root'
})
export class RecipeApiService{

  constructor(private http: HttpClient) { }

  private readonly url = 'https://cookingappapi2023.azurewebsites.net/api';
  
  // Retrieves recipe results based on the given recipe name and count.
  GetRecipe(recipeName: string, count: number): Observable<Result[]>{
    return this.http.get<Result[]>(this.url + '/Home/GetRecipe/' + recipeName + '/' + count);
  }

  // Retrieves user's favorite recipes based on the user ID.
  GetUserFavorites(UserId: number): Observable<Result[]>{
    return this.http.get<Result[]>(this.url + '/Favorites/GetUserFavorites/' + UserId);
  }

  // Adds a new favorite recipe for a user.
  AddFavorites(favorites: Favorite): Observable<Favorite>{
    return this.http.post<Favorite>(this.url + '/Favorites/AddFavorite', favorites );
  }

  // Adds a new recipe.
  AddRecipe(userrecipes: UserRecipe): Observable<UserRecipe>{
    return this.http.post<UserRecipe>(this.url + '/Recipe',userrecipes);
  }

  // Retrieves recipe details based on the recipe ID.
  GetRecipeById(recipeId: number): Observable<Result[]>{
    return this.http.get<Result[]>(this.url + '/Recipe/GetRecipeById/' + recipeId);
  }

  // Retrieves the last added recipe.
  GetLastRecipe(): Observable<UserRecipe>{
    return this.http.get<UserRecipe>(this.url + '/Recipe/GetLastRecipe');
  }

  // Deletes a favorite recipe based on the ID.
  deleteFavorite(id: number): Observable<any> {
    return this.http.delete<any>(`${this.url}/Favorites/DeleteFavorite/${id}`);
  }
  
  // Retrieves favorite recipe details based on the ID.
  GetFavoriteRecipe(id: number): Observable<any> {
    return this.http.get<Favoriterecipe>(`${this.url}/Recipe/GetFavoriteRecipe/${id}`);
  }

  // Adds a User.
  AddUser(users: Users): Observable<Users>{
    return this.http.post<Users>(this.url + '/Users',users);
  }

  GetUsers(userName: string): Observable<Users>{
    return this.http.get<Users>(this.url + '/Users/GetUserName/' + userName);
  }
}
