import {Component, Inject, OnInit} from '@angular/core';
import {Journey} from '../../models/journey';
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from '@angular/material/dialog';
import {CurrencyCalculatorService} from '../../services/currency-calculator.service';

@Component({
  selector: 'app-view-journey-detail',
  templateUrl: './view-journey-detail.component.html',
  styleUrls: ['./view-journey-detail.component.scss']
})
export class ViewJourneyDetailComponent implements OnInit {
  journey: Journey;
  coin: string;

  constructor(public dialog: MatDialog, private CurrencyCalculator: CurrencyCalculatorService,
              public dialogRef: MatDialogRef<ViewJourneyDetailComponent>, @Inject(MAT_DIALOG_DATA) public data: MatDialog) {
    this.journey = new Journey();

  }

  ngOnInit(): void {
    this.journey = this.data['journey'];
  }
  changeTheTypeOfCurrencyToDisplay(valueCurrencys: string): void {
    const factormultiply =  (this.journey.flights[0].price + this.journey.flights[1].price);
    this.journey.prince = this.CurrencyCalculator.cunrrecyCalculator(Number.parseFloat(valueCurrencys), factormultiply);
  }
}
