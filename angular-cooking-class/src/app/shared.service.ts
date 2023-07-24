import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor() { }

  private usernameSource = new BehaviorSubject<string>('');
  username$ = this.usernameSource.asObservable();

  updateUsername(username: string) {
    this.usernameSource.next(username);
  }
}
