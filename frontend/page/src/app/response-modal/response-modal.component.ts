import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-response-modal',
  templateUrl: './response-modal.component.html',
  styleUrls: ['./response-modal.component.css']
})
export class ResponseModalComponent implements OnInit {
  @Input() response: any; 
  
  constructor(public activeModal: NgbActiveModal) {}

  ngOnInit() {}
}
