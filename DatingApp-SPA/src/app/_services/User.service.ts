import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUri = environment.apiUrl  ;

constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUri + 'users');
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUri + 'users/' + id);
  }

  updateUser(id: number, user: User) {
    return this.http.put(this.baseUri + 'users/' + id, user);
  }
}
