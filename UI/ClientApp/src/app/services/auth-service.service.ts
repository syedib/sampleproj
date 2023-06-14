import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { CreateUser, LoginUser } from '../models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  createUser(user: CreateUser): Observable<boolean> {
    return this.httpClient.post<boolean>('https://localhost:44377/auth/CreateUser', user);
  }

  getToken() {
    return localStorage.getItem('access_token');
  }

  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('access_token');
    return authToken !== null ? true : false;
  }

  doLogout() {
    let removeToken = localStorage.removeItem('access_token');
  }

  login(user: LoginUser) : Observable<any> {
    return this.httpClient
      .post<any>('https://localhost:44377/auth/LoginUser', user).pipe(tap((res) =>
      {
        console.log('token', res.token);
          localStorage.setItem('access_token', res.token)
      }));
  }

}
