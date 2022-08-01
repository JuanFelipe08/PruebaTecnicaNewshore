import {Flight} from './flight';

export class Journey {
  origin: string | undefined;
  destination: string | undefined;
  prince: number | undefined;
  flights: Flight[] | undefined;
}
