import { Component, OnInit } from '@angular/core';
import { RecipeApiService } from '../recipe-api.service'
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Favorite } from '../favorite';
import { Result } from '../recipe';
import { UserRecipe } from '../user-recipe';
import { Favoriterecipe } from '../favoriterecipe';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';



@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit{
      userFavorites: any[] = [];
      username!: string;
      userId!: number;



      recipeFavorite: Favoriterecipe[] =[];


      // allows the component to access the necessary services
      constructor(private recipeApiService: RecipeApiService, private http: HttpClient, private cookieService: CookieService, private router: Router) { 
        this.recipeFavorite = [];
      }

      ngOnInit(): void {
        this.username = this.cookieService.get('username');
        this.userId = Number(this.cookieService.get('userId'));
        this.GetRecipeDetailsByRecipeId();
      }


      // Retrieves the details of the favorite recipes by recipe ID
      GetRecipeDetailsByRecipeId() {
        this.recipeApiService.GetFavoriteRecipe(this.userId)
          .subscribe(
            (response) => {
              this.recipeFavorite = response;

              console.log(response);
    
            }
          );
      }

    // Deletes a favorite recipe from the user's favorites
    DeleteFavorite(favorite: Favoriterecipe) {
      favorite.isFavorite = !favorite.isFavorite; // Toggle the isFavorite property
        console.log(favorite.favoriteId)
        // Update the favorite in the database
          this.recipeApiService.deleteFavorite(favorite.favoriteId).subscribe(
            (response: any) => {
            console.log('Favorite updated:', favorite);
            this.GetRecipeDetailsByRecipeId();
            }
          );

      
 }



// future and past implementations saved for later use

  /* GetUserFavorites() {
    this.recipeApiService.GetUserFavorites(1)
      .subscribe(
        (response) => {
          this.userFavorites = response;

          console.log(this.userFavorites);
 
        }
      );
  } */


/*   DeleteFavorite(favoriteId: number) {

    this.recipeApiService.deleteFavorite(favoriteId)
      .subscribe(
        (response) => {
          this.recipeFavorite = response;

          console.log(response);
 
        }
      );
      this.GetRecipeDetailsByRecipeId();
    this.router.navigateByUrl('favorites', { skipLocationChange: true }).then(() => {
      this.router.navigate(['favorites']);
    });



  
} */

navigateRecipeDetail(name: string) {
  console.log('Recipe ID:', name);
  this.router.navigate(['/recipe-detail', name]);
}



}
