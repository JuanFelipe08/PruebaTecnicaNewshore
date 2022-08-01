import {Component} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Journey} from '../../models/journey';
import {JourneyService} from '../../services/journey.service';
import {MatDialog} from '@angular/material/dialog';
import {ViewJourneyDetailComponent} from '../view-journey-detail/view-journey-detail.component';
import {MatSnackBar,  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition,} from '@angular/material/snack-bar';
import {SnackBarComponent} from '../snack-bar/snack-bar.component';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent {
  journey: Journey;
  horizontalPosition: MatSnackBarHorizontalPosition = 'right';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private serviceJourney: JourneyService, public dialog: MatDialog, private snackBar: MatSnackBar) {
    this.journey = new Journey();
  }

  searchFlights(form: NgForm): void {
    if (form.invalid) {
      return;
    }

    if (this.journey.origin == this.journey.destination) {
      return;
    }

    const flightOrigin = this.journey.origin.toUpperCase();
    const flightDestination = this.journey.destination.toUpperCase();
    this.serviceJourney.searchJourney(flightOrigin, flightDestination).subscribe((res: Journey) => {
      this.dialog.open(ViewJourneyDetailComponent, {
        width: '75vw',
        data: {
          journey: res
        }
      });
    }, (error: any) => {
      this.snackBar.openFromComponent(SnackBarComponent, {
        duration: 2000,
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
      });
    });
  }
}
