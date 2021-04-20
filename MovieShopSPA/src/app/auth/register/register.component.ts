import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Register } from 'src/app/shared/models/register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerInfo: Register = {
    email: '',
    password: '',
    firstName: '',
    lastName: '',
  }
  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
  }
  register() {
    this.authService.register(this.registerInfo).subscribe(
      (response) => {
        if (response) {
          // doesn't go here
          this.router.navigate(['login']);
        }
        this.router.navigate(['login']);
      },
      (err: any) => { console.log(err); });
  };
}

