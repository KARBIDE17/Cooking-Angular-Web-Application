import { Component, OnInit } from '@angular/core';
import { RecipeApiService } from '../recipe-api.service'
import { Ingredient, Instruction, Nutrition, Recipe, Result, Section } from '../recipe';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { Favorite } from '../favorite';
import { UserRecipe } from '../user-recipe';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  // An array to store the results of recipes
  results: Result[] = [];
  username!: string;
  userId!: number;
  selectedRecipe!: any;

 
  // Injecting the RecipeApiService and HttpClient dependencies
  constructor(private recipeApiService: RecipeApiService, private http: HttpClient, private cookieService: CookieService, private router: Router) { }

  // Lifecycle hook that is called after the component is initialized
  // Can be used to perform initialization tasks
  ngOnInit(): void {
    this.username = this.cookieService.get('username');
    this.userId = Number(this.cookieService.get('userId'));
  }

  //Retrieves recipes based on the provided recipe name.
  getRecipe(recipeName: string) {
    const recipeCount = 5;
    this.recipeApiService.GetRecipe(recipeName, recipeCount).subscribe(
      (response: any) => {
        this.results = response.results;
        console.log(this.results);
      }
    );
  }

//Handles the form submission event.
//Retrieves recipes based on the submitted recipe name.
  onSubmit(form: NgForm) {
    if (form.valid) {
      const recipeName = form.value.recipeName;
      this.getRecipe(recipeName);
    }
  }

  //Updates the favorite status of a recipe for a given user.
  updateFavoriteStatus(recipesid: number, recname: string, recdescription: string, thumbnailUrl: string, thumbnail_alt_text: string) {
    if (recipesid != undefined) {
      // Create a new Favorite object for the user and the added recipe
      let newUserRecipe: UserRecipe = {

        recipeId: 1,
        Id: recipesid,
        Name: recname,
        Description: recdescription,
        thumbnailUrl: thumbnailUrl,
        thumbnailAltText: thumbnail_alt_text,


      };

      // Add the new recipe to the recipe API service
      this.recipeApiService.AddRecipe(newUserRecipe).subscribe(
        (response: UserRecipe) => {
          console.log('Recipe Added:', response);
         
          // Create a new Favorite object for the user and the added recipe
          const newFavorite: Favorite = {
            userId: this.userId,
            recipeId: response.recipeId,
            IsFavorite: true,
            favoriteDescription: "This is my favorite"
          };

          // Update the favorite status by adding the new favorite to the recipe API service
          this.recipeApiService.AddFavorites(newFavorite).subscribe(
            (response: any) => {
              console.log('Favorite updated:', response);
            }
          );

        }
      );
    }
  }

  navigateRecipeDetail(name: string) {
    console.log('Recipe ID:', name);
    this.router.navigate(['/recipe-detail', name]);
  }

}
