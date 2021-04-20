import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { HomeComponent } from './home/home.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';

const routes: Routes = [
  
  // the path url calls the component using router
  // app-component.html calls router-outlet which calls HomeComponent initially.
  {path: "", component: HomeComponent},
  {path: "movies/genre/:id", component: MovieCardListComponent},
  {path: "movies/:id", component: MovieDetailsComponent},
  {path: "login", component: LoginComponent},
  {path: "register", component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
