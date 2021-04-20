import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movie-card';

@Component({
  selector: 'app-movie-card-list',
  templateUrl: './movie-card-list.component.html',
  styleUrls: ['./movie-card-list.component.css']
})
export class MovieCardListComponent implements OnInit {

  movies: MovieCard[] | undefined;
  genreId: number | undefined;

  constructor(private movieService: MovieService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(
      params => {
        this.genreId = Number(params.get('id'));
        this.movieService.getMoviesByGenre(this.genreId)
          .subscribe(g => {
            this.movies = g;
          });
      }
    )
  }

}
