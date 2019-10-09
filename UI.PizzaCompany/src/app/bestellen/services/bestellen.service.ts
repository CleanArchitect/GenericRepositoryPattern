import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

export class BestellenService {
    constructor(private httpClient: HttpClient) { }

    getMenu(): Observable<any> {
        return this.httpClient.get<any>('http://localhost:5001/api/pizzas/menu');
    }
}