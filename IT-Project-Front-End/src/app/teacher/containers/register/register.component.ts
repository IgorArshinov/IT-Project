import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { JwtService } from '../../services/jwt.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(
    private router: Router,
    private jwtService: JwtService,
  ) {
  }

  ngOnInit() {
    this.registerForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.minLength(3)]),
    });
  }

  onRegister() {
    this.jwtService.register(this.registerForm.controls['email'].value, this.registerForm.controls['password'].value).pipe(first())
      .subscribe(data => {
          this.router.navigateByUrl('/teacher/login');
        },
      );
  }
}
