import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'User/';
  }

  getUsers(search: string, somenteAtivos: boolean): Observable<User[]> {
    return this.http.get<User[]>(`${this.myAppUrl}${this.myApiUrl}GetAll?search=${search}&somenteAtivos=${somenteAtivos}`, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getUser(userId: number): Observable<User> {
      return this.http.get<User>(`${this.myAppUrl}${this.myApiUrl}GetById/${userId}`, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveUser(user): Observable<User> {
      return this.http.post<User>(`${this.myAppUrl}${this.myApiUrl}PostUser/`, JSON.stringify(user), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateUser(userId: number, user): Observable<User> {
      return this.http.put<User>(`${this.myAppUrl}${this.myApiUrl}PutUser/${userId}`, JSON.stringify(user), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateUserState(userId: number, user): Observable<User> {
    return this.http.put<User>(`${this.myAppUrl}${this.myApiUrl}PutUserState/${userId}`, JSON.stringify(user), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

  deleteUser(userId: number): Observable<User> {
      return this.http.delete<User>(`${this.myAppUrl}${this.myApiUrl}DeleteUser/${userId}`, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
