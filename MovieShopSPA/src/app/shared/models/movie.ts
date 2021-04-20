import { Cast } from "./cast";
import { Genre } from "./genre";

export interface Movie {

    id: number;
    title: string;
    posterUrl: string;
    backdropUrl: string;
    rating: number;
    overview: string;
    tagline: string;
    budget: number;
    revenue: number;
    imdbUrl: string;
    tmdbUrl: string;
    releaseDate: Date;
    runTime: number;
    price: number;
    favoritesCount: number;
    casts: Cast[];
    genres: Genre[];
  
  }