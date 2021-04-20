import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { Movie } from 'src/app/shared/models/movie';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  movie: Movie | undefined;
  id: number | undefined;
  constructor(private movieService: MovieService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(
      params => {
        this.id = Number(params.get('id'));
        this.getMovieDetails();
      }
    );
  }

  getMovieDetails() {
    this.movieService.getMovieDetails(Number(this.id))
      .subscribe(m => {
        this.movie = m;
      })
  }

}
