import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(protected http: HttpClient) {

  }

  // makes get request to api with given url
  getAll(path: string): Observable<any[]> {

    return this.http.get(`${environment.apiUrl}${path}`)
      .pipe(
        map(resp => resp as any[])
      );

  }

  // makes get request to api with given url
  getOne(path: string, id?: any, queryParams?: Map<any, any>): Observable<any> {
    let getUrl: string;
    if (id) {
      getUrl = `${environment.apiUrl}${path}` + '/' + id;
    } else {
      getUrl = `${environment.apiUrl}${path}`;
    }

    let params = new HttpParams();
    if (queryParams) {
      queryParams.forEach((value: string, key: string) => {
        params = params.append(key, value);
      });
    }

    return this.http.get(getUrl, { params }).pipe(
      map(resp => resp as any),
    );
  }

  // example for login, takes login path and model input to post to api url
  create(path: string, resource: any, options?: any ): Observable<any> {

    return this.http.post(`${environment.apiUrl}${path}`, resource).pipe(
      map(response => response)
    )
  }

  post(path: string, resource: any) {
    this.http.post(`${environment.apiUrl}${path}`, resource)
  }

}
