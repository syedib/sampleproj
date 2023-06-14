import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth-service.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {

  userForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.userForm = this.fb.group({
      fullName: new FormControl(''),
      dateOfBirth: new FormControl(''),
      userName: new FormControl(''),
      password: new FormControl(''),
      confirmPassword: new FormControl('')
    });
  }

  ngOnInit(): void {
  }

  createUser(){
    if (this.userForm.controls['password'].value !== this.userForm.controls['confirmPassword'].value)
    {
      alert("Password is not matching")
      return;
    }

    const user = {
      ...this.userForm.value, dateOfBirth: new Date('2018-10-15T07:53:00.000Z')
    };

    //alert(JSON.stringify(this.userForm.value));
    this.authService.createUser(user).subscribe(_ => {
      alert("User Created");

      this.router.navigate(['/']);
    });
  }

}
