import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  constructor(private router: Router, private userService: UserService) {}

  users :any=[];

    ngOnInit() {
    this.loadUsers();
    const navigation = this.router.getCurrentNavigation();
    const message = navigation?.extras.state?.['message'];

    if (message) {
      alert(message); // simple browser alert
    }
  }

  loadUsers() {
    this.userService.getUsers().subscribe((response:any)=> this.users = response.data);
  }
  
goToUpdateUser() {
  this.router.navigate(['/update-user']);
}
}
