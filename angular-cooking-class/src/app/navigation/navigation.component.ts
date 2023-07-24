import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})

export class NavigationComponent {

  username!: string;
  


  constructor( private cookieService: CookieService, private sharedService: SharedService) {}

  ngOnInit(): void {
    
    this.sharedService.username$.subscribe(username => {
      this.username = username;
    });
 
  }
}
