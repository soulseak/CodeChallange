﻿import { Component } from '@angular/core';
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
    model: Member = { memberId: '', name: '' };
    clicked: number = 0;


    submitted = false;

    onSubmit() { this.submitted = true; }
    public doSomething()
    {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(this.model);
        this.http.post("/api/Member/Create/", body, options)
            .map(res => res.json)
            .subscribe();

    }

}