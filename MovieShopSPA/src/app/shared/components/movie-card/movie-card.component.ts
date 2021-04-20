import { Component, Input, OnInit } from '@angular/core';
import { MovieCard } from '../../models/movie-card';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {

  // parent to child, here it is expecting this MovieCard
  // passed from home.html
  @Input() movie: MovieCard | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
