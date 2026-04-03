import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent {
  users= [];
  userForm: FormGroup;
  editingUser: any= null;

  constructor(private userService: UserService, private fb: FormBuilder, private router: Router) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  submitForm() {
    if (this.userForm.invalid) return;

    const userData: any = this.userForm.value;

    this.userService.createUser(userData).subscribe({
        next: (userCreation:any) => {
           this.router.navigate([''], {
      state: { message: userCreation.response }
    });
        },
        error: err => {
          this.router.navigate([''], {
      state: { message: err.response }
    });
        }
      });
  }
}