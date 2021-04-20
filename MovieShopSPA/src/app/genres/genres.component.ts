import { Component, OnInit } from '@angular/core';
import { GenreService } from '../core/services/genre.service';
import { Genre } from '../shared/models/genre';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  genres: Genre[] | undefined;
  
  constructor(private genreService: GenreService) { }

  ngOnInit() {

    // calls genreservice method and subscribes to execute (like to list) while storing into Genre model
    // the app-component.html calls app-header selector which calls the header component
    // then the header component html has app-genres selector which calls this component
    // which displays this genre component html
    // the genre component html file contains for loop that loops through this genres model that we 
    // defined in the shared models folder
    this.genreService.getAllGenres().subscribe(
      g => {
        this.genres = g;
        console.table(this.genres);
      }
    );

  }

}
