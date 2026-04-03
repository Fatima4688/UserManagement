import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'http://localhost:5051/api/User';

  constructor(private http: HttpClient) {}

  getUsers(){
    const url= `${this.apiUrl}/get-users`
    return this.http.get(url);
  }

  createUser(user: any){
    const url= `${this.apiUrl}/create-user`
    return this.http.post(url, user);
  }
}
