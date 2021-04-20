import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/models/user';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isAuthenticated: boolean | undefined;
  currentUser: User | undefined;
  loggedIn: boolean = false;

  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    // sets isAuthenticated var to authService value
    // authService.isAuthenticated is a BehaviorSubject that is initially false
    this.authService.isAuthenticated.subscribe(
      auth => {
        this.isAuthenticated = auth;
        console.log('Auth Status' + this.isAuthenticated)
        if (this.isAuthenticated) {
          this.loggedIn = true;
        }
      }
    );
  }
  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/login');
    this.loggedIn = false;
  }
  isloggedIn() {
    return this.loggedIn;
  }

}
