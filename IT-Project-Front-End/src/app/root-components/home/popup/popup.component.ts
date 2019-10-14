import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-popup',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './popup.component.html',
})
export class PopupComponent implements OnInit {
  numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
  pincode = '';
  disableNumbers;

  constructor(private router: Router, public dialogRef: MatDialogRef<PopupComponent>) {}

  ngOnInit() {}

  addToCode = n => {
    this.pincode = this.pincode + n;
    if (this.pincode.length === 4) {
      this.disableNumbers = true;
      if (this.pincode === '9999') {
        new Promise(resolve => setTimeout(resolve, 1000)).then(e => {
          this.router.navigateByUrl('/teacher/login');
          this.dialogRef.close();
        });
      }else {
        new Promise(resolve => setTimeout(resolve, 1000)).then(e => {
          this.router.navigateByUrl('/student/exercise/series/' + this.pincode);
          this.dialogRef.close();
        });
      }
    }
  };

  removeFromCode = () => {
    this.pincode = this.pincode.slice(0, this.pincode.length - 1);
    if (this.pincode.length < 4) {
      this.disableNumbers = false;
    }
  };
}
