import {Injectable} from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class CurrencyCalculatorService {

  constructor() {
  }

  cunrrecyCalculator(valueCurrency: number, factorToMultiplicy: number): number {
    return (factorToMultiplicy * valueCurrency);
  }
}
