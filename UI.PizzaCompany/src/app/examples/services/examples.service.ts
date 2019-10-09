import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { INewExample } from "../dialog-new-example/models/INewExample";

export class ExamplesService {
    constructor(private httpClient: HttpClient) {
    }

    getExamples(): Observable<any> {
        return this.httpClient.get<any>('http://localhost:5000/api/examples', {
            withCredentials: true
        });
    }

    addExample(newExample: INewExample): Observable<any> {
        return this.httpClient.post<any>('http://localhost:5000/api/examples', newExample, {
            withCredentials: true
        });
    }
}