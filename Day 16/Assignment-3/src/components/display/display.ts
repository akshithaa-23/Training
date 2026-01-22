import { Component,inject } from '@angular/core';
import { Calculator } from '../../services/calculator';

@Component({
  selector: 'app-display',
  imports: [],
  templateUrl: './display.html',
  styleUrl: './display.css',
})
export class Display {

  private calc=inject(Calculator);
  addr=this.calc.add(10,5);
  subr=this.calc.sub(19,7);
  mulr=this.calc.mul(13,4);
  divr=this.calc.divv(17,5);

}
