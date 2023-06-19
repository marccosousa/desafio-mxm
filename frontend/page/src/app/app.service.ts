import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class AppService {
    apiUrl = 'https://api-ferias.up.railway.app/api/Ferias'

    constructor (private http: HttpClient) { }

    async gerarFerias(ferias: any) {
        return await this.http.post(this.apiUrl, ferias, {responseType: 'text'});
    }
}