import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  ferias: any = {};
  
  onSubmit(form: any) {
    console.log(form); 
    console.log(this.ferias);
   }

  constructor() { }

  ngOnInit() { }
}
