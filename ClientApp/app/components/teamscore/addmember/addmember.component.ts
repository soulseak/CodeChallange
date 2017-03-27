import { Component } from '@angular/core';
import { Http, Headers, Response, RequestOptions} from '@angular/http';
import { Observable } from "rxjs/Rx";

import { Member } from '../Member';
import { Team } from '../Team';
import { Match } from '../Match';

@Component({
    selector: 'addmember',
    template: require('./addmember.component.html')
})
export class AddMemberComponent {
    
    constructor(private http: Http) { }
    model: Member = { MemberId: '0', Name: '' };

    submitted = false;

    onSubmit() { this.submitted = true; }
    public addMember()
    {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(this.model);
        this.http.post("/api/Member/Create/", body, options)
            .subscribe();
        console.log("done");
    }

}