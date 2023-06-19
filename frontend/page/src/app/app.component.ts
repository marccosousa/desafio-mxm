import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { FormGroup } from '@angular/forms';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ResponseModalComponent } from './response-modal/response-modal.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  constructor(private service: AppService, private modalService: NgbModal ) { }
  
  ferias: any = {};
  exibindoSpinner: boolean = false; 
  
  async onSubmit(form: any) {
    console.log(form); 
    console.log(this.ferias);
    this.gerarFerias(form)
   }
   
   async gerarFerias(f: FormGroup) {
    this.exibindoSpinner = true; 
    (await this.service.gerarFerias(this.ferias))
                 .subscribe(response => {
                  console.log(response);
                  this.exibindoSpinner = false;
                  f.reset(); 
                  this.mostrarFeriasModal(response);
                 }); 
   }

   mostrarFeriasModal(response: any) {
      const modalRef = this.modalService.open(ResponseModalComponent); 
      modalRef.componentInstance.response = response; 
   }

  ngOnInit() { }
}
