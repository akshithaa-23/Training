import { Component ,inject,OnInit} from '@angular/core';
import { MsgService } from '../../services/msg-service';

@Component({
  selector: 'app-arraydisplay',
  imports: [],
  templateUrl: './arraydisplay.html',
  styleUrl: './arraydisplay.css',
})
export class Arraydisplay {
  private amsg=inject(MsgService);
  a :string []=[];
  ngOnInit(){
    this.amsg.addData(['apple','banana','orange']);
    this.a=this.amsg.getData();
  }
}
