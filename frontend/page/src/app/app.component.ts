import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  constructor(private service: AppService) { }
  
  ferias: any = {};
  
  async onSubmit(form: any) {
    console.log(form); 
    console.log(this.ferias);
    this.gerarFerias(form)
   }
   
   async gerarFerias(f: FormGroup) {
     (await this.service.gerarFerias(this.ferias))
                 .subscribe(response => {
                  console.log(response);
                  f.reset()
                 }); 
   }

  ngOnInit() { }
}
