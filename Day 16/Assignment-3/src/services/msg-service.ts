import { Injectable,inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MsgService {
  private data: string[]=[];
  getData(){
    return this.data;
  }
  addData(msg : string []){
    msg.forEach((i)=>{
      this.data.push(i);
    }
    )
  }
}

