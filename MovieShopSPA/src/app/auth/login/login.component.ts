import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Login } from 'src/app/shared/models/login';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  // login component html to here to ...
  // two way binding 
  // one way binding 

  userLogin: Login = {
    email: '', 
    password: ''
  };
  invalidLogin: boolean = false;
  returnUrl: string | undefined;
  user: User | undefined;

  constructor( private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    // console.log(this.userLogin);
    this.route.queryParams.subscribe(params => this.returnUrl = params.returnUrl || '/');
  }

  // login(f: NgForm) {
  //   console.log(this.userLogin);
  // }
  login() {
    this.authService.login(this.userLogin).subscribe(
      (response) => {
        if (response) {
          this.router.navigate([this.returnUrl]);
        }
        else {
          this.invalidLogin = true;
        }
      },
      (err: any) => { this.invalidLogin = true, console.log(err); });
  }

  // for testing
  get twowayInfo(){
    return JSON.stringify(this.userLogin);
  }
}
