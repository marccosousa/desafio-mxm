import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class AppService {
    apiUrl = 'https://localhost:7034/api/Ferias'

    constructor (private http: HttpClient) { }

    async gerarFerias(ferias: any) {
        return await this.http.post(this.apiUrl, ferias, {responseType: 'text'});
    }
}