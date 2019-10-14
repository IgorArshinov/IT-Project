import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtService } from '../../services/jwt.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private router: Router, private jwtService: JwtService) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.minLength(3)]),
    });
  }

  onLogin() {
    if (this.loginForm.invalid) {
      document.getElementById('email').style.borderColor = 'red';
    }
    this.jwtService
      .login(this.loginForm.controls['email'].value, this.loginForm.controls['password'].value)
      .pipe(first())
      .subscribe(data => {
        this.router.navigateByUrl('/teacher/dashboard');
      });
  }

  onRegister() {
    this.router.navigateByUrl('/teacher/register');
  }
}
