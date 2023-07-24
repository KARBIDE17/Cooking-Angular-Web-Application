import { Component } from '@angular/core';
import { Users } from '../users';
import { RecipeApiService } from '../recipe-api.service';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  user: Users = {
    userId: 0,
    userName: '',
    userPassword: '',
    userEmail: '',
    userPhone: ''
  };
  
  constructor(private recipeApiService: RecipeApiService, private router: Router, private http: HttpClient) { }
  
  
  userMessage: string | null = null;

  register() {
    // You can handle the registration logic here
    console.log('Registration form submitted');    
    console.log('Name:', this.user.userName);
    console.log('Email:', this.user.userEmail);
    console.log('Password:', this.user.userPassword); 

    this.recipeApiService.AddUser(this.user).subscribe(
      (response: Users) => {
        console.log('User Added:', response);
        this.userMessage = "Registration Successful";
        this.router.navigate(['/login']);
  },
  (error) => {
    console.log('Registration failed');
    if (error.error && error.error.error) {
      this.userMessage = error.error.error;

    } else {
      this.userMessage = 'An error occurred during registration. ' + error.error;

    }
  }
  );
}

}